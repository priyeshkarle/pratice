using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.WebAPI.Models.Tasks
{
    public class Task
    {
        public Guid ID { get; set; }
        public string Title { get; set; }

        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

        public Guid UserID { get; set; }

        public static Task Marashall(MyApp.API.Task.EF.Task input)
        {
            return new Task()
            {
                DueDate = input.DueDate,
                ID = input.ID,
                Notes = input.Notes,
                Priority = input.Priority,
                Status = input.Status,
                Title = input.Title,
                UserID = input.UserID
            };
        }

        public static MyApp.API.Task.EF.Task Marashall(Task input)
        {
            return new MyApp.API.Task.EF.Task()
            {
                DueDate = input.DueDate,
                ID = input.ID,
                Notes = input.Notes,
                Priority = input.Priority,
                Status = input.Status,
                Title = input.Title,
                UserID = input.UserID
            };
        }
    }
}