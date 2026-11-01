namespace PerfumeSystem;

public class Admin
{
    public string Username { get; set; }
    public string Password { get; set; }

    public Admin()
    {
        Username = "";
        Password = "";
    }

    public Admin(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public Admin(Admin other)
    {
        Username = other.Username;
        Password = other.Password;
    }
}
