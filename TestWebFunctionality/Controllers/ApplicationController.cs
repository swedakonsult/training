using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TestWebFunctionality.Controllers
{
    public class ApplicationController : Controller
    {
        private const int _sleepInterval = 100;

        [HttpGet]
        public ActionResult RunHttps(string on, int iterations = 3)
        {
            if (iterations > 10)
            {
                iterations = 10;
            }
            var doubleIterations = iterations * 2;
            var target = new UriBuilder("https", on);
            var invalidRequestService = new RequestService("sslldd");
            var validRequestService = new RequestService(null);
            var response = new RequestResult[doubleIterations];
            var iterator = new int[iterations];
            for (int i = 0; i < iterations; i++)
            {
                iterator[i] = i;
            }
            Debug.WriteLine("starting RunHttps");
            var result = Parallel.ForEach(iterator, (a) =>
            {
                var m = new UriBuilder(target.Uri);
                var n = new UriBuilder(target.Uri);
                m.Query = "special=" + (a * 2);
                n.Query = "special=" + (a * 2 + 1);
                Parallel.Invoke(
                    () => SendBadRequest(a * 2, response, m.Uri, invalidRequestService),
                    () => SendGoodRequest(a * 2 + 1, response, n.Uri, validRequestService)
                );
            });
            Debug.WriteLine("completed RunHttps");
            return Json(new {Results = response, Setup = new {on = on, iterations = iterations}}, JsonRequestBehavior.AllowGet);
        }

        private void SendGoodRequest(int iteration, RequestResult[] log, Uri uri, RequestService service)
        {
            Thread.Sleep(_sleepInterval);
            Debug.WriteLine("[{0}]: starting SendGoodRequest", iteration);
            var result = new RequestResult()
            {
                Passed = true
            };
            try
            {
                service.SendRequest(uri, iteration);
            }
            catch (WebException we)
            {
                Debug.WriteLine("[{0}]: exception thrown", iteration);
                result.Passed = false;
            }
            finally
            {
                log[iteration] = result;
                Debug.WriteLine("[{0}]: completed SendGoodRequest", iteration);
            }
        }
        private void SendBadRequest(int iteration, RequestResult[] log, Uri uri, RequestService service)
        {
            Thread.Sleep(_sleepInterval);
            Debug.WriteLine("[{0}]: starting SendBadRequest", iteration);
            var result = new RequestResult()
            {
                Passed = false
            };
            try
            {
                service.SendRequest(uri, iteration);
            }
            catch (WebException we)
            {
                Debug.WriteLine("[{0}]: exception thrown", iteration);
                result.Passed = true;
            }
            finally
            {
                log[iteration] = result;
                Debug.WriteLine("[{0}]: completed SendBadRequest", iteration);
            }
        }
	}
}