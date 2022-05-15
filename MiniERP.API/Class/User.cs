namespace MiniERP.API.Class
{
    public class User
    {
        public int UsuarioID { get; set; } = 0;
        public string CompleteName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
