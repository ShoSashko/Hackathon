namespace VideoService.Data.Entities
{
    public class UsersToFlows
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int FlowId  { get; set; }

        public Flow Flow { get; set; }

        public Priority Priority { get; set; }
    }
}
