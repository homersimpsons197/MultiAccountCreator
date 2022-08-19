using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AccountCreator
{
    internal class Captcha
    {
        public static string token = "";

        public void ReCaptcha(Form1 f, String key, String url, String p)
        {
            try
            {

                var client = new RestClient("http://2captcha.com/in.php");
                string reqUrl = "http://2captcha.com/in.php?key=d77072070b4a8a5ba9cfbb775693a083&method=userrecaptcha&googlekey=" + key + "&pageurl=" + url + "&proxy=" + p + "&proxytype=http";
                var request = new RestRequest(reqUrl, Method.Post);
                RestResponse response = client.Execute(request);
                Console.WriteLine("Captcha receive with success: " + response.IsSuccessful + "\n" + response.Content);

                Thread.Sleep(5000);

                string content = response.Content;

                Regex filter = new Regex(@"[0-9]{11}");
                var match = filter.Match(content);
                string id = match.ToString();

                do
                {
                    Console.WriteLine("Checking status...");
                    client = new RestClient("http://2captcha.com/res.php");

                    request = new RestRequest("http://2captcha.com/res.php?key=d77072070b4a8a5ba9cfbb775693a083&action=get&id=" + id, Method.Get);
                    response = client.Execute(request);
                    Thread.Sleep(5000);
                }
                while (!response.Content.Contains("OK"));

                token = response.Content;
                token = token.Replace("OK|", "");
                Console.WriteLine(token);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void HCaptcha(Form1 f, String key, String url, String p)
        {                     
            var client = new RestClient("http://2captcha.com/in.php");

            string reqUrl = "http://2captcha.com/in.php?key=d77072070b4a8a5ba9cfbb775693a083&method=hcaptcha&sitekey=" + key + "&pageurl=" + url + "&proxy=" + p + "&proxytype=http";
            var request = new RestRequest(reqUrl, Method.Post);
            RestResponse response = client.Execute(request);
            f.rTxtLog.Text += "HCaptcha response: " + response.Content;

            Thread.Sleep(5000);

            string content = response.Content;

            Regex filter = new Regex(@"[0-9]{11}");
            var match = filter.Match(content);
            string id = match.ToString();
            f.rTxtLog.Text += "HCaptcha ID: " + id;

            do
            {
                Console.WriteLine("Checking status...");
                client = new RestClient("http://2captcha.com/res.php");

                request = new RestRequest("http://2captcha.com/res.php?key=d77072070b4a8a5ba9cfbb775693a083&action=get&id=" + id, Method.Get);
                response = client.Execute(request);
                f.rTxtLog.Text += response.Content;
                Thread.Sleep(5000);
            }
            while (!response.Content.Contains("OK"));

            token = response.Content;
            token = token.Replace("OK|", "");
            f.rTxtLog.Text += "HCaptcha Solved token: " + token;
        }

        public String GetToken()
        {
            return token;
        }
    }
}
