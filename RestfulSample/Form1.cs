using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

/* 
 * Dans .NET 3.0 et versions antérieures, XmlDocument est le meilleur choix
 * Dans .NET 3.5 et supérieur, XDocument est une nouvelle alternative très appropriée
 *
 * XDocument:
 * Pour des raisons héritées, cet exemple utilise XmlDocument plutôt que XDocument
 * Cependant, pour référence, la fonction ConstructSelection () est dupliquée au format XDocument
 * Également à titre d'exemple, XElement fournit un moyen très simple d'imprimer des xml en retrait
 * Par exemple. Console.Write (XElement.Parse (XmlDocument.OuterXml) .ToString ());
 *
 * À propos de ce programme:
 * Il s'agit principalement de démontrer la traversée d'un document XML
 * Et envoi / réception de demandes / réponses
 * 
 */

namespace RestfulSample
{

    public partial class Form1 : Form
    {
        Authentication authenticator;
        RefreshHandler refreshHandler;

        public Form1()
        {
            InitializeComponent();
        }

		/* à des fins de traçage:
         * en cliquant sur un nœud dans l'arborescence, (l'étiquette / le nom du nœud, pas la case à cocher)
         * imprimer le chemin complet du nœud dans la tracebox
         */
		private void SelectionView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
  
        }

		/* après avoir coché une case, il y a plusieurs conditions à gérer
         * si un nouveau nœud (et valide) a été vérifié, mettre à jour les paramètres
         * annule lorsque le nœud vérifié était un paramètre précédemment sélectionné
         */
		private void SelectionView_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
			// bloquer le contrôle jusqu'à la fin du rafraîchissement
			SelectionView.Enabled = false;
            SelectionView.Refresh();

			// si l'action n'a pas été activée par la souris, ignore-la
			// empêche cette fonction de boucler indéfiniment
			if (e.Action != TreeViewAction.ByMouse)
            {
                SelectionView.Enabled = true;
                return;
            }

			// si le nœud est de niveau 0, c'est-à-dire avec les noms des paramètres, décoche-le et retourne-le
			if (e.Node.Level != 1)
            {
                e.Node.Checked = false;
                SelectionView.Enabled = true;
                return;
            }

			/* si le nœud est de niveau 1 et vient d'être vérifié par la souris:
             * 1) décochez
             * 2) restauration si nécessaire
             * 3) effectuer la mise à jour
             */
			if (e.Node.Checked)
            {
                bool siblingWasChecked = false;

				// décochez chaque case
				foreach (TreeNode node in e.Node.Parent.Nodes)
                {
                    if (e.Node != node)
                    {
                        if (node.Checked)
                        {
                            siblingWasChecked = true;
                            node.Checked = false;
                        }
                    }
                }

				// si une cse n'a pas été cochée, annuler
				if (siblingWasChecked == true)
                {
					// supprimer les nœuds enfants successifs de la case parent
					// des options qui n'existent plus en raison de la restauration
					TreeNode node = e.Node.Parent.NextNode;
                    while (node != null)
                    {
                        if (node.Nodes != null && node.Nodes.Count > 0)
                        {
                            for (int i = node.Nodes.Count - 1; i >= 0; i--)
                            {
                                node.Nodes[i].Remove();
                            }
                        }
                        node = node.NextNode;
                    }
					// dire à refreshHandler de supprimer les informations de l'index et plus
					refreshHandler.pop(e.Node.Parent.Index);
                }

				// effectuer une demande de mise à jour sur le serveur en fonction du nom de ce nœud
				string selection = e.Node.Name;
                refreshHandler.updateParameter(e.Node.Parent.Index, selection, SelectionView, TraceBox);
            }

			// fin de la mise à jour de l'arborescence, réactivation du contrôle
			SelectionView.Enabled = true;

            return;
        }

		/* nécessite nom d'utilisateur, mot de passe et nom d'hôte CMS + numéro de port
         */
		private void LogonButton_Click(object sender, EventArgs e)
        {
            if (UserNameBox.Text == "" || PasswordBox.Text == "")
            {
                TraceBox.Text += "Veuillez saisir un nom d'utilisateur et un mot de passe.\n";
                return;
            }

            if (authenticator != null && authenticator.isLoggedOn())
            {
                TraceBox.Text += "Veuillez vous déconnecter avant de vous reconnecter.\n";
                return;
            }

            TraceBox.Text += "Connexion en cours...   ";
            authenticator = new Authentication(UserNameBox.Text, PasswordBox.Text, CMSTextBox.Text);
            int result = authenticator.Logon();
            if (result != 0)
            {
                TraceBox.Text += "La connexion a échoué. Erreur:\n " + result.ToString() + "\n";
            }
            else
            {
                TraceBox.Text += "Connexion réussie.\n";
            }
        }

        private void LogoffButton_Click(object sender, EventArgs e)
        {
            if (!authenticator.isLoggedOn())
            {
                TraceBox.Text += "Pas actuellement connecté, donc impossible de se déconnecter.\n";
                return;
            }

            TraceBox.Text += "Déconnexion en cours...\n   ";

            int result = authenticator.Logoff();

            if (result != 0)
            {
                TraceBox.Text += "La déconnexion a échoué. Erreur: " + result.ToString() + "\n";
            }
            else
            {
                TraceBox.Text += "Déconnexion réussi.\n";
            }
        }

		/* récupère les noms des paramètres du document fournis par docid
         * ainsi que la liste des valeurs du premier paramètre
         * remplit ensuite l'arborescence
         */
		private void ParamDocButton_Click(object sender, EventArgs e)
        {
            if (authenticator == null || !authenticator.isLoggedOn())
            {
                TraceBox.Text += "Non connecté. Impossible de récupérer les paramètres du document.\n";
                return;
            }

            TraceBox.Text += "Récupération des paramètres du document...\n";

            refreshHandler = new RefreshHandler(authenticator, DocidBox.Text);

            int result = refreshHandler.getParameterNames(SelectionView, TraceBox);
            if (result != 0)
            {
                TraceBox.Text += "Erreur lors de la récupération du paramètre. Code d'erreur: " + result.ToString() + "\n";
            }
            else
            {
                TraceBox.Text += "Paramètres récupérés avec succès.\n";
            }
        }

		private void SelectionLabel_Click(object sender, EventArgs e)
		{

		}

		private void CMSTextBox_TextChanged(object sender, EventArgs e)
		{

		}

		private void AllDocumentsButton_Click(object sender, EventArgs e)
		{
			if (authenticator == null || !authenticator.isLoggedOn())
			{
				TraceBox.Text += "Non connecté. Impossible de récupérer les documents.\n";
				return;
			}

			TraceBox.Text += "Récupération des documents...\n";
			refreshHandler = new RefreshHandler(authenticator, DocidBox.Text);
			var result = refreshHandler.getAllDocuments();
			dataGridView.DataSource = result;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void ViewDocumentButton_Click(object sender, EventArgs e)
		{
			if (authenticator == null || !authenticator.isLoggedOn())
			{
				TraceBox.Text += "Non connecté. Impossible d'afficher le document.\n";
				return;
			}
			try
			{
				TraceBox.Text += "Affichage du document...\n";
				refreshHandler = new RefreshHandler(authenticator, DocidBox.Text);
				var detailDoc = refreshHandler.getViewDocument();
				refreshHandler.getDocumentPdf();
				dataGridViewDocument.DataSource = detailDoc;
				webBrowser.Url = new Uri(refreshHandler.pathRapport);
				return;
			}
			catch (Exception ex)
			{
				TraceBox.Text += "Erreur... Impossible d'afficher le document.\n";
				return;
			}
		}

		private void reportViewer1_Load(object sender, EventArgs e)
		{
			
		}

		private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void DocidBox_TextChanged(object sender, EventArgs e)
		{

		}

		private void bindingSource1_CurrentChanged(object sender, EventArgs e)
		{

		}

		private void dataGridViewDocument_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void reportViewer1_Load_1(object sender, EventArgs e)
		{

		}

		private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{

		}

		private void TraceBox_TextChanged(object sender, EventArgs e)
		{

		}
	}
}