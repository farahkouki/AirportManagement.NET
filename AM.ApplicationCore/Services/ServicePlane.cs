using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeletePlanes()
        {
            //foreach (Plane p in GetMany(p => (DateTime.Now - p.ManufactureDate).TotalDays > 3650))
            //    Delete(p);


            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays > 3650);

        }

        public IEnumerable<Flight> GetFlights(int n)
        {

            return GetMany().OrderBy(p => p.PlaneId).Take(n)
                .SelectMany(p => p.Flights).OrderBy(p => p.FlightDate);

            //var req = (from f in GetMany()
            //          orderby f.PlaneId descending
            //          select f);
            //return req;


        }

        public IEnumerable<Passenger> GetPassenger(Plane p)
        {
           return p.Flights.SelectMany(f=>f.Tickets).Select(t=>t.Passenger);
        }

        public bool IsAvailablePlane(Flight f, int n)
        {
            return f.Plane.Capacity - f.Tickets.Count > n;
        }
    }
}
