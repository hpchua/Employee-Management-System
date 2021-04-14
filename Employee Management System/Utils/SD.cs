namespace Employee_Management_System.Utils
{
    public class SD
    {
        //Status ID
        public const long ACTIVE_STATUS_ID = 1;
        public const long DISABLED_STATUS_ID = 2;
        public const long SUSPENDED_STATUS_ID = 3;

        //Login Attempt
        public const byte DEFAULT_LOGIN_ATTEMPT = 0;
        public const byte DISABLED_LOGIN_ATTEMPT = 5;
        public const byte MAXIMUM_LOGIN_ATTEMPT = 10;

        public static class SortOrderParameter
        {
            public const string ASCENDING = "asc";
            public const string DESCENDING = "desc";

            public const string FullName = "FullName";

            public const string JoinedDate = "JoinedDate";

            public const string Team = "TeamName";

            public const string Position = "PositionName";

            public const string Status = "StatusName";
        }
    }
}