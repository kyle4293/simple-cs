using System;
using System.IO;
using System.Collections.Generic;

public static class DataStorage
{
    private static readonly string DataFilePath = "users.txt";

    public static void SaveUsers(UserManager userManager)
    {
        using (var writer = new StreamWriter(DataFilePath))
        {
            foreach (var user in userManager.GetAllUsers())
            {
                writer.WriteLine($"{user.Name},{user.Age},{user.Role}");
            }
        }
    }

    public static void LoadUsers(UserManager userManager)
    {
        if (!File.Exists(DataFilePath))
            return;

        using (var reader = new StreamReader(DataFilePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                if (parts.Length == 3 && int.TryParse(parts[1], out int age))
                {
                    var user = new User(parts[0], age, parts[2]);
                    userManager.AddUser(user);
                }
            }
        }
    }
}
