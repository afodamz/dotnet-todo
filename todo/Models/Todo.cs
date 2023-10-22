using System;
using System.ComponentModel.DataAnnotations;

namespace todo.Models
{
	public class Todo
	{
		[Key]
		public int Id { get; set; }
		[Required]
        public required string Title { get; set; }
		public string? Description { get; set; }
		public bool IsCompleted { get; set; } = false;
		public bool IsDeleted { get; set; } = false;

	}
}

