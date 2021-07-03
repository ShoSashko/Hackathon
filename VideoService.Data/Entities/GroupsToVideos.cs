namespace VideoService.Data.Entities
{
    public class GroupsToVideos
    {
        public int GroupId { get; set; }

        public Group Group { get; set; }

        public int VideoId { get; set; }

        public Video Video { get; set; }

        public Priority Priority { get; set; }
    }
}
