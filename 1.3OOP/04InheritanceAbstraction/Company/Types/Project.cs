using System;

namespace Company.Types
{
    public class Project
    {
        private string name;
        private DateTime startsDate;
        private string details;
        private bool state;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime StartsDate
        {
            get { return startsDate; }
            set { startsDate = value; }
        }

        public string Details
        {
            get { return details; }
            set { details = value; }
        }

        public bool State
        {
            get { return state; }
            set { state = value; }
        }

        public Project(string name, DateTime startsDate, string details, bool state)
        {
            Name = name;
            StartsDate = startsDate;
            Details = details;
            State = state;
        }

        public void CloseProject()
        {
            state = false;
        }

        public override string ToString()
        {
            return string.Format("Project name: {0}, start date: {1}, details: {2} and the state is: {3}", Name,
                StartsDate.ToShortDateString(), Details, State ? "open" : "closed");
        }
    }
}