
using Google.Protobuf.WellKnownTypes;
using NuGet.Protocol.Plugins;
using Org.BouncyCastle.Asn1.Ocsp;
using RestSharp;
using RestSharp.Authenticators;
using Reuse_it.Models.viewModels;
using System.Text.Json;
using System.Text.Json.Serialization;
using Method = RestSharp.Method;

namespace Reuse_it.Models.Api
{
    public class ApiPostman : IApiPostman
    {
        private string _tenant="Black";
        private string _apikey = "Rp/eXsI32u0BO2V3tCz+gMajdM8SdTrN95n5KZTADMA=";
        private string _host = "http://hack-smartlocker.sintrasviluppo.it/";

        public RestClient InizializeClient() {
            return new RestClient(_host);
        }
        public RestClient InizializeClient(string addPath)
        {
            return new RestClient(_host + addPath);
        }

        public RestRequest inizializeRequest(string addpath, string method) {
            RestRequest request;
            if (method.ToString().ToLower().Equals("post"))
            {
                request = new RestRequest(_host + addpath,Method.Post);

            }
            else { 
                request = new RestRequest(_host+addpath,Method.Get);

            }
            request.AddHeader("x-apikey", _apikey);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Accept", "*/*");
            //request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            //request.AddHeader("Connection", "keep-alive");
            request.AddHeader("x-tenant", _tenant);
            return request;
        }
        public string? GetResponse(RestClient rc,RestRequest rr) {
            RestResponse re = rc.Get(rr);

            return re.Content.ToString();
        }
        public RestRequest AddParameterEncoded(RestRequest rr, string nameParameter, int id)
        {
            return rr.AddParameter(nameParameter, id,true);
        }
        public RestRequest AddParameter(RestRequest rr, string nameParameter, int id)
        {
            return rr.AddParameter(nameParameter, id);
        }

        public RestResponse PostBooking(RestClient rc, RestRequest rr)
        {
            return rc.Post(rr);
        }

        public RestRequest addBody(RestRequest request, bookViewModel bookSlot)
        {
            return request.AddBody(bookSlot);
        }

        public RestResponse PostRelese(RestClient client, RestRequest request)
        {
            return client.Post(request);
        }

        public RestRequest inizializeRequest()
        {
            var request = new RestRequest();
            request.AddHeader("x-apikey", _apikey);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Accept", "*/*");
            //request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            //request.AddHeader("Connection", "keep-alive");
            request.AddHeader("x-tenant", _tenant);
            return request;
        }
    }
}
