using BlazorApp.Shared.Models;

namespace BlazorApp.Server.Interfaces
{
    public interface TodoInterface
    {
        //public List<Todo> GetTodoList(Pagination pagination);
        public void AddTodo(Todo todo);
        public void UpdateTodo(Todo todo);
        public Todo GetTodo(int id);
        public void DeleteTodo(int id);

        public void AddTodoDetail(TodoDetails todoDetail);


    }
}
