using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using DHTMLX.Scheduler.Controls;

using School_TimeTable.Models;
namespace School_TimeTable.Controllers
{
    public class CalendarController : Controller
    {

        // GET: School
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Student student)
        {
            if (ModelState.IsValid)
            {
                using (SchoolEntities db = new SchoolEntities())
                {

                    var obj = db.Students.Where(s => s.User_Name.Equals(student.User_Name) && s.Password.Equals(student.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Student_ID"] = obj.Student_Id.ToString();
                        Session["UserName"] = obj.User_Name.ToString();
                        return RedirectToAction("Index");
                    }
                 
                }
            }
            return View(student);
        }


        public ActionResult TeacherLogin(teacher teacher)
        {
            if (ModelState.IsValid)
            {
                using (SchoolEntities db = new SchoolEntities())
                {

                    var obj = db.Teachers.Where(t => t.user_name.Equals(teacher.user_name) && t.password.Equals(teacher.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Teacher_ID"] = obj.teacher_id.ToString();
                        Session["UserName"] = obj.user_name.ToString();
                        Session["Subject_id"] = obj.subject_id.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(teacher);
        }
        public ActionResult Index()
        {
            
            var scheduler = new DHXScheduler(this);
            scheduler.InitialDate = DateTime.Today; 

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler);
        }

        public ContentResult Data()
        {
            var data = new SchedulerAjaxData(
              new SchedulerContext().CalendarEvents.Select(e => new { e.id, e.text, e.start_date, e.end_date }).Where(t => t.id.Equals(Session["Subject_id"])));
            return (ContentResult)data;
        }

        public ContentResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
            var changedEvent = DHXEventsHelper.Bind<CalendarEvent>(actionValues);
            var entities = new SchedulerContext();
            try
            {
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        entities.CalendarEvents.Add(changedEvent);
                        break;
                    case DataActionTypes.Delete:
                        changedEvent = entities.CalendarEvents.FirstOrDefault(ev => ev.id == action.SourceId);
                        entities.CalendarEvents.Remove(changedEvent);
                        break;
                    default:// "update"
                        var target = entities.CalendarEvents.Single(e => e.id == changedEvent.id);
                        DHXEventsHelper.Update(target, changedEvent, new List<string> { "id" });
                        break;
                }
                entities.SaveChanges();
                action.TargetId = changedEvent.id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
        }
    }
}

