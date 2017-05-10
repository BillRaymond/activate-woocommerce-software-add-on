# Important
I am in no way affiliated with Automattic, which owns and runs Wordpress, WooCommerce, and WooCommerce Add-ons. Their documentation or support for this API could change at any time.

# About
The WooCommerce Software Add-on is a product that allows you to sell software licenses on a Wordpress site with WooCommerce installed. This Visual Studio solution allows you to activate a purchased license. If none exists, it will handle the error.

# Setup your environment
If you write an app using C# and want to activate the license, you send a RESTful request to verify the license is valid.

To use this solution, you will need:
1. A Wordpress website.
2. WooCommerce installed on the Wordpress website.
3. The paid WooCommerce Software Add-on.

Visit this site for the WooCommerce Software Add-on documentation and API:
https://docs.woocommerce.com/document/software-add-on/?_ga=2.75897301.1354311323.1494374008-934541800.1494372488

After you install these products, you need to configure the WooCommerce Software Add-on. I'm not going to go into all the details here because you will configure it for your particular needs.

When someone makes a software purchase (free or paid), the WooCommerce Add-on will generate a license key. Based on how you set up the WooCommerce Software Add-on, the user will have a set number of licenses to use (by default a user gets 5 activations).

To activate a license, you will make a REST request and receive a JSON response.

This sample solution shows you how to activate a license, which will automatically deduct a license from the user's available license key activations.
Read the documentation for the WooCommerce Software Add-on and you will find you can deactivate, reset, or check license keys, but I do not include that functionality in this solution.

# Solution References
You may need to manually add the following references to your project using the Solution Explorer:
- System.Web
- System.Runtime.Serialization

# Run the solution
To run this solution, follow these steps:
1. Download or clone this solution.
2. Open the solution in Visual Studio.
3. Edit the Program.cs file and update the following variables: ActivationLicenseKey, ActivationLicenseProductId, and ActivationLicenseEmail.
4. Run the solution.

# Compatibility
- This solution has only been tested using .Net 4.5.2 using Visual Studio 2017. You can probably use older versions.
- To the best of my knowledge, this solution works with any version of the Software Add-on.

# Known Issues
- Be aware that the WooCommerce Software Add-on does not always provide a standard JSON response. For example, if there is success, you might get one JSON response and if there is an error, you might get another response. My code handles this with activations, but beware you may encounter issues when adding your own code.

# License
You are free to use this code in any solution you desire, but a mention would be nice.

# Contributions
- Any and all contributions are welcome so long as they focus on use cases for the core WooCommerce Software Add-on API.
- Log an issue if you are looking for a new feature or found a bug. This is pretty basic code and I do not plan to update it much unless there are requests to do so.
