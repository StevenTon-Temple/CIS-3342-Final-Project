namespace ProjectFive.Models
{
    public class AccountModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role_ID { get; set; }
        public string Role { get; set; }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Username}, {Email}, {Password}, {Role_ID}, {Role}";
        }
    }

    public class AccountApiModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role_ID { get; set; }
        public string role { get; set; }
    
    }

    
}
