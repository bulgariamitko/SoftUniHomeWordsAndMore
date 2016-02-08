namespace BigMani.IO
{
    /// <summary>
    /// Report Interface it must have Manufacturer, Model and Mark and a method ToString
    /// </summary>
    public interface IReport
    {
        string Manufacturer { get; set; }

        string Model { get; set; }

        int Mark { get; set; }

        /// <summary>
        /// Will print to the console a Report
        /// </summary>
        /// <param>without patams</param>
        string ToString();
    }
}