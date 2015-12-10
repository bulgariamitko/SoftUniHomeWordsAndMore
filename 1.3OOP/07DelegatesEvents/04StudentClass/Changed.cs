using System;

namespace _04StudentClass
{
    public class Changed : EventArgs
    {
        public string PropertyName { get; set; }
        public dynamic OldValue { get; set; }
        public dynamic NewValue { get; set; }

        public Changed(string propertyName, dynamic oldValue, dynamic newValue)
        {
            PropertyName = propertyName;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}