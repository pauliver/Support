namespace Support
{
    public abstract class BaseList
    {
        enum ListUsage
        {
            WhiteList,
            BlackList,
            Undefined
        }
        
        private ArrayList list;
        
        public ArrayList List { get => list; set => list = value; }
        private ListUsage ListUsage { get => listUsage; set => listUsage = value; }

        private ListUsage listUsage;

        abstract public BaseList(ListUsage ListType)
        {
            this.listUsage = ListType;
        }
    }
}