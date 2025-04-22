// See https://aka.ms/new-console-template for more information


using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

Console.WriteLine("Hello, World!");

Plane plane = new Plane();
plane.Capacity = 100;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Airbus;

//Plane plane2 = new Plane(200,new DateTime(2024,12,11,12,12,00),PlaneType.Boeing);
//Initialiseur d'objets
Plane plane2 =  new Plane{Capacity=200,PlaneType=PlaneType.Boeing,
    ManufactureDate= new DateTime(2024, 12, 11, 12, 12, 00) };
Console.WriteLine(plane);
Passenger p1 = new Passenger { FullName=new FullName
{
    FirstName = "amina",
    LastName = "aoun"
},
                               EmailAddress="amina.aoun@esprit.tn"};
Console.WriteLine("*****CheckProfile********");
Console.WriteLine(p1.CheckProfile("Amina", "Aoun"));
Console.WriteLine(p1.CheckProfile("amina", "aoun","abc"));
Staff s1 = new Staff { FullName = new FullName { FirstName = "Staff1" } };
Traveller t1 = new Traveller {
    FullName = new FullName { FirstName = "Traveller1" } };
Console.WriteLine("*****PassengerType********");
p1.PassengerType();
s1.PassengerType();
t1.PassengerType();
FlightMethods fm= new FlightMethods();
fm.Flights = TestData.listFlights;
Console.WriteLine("*****GetFlightDates********");
foreach(DateTime d in fm.GetFlightDates("Paris"))
    Console.WriteLine(d);
Console.WriteLine("*****GetFlights********");
fm.GetFlights("Destination", "Madrid");
fm.GetFlights("EstimatedDuration", "100");
Console.WriteLine("*******ShowFlightDetails*******");
fm.ShowFlightDetails(TestData.BoingPlane);
Console.WriteLine("*****OrderedDurationFlights*****");
foreach(Flight f in fm.OrderedDurationFlights())
    Console.WriteLine(f);
Console.WriteLine("*********DurationAverage*********");
Console.WriteLine(fm.DurationAverage("Paris"));
Console.WriteLine("appel avec delegate");
Console.WriteLine(fm.DurationAverageDel("Paris"));
Console.WriteLine("*************ProgrammedFlightNumber******");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2021,12,31)));
Console.WriteLine("*************SeniorTravellers******");
//foreach(Traveller t in fm.SeniorTravellers(TestData.flight1))
//    Console.WriteLine(t);
Console.WriteLine("********DestinationGroupedFlights*******");
fm.DestinationGroupedFlights();
Console.WriteLine("*******UpperFullName**********");
p1.UpperFullName();
Console.WriteLine(p1.FullName.FirstName+" "+p1.FullName.LastName);
AMContext ctx= new AMContext();
////Insert 2 planes
//Plane plane1 = new Plane { Capacity = 100, ManufactureDate=new DateTime(2024,11,08),PlaneType=PlaneType.Airbus };
//Flight flight1 = new Flight { Destination="Paris",Departure="Tunis",EstimatedDuration=100,EffectiveArrival=new DateTime(2024,11,08,10,10,00),FlightDate = new DateTime(2024,11,08,12,10,00),AirlineLogo="logo",Plane=plane1};
//ctx.Planes.Add(plane1);
//ctx.Flights.Add(flight1);
//ctx.SaveChanges();


//ctx.Planes.Add(TestData.BoingPlane);
//ctx.Planes.Add(TestData.Airbusplane);

////Inseret 2 flights
//ctx.Flights.Add(TestData.flight1);
//ctx.Flights.Add(TestData.flight2);
//persistance
//ctx.SaveChanges();
Console.WriteLine("Ajout avec succès");
//Afficher le contenu de la table flights
foreach (Flight f in ctx.Flights)
    Console.WriteLine("destination: " + f.Destination + "Flight date :" + f.FlightDate + "capacity :"+f.Plane.Capacity);
AMContext ctx2= new AMContext();
UnitOfWork uow=new UnitOfWork(ctx2); 
ServiceFlights sf =new ServiceFlights(uow);
ServicePlane sp=new ServicePlane(uow);

sp.Add(plane2);
sp.Commit();
foreach (Flight f in sf.GetMany())
    Console.WriteLine("destination: " + f.Destination + "Flight date :" + f.FlightDate + "capacity :" + f.Plane.Capacity);

