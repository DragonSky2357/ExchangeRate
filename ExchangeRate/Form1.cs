using ExchangeRate.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Abot.Crawler;
using Abot.Poco;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace ExchangeRate
{
    public partial class Form1 : Form
    {
        private ExchangeRateManagement Management;
        Label[] labelBasicRateOfExchang;
        Label[] labelNetChange;
        Label[] labelFluctuationRatio;
        PictureBox[] pictureVariation;

        public Form1()
        {
            InitializeComponent();
            Management = new ExchangeRateManagement();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDefalutSet();   //이미지 및 기본 설정
            LoadLabelPictureSet();  //레이블 데이터 설정
            DataSet();  //데이터 삽입 및 증감이미지 설정
        }

        private void LoadDefalutSet()
        {
            pictureUSA.Image = Properties.Resources.USA;
            pictureChina.Image = Properties.Resources.China;
            pictureEU.Image = Properties.Resources.EU;
            pictureAustralia.Image = Properties.Resources.Australia;
            pictureNewZealand.Image = Properties.Resources.NewZealand;
            pictureJapan.Image = Properties.Resources.Japan;
            pictureUK.Image = Properties.Resources.UK;
            pictureCanada.Image = Properties.Resources.Canada;
            
        }

        private void LoadLabelPictureSet()
        {
            labelBasicRateOfExchang = new Label[] { lblBasicRateOfExchangeUSD,lblBasicRateOfExchangeCNY,lblBasicRateOfExchangeEUR,lblBasicRateOfExchangeNZD,
                                                    lblBasicRateOfExchangeJPY,lblBasicRateOfExchangeAUD,lblBasicRateOfExchangeGBP,lblBasicRateOfExchangeCAD};

            labelNetChange = new Label[] {lblNetChangeUSD,lblNetChangeCNY,lblNetChangeEUR,lblNetChangeNZD,lblNetChangeJPY,lblNetChangeAUD,
                                        lblNetChangeGBP,lblNetChangeCAD};

            labelFluctuationRatio = new Label[] { lblFluctuationRatioUSD,lblFluctuationRatioCNY,lblFluctuationRatioEUR,lblFluctuationRatioNZD,
                                                  lblFluctuationRatioJPY,lblFluctuationRatioAUD,lblFluctuationRatioGBP,lblFluctuationRatioCAD};

            pictureVariation = new PictureBox[] { pictureVariationUSD,pictureVariationCNY,pictureVariationEUR,pictureVariationNZD,
                                                  pictureVariationJPY,pictureVariationAUD,pictureVariationGBP,pictureVariationCAD};
        }

        private void DataSet()
        {
           for(int i = 0; i < Management.GetExchangeRates().Count; i++)
            {
                var item = Management.GetExchangeRates()[i];

                labelBasicRateOfExchang[i].Text = item.GetBasicRateOfExchange();
                labelNetChange[i].Text = item.GetNetChange();
                labelFluctuationRatio[i].Text = item.GetFluctuationRatio();
                

                if (IncreaseAndDecreaseFind(item.GetFluctuationRatio().ToString()))
                {
                    labelFluctuationRatio[i].BackColor = Color.Blue;
                    labelNetChange[i].ForeColor = Color.CornflowerBlue;
                    pictureVariation[i].Image = Properties.Resources.IncreaseArrow;
                }
                else
                {
                    labelFluctuationRatio[i].BackColor = Color.Red;
                    labelNetChange[i].ForeColor = Color.OrangeRed;
                    pictureVariation[i].Image = Properties.Resources.DecreaseArrow;
                }
                
            }
        }

        private bool IncreaseAndDecreaseFind(string FluctuationRatio) //증감 체크
        {
            if (FluctuationRatio[0] == '+')
                return true;
            else
                return false;
        }

    }
}
