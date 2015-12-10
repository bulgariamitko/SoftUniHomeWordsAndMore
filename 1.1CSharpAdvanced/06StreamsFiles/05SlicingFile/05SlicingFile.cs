using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string source = "../../file.txt";
        string destination;
        int n = 5;

        List<string> collectedDestinations = new List<string>(n);

        for (int i = 0; i < n; i++)
        {
            destination = "../../Part-" + i + ".txt";
            collectedDestinations.Add(destination);
            Slice(source, destination, n);
        }


        string newSource = "../../assembled.txt";
        Assemble(collectedDestinations, newSource);
    }

    static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        using (var source = new FileStream(sourceFile, FileMode.Open))
        {
            int index = 1;
            while (source.Position < source.Length)
            {
                using (var destination = new FileStream(destinationDirectory, FileMode.Create))
                {
                    double fileLength = source.Length;
                    byte[] buffer = new byte[4096];
                    int chunkBytesRead = 0;
                    while (chunkBytesRead < source.Length / parts)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        chunkBytesRead += readBytes;
                        destination.Write(buffer, 0, readBytes);
                    }
                }
                index++;
            }
        }
    }
    static void Assemble(List<string> files, string destinationDirectory)
    {
        var create = new FileStream(destinationDirectory, FileMode.Create);
        try
        {
            for (int i = 0; i < files.Count; i++)
            {
                var opener = new FileStream(files[i], FileMode.Open);
                byte[] bytes = Encoding.ASCII.GetBytes(files[i]);
                create.Write(bytes, 0, bytes.Length);
            }

        }
        finally
        {
            create.Close();
        }

    }
}