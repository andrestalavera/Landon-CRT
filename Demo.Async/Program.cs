using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Demo.Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var webClient = new WebClient();
            var api = "http://localhost:5000/Countries";
            var watch = new Stopwatch();

            {
                // sync
                watch.Start();
                var json = webClient.DownloadString(api);
                Console.WriteLine("Sync ended : " + watch.ElapsedMilliseconds);
            }

            {
                // eap
                Console.ReadLine();
                watch.Restart();
                webClient.DownloadStringAsync(new Uri(api));
                webClient.DownloadStringCompleted += (sender, e) =>
                {
                    var json = e.Result;
                    Console.WriteLine("EAP ended : " + watch.ElapsedMilliseconds);
                };
            }

            {
                // tap
                Console.ReadLine();
                watch.Restart();
                var json = await webClient.DownloadStringTaskAsync(new Uri(api));
                Console.WriteLine("TAP ended : " + watch.ElapsedMilliseconds);
            }

        }
    }
}
