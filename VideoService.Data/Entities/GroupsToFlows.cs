namespace VideoService.Data.Entities
{
    public class GroupsToFlows
    {
        public int GroupId { get; set; }

        public Group Group { get; set; }

        public int FlowId { get; set; }

        public Flow Flow { get; set; }

        public Priority Priority { get; set; }
    }
}
