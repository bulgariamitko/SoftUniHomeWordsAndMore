namespace BigMani.Controllers
{
    using System;

    public class LineExecuting
    {
        public LineExecuting(string line)
        {
            try
            {
                this.Name = line.Substring(0, line.IndexOf(' '));

                // BUG: it must line.IndexOf(' ') be increased by 1 else it return the first parameter empty space
                this.Parameters = line.Substring(line.IndexOf(' ') + 1)
                    .Split(new[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Invalid command", ex);
            }
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }
    }
}
