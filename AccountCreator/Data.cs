using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountCreator
{
    internal class Data
    {
        public void Sleep()
        {
            System.Random randomSleep = new System.Random();
            int sleep = randomSleep.Next(1, 3);

            switch (sleep)
            {
                case 1:
                    Thread.Sleep(3000);
                    break;
                case 2:
                    Thread.Sleep(4000);
                    break;
            }
        }

        public String Proxy(Form1 f)
        {
            String proxyCounterPath = string.Format(@"{0}\proxyCounter.txt", f.GetFilePath());
            String proxyFilePath = string.Format(@"{0}\proxy.txt", f.GetFilePath());

            if (!File.Exists(proxyCounterPath))
            {
                using (StreamWriter sw = File.CreateText(proxyCounterPath))
                {
                    sw.Write("0");
                }
            }

            string proxyCount = File.ReadAllLines(proxyCounterPath).First();
            int proxyCounter = int.Parse(proxyCount);
            proxyCounter++;

            String[] proxy = File.ReadAllLines(proxyFilePath);

            using (StreamWriter sw = File.CreateText(proxyCounterPath))
            {
                sw.Write(proxyCounter.ToString());
            }

            return proxy[proxyCounter - 1];
        }

        public String Email(Form1 f)
        {
            String emailCounterPath = string.Format(@"{0}\emailCounter.txt", f.GetFilePath());
            String emailFilePath = string.Format(@"{0}\email.txt", f.GetFilePath());

            if (!File.Exists(emailCounterPath))
            {
                using (StreamWriter sw = File.CreateText(emailCounterPath))
                {
                    sw.Write("0");
                }
            }

            string emailCount = File.ReadAllLines(emailCounterPath).First();
            int emailCounter = int.Parse(emailCount);
            emailCounter++;

            String[] emailArr = File.ReadAllLines(emailFilePath);

            using (StreamWriter sw = File.CreateText(emailCounterPath))
            {
                sw.Write(emailCounter.ToString());
            }

            return emailArr[emailCounter - 1];
        }

        public string FirstName(Form1 f)
        {
            String fNameFilePath = string.Format(@"{0}\fName.txt", f.GetFilePath());
            String[] fNameArr = File.ReadAllLines(fNameFilePath);

            System.Random random = new System.Random();
            int randomFName = random.Next(0, fNameArr.Length + 1);

            return fNameArr[randomFName];
        }

        public string LastName(Form1 f)
        {
            String lNameFilePath = string.Format(@"{0}\lName.txt", f.GetFilePath());
            String[] lNameArr = File.ReadAllLines(lNameFilePath);

            System.Random random = new System.Random();
            int randomLName = random.Next(0, lNameArr.Length + 1);

            return lNameArr[randomLName];
        }

        public String Username(Form1 f)
        {
            String fNameFilePath = string.Format(@"{0}\fName.txt", f.GetFilePath());
            String lNameFilePath = string.Format(@"{0}\lName.txt", f.GetFilePath());

            String[] fNameArr = File.ReadAllLines(fNameFilePath);
            String[] lNameArr = File.ReadAllLines(lNameFilePath);

            System.Random random1 = new System.Random();
            int randomFName = random1.Next(0, fNameArr.Length + 1);

            System.Random random2 = new System.Random();
            int randomLName = random2.Next(0, lNameArr.Length + 1);

            System.Random random3 = new System.Random();
            int randomDigits = random3.Next(11111, 99999);

            String username = fNameArr[randomFName] + lNameArr[randomLName][0] + randomDigits.ToString();

            return username;
        }

        public string GMailPass(Form1 f)
        {
            String password = "Fresn013";

            return password;
        }

        public void CounterReset(Form1 f)
        {
            String emailCounterPath = string.Format(@"{0}\emailCounter.txt", f.GetFilePath());
            String proxyCounterPath = string.Format(@"{0}\proxyCounter.txt", f.GetFilePath());

            using (StreamWriter sw = File.CreateText(emailCounterPath))
            {
                sw.Write(0);
            }

            using (StreamWriter sw = File.CreateText(proxyCounterPath))
            {
                sw.Write(0);
            }
        }
    }
}
