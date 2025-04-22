using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType 
            { Boeing
            ,Airbus}
    public class Plane
    {
        //Property
        public int PlaneId { get; set; }
        [Range(1,int.MaxValue)]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType PlaneType { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        [NotMapped]
        public string Information { get { return PlaneId + " " + ManufactureDate + " " + Capacity; } }

        public override string ToString()
        {
            return "Capacity: "+Capacity+" PlaneType: "+PlaneType;
        }
    }
}
