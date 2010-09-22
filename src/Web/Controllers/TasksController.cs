﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trackyourtasks.Core.DAL.Repositories.Impl;
using Trackyourtasks.Core.DAL.DataModel;

namespace Web.Controllers
{
    public class TasksController : Controller
    {
        [HttpPost]
        public JsonResult GetAllTasks()
        {
            var repository = new TasksRepository();
            return Json(repository.GetAllTasks().ToList());
        }

        [HttpPost]
        public JsonResult Submit(IList<Task> tasks)
        {
            var repository = new TasksRepository();

            foreach (var task in tasks)
            {
                if (task.Id != 0)
                {
                    var taskToUpdate = repository.FindTaskById(task.Id);
                    taskToUpdate.ActualWork = task.ActualWork;
                    taskToUpdate.Description = task.Description;
                    taskToUpdate.Status = task.Status;

                    repository.SaveTask(taskToUpdate);
                }
                else
                {
                    repository.SaveTask(task);
                }
            }

            return Json(null);
        }

        [HttpPost]
        public JsonResult Delete(IList<Task> tasks)
        {
            var repository = new TasksRepository();
            foreach (var task in tasks)
            {
                if (task.Id != 0)
                {
                    var taskToDelete = repository.FindTaskById(task.Id);
                    repository.DeleteTask(taskToDelete);
                }
            }

            return Json(null);
        }

    }
}