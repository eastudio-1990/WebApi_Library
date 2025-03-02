namespace Library.Core.DTO
{
    public class CreateUpdateUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        /// <summary>
        /// Admin , User
        /// </summary>
        public string Role { get; set; }
    }
}
