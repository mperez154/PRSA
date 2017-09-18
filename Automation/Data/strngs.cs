namespace Automation.Data
{
    class Strngs
    {
        private static string dateFormat = "g";
        private static string qaEmail = "ozerep154+automated@gmail.com";
        private static string attribute = "value";
        private static string QA = "http://node1-qa/smart.luis/";
        private static string Staging = "http://smartluis-v2-staging.azurewebsites.net/";
        private static string Create = "Reservations/Reserve/?uniqueid=";
        private static string Find = "Reservations/Confirmation/?uniqueid=";
        private static string Joes = "432D9FA1-60C8-44D6-B5F0-EC5A70F64CDB";
        private static string WallyPark = "50027BC7-3591-4530-9284-224500614542";
        private static string AdminPage = "Admin/Account/Login?returnUrl=/smart.luis/admin/home";
        private static string LoyaltyPage = "Loyalty/Login?uniqueid=";

        public static string GetReservationURL(string enviroment, string company)
        {
            if (enviroment == "QA" && company == "Joes")
            {
                return QA + Create + Joes;
            }
            else if (enviroment == "QA" && company == "WallyPark")
            {
                return QA + Create + WallyPark;
            }
            else if (enviroment == "Staging" && company == "Joes")
            {
                return Staging + Create + Joes;
            }
            else return Staging + Create + WallyPark;
        }

        public static string GetLoyaltyURL(string enviroment, string company)
        {
            if (enviroment == "QA" && company == "Joes")
            {
                return QA + LoyaltyPage + Joes;
            }
            else if (enviroment == "QA" && company == "WallyPark")
            {
                return QA + LoyaltyPage + WallyPark;
            }
            else if (enviroment == "Staging" && company == "Joes")
            {
                return Staging + LoyaltyPage + Joes;
            }
            else return Staging + LoyaltyPage + WallyPark;
        }

        public static string GetFindURL(string enviroment, string company)
        {
            if (enviroment == "QA" && company == "Joes")
            {
                return QA + Find + Joes;
            }
            else if (enviroment == "QA" && company == "WallyPark")
            {
                return QA + Find + WallyPark;
            }
            else if (enviroment == "Staging" && company == "Joes")
            {
                return Staging + Find + Joes;
            }
            else return Staging + Find + WallyPark;
        }

        public static string GetAdminURL(string enviroment)
        {
            if (enviroment == "QA")
            {
                return QA + AdminPage;
            }
            else return Staging + AdminPage;
        }

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

