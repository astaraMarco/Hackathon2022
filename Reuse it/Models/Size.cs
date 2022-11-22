namespace Reuse_it.Models
{
    public class Size
    {
        double height { get; set; }
        double width { get; set; }
        double length { get; set; }
        public Size(double h,double w, double l)
        {
            height = h;
            width = w;
            length = l;
        }
    }
}
