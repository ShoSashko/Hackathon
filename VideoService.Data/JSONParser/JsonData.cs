using Newtonsoft.Json;
using System.Collections.Generic;
using VideoService.Data.Entities;

namespace VideoService.Data.JSONParser
{
    public class JsonData
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; }

        [JsonProperty("videos")]
        public List<Video> Videos { get; set; }

        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        [JsonProperty("flows")]
        public List<Flow> Flows { get; set; }

        [JsonProperty("usersToVideos")]
        public List<UsersToVideos> UsersToVideos { get; set; }

        [JsonProperty("usersToGroups")]
        public List<UsersToGroups> UsersToGroups { get; set; }

        [JsonProperty("usersToFlows")]
        public List<UsersToFlows> UsersToFlows { get; set; }

        [JsonProperty("groupsToVideos")]
        public List<GroupsToVideos> GroupsToVideos { get; set; }

        [JsonProperty("groupsToFlows")]
        public List<GroupsToFlows> GroupsToFlows { get; set; }

        [JsonProperty("flowsToVideos")]
        public List<FlowsToVideos> FlowsToVideos { get; set; }
    }
}
