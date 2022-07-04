using BlazorApp.Shared.Models;
using BlazorApp.Server.Models;
using BlazorApp.Server.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Services
{
    public class TodoManager : TodoInterface
    {
        private readonly TodoDatabaseContext _dbContext;

        public TodoManager(TodoDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        public void AddTodo(Todo todo)
        {
            try
            {
                _dbContext.Todos.Add(todo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void AddTodoDetail(TodoDetails todoDetail)
        {
            try
            {
                _dbContext.TodoDetail.Add(todoDetail);
                _dbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public void DeleteTodo(int id)
        {
            try
            {
                Todo? todo = _dbContext.Todos.Find(id);
                if(todo != null)
                {
                    _dbContext.Todos.Remove(todo);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public Todo GetTodo(int id)
        {
            try
            {
                Todo? todo = _dbContext.Todos.Find(id);
                if(todo != null)
                {
                    return todo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateTodo(Todo todo)
        {
            try
            {
                _dbContext.Entry(todo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {

            }
        }
    }
}
