using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //int? tmp1 = 1;
            //double tmp2 = 2.0;
            //string tmp3 = "XD";
            //bool tmp4 = true;

            //var tmp5 = "KK";
            //var tmp6 = "i cos";

            //var tmp7 = 2;

            //var path = @"C:\Users\s19171\Desktop\Cw1";

            //Console.WriteLine($"{tmp5} {tmp6} {tmp1+tmp7}");

            //var newPerson = new Person { FirstName = "Ala" };

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            //var httpClient = new HttpClient();

            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                //status code: 2xx
                if (response.IsSuccessStatusCode)
                {
                    var htmlContent = await response.Content.ReadAsStringAsync();
                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var matches = regex.Matches(htmlContent);

                    foreach (var match in matches)
                    {
                        Console.WriteLine(match.ToString());
                    }
                }
            }
        }
    }
}
