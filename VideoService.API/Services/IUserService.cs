using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoService.API.Dtos;
using VideoService.Data.Entities;

namespace VideoService.API.Services
{
    public interface IUserService
    {
        List<VideoViewModel> GetUserVideos(int userId, PriorityDto priority);
        
        List<PathViewModel> GetPaths(int userId, int videoId, PriorityDto priority);

        public List<User> GetUsers();
    }
}
