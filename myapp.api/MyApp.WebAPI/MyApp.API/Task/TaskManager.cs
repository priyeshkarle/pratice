using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.API.Task.EF;

namespace MyApp.API.Task
{
    class TaskManager : Interfaces.ITaskManager, IDisposable
    {
        EF.TaskEF _context = new TaskEF();

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<List<EF.Task>> GetOpenTasks(Guid userid)
        {
            return System.Threading.Tasks.Task.Run<List<EF.Task>>(() =>
            {
                return _context.Tasks.Where(t => t.UserID == userid).ToList();
            });
        }

        public Task<EF.Task> GetTaskByID(Guid id)
        {
            return System.Threading.Tasks.Task.Run<EF.Task>(() =>
            {
                return _context.Tasks.Where(t => t.ID == id).FirstOrDefault();
            });
        }

        public Task<EF.Task> Save(EF.Task task)
        {
            return System.Threading.Tasks.Task.Run<EF.Task>(async () =>
            {
                if (task.ID == Guid.Empty)
                {
                    task.ID = Guid.NewGuid();
                    _context.Tasks.Add(task);
                }
                else
                {
                    var modifiedEntry = _context.Entry(task);
                    modifiedEntry.State = System.Data.Entity.EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return task;
            });
        }
    }
}
