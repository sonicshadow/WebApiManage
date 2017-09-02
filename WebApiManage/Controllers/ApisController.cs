using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApiManage.Models;

namespace WebApiManage.Controllers
{
    public class ApisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Apis
        public ActionResult Index(int pid, string group)
        {
            var project = db.Projects.Include("Apis").FirstOrDefault(s => s.ID == pid);
            if (project == null)
            {
                return new HttpNotFoundResult();
            }
            ViewBag.Groups = project.Apis.GroupBy(s => s.Group).Select(s => s.Key).ToList();
            var apis = string.IsNullOrWhiteSpace(group) ? project.Apis : project.Apis.Where(s => s.Group == group);
            ViewBag.ProjectName = project.Name;
            return View(apis.ToList());
        }

        // GET: Apis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Api api = db.Apis.Find(id);
            if (api == null)
            {
                return HttpNotFound();
            }
            return View(api);
        }

        // GET: Apis/Create
        public ActionResult Create(int? pid)
        {
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", pid.HasValue ? pid.Value : 1);

            return View(new Api { Group = Request["group"] });
        }

        // POST: Apis/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,Name,Group,Url,Type,Parameters,Info")] Api api)
        {
            if (ModelState.IsValid)
            {
                db.Apis.Add(api);
                db.SaveChanges();
                string returnUrl = Request["ReturnUrl"];
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", new { pid = api.ProjectID });
            }

            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", api.ProjectID);
            return View(api);
        }

        // GET: Apis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Api api = db.Apis.Find(id);
            if (api == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", api.ProjectID);
            return View(api);
        }

        // POST: Apis/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,Name,Group,Url,Type,Parameters,Info")] Api api)
        {
            if (ModelState.IsValid)
            {
                db.Entry(api).State = EntityState.Modified;
                db.SaveChanges();
                string returnUrl = Request["ReturnUrl"];
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }
            }
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", api.ProjectID);
            return View(api);
        }

        // GET: Apis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Api api = db.Apis.Find(id);
            if (api == null)
            {
                return HttpNotFound();
            }
            return View(api);
        }

        // POST: Apis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Api api = db.Apis.Find(id);
            db.Apis.Remove(api);
            db.SaveChanges();
            return RedirectToAction("Index", new { PID = api.ProjectID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
