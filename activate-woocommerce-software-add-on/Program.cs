using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;
using System.ComponentModel;

namespace activate_woocommerce_software_add_on
{
    class Program
    {
        static void Main(string[] args)
        {
            // This sample code connects to a Wordpress site with WooCommerce and the WooCommerce Software Add-on installed.
            // You must already have an license key available for testing.

            //

            Console.WriteLine("* Start attempting to activate license.");

            //the license uri is usually yourwebsite.com, even if the WC Software Add-on is installed in another folder.
            //if this is not working, go to the WC Software Add-on documentation for more details. Find that detail in the README.md file for this solution.
            var licenseUri = "https://mywebsite.com";

            //build the url to call the Optical Authoring website's software licensing component.
            var builder = new UriBuilder(licenseUri); //you may need to manually add System.Web as a reference in the Solution Explorer.
            builder.Port = -1;

            var ActivationLicenseKey = "[add your license key here, including dashes]";
            var ActivationLicenseProductId = "[add the software product id associated with the license key here]";
            var ActivationLicenseEmail = "[add the email associated with the license key here]";
            var ActivationSig = ""; //stores a response text string sent by the JSON response.

            //build the query string.
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["wc-api"] = "software-api";
            query["request"] = "activation";
            query["license_key"] = ActivationLicenseKey;
            query["product_id"] = ActivationLicenseProductId;
            query["email"] = ActivationLicenseEmail;
            builder.Query = query.ToString();
            string url = builder.ToString();
            Console.WriteLine("activation request:");
            Console.WriteLine(url); //display the REST endpoint.

            //make the synchronous call to the web service.
            try
            {
                var syncClient = new WebClient();
                var responseStream = syncClient.DownloadString(url);
                Console.WriteLine("Response stream:");
                Console.WriteLine(responseStream); //display the server json response.

                //serialize the response stream so the values are available in a class.
                //NOTE: You are only guaranteed a response with "Activated" and "Sig".
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(ActivationResponse));
                var ms = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(responseStream));

                ActivationResponse ar = (ActivationResponse)js.ReadObject(ms);

                Console.WriteLine("Activation: " + ar.Activated);
                if (!string.IsNullOrEmpty(ar.ErrorMessage) && !string.IsNullOrEmpty(ar.ErrorCode))
                {
                    //could not activate the license.
                    Console.WriteLine("could not activate product.");
                    Console.WriteLine("Error code: " + ar.ErrorMessage);
                    Console.WriteLine("Error message: " + ar.ErrorMessage);
                    ActivationSig = ar.Sig;
                    Console.WriteLine("call failed.");
                    Console.WriteLine(ActivationSig); //displays the full response from the endpoint, not formatted with json.
                    Console.ReadKey();
                    return;
                }
                else
                {
                    //license is activated.
                    Console.WriteLine("Product is active.");
                    ActivationSig = ar.Sig;
                    Console.WriteLine("Sig:");
                    Console.WriteLine(ActivationSig); //displays the full response from the endpoint, not formatted with json.
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured. Could not activate the license.");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;
            }
            Console.ReadKey();
        }
    }
}
