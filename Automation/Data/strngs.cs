namespace Automation.Data
{
    class strngs
    {
        private static string createReservationPage = "http://node1-qa/smart.luis/Reservations/Reserve/?uniqueid=50027BC7-3591-4530-9284-224500614542"; 
        private static string findReservationPage = "http://node1-qa/smart.luis/Reservations/Confirmation/?uniqueid=50027BC7-3591-4530-9284-224500614542";
        private static string loyaltyLoginPage = "http://node1-qa/smart.luis/Loyalty/Login?uniqueid=50027bc7-3591-4530-9284-224500614542";
        private static string adminLoginPage = "http://node1-qa/Smart.Luis/Admin/Account/Login?returnUrl=/smart.luis/admin/home";

        public static string getCreateReservationPage()
        {
            return createReservationPage;
        }
        public static string getFindReservationPage()
        {
            return findReservationPage;
        }
        public static string getLoyaltyLoginPage()
        {
            return loyaltyLoginPage;
        }
        public static string getAdminLoginPage()
        {
            return adminLoginPage;
        }
    }
}
