using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.API.Interfaces
{
    public interface ITaskManager : IDisposable
    {
        Task<Task.EF.Task> GetTaskByID(Guid id);
        Task<Task.EF.Task> Save(Task.EF.Task task);
        Task<List<Task.EF.Task>> GetOpenTasks(Guid userid);
    }
}
