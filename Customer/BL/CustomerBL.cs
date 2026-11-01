namespace PerfumeSystem;

public class CustomerBL
{
    public static bool IsValidPhone(string phone)
    {
        if (phone.Length != 11)
            return false;

        foreach (char ch in phone)
        {
            if (!char.IsDigit(ch))
                return false;
        }
        return true;
    }
}
