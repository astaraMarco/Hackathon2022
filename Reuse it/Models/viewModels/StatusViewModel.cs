namespace Reuse_it.Models.viewModels
{
    public class StatusViewModel
    {
        public bool booked { get; set; }
        public bool open { get; set; }
        public string? boockedBy { get; set; }
        public string? boockedFrom { get; set; }
        public string? content { get; set; }
        public int customerId { get; set; }
        public List<string> unlockCodes { get; set; }

    }
}
