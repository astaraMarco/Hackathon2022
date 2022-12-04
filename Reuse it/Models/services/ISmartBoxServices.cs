using Reuse_it.Models.viewModels;

namespace Reuse_it.Models.services
{
    public interface ISmartBoxServices
    {
        public List<SmartBoxViewModel>? SmartBoxGet();
        public List<SmartBoxViewModel>? SmartBoxGetWithAddress(string address);
        public List<SmartBoxViewModel>? SmartBoxGetWithRegions(string regione);
        public List<SmartBoxViewModel>? SmartBoxGetWithProvincia(string provincia);
        public List<SmartBoxViewModel>? SmartBoxGetWithAddress(List<SmartBoxViewModel> smartBox, string address);
        public List<SmartBoxViewModel>? SmartBoxGetWithRegions(List<SmartBoxViewModel> smartBox, string regione);
        public List<SmartBoxViewModel>? SmartBoxGetWithProvincia(List<SmartBoxViewModel> smartBox, string provincia);
        List<SmartBoxViewModel>? SmartBoxGetWithNome(string v);
        List<SmartBoxViewModel>? SmartBoxGetWithNome(List<SmartBoxViewModel> smartBox, string v);
        List<SlotViewModels> GetSlotsLocker(int id);
        List<SlotViewModels> GetSlotsLockerFree(int id);
        bool BlockingSlot(int id,int idProduct);
        string ReleaseSlot(int id);
    }
}
