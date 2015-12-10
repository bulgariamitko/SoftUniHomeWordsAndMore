namespace _01Human
{
    public class Worker : Human
    {
        private int weekSalary;
        private int workHoursPerDay;

        public int WeekSalary
        {
            get { return weekSalary; }
            set { weekSalary = value; }
        }

        public int WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set { workHoursPerDay = value; }
        }

        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay) : base(firstName, lastName)
        {
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }

        public double MoneyPerHour()
        {
            double money = (double) WeekSalary/(5*(double) WorkHoursPerDay);
            return money;
        }
    }
}