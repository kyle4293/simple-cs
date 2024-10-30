using System;
using System.Collections.Generic;
using System.Linq;

public class UserManager
{
    private List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
        Console.WriteLine($"User added: {user.Name}");
        Logger.Log($"User added: {user.Name}, Role: {user.Role}");
    }

    public void DeleteUser(string name)
    {
        var user = _users.FirstOrDefault(u => u.Name == name);
        if (user != null)
        {
            _users.Remove(user);
            Console.WriteLine($"User deleted: {name}");
            Logger.Log($"User deleted: {name}");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    public User SearchUser(string name)
    {
        return _users.FirstOrDefault(u => u.Name == name);
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }
}
