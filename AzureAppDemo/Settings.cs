using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAppDemo
{
    public static class Settings
    {
        //  Update the four values below appropriately after running the script.  Be sure to update your Azure AD application permissions in the portal, too!
        //  Note:  A delay exists between Azure AD and Graph.  The delay is regularly 20 minutes
        //         and sometimes longer.  Be patient if this demo doesn't work immediately after setup.
        public static string AzureAppId = "6a3cc024-25e5-4a9e-ab1b-b86ef95a7a33";
        public static string CertPath = @"C:\Temp\DemoApp\DemoApp.pfx";
        public static string CertPassword = "SuperSecretPassword";
        public static string TenantName = "jonhussdev.onmicrosoft.com";

        
        //  Don't need to update these
        public static string AzureADAuthority = $"https://login.windows.net/{TenantName}";
        public static string GraphQueryUrl = $"https://graph.microsoft.com/v1.0/{TenantName}/";
        public static string GraphResource = "https://graph.microsoft.com/";

    }
}
