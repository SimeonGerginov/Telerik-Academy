using System;

namespace ProjectManager.Common
{
    public abstract class DateTimeProvider
    {
        private static DateTimeProvider current = DefaultDateTimeProvider.Instance;

        protected DateTimeProvider()
        {
        }

        public static DateTimeProvider Current
        {
            get
            {
                return current;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("DateTimeProvider is null!");
                }

                current = value;
            }
        }

        public abstract DateTime UtcNow { get; }

        public static void ResetToDefault()
        {
            current = DefaultDateTimeProvider.Instance;
        }
    }
}
