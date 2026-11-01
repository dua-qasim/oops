namespace PerfumeSystem;

public class AdminUI
{
    private AdminDL dl;
    public string CurrentUser = "";

    public AdminUI(AdminDL dl)
    {
        this.dl = dl;
    }

    public static string ReadPassword(string message)
    {
        Console.Write(message);
        string pass = "";
        ConsoleKeyInfo key;

        while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
        {
            if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
            {
                pass = pass.Substring(0, pass.Length - 1);
                Console.Write("\b \b");
            }
            else if (!char.IsControl(key.KeyChar))
            {
                pass = pass + key.KeyChar;
                Console.Write("*");
            }
        }

        Console.WriteLine();
        return pass;
    }

    public bool Login()
    {
        for (int attempt = 1; attempt <= 3; attempt++)
        {
            Console.Clear();
            Console.WriteLine("==== ADMIN LOGIN ====");
            string user = PerfumeUI.ReadText("Username: ");
            string pass = ReadPassword("Password: ");

            if (dl.Login(user, pass))
            {
                CurrentUser = user;
                return true;
            }

            Console.WriteLine("Wrong username or password! Attempt " + attempt + "/3");
            PerfumeUI.Pause();
        }
        return false;
    }

    public void AddAdmin()
    {
        Console.Clear();
        string user = PerfumeUI.ReadText("New username: ");
        string pass = ReadPassword("New password: ");

        if (dl.AddAdmin(new Admin(user, pass)))
            Console.WriteLine("Admin Added!");
        else
            Console.WriteLine("Username already exists!");

        PerfumeUI.Pause();
    }

    public void ChangePassword()
    {
        Console.Clear();
        string newPass = ReadPassword("Enter new password: ");

        if (dl.ChangePassword(CurrentUser, newPass))
            Console.WriteLine("Password Changed!");
        else
            Console.WriteLine("Error!");

        PerfumeUI.Pause();
    }

    public void ViewAdmins()
    {
        Console.Clear();
        Console.WriteLine("Admins:");
        foreach (Admin a in dl.GetAll())
        {
            Console.WriteLine("- " + a.Username);
        }
        PerfumeUI.Pause();
    }

    public void DeleteAdmin()
    {
        Console.Clear();
        string user = PerfumeUI.ReadText("Username to delete: ");

        if (dl.DeleteAdmin(user))
            Console.WriteLine("Admin Deleted!");
        else
            Console.WriteLine("Cannot delete (not found or last admin)!");

        PerfumeUI.Pause();
    }
}
