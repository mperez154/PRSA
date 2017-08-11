namespace Automation.Data
{
    class strngs
    {
        private static string createReservationPage = "http://smartluis-v2-staging.azurewebsites.net/Reservations/Reserve/?uniqueid=50027BC7-3591-4530-9284-224500614542"; 
        private static string findReservationPage = "http://node1-qa/smart.luis/Reservations/Confirmation/?uniqueid=50027BC7-3591-4530-9284-224500614542";
        private static string loyaltyLoginPage = "http://node1-qa/smart.luis/Loyalty/Login?uniqueid=50027bc7-3591-4530-9284-224500614542";
        private static string adminLoginPage = "http://smartluis-v2-staging.azurewebsites.net/Reservations/Reserve/?uniqueid=432D9FA1-60C8-44D6-B5F0-EC5A70F64CDB";
        private static string JoesCreateReservation = "http://smartluis-v2-staging.azurewebsites.net/Reservations/Reserve/?uniqueid=432D9FA1-60C8-44D6-B5F0-EC5A70F64CDB";
        private static string dateFormat = "g";
        private static string qaEmail = "ozerep154@gmail.com";

        public static string GetQAEmail()
        {
            return qaEmail;
        }

        public static string GetDateFormat()
        {
            return dateFormat;
        }

        public static string GetReservationPage()
        {
            return createReservationPage;
        }
        public static string getFindPage()
        {
            return findReservationPage;
        }
        public static string getLoyaltyPage()
        {
            return loyaltyLoginPage;
        }
        public static string getAdminPage()
        {
            return adminLoginPage;
        }
        public static string GetJoesParking()
        {
            return JoesCreateReservation;
        }
    }
}

