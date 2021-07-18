using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserveSport.Helper
{
    public static class Payments
    {
        public static JObject DoPayment(string mobile, string merchant, int amount, string callbackurl, string description)
        {
            string[] metadata = new string[1];
            metadata[0] = $"[mobile: {mobile}]";
            //be dalil in ke metadata be sorate araye ast va do meghdare mobile va email dar metadata gharar mmigirad
            //shoma mitavanid in maghadir ra az kharidar begirid va set konid dar gheir in sorat khali ersal konid
            string requesturl;
            requesturl = "https://api.zarinpal.com/pg/v4/payment/request.json?merchant_id=" +
                merchant + "&amount=" + amount +
                "&callback_url=" + callbackurl +
                "&description=" + description +
                "&metadata[0]=" + metadata[0];
            ;
            var client = new RestClient(requesturl);
            client.Timeout = -1;
            var request = new RestRequest(RestSharp.Method.POST);
            request.AddHeader("accept", "application/json");
            request.AddHeader("content-type", "application/json");
            IRestResponse requestresponse = client.Execute(request);
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(requestresponse.Content);
            string errorscode = jo["errors"].ToString();
            Newtonsoft.Json.Linq.JObject jodata = Newtonsoft.Json.Linq.JObject.Parse(requestresponse.Content);
            string dataauth = jodata["data"].ToString();
            return jodata;
        }
        public static Tuple<JObject,string,string> DoVerify(int amount,string merchant,string authority)
        {
            
            string url = "https://api.zarinpal.com/pg/v4/payment/verify.json?merchant_id=" +
                         merchant + "&amount="
                         + amount + "&authority="
                         + authority;
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", "application/json");
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);
            Newtonsoft.Json.Linq.JObject jodata = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
            string data = jodata["data"].ToString();
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
            string errors = jo["errors"].ToString();
            return Tuple.Create(jodata,data,errors);
        }
    }
}
