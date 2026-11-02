namespace PerfumeSystem;

class Program
{
    static void Main()
    {
        PerfumeDL perfumeDL = new PerfumeDL();
        SaleDL saleDL = new SaleDL();
        CustomerDL customerDL = new CustomerDL();
        AdminDL adminDL = new AdminDL();

        perfumeDL.LoadData();
        saleDL.LoadData();
        customerDL.LoadData();
        adminDL.LoadData();

        PerfumeUI perfumeUI = new PerfumeUI(perfumeDL);
        SaleUI saleUI = new SaleUI(saleDL);
        CustomerUI customerUI = new CustomerUI(customerDL);
        AdminUI adminUI = new AdminUI(adminDL);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("======= MANAR FRAGRANCES =======");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Exit");
            Console.Write("Choose option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                if (adminUI.Login())
                    AdminMenu(perfumeUI, saleUI, customerUI, adminUI);
            }
            else if (option == "2")
            {
                CustomerMenu(perfumeUI, saleUI, perfumeDL, customerDL);
            }
            else if (option == "3")
            {
                break;
            }
        }
    }

    static void AdminMenu(PerfumeUI perfumeUI, SaleUI saleUI, CustomerUI customerUI, AdminUI adminUI)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== ADMIN MENU ====");
            Console.WriteLine("1. Add Perfume");
            Console.WriteLine("2. View Perfumes");
            Console.WriteLine("3. Search Perfume");
            Console.WriteLine("4. Update Price");
            Console.WriteLine("5. Delete Perfume");
            Console.WriteLine("6. Sort Perfumes");
            Console.WriteLine("7. View Sales");
            Console.WriteLine("8. Update Sale");
            Console.WriteLine("9. Delete Sale");
            Console.WriteLine("10. Add Customer");
            Console.WriteLine("11. View Customers");
            Console.WriteLine("12. Search Customer");
            Console.WriteLine("13. Update Customer Phone");
            Console.WriteLine("14. Delete Customer");
            Console.WriteLine("15. Sort Customers");
            Console.WriteLine("16. Add Admin");
            Console.WriteLine("17. View Admins");
            Console.WriteLine("18. Change Password");
            Console.WriteLine("19. Delete Admin");
            Console.WriteLine("20. Logout");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            if (choice == "1") perfumeUI.AddPerfume();
            else if (choice == "2") perfumeUI.ViewPerfumes();
            else if (choice == "3") perfumeUI.SearchPerfume();
            else if (choice == "4") perfumeUI.UpdatePrice();
            else if (choice == "5") perfumeUI.DeletePerfume();
            else if (choice == "6") perfumeUI.SortPerfumes();
            else if (choice == "7") saleUI.ViewSales();
            else if (choice == "8") saleUI.UpdateSale();
            else if (choice == "9") saleUI.DeleteSale();
            else if (choice == "10") customerUI.AddCustomer();
            else if (choice == "11") customerUI.ViewCustomers();
            else if (choice == "12") customerUI.SearchCustomer();
            else if (choice == "13") customerUI.UpdatePhone();
            else if (choice == "14") customerUI.DeleteCustomer();
            else if (choice == "15") customerUI.SortCustomers();
            else if (choice == "16") adminUI.AddAdmin();
            else if (choice == "17") adminUI.ViewAdmins();
            else if (choice == "18") adminUI.ChangePassword();
            else if (choice == "19") adminUI.DeleteAdmin();
            else if (choice == "20") break;
        }
    }

    static void CustomerMenu(PerfumeUI perfumeUI, SaleUI saleUI, PerfumeDL perfumeDL, CustomerDL customerDL)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==== CUSTOMER MENU ====");
            Console.WriteLine("1. View Perfumes");
            Console.WriteLine("2. Search Perfume");
            Console.WriteLine("3. Buy Perfume");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            if (choice == "1") perfumeUI.ViewPerfumes();
            else if (choice == "2") perfumeUI.SearchPerfume();
            else if (choice == "3") saleUI.BuyPerfume(perfumeDL, customerDL);
            else if (choice == "4") break;
        }
    }
}
