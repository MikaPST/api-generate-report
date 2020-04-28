using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net; // à l'aide de .NET Framework 4.0
using System.Xml; // pour XmlDocument
using System.IO; // pour StreamReader (conversion de xml en chaînes)
using System.Xml.Linq; // pour analyser XML dans un format indenté

namespace RestfulSample
{

	class RefreshHandler
	{
		private Authentication authenticator;
		private List<string> docParamNames;
		private List<string> docParamids;
		private List<string> currentSelection;
		public string docid;
		public string pathRapport; 

		public RefreshHandler(Authentication authentication, string documentid)
		{
			authenticator = authentication;
			docid = documentid;
			docParamNames = new List<string>();
			docParamids = new List<string>();
			currentSelection = new List<string>();
		}

		public List<ListDocumentsData> getAllDocuments()
		{
			string pPathRapport = "";
			XmlDocument paramRecv = new XmlDocument(); ;
			var nsmgrRecv = new XmlNamespaceManager(paramRecv.NameTable);
			var result = authenticator.CreateWebRequest(null, paramRecv, "GET",
			   "/biprws/raylight/v1/documents/", out pPathRapport);
			if (result != 0)
			{
				return new List<ListDocumentsData>();
			}
			var resultat = new List<ListDocumentsData>();
			var nameDocList = paramRecv.SelectNodes("//document", nsmgrRecv);
			foreach (XmlNode node in nameDocList)
			{
				var list = new ListDocumentsData();
				list.Name = node.SelectSingleNode("name", nsmgrRecv).InnerText;
				list.Id = node.SelectSingleNode("id", nsmgrRecv).InnerText;
				resultat.Add(list);
			}
			return resultat;
		}

		public List<DocumentData> getViewDocument()
		{
			string pPathRapport = "";
			XmlDocument paramRecv = new XmlDocument(); ;
			var nsmgrRecv = new XmlNamespaceManager(paramRecv.NameTable);
			var detailsResult = authenticator.CreateWebRequest(null, paramRecv, "GET",
						   "/biprws/raylight/v1/documents/" + docid, out pPathRapport);
			if (detailsResult != 0)
			{
				return new List<DocumentData>();
			}
			var resultat = new List<DocumentData>();
			var nameDocList = paramRecv.SelectNodes("//document", nsmgrRecv);
			foreach (XmlNode node in nameDocList)
			{
				var detailsDoc = new DocumentData();
				detailsDoc.Name = node.SelectSingleNode("name", nsmgrRecv).InnerText;
				detailsDoc.Id = node.SelectSingleNode("id", nsmgrRecv).InnerText;
				detailsDoc.Path = node.SelectSingleNode("path", nsmgrRecv).InnerText;
				detailsDoc.Size = node.SelectSingleNode("size", nsmgrRecv).InnerText;
				detailsDoc.State = node.SelectSingleNode("state", nsmgrRecv).InnerText;
				resultat.Add(detailsDoc);
			}
			return resultat;
		}

		public void getDocumentPdf()
		{
			string pPathRapport = "";
			XmlDocument paramRecv = new XmlDocument(); ;
			var nsmgrRecv = new XmlNamespaceManager(paramRecv.NameTable);
			var result = authenticator.CreateWebRequest(null, paramRecv, "GET",
						   "/biprws/raylight/v1/documents/" + docid, out pPathRapport, @"application/pdf");
			pathRapport = pPathRapport;
			var resultat = new List<DocumentData>();
			var nameDocList = paramRecv.SelectNodes("//document", nsmgrRecv);

			return;
		}

		/* envoie une demande pour la liste des paramètres
         * récupère tous les noms des paramètres
         * récupère les options du premier paramètre uniquement
         * remplit l'arborescence avec les informations ci-dessus
         *
         * En cas de succès: retourne 0
         * En cas d'échec: retourne un entier positif
         */
		public int getParameterNames(TreeView selectionView, RichTextBox TraceBox)
        {
            XmlDocument paramRecv;
            XmlDocument paramSend;
            XmlNamespaceManager nsmgrRecv;
            XmlNamespaceManager nsmgrSend;
            XmlNodeList parameterList, selectionList, paramidList;
            string paramid;
            List<string> valuesList = new List<string>();
            int result;

			// -------------------------------------------------------------------------
			// initialise
			paramRecv = new XmlDocument();
            paramSend = new XmlDocument();
            nsmgrRecv = new XmlNamespaceManager(paramRecv.NameTable);
            nsmgrRecv.AddNamespace("rest", "");
            nsmgrSend = new XmlNamespaceManager(paramSend.NameTable);
            nsmgrSend.AddNamespace("rest", "");


			// -------------------------------------------------------------------------
			// envoi une demande pour le formulaire des paramètres
			result = authenticator.CreateWebRequest(null, paramRecv, "GET",
                "/biprws/raylight/v1/documents/" + docid + "/parameters?lovInfo=true");
            if (result != 0)
            {
                return result;
            }

			// remplir l'arborescence avec les noms des paramètres
			parameterList = paramRecv.SelectNodes("//rest:name", nsmgrRecv);
            selectionView.BeginUpdate();
            foreach (XmlNode node in parameterList)
            {
                TreeNode newNode = new TreeNode(node.InnerText);
                newNode.Name = node.InnerText;
                selectionView.Nodes.Add(newNode);
                docParamNames.Add(node.InnerText);
            }
            selectionView.EndUpdate();


			// -------------------------------------------------------------------------
			// saisir les détails du premier paramètre
			parameterList = paramRecv.SelectNodes("//rest:parameter", nsmgrRecv);
            XmlNode parameter = parameterList.Item(0);
            paramidList = paramRecv.SelectNodes("//rest:parameter/id", nsmgrRecv);
            paramid = paramidList.Item(0).InnerXml;

			// mettre à jour les identifiants des paramètres du document
			foreach (XmlNode node in paramidList)
            {
                docParamids.Add(node.InnerXml);
            }

			// obtenir la liste des valeurs possibles (pour le premier paramètre)
			selectionList = parameter.SelectNodes("answer/info/lov/values/value", nsmgrRecv);
            foreach (XmlNode node in selectionList)
            {
                valuesList.Add(node.InnerText);
            }

			// mettre à jour l'arborescence avec les premières valeurs des paramètres
			updateView(selectionView, 0, valuesList);

            return 0;
        }

		/* met à jour le nœud indexé avec de nouveaux sous-nœuds, nommés 
         * d'après la liste de valeurs ne met à jour que les nœuds de niveau 0
         *
         * En cas de succès: retourne 0
         * En cas d'échec: retourne un entier positif
         */
		private void updateView(TreeView view, int index, List<string> values)
        {
            view.BeginUpdate();
            TreeNode node = view.Nodes[index];

            foreach (string value in values)
            {
                TreeNode newNode = new TreeNode(value);
                newNode.Name = value;
                node.Nodes.Add(newNode);
            }

            node.Expand();
            view.EndUpdate();
            return;
        }

		/* prend un XmlDocument et attache un nouveau paramètre choisi avec paramid et value
         * il s'agit de la version XmlDocument. Convient à toutes les versions de .NET
         *
         * Si vous avez accès à une version plus récente de .NET (c'est-à-dire supérieure à 3.5),
         * envisagez plutôt d'utiliser constructSelectionLINQ (). Ces deux fonctions sont identiques.
         */
		private void constructSelection(XmlDocument doc, string value, string paramid)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("rest", "");

			// déterminer combien de paramètres sont déjà dans le document
			XmlNodeList currentParameter = doc.SelectNodes("//rest:parameters", nsmgr);

            XmlNode parent;
			// besoin d'initialiser xml si c'est le premier paramètre
			if (currentParameter.Count == 0)
            {
				// la déclaration n'est pas obligatoire mais recommandée
				XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(declaration, root);

                parent = doc.CreateElement("parameters");
                doc.AppendChild(parent);
            }
            else
            {
				// trouver le nœud parent,il doit exister
				parent = currentParameter.Item(0);
            }

            XmlElement element1 = doc.CreateElement("parameter");
            parent.AppendChild(element1);

            XmlElement element2 = doc.CreateElement("id");
            element2.InnerText = paramid;
            element1.AppendChild(element2);

            XmlElement element3 = doc.CreateElement("answer");
            element1.AppendChild(element3);

            XmlElement element4 = doc.CreateElement("values");
            element3.AppendChild(element4);

            XmlElement element5 = doc.CreateElement("value");
            element5.InnerText = value;
            element4.AppendChild(element5);

            return;
        }

		/* prend un XmlDocument et attache un nouveau paramètre choisi avec paramid et value
         * c'est la version linq, donc le XmlDocument sera converti
         * vers un XDocument, modifié, puis analysé en arrière dans un XmlDocument avant de revenir
         */
		private void constructSelectionLINQ(XmlDocument doc, string value, string paramid)
        {
            XDocument xdoc;

			// construit un XElement pour le paramètre à insérer
			XElement parameter =
            new XElement("parameter",
                new XElement("id", paramid),
                new XElement("answer",
                    new XElement("values",
                        new XElement("value", value)
                    )
                )
            );

			// initialise le xml s'il est vide et attacher le paramètre
			if (doc.OuterXml == "")
            {
                xdoc = new XDocument(
                            new XElement("parameters",
                                parameter
                            )
                        );
            }
            else
            {
                xdoc = XDocument.Parse(doc.OuterXml);
                XElement root = xdoc.Root;
                root.Add(parameter);
            }

			// réanalyser le XDocument en XmlDocument
			doc.Load(xdoc.CreateReader());

            return;
        }

		/* envoie une requête avec les paramètres currentSelection [0 ... index] + sélection
         * met à jour les données stockées (de cet objet) et met à jour l'arborescence donnée
         */
		public void updateParameter(int index, string selection, TreeView view, RichTextBox TraceBox)
        {
            List<string> valuesList = new List<string>();
            XmlDocument send = new XmlDocument();
            XmlDocument recv = new XmlDocument();
            XmlNamespaceManager nsmgrRecv = new XmlNamespaceManager(recv.NameTable);
            nsmgrRecv.AddNamespace("rest", "");

            currentSelection.Add(selection);

            for (int i = 0; i < index + 1; i++)
            {
				// construit et envoyer la demande
				constructSelection(send, currentSelection[i], docParamids[i]);
			}
			authenticator.CreateWebRequest(send, recv, "PUT", "/biprws/raylight/v1/documents/" + docid + "/parameters?lovInfo=true");

            TraceBox.Text += "Liste de valeurs récupérée pour le paramètre " + currentSelection.Count.ToString() + ".\n";

			// s'il s'agit du dernier paramètre: actualisation terminée, et pas besoin de mettre à jour d'autres valeurs
			if (index + 1 == docParamids.Count)
            {
                XmlNodeList success = recv.SelectNodes("//rest:success", nsmgrRecv);
                if (success.Count != 0)
                {
                    TraceBox.Text += "Actualisation réussie du document. docid: " + docid + "\n";
                }
                return;
            }

			// trouver le bon paramètre
			XmlNodeList parameterList = recv.SelectNodes("//rest:parameter", nsmgrRecv);
            XmlNode parameter = parameterList.Item(0);

            XmlNodeList selectionList = parameter.SelectNodes("answer/info/lov/values/value", nsmgrRecv);
            foreach (XmlNode node in selectionList)
            {
                valuesList.Add(node.InnerText);
            }

			// l'arborescence mis à jour
			updateView(view, index + 1, valuesList);

            return;
        }

		/* revient sur les valeurs des paramètres actuellement sélectionnés par
         * suppression de currentSelection [index ... currentSelection.Count]
         */
		public void pop(int index)
		{
			if (index < currentSelection.Count)
			{
				currentSelection.RemoveRange(index, currentSelection.Count - (index));
			}
		}
	}
}
