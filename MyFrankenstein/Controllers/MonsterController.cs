using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFrankenstein.Models;
using System.IO;

namespace MyFrankenstein.Controllers
{ 
    public class MonsterController : Controller
    {
        private MonsterDBContext db = new MonsterDBContext();

        //
        // GET: /Monster/

        public ViewResult Index()
        {
            return View(db.Monsters.ToList());
        }

        //
        // GET: /Monster/Details/5

        public ViewResult Details(int id)
        {
            Monster monster = db.Monsters.Find(id);
            return View(monster);
        }

        //
        // GET: /Monster/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Monster/Create

        [HttpPost]
        public ActionResult Create(Monster monster, HttpPostedFileBase file)
        {
                try
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        monster.ImgName = fileName;
                        monster.ImgType = Path.GetExtension(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                        monster.ImgUrl = path;          // Local Url, what's the point to save ?

                        file.SaveAs(path);
                    }
                    ViewBag.Message = "Upload successful";
  //                  return RedirectToAction("Create");
                }
                catch
                {
                    ViewBag.Message = "Image file upload failed."; 
                    return View(monster);
                }
            
            if (ModelState.IsValid)
            {
                monster.Contributor = User.Identity.Name;       // add user name to the monster record
                db.Monsters.Add(monster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monster);
        }
        
        //
        // GET: /Monster/Edit/5
 
        public ActionResult Edit(int id)
        {
            Monster monster = db.Monsters.Find(id);
            return View(monster);
        }

        //
        // POST: /Monster/Edit/5

        [HttpPost]
        public ActionResult Edit(Monster monster, HttpPostedFileBase file)
        {
            try
            {   
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    monster.ImgName = fileName;
                    monster.ImgType = Path.GetExtension(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    monster.ImgUrl = path;          // Local Url, what's the point to save in DB ?

                    file.SaveAs(path);
                }
                ViewBag.Message = "Upload successful";
                //                  return RedirectToAction("Edit");
            }
            catch
            {
                ViewBag.Message = "Image file upload failed.";
                return View(monster);
            }

            if (ModelState.IsValid)                                 // Update the record
            {
                db.Entry(monster).State = EntityState.Modified; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monster);
        }

        //
        // GET: /Monster/Delete/5
 
        public ActionResult Delete(int id)
        {
            Monster monster = db.Monsters.Find(id);
            return View(monster);
        }

        //
        // POST: /Monster/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Monster monster = db.Monsters.Find(id);
            db.Monsters.Remove(monster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}