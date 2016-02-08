namespace BigMani.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BigMani.Models;

    public static class Data
    {
        static Data()
        {
            AirConditioners = new List<AirConditioner>();
            Reports = new List<Report>();
        }

        public static List<AirConditioner> AirConditioners { get; set; }

        public static List<Report> Reports { get; set; }

        public static void AddAirConditioner(AirConditioner airConditioner)
        {
            AirConditioners.Add(airConditioner);
        }

        public static void RemoveAirConditioner(AirConditioner airConditioner)
        {
            AirConditioners.Remove(airConditioner);
        }

        public static AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            return AirConditioners.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public static int GetAirConditionersCount()
        {
            return AirConditioners.Count;
        }

        public static void AddReport(Report report)
        {
            Reports.Add(report);
        }

        public static void RemoveReport(Report report)
        {
            Reports.Remove(report);
        }

        public static Report GetReport(string manufacturer, string model)
        {
            return Reports.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public static int GetReportsCount()
        {
            return Reports.Count;
        }

        public static List<Report> GetReportsByManufacturer(string manufacturer)
        {
            return Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }
    }
}