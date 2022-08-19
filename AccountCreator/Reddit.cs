using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountCreator
{
    internal class Reddit
    {
        Form1 f;
        Data data = new Data();
        Captcha captcha = new Captcha();

        DateTime timeStamp;

        IWebDriver d;

        public static string pass = "Fresn0@13";
        public static int counter;

        public Reddit(Form1 f)
        {
            this.f = f;
            timeStamp = DateTime.Now;
        }

        public void CreateReddit()
        {
            do
            {
                try
                {
                    var c = new ChromeOptions();
                    
                    c.AddArguments(String.Format(@"--user-data-dir={0}", f.GetDriverPath()));
                    c.AddArguments("--profile-directory=Profile 12");
                    c.AddExcludedArgument("--enable-automation");
                    c.AcceptInsecureCertificates = true;
                    c.AddArguments("--ignore-ssl-errors");
                    c.AddArgument("start-maximized");
                    c.AddArguments("--lang=en");
                    c.AddArguments("--disable-blink-features=AutomationControlled");
                    c.AddArguments("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Safari/537.36");

                    String proxy = "192.161.162.217:8800";

                    Proxy p = new Proxy();
                    p.Kind = ProxyKind.Manual;
                    p.IsAutoDetect = false;
                    p.HttpProxy = proxy;
                    p.SslProxy = proxy;
                    c.Proxy = p;

                    d = new ChromeDriver(String.Format(@"{0}", f.GetDriverPath()), c);

                    var wait = new WebDriverWait(d, new TimeSpan(0, 0, 30));

                    d.Navigate().GoToUrl("http://www.fakemailgenerator.com/");
                    var error = d.FindElements(By.XPath("//*[@id='cf-error-details']/header/h1/span[1]")).Count;
                    if (error == 0)
                    {
                        string fakeMail = d.FindElement(By.XPath("//span[@id='cxtEmail']")).Text;

                        ((IJavaScriptExecutor)d).ExecuteScript("window.open();");
                        d.SwitchTo().Window(d.WindowHandles.Last());

                        d.Navigate().GoToUrl("https://old.reddit.com/login");
                        data.Sleep();


                        string username = data.Username(f);

                        var usernameTxtBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@id='user_reg']")));
                        usernameTxtBox.SendKeys(username);
                        data.Sleep();

                        var passwordTxtBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@id='passwd_reg']")));
                        passwordTxtBox.SendKeys(pass);
                        data.Sleep();

                        var passwordTxtBoxConfirm = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@placeholder='verify password']")));
                        passwordTxtBoxConfirm.SendKeys(pass);
                        data.Sleep();

                        //string email = data.Email(f);

                        var emailTxtBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@id='email_reg']")));
                        emailTxtBox.SendKeys(fakeMail);
                        Thread.Sleep(10000);

                        var iframeSrc = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//iframe")));

                        if (!File.Exists(String.Format(@"{0}\html.txt", f.GetFilePath())))
                        {
                            using (StreamWriter sw = File.CreateText(String.Format(@"{0}\html.txt", f.GetFilePath())))
                            {

                            }
                        }

                        foreach (var iframe in iframeSrc)
                        {
                            String source = iframe.GetAttribute("src");

                            if (source != "")
                            {
                                using (StreamWriter sw = File.AppendText(String.Format(@"{0}\html.txt", f.GetFilePath())))
                                {
                                    sw.Write(source + "\n");
                                }
                            }
                        }

                        String[] srcArr = File.ReadAllLines(String.Format(@"{0}\html.txt", f.GetFilePath()));

                        File.Delete(String.Format(@"{0}\html.txt", f.GetFilePath()));

                        Regex filter = new Regex(@"(.*?.*=)");

                        var match = filter.Match(srcArr[2]);

                        String rawKey = match.ToString();
                        String key = srcArr[2].Replace(String.Format("{0}", rawKey), "");
                        String url = d.Url;

                        captcha.ReCaptcha(f, key, url, proxy);

                        IJavaScriptExecutor e = (IJavaScriptExecutor)d;
                        string javascript_code = string.Format("document.getElementById('g-recaptcha-response').innerHTML = '{0}';", captcha.GetToken());
                        e.ExecuteScript(javascript_code);
                        data.Sleep();

                        var submit = d.FindElement(By.TagName("form"));
                        submit.Submit();
                        data.Sleep();

                        using (StreamWriter sw = File.AppendText(String.Format(@"{0}\accounts\reddit.txt", f.GetFilePath())))
                        {
                            sw.Write(username + "-" + pass + "-" + proxy + "\n");
                        }

                        int exist = 0;

                        d.SwitchTo().Window(d.WindowHandles[0]);

                        do
                        {
                            var emailFrame = d.FindElements(By.XPath("//*[@id='emailFrame']")).Count;
                            exist = emailFrame;
                        }
                        while (exist == 0);

                        var mailFrame = d.FindElement(By.XPath("//*[@id='emailFrame']"));

                        d.SwitchTo().Frame(mailFrame);

                        var verify = d.FindElement(By.XPath("/html/body/center/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[1]/td/table/tbody/tr/td/table/tbody/tr/td/table/tbody/tr[3]/td/table/tbody/tr/td/a/span/strong"));
                        verify.Click();
                        Thread.Sleep(10000);

                        d.Quit();

                        f.rTxtLog.Text += "Reddit account created => " + username + " " + pass + "\n";

                        counter++;

                        data.Sleep();
                    }
                    else if (error > 0)
                    {
                        counter++;

                        d.Quit();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    break;
                }
            }
            while (counter != f.GetNbOfAcc());

            data.CounterReset(f);
        }
    }
}

