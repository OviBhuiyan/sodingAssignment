using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SODING_INDIVIDUAL_ASSIGNMENT.Models;
using SODING_INDIVIDUAL_ASSIGNMENT.BLL;
using SODING_INDIVIDUAL_ASSIGNMENT.ViewModel;

namespace SODING_INDIVIDUAL_ASSIGNMENT.Controllers
{
    public class TaskController : Controller
    {
        private BLL_Task bll_task;

        // GET: Task
        public ActionResult Index()
        {
            bll_task = new BLL_Task();
            return View(bll_task.GetAllTaskInfo());
        }

      
        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskVM vm)
        {
            if (ModelState.IsValid)
            {
                bll_task = new BLL_Task();
                if (bll_task.CreateTaskInfo(vm))
                {
                    TempData["message"] = "Task Saved Successfully";
                   
                    return RedirectToAction("Index");
                }
               else
                {

                    TempData["message"] = "Task not saved";
                    return View(vm);
                }
            }

            return View(vm);
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            bll_task = new BLL_Task();
            TaskVM vm = bll_task.GetTaskInfoById(Convert.ToInt32(id));
            if (vm == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Task/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskVM vm)
        {
            if (ModelState.IsValid)
            {
                bll_task = new BLL_Task();
                if (bll_task.UpdateTaskInfo(vm))
                {
                    TempData["message"] = "Task update Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "Task update problem !";
                    return View(vm);
                }


              
            }
            return View(vm);
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bll_task = new BLL_Task();
            TaskVM vm = bll_task.GetTaskInfoById(Convert.ToInt32(id));
            if (vm == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bll_task = new BLL_Task();
            if (bll_task.DeleteTaskInfo(id))
            {
                TempData["message"] = "Task Delete Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Task not Deleted !";
                return RedirectToAction("Index");
            }
          
        }

     
    }
}
