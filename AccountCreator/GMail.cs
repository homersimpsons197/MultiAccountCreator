using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountCreator
{
    internal class GMail
    {
        Form1 f;
        Data data = new Data();
        Captcha c = new Captcha();
        IWebDriver d;
        DateTime timeStamp;

        public GMail(Form1 f)
        {
            this.f = f;
            timeStamp = DateTime.Now;
        }

        public void CreateGMail()
        {
            try
            {
                var c = new ChromeOptions();

                c.AddExcludedArgument("--enable-automation");
                c.AcceptInsecureCertificates = true;
                c.AddArguments("--ignore-ssl-errors");
                c.AddArgument("start-maximized");
                c.AddArguments("--lang=en");
                c.AddArguments("--disable-blink-features=AutomationControlled");
                c.AddArguments("--user-agent=Mozilla/5.0 (Linux; Android 12) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.70 Mobile Safari/537.36");
                c.AddArgument("incognito");

                //String proxy = data.Proxy(f);

                //Proxy p = new Proxy();
                //p.Kind = ProxyKind.Manual;
                //p.IsAutoDetect = false;
                //p.HttpProxy = proxy;
                //p.SslProxy = proxy;
                //c.Proxy = p;

                d = new ChromeDriver(String.Format(@"{0}", f.GetDriverPath()), c);

                var wait = new WebDriverWait(d, new TimeSpan(0, 0, 30));
                d.Navigate().GoToUrl("http://www.fakemailgenerator.com/");
                //string url = d.Url;
                ////MessageBox.Show(url);
                //((IJavaScriptExecutor)d).ExecuteScript("window.open();");
                //d.SwitchTo().Window(d.WindowHandles.Last());
                //d.Navigate().GoToUrl("https://accounts.google.com/");
                //data.Sleep();
                
                //var createAcc = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='view_container']/div/div/div[2]/div/div[2]/div/div[2]/div/div/div[1]/div/button/span")));
                //createAcc.Click();
                //data.Sleep();

                //var forMySelf = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='view_container']/div/div/div[2]/div/div[2]/div/div[2]/div/div/div[2]/div/ul/li[1]/span[2]")));
                //forMySelf.Click();
                //data.Sleep();

                //string firstName = data.FirstName(f);
                //var fName = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='view_container']/div/div/div[2]/div/div[2]/div/div[2]/div/div/div[2]/div/ul/li[1]/span[2]")));
                //fName.SendKeys(firstName);

                //string lastName = data.FirstName(f);
                //var lName = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='lastName']")));
                //lName.SendKeys(lastName);

                
                //var uName = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='lastName']")));
                //if (uName.GetAttribute("value").Equals(""))
                //{
                //    string username = data.Username(f);
                //    uName.SendKeys(username);
                //}
                //else if (uName.GetAttribute("value").Equals(""))
                //{
                //    string username = d.FindElement(By.Id("username")).GetAttribute("value");                  
                //}

                //string password = data.GMailPass(f);
                //var pass = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='passwd']/div[1]/div/div[1]/input")));
                //pass.SendKeys(password);

                //var passConfirm = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='confirm-passwd']/div[1]/div/div[1]/input")));
                //passConfirm.SendKeys(password);
                
                //var nxtBtn1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='accountDetailsNext']/div/button/div[3]")));
                //nxtBtn1.Click();

            }
            catch (Exception ex)
            {
                f.rTxtLog.Text += ex;
            }
        }
    
    }
}
