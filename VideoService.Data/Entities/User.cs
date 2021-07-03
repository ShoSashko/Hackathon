using System.Collections.Generic;

namespace VideoService.Data.Entities
{
    public class User : Entity 
    {
        public List<UsersToVideos> UsersToVideos { get; set; }

        public List<UsersToGroups> UsersToGroups { get; set; }

        public List<UsersToFlows> UsersToFlows { get; set; }

    }
}
