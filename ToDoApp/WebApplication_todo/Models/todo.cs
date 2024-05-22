using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_todo.Models
{
    public class todo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public bool IsCompleted { get; set; }
        public string Detail { get; set; }
        public string Priority { get; set; }

    }
}