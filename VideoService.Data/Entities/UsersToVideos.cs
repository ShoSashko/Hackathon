namespace VideoService.Data.Entities
{
    public class UsersToVideos
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int VideoId { get; set; }

        public Video Video { get; set; }

        public Priority Priority { get; set; }
    }
}
