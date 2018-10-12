using System;
using System.Linq;
using Scheduler.Models.DB;
using Scheduler.Models.ViewModel;
using System.Collections.Generic;
using System.Web;

namespace Scheduler.Models.EntityManager
{
    public class JobManager
    {
        public void AddCustomer(CustomerModelView user)
        {

            using (SchedulerEntities db = new SchedulerEntities())
            {

                CUSTOMER CU = new CUSTOMER();
                      
                CU.CreatedBy = HttpContext.Current.User.Identity.Name;
                CU.LastModifiedBy = HttpContext.Current.User.Identity.Name;
                CU.CreationDate = DateTime.Now;

                CU.ID = Guid.NewGuid(); 
                CU.Firstname = user.Firstname;
                CU.Lastname = user.Lastname;
                CU.Address = user.Address;
                CU.Email = user.Email;
                CU.Mobile = user.Mobile;
                CU.Notes = user.Notes;
                db.CUSTOMERs.Add(CU);
                db.SaveChanges();
                 
            }
        }

        public void AddJobWorker(JobWorker jw)
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                JOBWORKER JW = new JOBWORKER();
                JW.CreatedBy = HttpContext.Current.User.Identity.Name;
                JW.LastModifiedBy = HttpContext.Current.User.Identity.Name;
                JW.CreationDate = DateTime.Now;
                            
                JW.WorkerId = jw.WorkerId;
                JW.JobId = jw.JobId;
              
                db.JOBWORKERs.Add(JW);
                db.SaveChanges();
                
            }

        }


        public void AddJobBlock(JobBlock jw)
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {

                var TUR = db.JOBBLOCKs.Where(t => t.JobId == jw.JobId);
                if (TUR.Any())
                {
                    db.JOBBLOCKs.Remove(TUR.FirstOrDefault());
                    db.SaveChanges();
                }




                JOBBLOCK JW = new JOBBLOCK();
                JW.CreatedBy = HttpContext.Current.User.Identity.Name;
                JW.LastModifiedBy = HttpContext.Current.User.Identity.Name;
                JW.CreationDate = DateTime.Now;

                JW.Date = jw.Date;
                JW.JobId = jw.JobId;
                JW.Time = jw.TimeSlot;
                JW.BlockId = Guid.NewGuid().ToString();
                db.JOBBLOCKs.Add(JW);
                try { 
                db.SaveChanges();
                }
                catch
                {

                }
            }

        }

        public void AddJobTool(JobTool jt)
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {

                JOBTOOL JT = new JOBTOOL();
                JT.CreatedBy = HttpContext.Current.User.Identity.Name;
                JT.LastModifiedBy = HttpContext.Current.User.Identity.Name;
                JT.CreationDate = DateTime.Now;
                JT.ToolId = jt.ToolId;
                JT.JobId = jt.JobId;

                db.JOBTOOLs.Add(JT);
                db.SaveChanges();
            }
        }

        public void AddJobType(JobTypeModelView jobtype)
        {

            using (SchedulerEntities db = new SchedulerEntities())
            {

                JOBTYPE JT = new JOBTYPE();

                JT.CreatedBy = HttpContext.Current.User.Identity.Name;
                JT.LastModifiedBy = HttpContext.Current.User.Identity.Name;
                JT.CreationDate = DateTime.Now;

                JT.ID = Guid.NewGuid();
                JT.Duration = jobtype.Duration;
                JT.Unit = jobtype.Unit;
                JT.Rate = jobtype.Rate;
                JT.SkillRequired = jobtype.SkillRequired;
                JT.WorkersRequired = jobtype.WorkersRequired;
                JT.Tools = jobtype.Tools;
                JT.ToolCost = jobtype.ToolsCost;
                JT.FacilitiesRequired = jobtype.FacilitiesRequired;
                JT.FacilitiesCost = jobtype.FacilitiesCost;
                JT.Description = jobtype.Description;
                JT.JobPrice = jobtype.JobPrice;

                db.JOBTYPEs.Add(JT);
                db.SaveChanges();

            }
        }

      
        public void AddJobMarketer(UserSignUpView user)
        {

            using (SchedulerEntities db = new SchedulerEntities())
            {

                SYSUser SU = new SYSUser();
                SU.LoginName = user.LoginName;
                SU.PasswordEncryptedText = user.Password;
                SU.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SU.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1; ;
                SU.RowCreatedDateTime = DateTime.Now;
                SU.RowModifiedDateTime = DateTime.Now;
                db.SYSUsers.Add(SU);
                db.SaveChanges();

            }
        }

        public void AddJobTool(UserSignUpView user)
        {

            using (SchedulerEntities db = new SchedulerEntities())
            {

                SYSUser SU = new SYSUser();
                SU.LoginName = user.LoginName;
                SU.PasswordEncryptedText = user.Password;
                SU.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SU.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1; ;
                SU.RowCreatedDateTime = DateTime.Now;
                SU.RowModifiedDateTime = DateTime.Now;
                db.SYSUsers.Add(SU);
                db.SaveChanges();

            }
        }

        public void AddJobWorker(UserSignUpView user)
        {

            using (SchedulerEntities db = new SchedulerEntities())
            {

                SYSUser SU = new SYSUser();
                SU.LoginName = user.LoginName;
                SU.PasswordEncryptedText = user.Password;
                SU.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SU.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1; ;
                SU.RowCreatedDateTime = DateTime.Now;
                SU.RowModifiedDateTime = DateTime.Now;
                db.SYSUsers.Add(SU);

                db.SaveChanges();

            }
        }
        public void AddJob(JobModelView user)
        {

            using (SchedulerEntities db = new SchedulerEntities())
            {

                JOB SU = new JOB();
                SU.ID = user.ID;
                SU.JobTypeID = user.JobTypeID;
                SU.CreatedBy = HttpContext.Current.User.Identity.Name;
                SU.LastModifiedBy = HttpContext.Current.User.Identity.Name; 
                SU.CreationDate = DateTime.Now;
                SU.Description = user.Description;
                SU.CustomerID = user.CustomerID;
                SU.Cost = user.Cost;
        
                db.SaveChanges();
        
            }
        }
        public bool IsLoginNameExist(string loginName)
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                return db.SYSUsers.Where(o => o.LoginName.Equals(loginName)).Any();
            }
        }


        public string GetUserPassword(string loginName)
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                var user = db.SYSUsers.Where(o => o.LoginName.ToLower().Equals(loginName));
                if (user.Any())
                    return user.FirstOrDefault().PasswordEncryptedText;
                else
                    return string.Empty;
            }
        }


        public bool IsUserInRole(string loginName, string roleName)
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                SYSUser SU = db.SYSUsers.Where(o => o.LoginName.ToLower().Equals(loginName))?.FirstOrDefault();
                if (SU != null)
                {
                    var roles = from q in db.SYSUserRoles
                                join r in db.LOOKUPRoles on q.LOOKUPRoleID equals r.LOOKUPRoleID
                                where r.RoleName.Equals(roleName) && q.SYSUserID.Equals(SU.SYSUserID)
                                select r.RoleName;

                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }

                return false;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                var customers = db.CUSTOMERs.Select(o => new Customer
                {
                    Text = o.Firstname,
                    Value = o.ID
                }).ToList();

                return customers;
            }
        }


        public List<JobType> GetJobTypeInfo()
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                var jobtypes = from w in db.JOBs
                               join o in db.JOBTYPEs on w.JobTypeID equals o.ID
                               select new JobType
                               {
                                   Text = o.Description,
                                   Value = w.ID,
                                   Rate = (double)o.Rate,
                                   Duration = (int)o.Duration,
                                   Unit = o.Unit,
                                   SkillsRequired = o.SkillRequired,
                                   WorkersRequired = (int)o.WorkersRequired,
                                   Tools = o.Tools,
                                   FacilitiesCost = (double)o.FacilitiesCost,
                                   ToolsCost = (double)o.ToolCost,
                                   FacilitiesRequired = o.FacilitiesRequired,
                                   JobPrice = (double)o.JobPrice
                               };

                return jobtypes.ToList();
            }
        }


        public int GetUserID(string loginName)
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                var user = db.SYSUsers.Where(o => o.LoginName.Equals(loginName));
                if (user.Any()) return user.FirstOrDefault().SYSUserID;
            }
            return 0;
        }

        public List<UserProfileView> GetAllUserProfiles()
        {
            List<UserProfileView> profiles = new List<UserProfileView>();

            using (SchedulerEntities db = new SchedulerEntities())
            {
                UserProfileView UPV;
                var users = db.SYSUsers.ToList();

                foreach (SYSUser u in db.SYSUsers)
                {
                    UPV = new UserProfileView();
                    UPV.SYSUserID = u.SYSUserID;
                    UPV.LoginName = u.LoginName;
                    UPV.Password = u.PasswordEncryptedText;

                    var SUP = db.SYSUserProfiles.Find(u.SYSUserID);
                    if (SUP != null)
                    {
                        UPV.FirstName = SUP.FirstName;
                        UPV.LastName = SUP.LastName;
                        UPV.Gender = SUP.Gender;
                    }

                    var SUR = db.SYSUserRoles.Where(o => o.SYSUserID.Equals(u.SYSUserID));
                    if (SUR.Any())
                    {
                        var userRole = SUR.FirstOrDefault();
                        UPV.LOOKUPRoleID = userRole.LOOKUPRoleID;
                        UPV.RoleName = userRole.LOOKUPRole.RoleName;
                        UPV.IsRoleActive = userRole.IsActive;
                    }

                    profiles.Add(UPV);
                }
            }

            return profiles;
        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                var paymenttypes = db.PAYMENTTYPEs.Select(o => new PaymentType
                {
                    Text = o.Description,
                    Value = o.ID.ToString()
                }).ToList();

                return paymenttypes;
            }
        }

        public List<JobType> GetAllJobTypes()
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                var jobtypes = db.JOBTYPEs.Select(o => new JobType
                {
                    Text = o.Description,
                    Value = o.ID
                }).ToList();

                return jobtypes;
            }
        }


        public List<PaymentMethod> GetAllPaymentMethods()
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                var paymentmethods = db.PAYMENTMETHODs.Select(o => new PaymentMethod
                {
                    Text = o.Description,
                    Value = o.id.ToString()
                }).ToList();

                return paymentmethods;
            }
        }

        public void UpdateJob(UserProfileView user)
        {

            using (SchedulerEntities db = new SchedulerEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        SYSUser SU = db.SYSUsers.Find(user.SYSUserID);
                        SU.LoginName = user.LoginName;
                        SU.PasswordEncryptedText = user.Password;
                        SU.RowCreatedSYSUserID = user.SYSUserID;
                        SU.RowModifiedSYSUserID = user.SYSUserID;
                        SU.RowCreatedDateTime = DateTime.Now;
                        SU.RowModifiedDateTime = DateTime.Now;

                        db.SaveChanges();

                        var userProfile = db.SYSUserProfiles.Where(o => o.SYSUserID == user.SYSUserID);
                        if (userProfile.Any())
                        {
                            SYSUserProfile SUP = userProfile.FirstOrDefault();
                            SUP.SYSUserID = SU.SYSUserID;
                            SUP.FirstName = user.FirstName;
                            SUP.LastName = user.LastName;
                            SUP.Gender = user.Gender;
                            SUP.RowCreatedSYSUserID = user.SYSUserID;
                            SUP.RowModifiedSYSUserID = user.SYSUserID;
                            SUP.RowCreatedDateTime = DateTime.Now;
                            SUP.RowModifiedDateTime = DateTime.Now;

                            db.SaveChanges();
                        }

                        if (user.LOOKUPRoleID > 0)
                        {
                            var userRole = db.SYSUserRoles.Where(o => o.SYSUserID == user.SYSUserID);
                            SYSUserRole SUR = null;
                            if (userRole.Any())
                            {
                                SUR = userRole.FirstOrDefault();
                                SUR.LOOKUPRoleID = user.LOOKUPRoleID;
                                SUR.SYSUserID = user.SYSUserID;
                                SUR.IsActive = true;
                                SUR.RowCreatedSYSUserID = user.SYSUserID;
                                SUR.RowModifiedSYSUserID = user.SYSUserID;
                                SUR.RowCreatedDateTime = DateTime.Now;
                                SUR.RowModifiedDateTime = DateTime.Now;
                            }
                            else
                            {
                                SUR = new SYSUserRole();
                                SUR.LOOKUPRoleID = user.LOOKUPRoleID;
                                SUR.SYSUserID = user.SYSUserID;
                                SUR.IsActive = true;
                                SUR.RowCreatedSYSUserID = user.SYSUserID;
                                SUR.RowModifiedSYSUserID = user.SYSUserID;
                                SUR.RowCreatedDateTime = DateTime.Now;
                                SUR.RowModifiedDateTime = DateTime.Now;
                                db.SYSUserRoles.Add(SUR);
                            }

                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }


        public void DeleteJob(Guid jobID)
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    
                        try
                        {

                            var SUR = db.JOBWORKERs.Where(o => o.JobId == jobID.ToString());
                            if (SUR.Any())
                            {
                                db.JOBWORKERs.Remove(SUR.FirstOrDefault());
                                db.SaveChanges();
                            }

                            var TUR = db.JOBTOOLs.Where(t => t.JobId == jobID.ToString());
                            if (SUR.Any())
                            {
                                db.JOBTOOLs.Remove(TUR.FirstOrDefault());
                                db.SaveChanges();
                            }

                            var JUR = db.JOBs.Where(t => t.ID == jobID);
                            if (SUR.Any())
                            {
                                db.JOBs.Remove(JUR.FirstOrDefault());
                                db.SaveChanges();
                            }
                            dbContextTransaction.Commit();
                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                        }
                   
                    

                }
            }
        }

        public void DeleteAssignment(string strJobId, string strAssignmentId, string assignmentType)
        {
            using (SchedulerEntities db = new SchedulerEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    if (assignmentType == "workerlist")
                    {
                        try
                        {

                            var SUR = db.JOBWORKERs.Where(o => o.WorkerId == strAssignmentId && o.JobId == strJobId);
                            if (SUR.Any())
                            {
                                db.JOBWORKERs.Remove(SUR.FirstOrDefault());
                                db.SaveChanges();
                            }

                            dbContextTransaction.Commit();
                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                    else if (assignmentType == "toollist")
                    {
                        try
                        {

                            var SUR = db.JOBTOOLs.Where(o => o.ToolId == strAssignmentId && o.JobId == strJobId);
                            if (SUR.Any())
                            {
                                db.JOBTOOLs.Remove(SUR.FirstOrDefault());
                                db.SaveChanges();
                            }

                            dbContextTransaction.Commit();
                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                        }
                    }

                    else if (assignmentType.Substring(0,4) == "book")
                    {
                        try
                        {

                            var JBLK = db.JOBBLOCKs.Where(o => o.JobId == strAssignmentId );
                            if (JBLK.Any())
                            {
                                db.JOBBLOCKs.Remove(JBLK.FirstOrDefault());
                                db.SaveChanges();
                            }

                            dbContextTransaction.Commit();
                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                        }
                    }




                    else if (assignmentType == "joblist")
                    {
                        try
                        {

                            var SUR = db.JOBWORKERs.Where(o => o.JobId == strAssignmentId);
                            if (SUR.Any())
                            {
                                db.JOBWORKERs.Remove(SUR.FirstOrDefault());
                                db.SaveChanges();
                            }

                            var TUR = db.JOBTOOLs.Where(t => t.JobId == strAssignmentId);
                            if (TUR.Any())
                            {
                                db.JOBTOOLs.Remove(TUR.FirstOrDefault());
                                db.SaveChanges();
                            }

                            var JUR = db.JOBs.Where(t => t.ID.ToString() == strAssignmentId);
                            if (JUR.Any())
                            {
                                db.JOBs.Remove(JUR.FirstOrDefault());
                                db.SaveChanges();
                            }
                            dbContextTransaction.Commit();
                        }
                        catch
                        {
                            dbContextTransaction.Rollback();
                        }

                    }

                }
            }
        }


        public UserProfileView GetUserProfile(int userID)
        {
            UserProfileView UPV = new UserProfileView();
            using (SchedulerEntities db = new SchedulerEntities())
            {
                var user = db.SYSUsers.Find(userID);
                if (user != null)
                {
                    UPV.SYSUserID = user.SYSUserID;
                    UPV.LoginName = user.LoginName;
                    UPV.Password = user.PasswordEncryptedText;

                    var SUP = db.SYSUserProfiles.Find(userID);
                    if (SUP != null)
                    {
                        UPV.FirstName = SUP.FirstName;
                        UPV.LastName = SUP.LastName;
                        UPV.Gender = SUP.Gender;
                    }

                    var SUR = db.SYSUserRoles.Find(userID);
                    if (SUR != null)
                    {
                        UPV.LOOKUPRoleID = SUR.LOOKUPRoleID;
                        UPV.RoleName = SUR.LOOKUPRole.RoleName;
                        UPV.IsRoleActive = SUR.IsActive;
                    }
                }
            }

            return UPV;
        }


    }
}