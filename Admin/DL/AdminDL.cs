namespace PerfumeSystem;

public class AdminDL
{
    private List<Admin> admins = new List<Admin>();
    private string filePath = "admins.txt";

    public void LoadData()
    {
        admins.Clear();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    admins.Add(new Admin(parts[0], parts[1]));
                }
            }
        }

        if (admins.Count == 0)
        {
            admins.Add(new Admin("admin", "1234"));
            SaveData();
        }
    }

    public void SaveData()
    {
        StreamWriter writer = new StreamWriter(filePath);

        for (int i = 0; i < admins.Count; i++)
        {
            writer.WriteLine(admins[i].Username + "|" + admins[i].Password);
        }

        writer.Close();
    }

    public bool AddAdmin(Admin a)
    {
        if (FindByUsername(a.Username) != null)
            return false;

        admins.Add(a);
        SaveData();
        return true;
    }

    public List<Admin> GetAll()
    {
        return admins;
    }

    public Admin FindByUsername(string username)
    {
        foreach (Admin a in admins)
        {
            if (a.Username == username)
                return a;
        }
        return null;
    }

    public bool Login(string username, string password)
    {
        foreach (Admin a in admins)
        {
            if (AdminBL.IsMatch(a, username, password))
                return true;
        }
        return false;
    }

    public bool ChangePassword(string username, string newPassword)
    {
        Admin a = FindByUsername(username);
        if (a == null)
            return false;

        a.Password = newPassword;
        SaveData();
        return true;
    }

    public bool DeleteAdmin(string username)
    {
        if (admins.Count == 1)
            return false;

        Admin a = FindByUsername(username);
        if (a == null)
            return false;

        admins.Remove(a);
        SaveData();
        return true;
    }
}
