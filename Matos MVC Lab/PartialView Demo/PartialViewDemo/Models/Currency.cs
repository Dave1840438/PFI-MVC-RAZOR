using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartialViewDemo.Models
{
    public class Currency
    {

        public String USD { get; set; }
        public String EUR { get; set; }
        public String GBP { get; set; }

        public Currency()
        {
            Refresh();
        }

        public void Refresh() 
        {
            USD = "$ " + GetCurrency("CAD", "USD");
            EUR = "€ " + GetCurrency("CAD", "EUR");
            GBP = "£ " + GetCurrency("CAD", "GBP");
        }

        public static string GetXMLValue(System.Xml.XmlDocument xmlDoc, string XMLElement)
        {
            string value = "";

            System.Xml.XmlElement root = xmlDoc.DocumentElement;
            if (root != null)
            {
                System.Xml.XmlNodeList lst = root.GetElementsByTagName(XMLElement);
                foreach (System.Xml.XmlNode n in lst)
                {
                    value += n.InnerText;
                }
            }
            return value;
        }

        //Pour plus de détails voir:
        //http://www.webservicex.net/currencyconvertor.asmx?op=ConversionRate
        private string GetCurrency(string fromCurrency, String toCurrency)
        {
            String conversion = "";
            string WebServideURL = @"http://www.webservicex.net/currencyconvertor.asmx/ConversionRate?FromCurrency=" + fromCurrency + @"&ToCurrency=" + toCurrency;
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            try
            {
                doc.Load(WebServideURL);
                conversion = doc.InnerText;
            }
            catch (Exception e)
            {
                conversion = "erreur";
            }
            return conversion;
        }
      
    }
}