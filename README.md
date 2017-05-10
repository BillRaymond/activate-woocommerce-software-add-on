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

When someone makes a purchase (free or paid), the WooCommerce Add-on will generate a license number. Based on how you set up the WooCommerce Software Add-on, the user will have a set number of licenses to use (by default a user gets 5 activations).

To activate a license, you will send a REST request and receive a JSON response.

This sample solution shows you how to activate a license, but you can of course use it to deactivate, reset, or check license keys as well.

# References
You may need to manually add the following references to your project using the Solution Explorer:
- System.Web
- System.Runtime.Serialization

# Run the solution

To run this solution, follow these steps:
1. Download or clone this solution.
2. Open the solution in Visual Studio and run.

# Compatibility
- This solution has only been tested using .Net 4.5.2 using Visual Studio 2017. You can probably use older versions.
- To the best of my knowledge, this solution works with any version of the Software Add-on.

# Known Issues
- Be aware that the WooCommerce Software Add-on does not always provide a standard JSON response. For example, if there is success, you will get one JSON response and if there is an error, you will get another response. My code handles this with activations, but beware you may encounter issues when adding your own code.

# License
You are free to use this code in any solution you desire, but a mention would be nice.

