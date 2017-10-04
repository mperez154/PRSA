namespace Automation.Data
{
    class Strngs
    {
        private static string dateFormat = "g";
        private static string qaEmail = "ozerep154+automated@gmail.com";
        private static string attribute = "value";

        public static string GetAttribute()
        {
            return attribute;
        }

        public static string GetQAEmail()
        {
            return qaEmail;
        }

        public static string GetDateFormat()
        {
            return dateFormat;
        }    
    }
}

