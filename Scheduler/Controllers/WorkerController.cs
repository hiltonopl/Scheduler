using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scheduler.Security;
using Scheduler.Models.ViewModel;
using Scheduler.Models.EntityManager;
using Scheduler.Models;
using Scheduler.Models.DB;
using System.Net;
using System.Web.Security;

namespace Scheduler.Controllers
{

    public class WorkerController : Controller
    {

        private SchedulerEntities db = new SchedulerEntities();
        //     private CreateWorkerViewModel wv = new CreateWorkerViewModel();

        private enum UserType
        {
            z,
            w,
            m,
            c,
            f,
            a
        };
        // GET: Job


        public ActionResult Index()
        {
            //     var teams = db.SYSUsers.ToList();

            //     /*
            //      * OPTION 1 : THE LONG WAY
            //      *
            //      * Description: Intended to show the process of creating the MultiSelectList.
            //      * Option 2 is much quicker.
            //      */

            //     //Initialize the empty list of SelecListItems
            //     List<SelectListItem> items = new List<SelectListItem>();

            //     // Loop over each team in our teams List...
            //     foreach (var team in teams)
            //     {
            //         // ... and instantiate a new SelectListItem for each one...
            //         var item = new SelectListItem
            //         {
            //             Value = team.SYSUserID.ToString(),
            //             Text = team.LoginName
            //         };
            //         // ... then add to our items List
            //         items.Add(item);
            //     };

            //     // Instantiate our MultiSelect list, adding in our items list and ordering by the Text field (i.e. Team name)
            //     MultiSelectList teamsList = new MultiSelectList(items.OrderBy(i => i.Text), "Value", "Text");

            //     /*
            //      * OPTION 2: THE SHORT WAY
            //      *
            //      * Description: Directly instantiates the MultiSelectList without all of the preamble.
            //      * Uncomment the below line and comment out the above instantiation of teamsList to test Option 2.
            //      */

            //     //MultiSelectList teamsList = new MultiSelectList(db.Teams.ToList().OrderBy(i => i.Name), "TeamId", "Name");

            //     // Instantiate our CreatePlayerViewModel and set the Teams property to our teamslist MultiSelectList...
            //     //EditWorkerViewModel model = new EditWorkerViewModel();
            ////     IEnumerable<Scheduler.Models.Worker> model =(IEnumerable <Scheduler.Models.Worker>) new  Worker { Jobs = (ICollection<Job>)teamsList };

            // ...and return it in our View.



            var result = from s in db.SYSUsers
                         join p in db.SYSUserProfiles on s.SYSUserID equals p.SYSUserID
                         join t in db.UserTypes on p.UserTypeID equals t.ID
                         where t.ID.Equals((int)UserType.w)
                         select new Worker
                         {
                             ID = s.SYSUserID,                           //Guid.Parse("1"),    //s.SYSUserID.ToString()
                             FirstName = p.FirstName,
                             LastName = p.LastName,
                             Mobile = p.Mobile,
                             Email = p.Email
                         };
            IEnumerable<Worker> model = (IEnumerable<Worker>)result;
            return View(model);
            //    return View(db.SYSUsers.ToList().OrderBy(i => i.LoginName));
            // return View(model);
        }


        [AuthorizeRoles("Admin")]
        public ActionResult AssignJobToBlock(int userID, string loginName, string password,
string firstName, string lastName, string gender, int roleID = 0)
        {
            UserProfileView UPV = new UserProfileView();
            UPV.SYSUserID = userID;
            UPV.LoginName = loginName;
            UPV.Password = password;
            UPV.FirstName = firstName;
            UPV.LastName = lastName;
            UPV.Gender = gender;

            if (roleID > 0)
                UPV.LOOKUPRoleID = roleID;

            UserManager UM = new UserManager();
            UM.UpdateUserAccount(UPV);

            return Json(new { success = true });
        }

        [AuthorizeRoles("Admin")]
        public ActionResult AssignWorkerToJobBlock(int userID, string loginName, string password,
string firstName, string lastName, string gender, int roleID = 0)
        {
            UserProfileView UPV = new UserProfileView();
            UPV.SYSUserID = userID;
            UPV.LoginName = loginName;
            UPV.Password = password;
            UPV.FirstName = firstName;
            UPV.LastName = lastName;
            UPV.Gender = gender;

            if (roleID > 0)
                UPV.LOOKUPRoleID = roleID;

            UserManager UM = new UserManager();
            UM.UpdateUserAccount(UPV);

            return Json(new { success = true });
        }


        [AuthorizeRoles("Admin")]
        public ActionResult JobStart(int userID)
        {
            UserManager UM = new UserManager();
            UM.DeleteUser(userID);
            return Json(new { success = true });
        }


        [AuthorizeRoles("Admin")]
        public ActionResult DeleteJob(int userID)
        {
            UserManager UM = new UserManager();
            UM.DeleteUser(userID);
            return Json(new { success = true });
        }



        // GET: Jobs/
        public ActionResult Create()
        {
            JobModelView JMV = new JobModelView();
            JobManager jm = new JobManager();

            JMV.JobCustomer = new JobCustomer();

            JMV.JobCustomer.Customer = jm.GetAllCustomers();
            JMV.JobType = jm.GetAllJobTypes();
            return View(JMV);
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobModelView model)
        {
            if (ModelState.IsValid)
            {

                var job = new JOB()
                {

                    ID = Guid.NewGuid(),
                    Description = model.Description,
                    Cost = model.Cost,
                    JobTypeID = model.JobTypeID,
                    CustomerID = model.CustomerID,
                    CreationDate = DateTime.Now,
                    CreatedBy = User.Identity.Name,
                    LastModifiedBy = User.Identity.Name
                };

                try
                {
                    db.JOBs.Add(job);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Jobs", "Index"));
                }

                return RedirectToAction("Index");
            }
            // Something failed, return
            return View(model);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JOB job = db.JOBs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(new EditJobViewModel { JobId = job.ID.ToString(), Name = job.Description });
        }


       

        // GET: Players/Edit/5
        public ActionResult Manage(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Retrieve Worker from db and perform null check
            //Worker worker = db.Workers.Find(id);
            var result = from s in db.SYSUsers
                         join p in db.SYSUserProfiles on s.SYSUserID equals p.SYSUserID
                         join t in db.UserTypes on p.UserTypeID equals t.ID
                         where t.ID.Equals((int)UserType.w)
                         select new Worker
                         {
                             ID = s.SYSUserID,                           //Guid.Parse("1"),    //s.SYSUserID.ToString()
                             FirstName = p.FirstName,
                             LastName = p.LastName,
                             Mobile = p.Mobile,
                             Email = p.Email
                         };

            List<Worker> wlist = result.ToList();
            Worker worker = wlist[0];

            if (worker == null)
            {
                return HttpNotFound();
            }
            worker.WorkerId = (Guid)id;
            // Instantiate new instance of EditWorkerViewModel
            EditWorkerViewModel model = new EditWorkerViewModel
            {
                // Can set the Worker name and Id filds of the ViewModel
                WorkerId = worker.WorkerId.ToString(),
                Name = worker.FirstName
            };



            // Retrieve list of worker jobs from db in order to find the teams that the Worker belongs to
            //  var workerJobs = db.Jobs.Where(i => i.Workers.Any(j => j.WorkerId.Equals(worker.WorkerId))).ToList();
            var qworkerJobs = from s in db.SYSUsers
                              join p in db.SYSUserProfiles on s.SYSUserID equals p.SYSUserID
                              join t in db.UserTypes on p.UserTypeID equals t.ID
                              join j in db.JOBs on s.SYSUserID equals j.WorkerID
                              //where j.WorkerID.Equals(1)
                              select new Job
                              {
                                  JobId = Guid.NewGuid()
                              };
            var jlist = qworkerJobs.ToList();
            List<Job> workerJobs = jlist;

            //var WorkerJobs = db.Jobs.Where(t => t.Workers.Contains(new Worker { WorkerId = worker.WorkerId })).ToList();

            // Check that workerJobs is not empty
            if (workerJobs != null)
            {
                // Initialize the array to number of teams in workerTeams
                string[] workerJobsIds = new string[workerJobs.Count()];

                // Then, set the value of platerTeams.Count so the for loop doesn't need to work it out every iteration
                int length = workerJobs.Count();

                // Now loop over each of the workerJobs and store the Id in the workerJobsId array
                for (int i = 0; i < length; i++)
                {
                    // Note that we employ the ToString() method to convert the Guid to the string
                    // workerJobs[i].JobId = new Guid(string.Format("00000000-0000-0000-0000-00{0:0000000000}", workerJobs[i].ID));       //Guid.Parse(workerJobs[i].ID.ToString());

                    workerJobsIds[i] = workerJobs[i].JobId.ToString();
                }

                // Instantiate the MultiSelectList, plugging in our playerTeamIds array
                MultiSelectList jobsList = new MultiSelectList(db.JOBs.ToList().OrderBy(i => i.Description), "ID", "Description", workerJobsIds);

                // Now add the teamsList to the Teams property of our EditPlayerViewModel (model)
                model.Jobs = jobsList;
                model.JobIds = workerJobsIds.ToList();
                // Return the ViewModel
                return View(model);
            }
            else
            {
                // Else instantiate the teamsList without any pre-selected values
                MultiSelectList jobsList = new MultiSelectList(db.JOBs.ToList().OrderBy(i => i.Description), "JobId", "Name");

                // Set the Teams property of the EditWorkerViewModel with the teamsList
                model.Jobs = jobsList;

                // Return the ViewModel
                return View(model);
            }


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(EditJobViewModel model)
        {

            if (ModelState.IsValid)
            {
                // Instantiate our new player with only the Id and Name properties
                Job job = new Job
                {
                    JobId = Guid.NewGuid(),
                    Name = model.Name
                };

                if (model.WorkerIds != null)
                {
                    foreach (var id in model.WorkerIds)
                    {
                        // Convert the id to a Guid from a string
                        var workerId = Guid.Parse(id);
                        // Retrieve team from database...
                        var worker = db.SYSUsers.Find(workerId);
                        // ... and add it to the player's Team collection
                        try
                        {
                            //  worker.Jobs.Add(job);
                        }
                        catch (Exception ex)
                        {
                            return View("Error", new HandleErrorInfo(ex, "Jobs", "Index"));
                        }
                    }
                }
                // Add new Player to db & save changes
                try
                {
                    //   db.JOBs.Add(job);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return View("Error", new HandleErrorInfo(ex, "Jobs", "Index"));
                }

                // If successful, return
                return RedirectToAction("Details", new { id = job.JobId });
            }
            else
            {
                ModelState.AddModelError("", "Something failed.");
                return View(model);
            }
        }

        [Authorize]
        public ActionResult EditJob()
        {
            string loginName = User.Identity.Name;
            UserManager UM = new UserManager();
            UserProfileView UPV = UM.GetUserProfile(UM.GetUserID(loginName));
            return View(UPV);
        }


        [HttpPost]
        [Authorize]
        public ActionResult EditJob(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }


        [HttpPost]
        [Authorize]
        public ActionResult UpdateBlockDisplay(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }


        //  Create new block
        public ActionResult CreateNewBlock(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }
        //      CreateBlocksForTheWeek
        public ActionResult CreateBlocksForTheWeek(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }
        //       MakeBlockUnassignable

        public ActionResult MakeBlockUnassignable(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }
        //       Modify block size

        public ActionResult ModifyBlockSize(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        //       Select Job
        public ActionResult SelectJob(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        //      Select worker
        public ActionResult SelectWorker(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        //       Select Tool
        public ActionResult SelectTool(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }
        //        DragAndDropJobtoBlock
        public ActionResult DragAndDropJobtoBlock(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }


        //       DragAndDropWorkerToJob
        public ActionResult DragAndDropWorkerToJob(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        //       DragAndDropToolToJob
        public ActionResult DragAndDropToolToJob(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        //       UnassignJobtoBlock
        public ActionResult UnassignJobtoBlock(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }


        //     UnassignWorkertoJob
        public ActionResult UnassignWorkertoJob(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        //      UnassignToolToJob
        public ActionResult UnassignToolToJob(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        //     EnterActualJobStart
        public ActionResult EnterActualJobStart(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        //       EnterActualJobEnd
        public ActionResult EnterActualJobEnd(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }


        //        AddAdditionalJobWorker
        public ActionResult AddAdditionalJobWorker(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        //       AddAdditionialJobTool
        public ActionResult AddAdditionialJobTool(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        //     AddMiscellaneousJobCost
        public ActionResult AddMiscellaneousJobCost(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }

        //       AddAdditionalJobLongDistanceCall
        public ActionResult AddAdditionalJobLongDistanceCall(UserProfileView profile)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                UM.UpdateUserAccount(profile);

                ViewBag.Status = "Update Sucessful!";
            }
            return View(profile);
        }








    }
}







