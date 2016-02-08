namespace BigMani.Models
{
    using IO;

    public class Report : IReport
    {
        public Report(string manufacturer, string model, int mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public int Mark { get; set; }

        public override string ToString()
        {
            string result = string.Empty;
            string pass = string.Empty;
            if (this.Mark == 0)
            {
                pass = "Failed";
            }
            else if (this.Mark == 1)
            {
                pass = "Passed";
            }

            result += "Report" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " + this.Manufacturer + "\r\n" +
                      "Model: " + this.Model + "\r\n" + "Mark: " + pass + "\r\n" + "====================";

            return result;
        }
    }
}
