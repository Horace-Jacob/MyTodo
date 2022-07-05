using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Server.Interfaces;
using BlazorApp.Shared.Models;
using BlazorApp.Server.Helpers;
using BlazorApp.Server.Models;


namespace BlazorApp.Server.Controllers
{
    [Route("todos")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly TodoInterface _ITodo;
        // private readonly IWebHostEnvironment env;
        private readonly TodoDatabaseContext _dbContext;
        public TodoController(TodoInterface iTodo, TodoDatabaseContext dbContext)
        {
            _ITodo = iTodo;
            _dbContext = dbContext;
            // this.env = env;
        }


        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetTodoList([FromQuery] Pagination pagination)
        {
            var queryable = _dbContext.Todos.AsQueryable();
            await HttpContext.PageParameters(queryable, pagination.PageSize);
            return await queryable.Paginate(pagination).ToListAsync();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Todo todo = _ITodo.GetTodo(id);
            if(todo != null)
            {
                return Ok(todo);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Todo todo)
        {
            _ITodo.AddTodo(todo);
        }

        

        [HttpPut]
        public void Put(Todo todo)
        {
            _ITodo.UpdateTodo(todo);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ITodo.DeleteTodo(id);
            return Ok();

        }

    }
}
