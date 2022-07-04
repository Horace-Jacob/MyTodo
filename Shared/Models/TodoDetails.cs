using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Shared.Models
{
    public class TodoDetails
    {
        [Key]
        public int DetailId {get; set;}
        public int todoid {get; set;}
        public string? detail {get; set;}
    }
}