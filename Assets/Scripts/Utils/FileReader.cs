using System;
using System.IO;
using UnityEngine;

public static class FileReader
{
    public static string ReadTextFile(string path)
    {
        string line = string.Empty;

        try
        {   // Open the text file using a stream reader.
            using (StreamReader sr = new StreamReader(@path))
            {
                // Read the stream to a string, and write the string to the console.
                line = sr.ReadToEnd();
            }
        }
        catch (Exception e)
        {
            Debug.Log("The file could not be read: " + e.Message);
        }

        return line;
    }
}
