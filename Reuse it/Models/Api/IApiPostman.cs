using Org.BouncyCastle.Asn1.Ocsp;
using RestSharp;
using Reuse_it.Models.viewModels;

namespace Reuse_it.Models.Api
{
    public interface IApiPostman
    {

        public RestRequest inizializeRequest();

        public RestRequest inizializeRequest(string addpath, string method);
        public RestClient InizializeClient();
        public RestClient InizializeClient(string addPath);

        public string? GetResponse(RestClient rc, RestRequest rr);
        RestRequest AddParameter(RestRequest rr,string nameParameter,int id);
        public RestRequest AddParameterEncoded(RestRequest rr, string nameParameter, int id);
        RestResponse PostBooking(RestClient rc, RestRequest rr);
        RestRequest addBody(RestRequest request, bookViewModel bookSlot);
        RestResponse PostRelese(RestClient client, RestRequest request);
    }
}
