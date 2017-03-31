using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AzureAppDemo
{
    public class AzureADInterface
    {
        public async Task<AuthenticationResult> GetToken(string resource)
        {
            X509Certificate2 cert = new X509Certificate2(Settings.CertPath, Settings.CertPassword);

            ClientAssertionCertificate cac = new ClientAssertionCertificate(Settings.AzureAppId, cert);
            
            AuthenticationContext authContext = new AuthenticationContext(Settings.AzureADAuthority);
            AuthenticationResult authResult = await authContext.AcquireTokenAsync(resource, cac);

            return authResult;
        }
    }
}
