using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlights : Service<Flight>,IserviceFlight
    {
        public ServiceFlights(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Flight> SortFlights()
        {
            return GetMany().OrderBy(f => f.Destination);
        }
    }
}
