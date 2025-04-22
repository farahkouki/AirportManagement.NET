using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        public FullName FullName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Date Of Birth")]
        public DateTime BirthDate { get; set; }
        [RegularExpression("^[0,9]{8}$")]
        public string TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        //public ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Ticket> tickes { get; set; }
        public override string ToString()
        {
            return "FirstName: " + FullName.FirstName 
                + " LastName: " + FullName.LastName
                + " BirthDate: " + BirthDate;
        }
        //public bool CheckProfile(string FirstName, string LastName)
        //{
        //    return this.FirstName == FirstName && this.LastName == LastName;
             
        //}
        //public bool CheckProfile(string FirstName, string LastName,string email)
        //{
        //    return this.FirstName == FirstName && this.LastName == LastName
        //        && EmailAddress==email;
        // }
        public bool CheckProfile(string FirstName, string LastName, string email=null)
        {
            if(email != null)
            return this.FullName.FirstName == FirstName && this.FullName.LastName == LastName
                && EmailAddress == email;
            else
                return this.FullName.FirstName == FirstName && this.FullName.LastName == LastName;

        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am the passenger: "+FullName.FirstName);
        }


    }
}
