using RestSharp;
using Reuse_it.Models.Api;
using Reuse_it.Models.Infrastructure;
using Reuse_it.Models.viewModels;
using System.Text.Json;

namespace Reuse_it.Models.services
{
    public class SmartBoxServices : ISmartBoxServices
    {
        private readonly IApiPostman apiPostman;
        private readonly IProductService productServices;


        public SmartBoxServices(IApiPostman api,IProductService ps) {
            apiPostman = api;
            productServices = ps;
        }

        public List<SmartBoxViewModel>? SmartBoxGet()
        {
            string addPath = "api/lockers/";
            var client = apiPostman.InizializeClient(addPath);
            var request = apiPostman.inizializeRequest();
            string? response = apiPostman.GetResponse(client, request);


            List<SmartBoxViewModel>? tmp = JsonSerializer.Deserialize<List<SmartBoxViewModel>>(response);

            return tmp;
        }

        public List<SmartBoxViewModel>? SmartBoxGetWithAddress(string address)
        {
            List<SmartBoxViewModel> CorrectSmartBox = new List<SmartBoxViewModel>();
            var smartBox = this.SmartBoxGet();
            foreach (var smart in smartBox)
            {
                if (smart.address.Equals(address))
                {
                    CorrectSmartBox.Add(smart);
                }
            }
            return CorrectSmartBox;
        }

        public List<SmartBoxViewModel>? SmartBoxGetWithRegions(string regione)
        {
            List<SmartBoxViewModel> CorrectSmartBox = new List<SmartBoxViewModel>();
            var smartBox = this.SmartBoxGet();
            foreach (var smart in smartBox)
            {
                if (smart.regione.Equals(regione))
                {
                    CorrectSmartBox.Add(smart);
                }
            }
            return CorrectSmartBox;
        }

        public List<SmartBoxViewModel>? SmartBoxGetWithProvincia(string provincia)
        {
            List<SmartBoxViewModel> CorrectSmartBox = new List<SmartBoxViewModel>();
            var smartBox=this.SmartBoxGet();
            foreach (var smart in smartBox)
            {
                if (smart.provincia == provincia)
                {
                    CorrectSmartBox.Add(smart);
                }
            }
            return CorrectSmartBox;
        }

        public List<SmartBoxViewModel>? SmartBoxGetWithAddress(List<SmartBoxViewModel> smartBox, string address)
        {
            List<SmartBoxViewModel> CorrectSmartBox = new List<SmartBoxViewModel>();
            foreach (var smart in smartBox)
            {
                if (smart.address.Equals(address))
                {
                    CorrectSmartBox.Add(smart);
                }
            }
            return CorrectSmartBox;
        }

        public List<SmartBoxViewModel>? SmartBoxGetWithRegions(List<SmartBoxViewModel> smartBox, string regione)
        {
            List<SmartBoxViewModel> CorrectSmartBox = new List<SmartBoxViewModel>();
            foreach (var smart in smartBox)
            {
                if (smart.regione.Equals(regione))
                {
                    CorrectSmartBox.Add(smart);
                }
            }
            return CorrectSmartBox;
        }

        public List<SmartBoxViewModel>? SmartBoxGetWithProvincia(List<SmartBoxViewModel> smartBox, string provincia)
        {
            List<SmartBoxViewModel> CorrectSmartBox = new List<SmartBoxViewModel>();
            foreach (var smart in smartBox)
            {
                if (smart.provincia == provincia)
                {
                    CorrectSmartBox.Add(smart);
                }
            }
            return CorrectSmartBox;
        }

        public List<SmartBoxViewModel>? SmartBoxGetWithNome(string v)
        {
            List<SmartBoxViewModel> CorrectSmartBox = new List<SmartBoxViewModel>();
            var smartBox = this.SmartBoxGet();
            foreach (var smart in smartBox)
            {
                if (smart.nome.Equals(v))
                {
                    CorrectSmartBox.Add(smart);
                }
            }
            return CorrectSmartBox;
        }

        public List<SmartBoxViewModel>? SmartBoxGetWithNome(List<SmartBoxViewModel> smartBox, string v)
        {
            List<SmartBoxViewModel> CorrectSmartBox = new List<SmartBoxViewModel>();
            foreach (var smart in smartBox)
            {
                if (smart.nome.Equals(v))
                {
                    CorrectSmartBox.Add(smart);
                }
            }
            return CorrectSmartBox;
        }

        public List<SlotViewModels> GetSlotsLocker(int id)
        {
            string addPath = "api/slots/";
            var client = apiPostman.InizializeClient(addPath);
            var request = apiPostman.inizializeRequest();


            request= apiPostman.AddParameter(request,"lockerId", id);

            string? response = apiPostman.GetResponse(client, request);


            List<SlotViewModels>? tmp = JsonSerializer.Deserialize<List<SlotViewModels>>(response);

            return tmp;

        }

        public List<SlotViewModels> GetSlotsLockerFree(int id)
        {   List<SlotViewModels> slotsFree= new List<SlotViewModels>();
            var slots = GetSlotsLocker(id);
            foreach (var slot in slots) {
                if (slot.status.booked != true) {
                    slotsFree.Add(slot);
                }
            }

            return slotsFree;
        }


        public bool BlockingSlot(int id, int idProduct)
        {
            string addPath = "api/book";
            var client =apiPostman.InizializeClient(addPath);
            var request = apiPostman.inizializeRequest();



            ProductViewModel pr = productServices.GetProduct(idProduct);
            bookViewModel bookSlot = new bookViewModel()
            {
                customerId = 1,
                customerName = "test",
                slotId = id,
                slotContent = pr.nome
            };

            request = apiPostman.addBody(request, bookSlot);

            var response = apiPostman.PostBooking(client,request);

            string s = response.Content.ToString();

            return true;
        }

        public string ReleaseSlot(int id)
        {
            string addPath = "api/release?slotId="+id;
            var client = apiPostman.InizializeClient(addPath);
            var request = apiPostman.inizializeRequest(addPath,"post");
            //request = apiPostman.AddParameterEncoded(request, "slotId",id);

            RestResponse response = apiPostman.PostBooking(client, request);

            string s = response.Content.ToString();

            return s;
        }
    }
}
