using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SODING_INDIVIDUAL_ASSIGNMENT.Models;
using SODING_INDIVIDUAL_ASSIGNMENT.ViewModel;
using System.Data.Entity;

namespace SODING_INDIVIDUAL_ASSIGNMENT.BLL
{
    public class BLL_Task
    {
        private DBSodingEntities entDB;


        public BLL_Task()
        {
            entDB = new DBSodingEntities();
        }
        public List<TaskVM> GetAllTaskInfo()
        {
            List<TaskVM> dtoList = new List<TaskVM>();
            try
            {
                List<tbl_Task> TaskList = entDB.tbl_Task.ToList();
                foreach (tbl_Task item in TaskList)
                {
                    TaskVM dtoTask = new TaskVM();
                    dtoTask.Id = item.Id;
                    dtoTask.TaskName = item.TaskName;
                   
                    dtoList.Add(dtoTask);

                }

            }
            catch (Exception)
            {

                throw;
            }

            return dtoList;

        }

        public bool CreateTaskInfo(TaskVM dtoTask)
        {
            bool isSaved = false;
            try
            {
                tbl_Task objTask = new tbl_Task();

                objTask.TaskName = dtoTask.TaskName;
              

                entDB.tbl_Task.Add(objTask);
                entDB.SaveChanges();
                isSaved = true;
            }
            catch
            {
                return false;
            }

            return isSaved;
        }

        public bool UpdateTaskInfo(TaskVM dtoTask)
        {
            bool isSaved = false;
            try
            {

                tbl_Task objTask = new tbl_Task();
                objTask.Id = dtoTask.Id;
                objTask.TaskName = dtoTask.TaskName;

                entDB.Entry(objTask).State = EntityState.Modified;
                entDB.SaveChanges();
                isSaved = true;
            }
            catch
            {
                return false;
            }

            return isSaved;
        }

        public bool DeleteTaskInfo(int id)
        {
            bool isDeleted = false;
            try
            {
                tbl_Task objTask = entDB.tbl_Task.Find(id);
                entDB.tbl_Task.Remove(objTask);
                entDB.SaveChanges();
                isDeleted = true;
            }
            catch
            {
                return false;
            }

            return isDeleted;
        }

        public TaskVM GetTaskInfoById(int id)
        {
            TaskVM dto = new TaskVM();

            tbl_Task objTask = entDB.tbl_Task.Find(id);
            dto.Id = objTask.Id;
            dto.TaskName = objTask.TaskName;

            return dto;
        }




    }
}