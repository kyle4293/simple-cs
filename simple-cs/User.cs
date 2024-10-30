public class User
{
    public string Name { get; }
    public int Age { get; }
    public string Role { get; }

    public User(string name, int age, string role)
    {
        Name = name;
        Age = age;
        Role = role;
    }
}
