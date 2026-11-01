namespace PerfumeSystem;

public class AdminBL
{
    public static bool IsMatch(Admin a, string username, string password)
    {
        return a.Username == username && a.Password == password;
    }
}
