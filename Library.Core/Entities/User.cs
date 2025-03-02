using System.ComponentModel.DataAnnotations;

namespace Library.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        /// <summary>
        /// Admin , User
        /// </summary>
        [MaxLength(10)]
        public string Role { get; set; }
    }
}
