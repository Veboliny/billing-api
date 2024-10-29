namespace back_facturation_api.DbData.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Groupe { get; set; } = string.Empty;
        public bool PasswordIsExpired { get; set; } = false;
        public DateOnly AccountCreationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly LastConnection { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}