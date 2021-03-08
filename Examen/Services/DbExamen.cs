using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Examen.Models;
using System.Data.Entity;


namespace Examen.Services
{
    public class DbExamen
    {
        public List<Project> LstProjects()
        {
            List<Project> lstProjects;
            using (var db = new ExamenContext())
            {
                lstProjects = db.Projects.Include(x => x.Category).ToList();
            }
            return lstProjects;
        }

        public List<Category> LstCategories()
        {
            List<Category> lstCategories;
            using (var db = new ExamenContext())
            {
                lstCategories = db.Categories.ToList();
            }
            return lstCategories;
        }

        public bool AddProject(Project model)
        {
            bool res = false;
            try
            {
                using (var db = new ExamenContext())
                {

                    db.Projects.Add(model);
                    db.SaveChanges();
                    res = true;
                }
            }
            catch (Exception ex)
            {
                res = false;
                //log
            }
            return res;
        }

        public bool UpdateProject(Project model)
        {
            bool res = false;
            try
            {
                using (var db = new ExamenContext())
                {
                    Project projectRegistered = db.Projects.Where(x => x.ProjectID == model.ProjectID).FirstOrDefault();
                    if (projectRegistered != null)
                    {
                        projectRegistered.NameProject = model.NameProject;
                        projectRegistered.CategoryID = model.CategoryID;
                        res = (db.SaveChanges() > 0);

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }

        public Project GetProject(int idProject)
        {
            Project project;
            try
            {
                using (var db = new ExamenContext())
                {
                    project = db.Projects.Where(x => x.ProjectID == idProject).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                project = new Project();
                //Log
            }
            return project;
        }

        public bool DeleteProject(int idProject)
        {
            bool res = false;
            try
            {
                using(var db = new ExamenContext())
                {
                    Project projectRegistered = db.Projects.Where(x => x.ProjectID == idProject).FirstOrDefault();
                    if(projectRegistered != null)
                    {
                        db.Projects.Remove(projectRegistered);
                        res = (db.SaveChanges() > 0);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return res;
        }
    }
}