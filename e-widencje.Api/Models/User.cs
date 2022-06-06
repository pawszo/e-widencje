using System;
using System.ComponentModel.DataAnnotations;

namespace e_widencje.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public DateTime LastUpdate { get; set; }
        public int LastEditorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        /// <summary>
        /// PESEL
        /// </summary>
        public string PersonalId { get; set; }
        public bool? IsActive { get; set; }
    }
}
