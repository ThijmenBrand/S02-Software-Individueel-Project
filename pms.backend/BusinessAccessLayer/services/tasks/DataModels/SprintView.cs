namespace BusinessLayer.services.tasks.DataModels
{
    public class Item
    {
        public Item(int id, DateTime start, DateTime end)
        {
            this.id = id;
            group = id;
            this.start = start;
            this.end = end;
        }

        public int id { get; set; }
        public int group { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }

    public class Group
    {
        public Group(int id, string content)
        {
            this.id = id;
            this.content = content;
        }

        public int id { get; set; }
        public string content { get; set; }
    }
    public class SprintView
    {
        public SprintView(Group group, Item item)
        {
            this.group = group;
            this.item = item;
        }
        public Group group { get; set; }
        public Item item { get; set; }
    }
}
