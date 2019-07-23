using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate
{
    class ExchangeRate  //환율 기본 정보
    {
        readonly string nationName; //국가명
        readonly string currencyName;   //통화명
        readonly string basicRateOfExchange;    //매매기준율
        readonly string netChange;  //전일대비
        readonly string fluctuationRatio;   //등락률

        public ExchangeRate(string nationName, string currencyName, string basicRateOfExchange, string netChange, string fluctuationRatio)
        {
            this.nationName = nationName;
            this.currencyName = currencyName;
            this.basicRateOfExchange = basicRateOfExchange;
            this.netChange = netChange;
            this.fluctuationRatio = fluctuationRatio;
        }

        public string GetnationName() { return nationName; }
        public string GetCurrencyName() { return currencyName; }
        public string GetBasicRateOfExchange() { return basicRateOfExchange; }
        public string GetNetChange() { return netChange; }
        public string GetFluctuationRatio() { return fluctuationRatio; }

        public override string ToString()
        {
            return ("통화명:" + currencyName + '\t' + "매매기준율:" + basicRateOfExchange + '\t' + "전일대비:" + netChange + '\t' + "등락율:" + fluctuationRatio).ToString();
        }
    }
}
