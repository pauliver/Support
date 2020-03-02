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

        public LabelList LabelBlackList { get => labelBlackList; set => labelBlackList = value; }
        public LabelList LabelWhitelist { get => labelWhitelist; set => labelWhitelist = value; }

        public string SupportIssueLabel = "Support: Requested";
        public string StaleSupportIssueLabel = "Suport: Stale";

        public string SolvedSupportIssueLabel = "Support: Provided";

        public string LostIssueLabel = "Support: Issue Was Lost";

        public System.TimeSpan DesiredResponseTime = System.TimeSpan.FromMinutes(2880);// 2880 minutes is 48 hours is 2 days
        public System.TimeSpan AbandonedByAuthor =  System.TimeSpan.FromMinutes(10080); // 10080 miutes is 7 days
        public System.TimeSpan AbandonedBySystem =  System.TimeSpan.FromMinutes(10080); // 10080 minutes is 7 days
        public System.TimeSpan Lost = System.TimeSpan.FromMinutes(30240); //30240 minutes is 21 days
    

    }
}