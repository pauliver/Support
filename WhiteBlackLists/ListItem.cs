namespace Support
{
    public class ListItem
    {
        private string name;

        private int weight;

        private int internalId;


        public int InternalId { get => internalId; set => internalId = value; }
        
        public string Name { get => name; set => name = value; }

        public int Weight { get => weight; set => weight = value; }


        public ListItem(string p_name, int p_weight, int p_internalId)
        {
            this.name = p_name;
            this.weight = p_weight;
            this.internalId = p_internalId;
        }

    }
}