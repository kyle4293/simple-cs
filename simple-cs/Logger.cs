using System;
using System.IO;

public static class Logger
{
    private static readonly string LogFilePath = "user_management.log";

    public static void Log(string message)
    {
        using (var writer = new StreamWriter(LogFilePath, true))
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}
