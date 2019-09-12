using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class TodoListItem
    {
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Status { get; set; }

        public DateTimeOffset? DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }

        public DateTimeOffset? DateSolved { get; set; }
    }
}
