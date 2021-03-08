using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen.Services;
using Examen.Models;

namespace Examen.Controllers
{
    public class HomeController : Controller
    {
        #region Attributes        
        private readonly DbExamen _db;
        #endregion

        #region Builder
        public HomeController()
        {
            _db = new DbExamen();
        }
        #endregion

        public ActionResult Index()
        {
            ViewBag.lstCategories = _db.LstCategories();
            ViewBag.Project = new Project();
            return View();
        }

        [HttpPost]
        public JsonResult LstProjects()
        {
            List<Project> lstProjects = _db.LstProjects();
            return Json(new { data = lstProjects }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProject(Project Model)
        {
            if (ModelState.IsValid)
            {
                bool result = false;
                if (Model.ProjectID != 0)
                    result = _db.UpdateProject(Model);

                else
                    result = _db.AddProject(Model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditProject(int Id)
        {
            Project project = _db.GetProject(Id);
            ViewBag.lstCategories = _db.LstCategories();
            return PartialView("_FrmProject", project);
        }

        [HttpPost]        
        public JsonResult DeleteProject(int idProject)
        {
            bool result = _db.DeleteProject(idProject);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}