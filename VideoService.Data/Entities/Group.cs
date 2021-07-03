using System.Collections.Generic;

namespace VideoService.Data.Entities
{
    public class Group : Entity 
    {
        public List<UsersToGroups> UsersToGroups { get; set; }

        public List<GroupsToVideos> GroupsToVideos { get; set; }

        public List<GroupsToFlows> GroupsToFlows { get; set; }
    }
}
