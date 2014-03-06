using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TestWebFunctionality.Controllers
{
    public class RequestService
    {
        private readonly string _validDomain;

        public RequestService(string validDomain)
        {
            _validDomain = validDomain;
        }

        internal void SendRequest(Uri uri, int iteration)
        {
            AddDefaultHttpsValidator(iteration);

            var request = WebRequest.CreateHttp(uri);
            var response = request.GetResponse();
        }

        private void AddDefaultHttpsValidator(int iteration)
        {
            Debug.WriteLine("[{0}]: starting AddDefaultHttpsValidator", iteration);
            ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => CertificateValidator(a, b, c, d, _validDomain, iteration);
            Debug.WriteLine("[{0}]: after add, registered list count is {1}", iteration, ServicePointManager.ServerCertificateValidationCallback.GetInvocationList().Count());
            Debug.WriteLine("[{0}]: completed AddDefaultHttpsValidator", iteration);
        }

        private bool CertificateValidator(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors, string domain, int iteration)
        {
            var skip = string.IsNullOrWhiteSpace(domain);
            Debug.WriteLine("[{0}]: starting CertificateValidator {1} validation for {2}", iteration, skip ? "without" : "with", ((HttpWebRequest)sender).RequestUri);
            Debug.WriteLine("[{0}]: certificate errors are {1}", iteration, (int)sslPolicyErrors);
            if (skip)
            {
                Debug.WriteLine("[{0}]: domain empty", iteration);
                Debug.WriteLine("[{0}]: exiting CertificateValidator", iteration);
                return true;
            }
            var contains = certificate.Subject.Contains(domain);
            if (contains)
            {
                Debug.WriteLine("[{0}]: contains", iteration);
                Debug.WriteLine("[{0}]: exiting CertificateValidator", iteration);
                return true;
            }
            Debug.WriteLine("[{0}]: does not contain", iteration);
            Debug.WriteLine("[{0}]: exiting CertificateValidator", iteration);
            return false;
        }
    }
}
