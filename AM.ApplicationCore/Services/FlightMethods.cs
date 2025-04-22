using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Plane = AM.ApplicationCore.Domain.Plane;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; }=new List<Flight>(){ };
        public Action<Plane> FlightDetailsDel;
        public Func<string,double> DurationAverageDel;
        public FlightMethods()
        {
            FlightDetailsDel = pl =>
            {
                var req = from f in Flights
                          where f.Plane == pl
                          select new { f.Destination, f.FlightDate };
                foreach (var f in req)
                    Console.WriteLine(f);
            }
                ;
            DurationAverageDel = dest => {
                var req = from f in Flights
                          where f.Destination == dest
                          select f.EstimatedDuration;
                return req.Average();
            };
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = from f in Flights
                      group f by f.Destination;
            var req2 = Flights.GroupBy(f => f.Destination);

            foreach (var g in req)
            {
                Console.WriteLine("Destination: "+g.Key);
                foreach(Flight f in g)
                    Console.WriteLine(f);
            }
            return req;
        }

        public double DurationAverage(string destination)
        {
            var req = from f in Flights
                      where f.Destination == destination
                      select f.EstimatedDuration;
            var req2 = Flights.Where(f => f.Destination == destination)
                               .Average(f=>f.EstimatedDuration);
            return req.Average();
        }

        public IEnumerable<DateTime> GetFlightDates(string dest)
        {
            IEnumerable<DateTime> result = new List<DateTime>();
            //for (int i = 0; i < Flights.Count; i++)
            //{
            //    if(Flights[i].Destination == dest)
            //        result.Add(Flights[i].FlightDate);

            //}
            //foreach (Flight f in Flights)
            //    if (f.Destination == dest)
            //        result.Add(f.FlightDate);
            result = from f in Flights
                     where f.Destination == dest
                     select f.FlightDate;
            result = Flights.Where(f => f.Destination == dest)
                            .Select(f => f.FlightDate);
            return result;
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch(filterType)
            {
                case "Destination":
                    foreach(Flight f in Flights)
                        if(f.Destination == filterValue)
                            Console.WriteLine(f);
                break;
                case "Departure":
                    foreach (Flight f in Flights)
                        if (f.Departure == filterValue)
                            Console.WriteLine(f);
                    break;
                case "EstimatedDuration":
                    foreach (Flight f in Flights)
                        if (f.EstimatedDuration == Int32.Parse(filterValue))
                            Console.WriteLine(f);
                    break;
            }
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
           var req = from f in Flights
                     orderby f.EstimatedDuration descending
                     select f;
            var req2 = Flights.OrderByDescending(f => f.EstimatedDuration);
            return req;
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var req = from f in Flights
                      where DateTime.Compare(startDate, f.FlightDate)<0
                            && (f.FlightDate-startDate).TotalDays<8
                      select f;
            var req2 = Flights.Where(f => DateTime.Compare(startDate, f.FlightDate) < 0
                            && (f.FlightDate - startDate).TotalDays < 8);
            return req.Count();
         
        }

        //public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        //{
        //    var req = from t in flight.Passengers.OfType<Traveller>()
        //              orderby t.BirthDate
        //              select t;
        //    var req2 = flight.Passengers.OfType<Traveller>().OrderBy(t => t.BirthDate);
        //    return req.Take(3);
        //    //Skip(3) ignorer les 3 premiers
        //}

        public void ShowFlightDetails(Plane plane)
        {
           
           var req = from f in Flights
                               where f.Plane == plane
                               select new { f.Destination, f.FlightDate };
            var req2 = Flights.Where(f => f.Plane == plane)
                            .Select(f => new { f.Destination, f.FlightDate });
            foreach(var f in req)
                Console.WriteLine(f);
        }
    }
}
