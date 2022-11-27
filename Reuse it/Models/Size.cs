using Microsoft.Build.Framework;
using Reuse_it.Enumerations;
using System.CodeDom;

namespace Reuse_it.Models
{
    public class Size
    {
        public double height { get; set; }
        public double width { get; set; }
        public double depth { get; set; }

        public Unit unit { get; set; }
        public Size()
        {

        }
        public Size(double height, double width, double depth, Unit unit)
        {

            this.height = height;
            this.width = width;
            this.depth = depth;
            this.unit = unit;
        }
        public Size(string size) {
            string[] tmp = size.Split(":");
            //1: altezza , 2: larghezza, 3: profondità
            height = Convert.ToInt16( tmp[0]);
            width = Convert.ToInt16( tmp[1]);
            depth = Convert.ToInt16( tmp[2]);
            switch (tmp[3]){

                case "mm":
                    unit = Unit.mm;
                break;
                case "cm":
                    unit = Unit.cm;
                break;
                case "m":
                    unit = Unit.m;
                break;
                default:
                    unit = Unit.mm;
                break;
            }

        }
        override
        public string ToString() {
            return height.ToString() + ":" + width.ToString() + ":" + depth.ToString() + ":" + unit.ToString();

        }
    }
}
