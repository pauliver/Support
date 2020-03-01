using System;
using System.Collections;


namespace Support
{

    public enum ListUsage
    {
        WhiteList,
        BlackList,
        Undefined
    }

    public abstract class BaseList
    {
        
        protected ArrayList list;
        protected ListUsage listUsage;
        
        public ArrayList List { get => list; set => list = value; }
        public ListUsage ListUsage { get => listUsage; set => listUsage = value; }


        public BaseList(ListUsage ListType)
        {
            this.listUsage = ListType;
        }
    }
}