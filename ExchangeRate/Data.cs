using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace StudyCS
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Minimize();

            driver.Url = "https://search.naver.com/search.naver?sm=top_hty&fbm=1&ie=utf8&query=%ED%99%98%EC%9C%A8";

            var rank = driver.FindElement(By.ClassName("rate_table_info"));
            var classification = rank.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            using (StreamWriter sw = new StreamWriter("data.txt"))
            {
                for (int i = 4; i < classification.Length; i += 5)
                    sw.WriteLine("{0} {1} {2} {3}",classification[i], classification[i + 1], classification[i + 3], classification[i + 4]);
            }

            driver.Close();

            return;
        }
    }
}


