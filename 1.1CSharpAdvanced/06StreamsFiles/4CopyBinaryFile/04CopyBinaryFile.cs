using System.IO;

namespace _4CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream copiedFile = new FileStream("../../image.jpg", FileMode.Open);
            FileStream newFile = new FileStream("../../copiedImage.jpg", FileMode.Create);

            using (copiedFile)
            {
                using (newFile)
                {

                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = copiedFile.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        newFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
