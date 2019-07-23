using System;
using System.IO;
using System.Threading;
using Abot.Crawler;
using Abot.Poco;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Net;
using System.Diagnostics;
using System.Windows.Forms;

namespace ExchangeRate
{
    class ExchangeRateManagement
    {
        private List<ExchangeRate> CBCExchangeRate= new List<ExchangeRate>();

        public ExchangeRateManagement() //데이터 수집 프로그램 실행
        {
            Process process = new Process();
            process.StartInfo.FileName = Application.StartupPath + @"\\Data.exe";
            process.StartInfo.Arguments = "-n";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();

            Thread.Sleep(3000);

            using (StreamReader sr = new StreamReader(Application.StartupPath + @"\\data.txt")) //데이터 수집
            {
                string dataLine;
                while((dataLine=sr.ReadLine())!=null)
                {
                    if (dataLine.Contains("일본"))    //일본의 경우 JPY 100을 읽는중 100을 제외시키는 과정
                        dataLine =dataLine.Remove(7, 4);
                    
                    var dataSplit = dataLine.Split(' ');
                    dataSplit[3]=dataSplit[3].Remove(0,2);
                    CBCExchangeRate.Add(new ExchangeRate(dataSplit[0], dataSplit[1], dataSplit[2], dataSplit[3], dataSplit[4]));
                }   
            }
        }

        public List<ExchangeRate> GetExchangeRates()
        {
            return CBCExchangeRate;
        }
    }
}