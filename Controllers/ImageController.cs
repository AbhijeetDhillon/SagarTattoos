using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SagarTattoos.Models;
using System.IO;


namespace SagarTattoos.Controllers
{
    public class ImageController : Controller
    {
      

        //
        // GET: /Image/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Image/Details/5

     

        //
        // GET: /Image/Create

        public ActionResult Create()
        {
            
            return View();
        }

        //
        // POST: /Image/Create

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file )
        {

            
            if (file != null )
                try
                {
                    Portfolio obj = new Portfolio();
                    obj.ImageName=file.FileName;
                    String path = Path.Combine(Server.MapPath("~/Portfolio"),
                                               Path.GetFileName(file.FileName));
                    
                    file.SaveAs(path);

                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View(); 
            //tbl.Image = 

            //if (ModelState.IsValid)
            //{

            //    db.tbl_Portfolio.Add(tbl);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(tbl);
        }

       

        // GET: /Image/Delete/5
[HttpGet]
        public ActionResult Delete(Portfolio model)
        {


            var model1 = new Portfolio();
            // ...
            return View(model1);
        }

        //
        // POST: /Image/Delete/5

        [HttpPost]
public ActionResult DeleteFile(string photoFileName)
        {            
             ViewBag.deleteSuccess = "false";
             var photoName = "";
             photoName = photoFileName;

             var fullPath = Server.MapPath("~/Portfolio/" + photoName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                ViewBag.deleteSuccess = "true";
            }
            return RedirectToAction("Delete");
        }

        protected override void Dispose(bool disposing)
        {
           
            base.Dispose(disposing);
        }
    }
}