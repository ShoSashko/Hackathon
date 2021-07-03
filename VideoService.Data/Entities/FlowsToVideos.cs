namespace VideoService.Data.Entities
{
    public class FlowsToVideos
    {
        public int FlowId { get; set; }

        public Flow Flow { get; set; }

        public int VideoId { get; set; }

        public Video Video { get; set; }
    }
}
