using MyApp.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyApp.WebAPI.Controllers
{
    public class TaskController : ApiController
    {
        public async Task<IHttpActionResult> Get(Guid id)
        {
            using (var taskmsgr = ObjectFactory.TaskManager)
            {
                var task = await taskmsgr.GetTaskByID(id);

                if (task == null) return NotFound();
                else
                {
                    return Ok<Models.Common.BaseResponse<Models.Tasks.Task>>(new Models.Common.BaseResponse<Models.Tasks.Task>() {
                        Data = Models.Tasks.Task.Marashall(task)
                    });
                }
            }
        }

        [HttpGet]
        [Route("api/Task/GetAll")]
        public async Task<IHttpActionResult> GetAll(Guid userid)
        {
            using (var taskmsgr = ObjectFactory.TaskManager)
            {
                var taskList = await taskmsgr.GetOpenTasks(userid);

                return Ok < Models.Common.BaseResponse<List<Models.Tasks.Task>>>(new Models.Common.BaseResponse<List<Models.Tasks.Task>>() {
                    Data = taskList.Select(t => Models.Tasks.Task.Marashall(t)).ToList()
                });
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Models.Common.BaseRequest<Models.Tasks.Task> task)
        {
            using (var taskmsgr = ObjectFactory.TaskManager)
            {
                var savedTask = await taskmsgr.Save(Models.Tasks.Task.Marashall(task.Data));

                if (task == null) return NotFound();
                else
                {
                    return Ok<Models.Common.BaseResponse<Models.Tasks.Task>>(new Models.Common.BaseResponse<Models.Tasks.Task>()
                    {
                        Data = Models.Tasks.Task.Marashall(savedTask)
                    });
                }
            }
        }
    }
}
