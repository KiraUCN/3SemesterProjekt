﻿using System.Diagnostics;

namespace WebshopClientDesktop.Logging
{
    public class Logger
    {
        public static void LogError(Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
        }

        public static void LogWarning(string message)
        {
            Debug.WriteLine($"Warning: {message}");
        }

        public static void LogInfo(string message)
        {
            Debug.WriteLine($"Info: {message}");
        }
    }
}
