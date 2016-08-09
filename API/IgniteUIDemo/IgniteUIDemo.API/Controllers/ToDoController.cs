using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using IgniteUIDemo.API.Models;
using IgniteUIDemo.API.Models.ViewModels;

namespace IgniteUIDemo.API.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods:"*")]
    public class ToDoController : ApiController
    {
        private readonly IToDoModel _model;

        public ToDoController(IToDoModel toDoModel)
        {
            _model = toDoModel;
        }

        public IHttpActionResult GetAllToDoItems()
        {
            return Ok(_model.Get());
        }

        public IHttpActionResult GetSpecificToDoItem(int id)
        {
            var item = _model.Get(id);
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            return Ok(item);
        }

        public IHttpActionResult PostNewToDoItem(ToDoItem toDoItem)
        {
            var id = _model.Create(toDoItem);

            return Created($"{Request.RequestUri}/{id}", _model.Get(id));
        }

        public object PutUpdatedToDoItem(int id, ToDoItem toDoItem)
        {
            _model.Save(id, toDoItem);
            return StatusCode(HttpStatusCode.Accepted);            
        }

        public IHttpActionResult DeleteToDoItem(int id)
        {
            _model.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
