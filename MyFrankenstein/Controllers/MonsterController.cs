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
            if (file != null)                               // If file was specified, do error checks
            {
                var fileName = Path.GetFileName(file.FileName);
                monster.ImgName = fileName;
                monster.ImgType = Path.GetExtension(file.FileName);

                if (!ImageType(monster.ImgType)) {
                    ModelState.AddModelError("", "Specified file is not an image type; please try a PNG, GIF, or JPG file.");
                    return View (monster);
                }
                else if (file.ContentLength == 0) {
                    ModelState.AddModelError("", "Specified file is empty, sorry.");
                    return View (monster);
                }
                else if (file.ContentLength > 1 * 1024 *1024) {
                    ModelState.AddModelError("", "Specified file is too big; please keep it less than 1Mb.");
                    return View (monster);
                }
                else {
                    try {
                        var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                        monster.ImgUrl = path;          // Local Url, keep for deleting purposes
                        file.SaveAs(path);
                    }
                    catch {
                        ModelState.AddModelError("", "Image file upload failed.");
                        return View(monster);
                    }
                }
            }

            if (ModelState.IsValid)                             // default add record, w/ or w/o image
            {
                monster.Contributor = User.Identity.Name;       // add user name to the monster record
                db.Monsters.Add(monster);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unknown error creating record in Database.");
            return View(monster);
        }

        public static bool ImageType(string imgExt)             // my humble image ext checker (I saw much fancier on Google)
        {
            var allowedExtensions = new[] { ".png", ".gif", ".jpg", ".jpeg" };

            if (allowedExtensions.Contains(imgExt)) return true;
            else return false;
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
            if (file != null)                                // If file was specified, do error checks
            {
                var fileName = Path.GetFileName(file.FileName);

                if (fileName != monster.ImgName) {          // but only do checks if input name is different       
                    monster.ImgName = fileName;
                    monster.ImgType = Path.GetExtension(file.FileName);

                    if (!ImageType(monster.ImgType)) {
                        ModelState.AddModelError("", "Specified file is not an image type; please try a PNG, GIF, or JPG file.");
                        return View(monster);
                    }
                    else if (file.ContentLength == 0) {
                        ModelState.AddModelError("", "Specified file is empty, sorry.");
                        return View(monster);
                    }
                    else if (file.ContentLength > 1 * 1024 * 1024) {
                        ModelState.AddModelError("", "Specified file is too big; please keep it less than 1Mb.");
                        return View(monster);
                    }
                    else {
                        var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                        try {
                            file.SaveAs(path);
                        }
                        catch {
                            ModelState.AddModelError("", "Image file upload failed.");
                            return View(monster);
                        }

                        System.IO.File.Delete(monster.ImgUrl);          // Delete previous image file
                        monster.ImgUrl = path;                          // Set new file name for db
                    }
                }
            }

            if (ModelState.IsValid)                                 // Update the record
            {
                db.Entry(monster).State = EntityState.Modified; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unknown error saving to Database.");
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

            if (monster.ImgName != "")                          // Get rid of image file (if exists)
            {                                                    
                try {
                    System.IO.File.Delete(monster.ImgUrl);
                }
                catch {
                    //  need some error processing here, but doesn't matter too much 
                    //  record is gone, and user can't do much about deleting the file on server
                    //      (good case for putting the image in the db next time)
                }
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}