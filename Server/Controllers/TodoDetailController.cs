using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Server.Interfaces;
using BlazorApp.Shared.Models;
using BlazorApp.Server.Helpers;
using BlazorApp.Server.Models;


namespace BlazorApp.Server.Controllers
{
    [Route("details")]
    [ApiController]
    public class TodoDetailController : Controller
    {
        private readonly TodoInterface _ITodo;
        private readonly IWebHostEnvironment env;
        private readonly TodoDatabaseContext _dbContext;
        public TodoDetailController(TodoInterface iTodo, TodoDatabaseContext dbContext)
        {
            _ITodo = iTodo;
            _dbContext = dbContext;
            this.env = env;
        }


        

        [HttpGet("{id}")]
        public ActionResult<List<TodoDetails>> GetTodoDetails(int id){
            try
            {
                List<TodoDetails>? todoDetail = _dbContext.TodoDetail.Where(element => element.todoid == id).ToList();
                if(todoDetail != null){
                return Ok(todoDetail);
                }
             return NotFound();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPost]
        public void PostDetails(TodoDetails todoDetail)
        {
            _ITodo.AddTodoDetail(todoDetail);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            try
            {
                List<TodoDetails>? todoDetail = _dbContext.TodoDetail.Where(element => element.todoid == id).ToList();
                if(todoDetail != null){
                    _dbContext.TodoDetail.RemoveRange(todoDetail);
                    _dbContext.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }


    }
}
