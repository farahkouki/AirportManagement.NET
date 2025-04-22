using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.Web.Controllers
{
    public class FlightController : Controller
    {

       IserviceFlight sf;
        IServicePlane pf;
        public FlightController(IserviceFlight sf , IServicePlane pf)
        {
            this.sf = sf;
            this.pf = pf;
        }
       

        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            if(dateDepart == null)
                return View(sf.GetMany());
            else
                return View(sf.GetMany(f => f.FlightDate.Equals(dateDepart)));
        }
        public ActionResult Sort()
        { 
            return View(sf.SortFlights());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View(sf.GetById(id));
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.lsPlanes = new SelectList(pf.GetMany(), "PlaneId", "Information");
            
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight collection,IFormFile imgLogo)
        {
            try
            {
                if(imgLogo == null)
                {
                    //récuperer le nom de fichier dans la propriéte AirlineLogo
                    collection.AirlineLogo = imgLogo.FileName;

                    //sauvegarder e fichier dans le dossier uploads
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "uploads", imgLogo.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    imgLogo.CopyTo(stream);
                }
                sf.Add(collection);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
           ViewBag.lsPlanes = new SelectList(pf.GetMany(), "PlaneId", "Information");
            return View(sf.GetById(id));
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight collection)
        {
            try
            {
                sf.Update(collection);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(sf.GetById(id));
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                sf.Delete(sf.GetById(id));
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
