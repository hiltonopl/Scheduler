using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scheduler.Models.EntityManager;

namespace Scheduler.Controllers
{
    public class _a957632154Controller : Controller
    {
        // GET: _a957632154
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult AssignWorker(JobWorker jw)
        {
            //JobWorker jwork = new JobWorker
            //{
            //    JobId = "asdf",
            //    WorkerId = "fdaf"
            //};
            //  JobManager...;

            JobManager JM = new JobManager();
            if (ModelState.IsValid)
            {
                JM.AddJobWorker(jw);
                return null;//RedirectToAction("Welcome", "Home");
            }
            else
            { ModelState.AddModelError("", "The password provided is incorrect.");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AssignBlock(JobBlock jb)
        {
            //JobWorker jwork = new JobWorker
            //{
            //    JobId = "asdf",
            //    WorkerId = "fdaf"
            //};
            //  JobManager...;

            JobManager JM = new JobManager();
            if (ModelState.IsValid)
            {
                JM.AddJobBlock(jb);
                return null;//RedirectToAction("Welcome", "Home");
            }
            else
            {
                ModelState.AddModelError("", "The password provided is incorrect.");
            }

            return View();
        }


        [HttpPost]
        public ActionResult AssignTool(JobTool jw)
        {

            JobManager JM = new JobManager();
            if (ModelState.IsValid)
            {
                JM.AddJobTool(jw);
                return null; //RedirectToAction("Welcome", "Home");
            }
            else
            {
                ModelState.AddModelError("", "The password provided is incorrect.");
            }

            return View();
        }

        [HttpPost]
        public ActionResult DeleteAssignment(Assignment ass)
        {
     
            JobManager JM = new JobManager();
            if (ModelState.IsValid)
            {
                JM.DeleteAssignment(ass.JobId,ass.AssignmentId,ass.AssignmentType);
                return null; //RedirectToAction("Welcome", "Home");
            }
            else
            {
                ModelState.AddModelError("", "The password provided is incorrect.");
            }

            return View();
        }
    }
}