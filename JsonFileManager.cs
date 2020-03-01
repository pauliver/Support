namespace Support
{
    public class JsonFileManager
    {
        private UserList authorWhitelist;
        private UserList authorBlackList;
        private LabelList labelWhitelist;
        private LabelList labelBlackList;

        public UserList AuthorBlackList { get => authorBlackList; set => authorBlackList = value; }
        public UserList AuthorWhitelist { get => authorWhitelist; set => authorWhitelist = value; }

        public LabelList LabelBlackList { get => authorBlackList; set => authorBlackList = value; }
        public LabelList LabelWhitelist { get => authorWhitelist; set => authorWhitelist = value; }

        public string SupportIssueLabel = "Support: Requested";
        public string StaleSupportIssueLabel = "Suport: Stale";

        public string SolvedSupportIssueLabel = "Support: Provided";

        public string LostIssueLabel = "Support: Issue Was Lost";

        public System.TimeSpan DesiredResponseTime = System.TimeSpan.FromHours(48); //2880

        public System.TimeSpan AbandonedByAuthor = System.TimeSpan = System.TimeSpan.FromDays(7); //10080
        public System.TimeSpan AbandonedBySystem = System.TimeSpan = System.TimeSpan.FromDays(7); //10080
        public System.TimeSpan Lost = System.TimeSpan = System.TimeSpan.FromDays(21); //30240
    

    }
}