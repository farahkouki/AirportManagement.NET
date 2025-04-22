using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        [ForeignKey("Flight")]
       //[key]
        public int FlightFk { get; set; }
        [ForeignKey("Passenger")]
       // [Key]
        public string passengerFk { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual Passenger Passenger { get; set; }
        public double Prix { get; set; }
        public string Siége { get; set; }
        public Boolean VIP { get; set; }
    }
}
