using System;

class Program
{
    static void Main()
    {
        var userManager = new UserManager();
        DataStorage.LoadUsers(userManager);
        int choice;

        do
        {
            PrintMenu();
            choice = GetValidIntInput("Choose an option: ");

            switch (choice)
            {
                case 1:
                    Console.Write("Enter user name: ");
                    string name = Console.ReadLine() ?? "";

                    int age = GetValidIntInput("Enter user age: ");

                    string role;
                    do
                    {
                        Console.Write("Enter user role (Admin/User): ");
                        role = Console.ReadLine()?.Trim().ToLower();
                    } while (role != "admin" && role != "user");

                    userManager.AddUser(new User(name, age, role));
                    break;

                case 2:
                    Console.Write("Enter user name to delete: ");
                    name = Console.ReadLine() ?? "";
                    userManager.DeleteUser(name);
                    break;

                case 3:
                    Console.Write("Enter user name to search: ");
                    name = Console.ReadLine() ?? "";
                    var user = userManager.SearchUser(name);
                    if (user != null)
                    {
                        Console.WriteLine($"Found User - Name: {user.Name}, Age: {user.Age}, Role: {user.Role}");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                    break;

                case 4:
                    Console.WriteLine("All Users:");
                    foreach (var u in userManager.GetAllUsers())
                    {
                        Console.WriteLine($"Name: {u.Name}, Age: {u.Age}, Role: {u.Role}");
                    }
                    break;

                case 0:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (choice != 0);

        DataStorage.SaveUsers(userManager);
    }

    static void PrintMenu()
    {
        Console.WriteLine("\n1. Add User");
        Console.WriteLine("2. Delete User");
        Console.WriteLine("3. Search User");
        Console.WriteLine("4. Show All Users");
        Console.WriteLine("0. Exit");
    }

    // 유효한 정수 입력을 받을 때까지 반복
    static int GetValidIntInput(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result))
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}
