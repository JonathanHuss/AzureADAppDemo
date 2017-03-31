using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Get the Access Token from Azure
            AzureADInterface azureAD = new AzureADInterface();
            AuthenticationResult authResult = azureAD.GetToken(Settings.GraphResource).Result;

            //  Query the data from Graph using that Access Token
            GraphHelper graphHelper = new GraphHelper();
            dynamic result = graphHelper.QueryGraph("users", authResult.AccessToken).Result;

            //  Dump the list of users to the console
            foreach(dynamic user in result.value)
            {
                Console.WriteLine(user.displayName);
            }

            Console.ReadLine();
        }
    }
}
