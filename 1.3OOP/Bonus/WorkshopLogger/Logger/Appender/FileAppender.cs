using System;
using System.IO;
using Logger.Interfaces;

namespace Logger
{
    public class FileAppender : Appender
    {
        private StreamWriter writer;

        public string Path { get; set; }

        public FileAppender(string path, IFormatter formatter) : base(formatter)
        {
            this.Path = path;
        }
        
        public void Append(string msg, ReportLevel level, DateTime date)
        {
            string output = this.Formatter.Format(msg, level, date);
            this.writer.WriteLine(output);
        }

        public void Close()
        {
            writer.Close();
        }
    }
}