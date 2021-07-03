namespace VideoService.Data.Entities
{
    public class UsersToGroups
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
