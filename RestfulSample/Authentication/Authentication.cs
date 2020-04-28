using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; // en utilisant .NET Framework 4.0
using System.Xml; // pour XmlDocument
using System.IO; // pour StreamReader (convertir le xmls en strings)
using System.Xml.Linq; // pour analyser le XML dans un format

namespace RestfulSample
{
    class Authentication
    {
        private string userName;
        private string password;
        private string logonToken;
		private string URI;
		private static string nameSpace = "YOU NAMESPACE";

        public Authentication(string userName, string password, string URI)
        {
            this.userName = userName;
            this.password = password;
            this.logonToken = "";
            this.URI = URI;
		}

        /* utilise le nom d'utilisateur et le mot de passe pour récupérer le logonToken
          *
          * En cas de succès: retourne 0
          * En cas d'échec: retourne un entier positif
        */
        public int Logon()
        {
            if (logonToken != "")
            {
				// possède déjà un jeton de connexion. 
				return 1;
            }

            XmlDocument docGET;
            XmlDocument docPOST;
            XmlNamespaceManager nsmgrGET, nsmgrPOST;
            XmlNodeList nodeList;
            int result;

            docGET = new XmlDocument();
            docPOST = new XmlDocument();

			// envoi d'une demande de formulaire de connexion
			result = CreateWebRequest(null, docGET, "GET", "/biprws/logon/long");

			if (result != 0)
            {
				return 2;
            }
			nsmgrGET = new XmlNamespaceManager(docGET.NameTable);
            nsmgrGET.AddNamespace("rest", nameSpace);

			// rechercher le nœud userName
			nodeList = docGET.SelectNodes("//rest:attr[@name='userName']", nsmgrGET);
            if (nodeList.Count != 1)
            {
				// il n'y a pas d'attribut userName. Erreur de retour
				return 3;
            }
            nodeList.Item(0).InnerText = userName;
			nodeList = docGET.SelectNodes("//rest:attr[@name='password']", nsmgrGET);
            if (nodeList.Count != 1)
            {
                return 3;
            }
            nodeList.Item(0).InnerText = password;

			// POST le document qui vient d'être rempli sur le serveur
			// afin de récupérer le jeton de connexion
			result = CreateWebRequest(docGET, docPOST, "POST", "/biprws/logon/long");

            nsmgrPOST = new XmlNamespaceManager(docPOST.NameTable);
            nsmgrPOST.AddNamespace("rest", nameSpace);

			// extrer le jeton de connexion de la réponse du serveur
			nodeList = docPOST.SelectNodes("//rest:attr[@name='logonToken']", nsmgrPOST);
            if (nodeList.Count != 1 || nodeList.Item(0).InnerText == "")
            {
				return 4;
            }

			// concaténer avec des guillemets doubles et stocker en tant que membre
			logonToken = "\"" + nodeList.Item(0).InnerText + "\"";

            return 0; // Succès
		}

		/* envoie une demande de déconnexion du serveur
         * libère également logonToken
         *
         * On est sûr d'appeler à nouveau Logon () après avoir appelé en utilisant cette méthode
         */
		public int Logoff()
        {
            XmlDocument empty = new XmlDocument();
            XmlDocument empty2 = new XmlDocument();
            int result = CreateWebRequest(empty, empty2, "POST", "/biprws/logoff");
            if (result == 0)
            {
                this.logonToken = "";
            }
            return result;
        }

        public bool isLoggedOn()
        {
            return (this.logonToken != "");
        }

		/* envoie une requête http et
          * récupère la réponse du serveur à (this.URI + URIExtension)
          * prend en charge les méthodes GET, PUT et POST
          *
          * send: [facultatif] le document xml qui sera envoyé en tant que body
          * utilisé uniquement dans les méthodes POST et PUT
          * recv: le document xml pour stocker la réponse du serveur dans
          * ce paramètre SERA écrasé
          * méthode: "GET", "PUT" ou "POST"
          * URIExtension: l'URI après le string par défaut. Par exemple. le "biprws / logon / long" d'un journal sur l'URI
          *
          * En cas de succès: retourne 0
          * En cas d'échec: retourne un entier positif
         */
		public int CreateWebRequest(XmlDocument send, XmlDocument recv, string method, string URIExtension, string accept = "application/xml")
		{
			string pPathRapport = "";
			return CreateWebRequest(send, recv, method, URIExtension, out pPathRapport, accept);
		}
		

		/* envoie une requête http et
          * récupère la réponse du serveur à (this.URI + URIExtension)
          * prend en charge les méthodes GET, PUT et POST
          *
          * send: [facultatif] le document xml qui sera envoyé en tant que body
          * utilisé uniquement dans les méthodes POST et PUT
          * recv: le document xml pour stocker la réponse du serveur dans
          * ce paramètre SERA écrasé
          * méthode: "GET", "PUT" ou "POST"
          * URIExtension: l'URI après le string par défaut. Par exemple. le "biprws / logon / long" d'un journal sur l'URI
          *
          * En cas de succès: retourne 0
          * En cas d'échec: retourne un entier positif
         */
		public int CreateWebRequest(XmlDocument send, XmlDocument recv, string method, string URIExtension, out string pPathRapport, string accept = "application/xml")
        {
            HttpWebRequest request;
            HttpWebResponse response;
			pPathRapport = "";


			if (method != "GET" && method != "PUT" && method != "POST")
            {
                return 1; // méthode non prise en charge
			}

            request = (HttpWebRequest)WebRequest.Create(URI + URIExtension);
            request.Method = method;
            request.ContentType = "application/xml";
            request.Accept = accept;
            if (logonToken != "")
            {
                request.Headers["X-SAP-LogonToken"] = logonToken;
            }

            // if the method is post or put, the body must be prepared
            if (method == "POST" || method == "PUT")
            {
				// turn the send xml into a stream and put it in request
				byte[] bytes = System.Text.Encoding.ASCII.GetBytes(send.OuterXml);
				Stream requestStream;
				try
				{
					requestStream = request.GetRequestStream();
					requestStream.Write(bytes, 0, bytes.Length);
					requestStream.Close();
				}
				catch
				{
					return 2;
				}
			}

            // send the request and retrieve the response
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
					// logging off has no response stream and an attempt to read it will fail
					if (URIExtension != "/biprws/logoff")
					{
						if (accept != "application/pdf")
						{
							recv.Load(response.GetResponseStream());
						}
						else
						{
							pPathRapport = @"c:\temp\report" + Guid.NewGuid().ToString() + ".pdf";
							FileStream stream = new FileStream(pPathRapport, FileMode.Create);
							response.GetResponseStream().CopyTo(stream);
							stream.Close();						
						}
                    }
                }
                else
                {
                    return 3;
                }
            }
            catch ( Exception ex)
            {
                return 4;
            }

            return 0;
        }
		
	}
}
