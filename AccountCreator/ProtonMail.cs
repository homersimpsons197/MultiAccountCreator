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
    internal class ProtonMail
    {
        Form1 f;
        Data data = new Data();
        Captcha captcha = new Captcha();

        IWebDriver d;

        DateTime timeStamp;

        public static string pass = "#Lagun@2056";
        public static int counter;

        public ProtonMail(Form1 f)
        {
            this.f = f;
            timeStamp = DateTime.Now;
        }

        public void CreateMail()
        {
            //do
            //{
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

                //String proxy = data.Proxy(f);

                //Proxy p = new Proxy();
                //p.Kind = ProxyKind.Manual;
                //p.IsAutoDetect = false;
                //p.HttpProxy = proxy;
                //p.SslProxy = proxy;
                //c.Proxy = p;

                d = new ChromeDriver(String.Format(@"{0}", f.GetDriverPath()), c);

                var wait = new WebDriverWait(d, new TimeSpan(0, 0, 30));

                d.Navigate().GoToUrl("https://account.proton.me/signup?plan=free&billing=12&currency=EUR&language=en");
                data.Sleep();

                d.SwitchTo().Frame(d.FindElement(By.XPath("//iframe[@src='https://account-api.proton.me/challenge/v4/html?Type=0&Name=username']")));

                string username = data.Username(f);
                var usernameTxtBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/label/div[2]/div/div[1]/input")));
                usernameTxtBox.SendKeys(username);
                data.Sleep();
                //Thread.Sleep(5000);

                d.SwitchTo().DefaultContent();

                //var free = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='upgrade-account-dialog']/div[2]/div[1]/div[1]/div[5]/button")));
                //free.Click();
                //data.Sleep();

                //d.SwitchTo().Window(d.WindowHandles.Last());


                //var checkbox1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='I do not own any other Free account.']")));
                //checkbox1.Click();
                //data.Sleep();

                //var checkbox2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='I will not use this account for business.']")));
                //checkbox2.Click();
                //data.Sleep();

                //var okBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='Ok']")));
                //okBtn.Click();
                //data.Sleep();

                //d.SwitchTo().Window(d.WindowHandles.Last());

                //string username = data.Username(f);
                //var emailTxtBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='signup-account-dialog']/div/div[1]/div/div/div/div[1]/input")));
                //emailTxtBox.SendKeys(username);
                //data.Sleep();


                var passTxtBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='password']")));
                passTxtBox.SendKeys(pass);
                data.Sleep();

                var pass2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='repeat-password']")));
                pass2.SendKeys(pass);
                data.Sleep();


                var checkbox3 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[normalize-space()='Create account']")));
                checkbox3.Click();
                data.Sleep();
                Thread.Sleep(5000);
                var iframeCount = d.FindElements(By.XPath("//iframe")).Count;
                //MessageBox.Show("Frame from default control: " + iframeCount.ToString());
                var iframeSrc = d.FindElements(By.XPath("//iframe"));
                d.SwitchTo().Frame(iframeSrc[0]);
                
                var iframeSrc2 = d.FindElements(By.XPath("//iframe"));

                if (!File.Exists(String.Format(@"{0}\html.txt", f.GetFilePath())))
                {
                    using (StreamWriter sw = File.CreateText(String.Format(@"{0}\html.txt", f.GetFilePath())))
                    {

                    }
                }

                    String source = iframeSrc2[0].GetAttribute("src");

                    if (source != "")
                    {
                        using (StreamWriter sw = File.AppendText(String.Format(@"{0}\html.txt", f.GetFilePath())))
                        {
                            sw.Write(source + "\n");
                        }
                    }
                String[] srcArr = File.ReadAllLines(String.Format(@"{0}\html.txt", f.GetFilePath()));

                File.Delete(String.Format(@"{0}\html.txt", f.GetFilePath()));
                
                d.SwitchTo().Frame(iframeSrc2[0]);
                //var chBox = d.FindElement(By.XPath("//*[@id='checkbox']"));
                //chBox.Click();
                data.Sleep();
                d.SwitchTo().DefaultContent();
                d.SwitchTo().Frame(iframeSrc[0]);
                Regex filter = new Regex(@"(sitekey)(.*\=light$)");

                var match = filter.Match(srcArr[0]);

                String rawKey = match.ToString();
                //String key = srcArr[0].Replace(String.Format("{0}", rawKey), "");
                String key = rawKey.Replace("sitekey=", "").Replace("&theme=light", "");

                String url = d.Url;
                
                //d.SwitchTo().Frame(iframeSrc2[0]);

                
                //var clickCaptcha = d.FindElement(By.XPath("//body"));
                //clickCaptcha.Click();
                //MessageBox.Show(btn.ToString());
                //captcha.HCaptcha(f, key, url, proxy);




                //data.Sleep();
                IJavaScriptExecutor e = (IJavaScriptExecutor)d;
                //MessageBox.Show(captcha.GetToken());
                string x = "[id^=\"g-recaptcha-response\"]";
                string javascript_code = string.Format("document.querySelector('{0}').innerHTML = '{1}';", x, captcha.GetToken());
                e.ExecuteScript(javascript_code);
                data.Sleep();
                //d.SwitchTo().Frame(iframeSrc[0]);
                d.SwitchTo().DefaultContent();
                d.SwitchTo().Frame(iframeSrc[0]);
                d.SwitchTo().Frame(iframeSrc2[1]);
                var btn = d.FindElement(By.XPath("//*[text()='Verify']"));
                btn.Click();
                ////var freakyBtn = d.FindElement(By.XPath("/html/body/div[2]/div[8]"));
                //// freakyBtn.Click();
                //var submit = d.FindElement(By.TagName("form"));
                //submit.Submit();
                ////string xx = "[aria-label=\"Submit Answers\"]";
                ////string javascript_btn = "const firstP = document.evaluate('/html/body/div[2]/div[8]',  document,  null,  XPathResult.FIRST_ORDERED_NODE_TYPE,  null,).singleNodeValue; firstP.click()";
                ////e.ExecuteScript(javascript_btn);
                //data.Sleep();
                //var checkbox4 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='I am at least 16 years old.']")));
                //checkbox4.Click();
                //data.Sleep();

                //var btnNext = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='Next']")));
                //btnNext.Click();
                //data.Sleep();

                //var btnOk = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[text()='Ok']")));
                //btnOk.Click();
                //data.Sleep();

                //using (StreamWriter sw = File.AppendText(String.Format(@"{0}\accounts\tutanota.txt", f.GetFilePath())))
                //{
                //    sw.Write(username + "@tutanota.com;" + pass + ";" + ";" + proxy + "\n");
                //}

                //d.Quit();

                //f.rTxtLog.Text += "Tutanota account created => " + username + "@tutanota.com;" + "  @" + timeStamp.ToString("HH: mm: ss") + "\n";

                //counter++;

                //data.Sleep();

                //f.rTxtLog.Text += "Account created: " + username + "@protonmail.me" + ";" + pass;

                //using (StreamWriter sw = File.AppendText(String.Format(@"{0}\accounts\proton.txt", f.GetFilePath())))
                //{
                //    sw.Write(username + "@protonmail.me" + ";" + pass + "\n");
                //}

            }
            catch (Exception ex)
            {
                f.rTxtLog.Text += ex;
            }
            }
            //while (counter != f.GetNbOfAcc());

            //data.CounterReset(f);
        }
    }
//}
