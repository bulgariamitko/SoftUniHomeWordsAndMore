using System;

namespace _04GenericVersion
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]
    public class VersionAttribute : System.Attribute
    {
        private int major;
        private int minor;

        public int Major
        {
            get { return major; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Value must be positive of zero!");
                }
                major = value;
            }
        }

        public int Minor
        {
            get { return minor; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Value must be positive of zero!");
                }
                minor = value;
            }
        }

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
    }
}