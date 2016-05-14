using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PhoneBookRESTXMLClient
{
   public partial class PhoneBookClient : System.Web.UI.Page
   {
       private const string OPERATION = "operation";
       private const string ADD_ENTRY = "Entry";
       private const string GET_ENTRIES = "Retrieve";

       // create an object to invoke to PhoneBookService
       private HttpClient client = new HttpClient();

       // namespace of XML response
       private XNamespace xmlNamespace = XNamespace.Get("http://schemas.datacontract.org/2004/07/PhoneBookRESTXMLService");//added  PhonebookRESTXML
       // handle page load events
      protected async void Page_Load(object sender, EventArgs e)
      {
         if (IsPostBack)
         {
            // send request to PhoneBookRESTXMLService if fields are filled
            if ((!string.IsNullOrEmpty(firstTextBox.Text)) &&
               (!string.IsNullOrEmpty(lastTextBox.Text)) &&
               (!string.IsNullOrEmpty(phoneTextBox.Text)))
            {
               HttpResponseMessage response =
                  await client.GetAsync(new Uri("http://localhost:52163/PhoneBookRESTXMLService.svc/Entry/" + lastTextBox.Text.Trim() + "/" + firstTextBox.Text.Trim() + "/" + phoneTextBox.Text.Trim()));

               clearFields();

               if (response.StatusCode == System.Net.HttpStatusCode.OK)
                  resultsTextBox.Text = "Entry added successfully";
               else
                  resultsTextBox.Text = "AddEntry failed with HTTP code " + response.StatusCode;
            } // end if
            else if (findLastTextBox.Text != string.Empty) // send request to PhoneBookRESTXMLService if field is filled - 
            {
                String result = await client.GetStringAsync(new Uri("http://localhost:52163/PhoneBookRESTXMLService.svc/Retrieve/" + findLastTextBox.Text));

               XDocument xmlResponse = XDocument.Parse(result); // parse the returned XML string 
               clearFields();

               // if there are no phone book entries in response
               if (xmlResponse.Element(xmlNamespace + "ArrayOfPhoneBookEntry").Value == string.Empty)
               {
                  resultsTextBox.Text = "No entries with that last name.";
               }
               else
               {
                   //print information for each phone book entry   from photo in xmlresponse.Descendants("photo")
                   foreach (XElement element in xmlResponse.Elements(xmlNamespace + "ArrayOfPhoneBookEntry").Elements())
                  {
                     resultsTextBox.Text += '\n' + 
                        string.Format("{0}, {1}, {2}",
                           element.Element(xmlNamespace + "FirstName").Value, //something
                           element.Element(xmlNamespace + "LastName").Value,
                           element.Element(xmlNamespace + "PhoneNumber").Value);
                  } // end foreach
               } // end else
            } // end if
         }
      }

      private void clearFields()
      {
         resultsTextBox.Text = string.Empty;
         firstTextBox.Text = string.Empty;
         lastTextBox.Text = string.Empty;
         phoneTextBox.Text = string.Empty;
         findLastTextBox.Text = string.Empty;
      }
   }
}

