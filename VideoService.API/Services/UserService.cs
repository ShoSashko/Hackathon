using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoService.API.Dtos;
using VideoService.Data.Entities;
using VideoService.DB.Migrations.Contexts;

namespace VideoService.API.Services
{
    public class UserService : IUserService
    {
        private readonly VideoServiceDbContext _context;
        public UserService(VideoServiceDbContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            var result = _context.Users.ToList();

            return result;
        }

        public List<VideoViewModel> GetUserVideos(int userId, PriorityDto priority)
        {

            var userToVideo = _context.Users.Where(x => x.Id == userId)
                .Include(x => x.UsersToVideos)
                .ThenInclude(y => y.Video)
                .SelectMany(x => x.UsersToVideos.Select(x => new { x.Video.Name, x.Priority }))
                .ToList();

                var result = userToVideo.Select(x => new VideoViewModel(x.Name, x.Priority)).ToList();

            var userFlow = _context.Users.Where(x=>x.Id == userId)
                .Include(x=>x.UsersToFlows)
                .ThenInclude(x=>x.Flow)
                .ThenInclude(x=>x.FlowsToVideos)
                .ThenInclude(x=>x.Video)
                .SelectMany(x => x.UsersToVideos.Select(x => new { x.Video.Name, x.Priority }))
                .ToList();


            var userFlowResult = userFlow.Select(x => new VideoViewModel(x.Name, x.Priority)).ToList();

            var userGroupsVideo = _context.Users.Where(x => x.Id == userId)
              .Include(x => x.UsersToGroups)
              .ThenInclude(x => x.Group)
              .ThenInclude(x => x.GroupsToVideos)
              .ThenInclude(x => x.Video)
              .SelectMany(x => x.UsersToVideos.Select(x => new { x.Video.Name, x.Priority }))
              .ToList();

            var userGroupVideoResult = userGroupsVideo.Select(x => new VideoViewModel(x.Name, x.Priority)).ToList();

            var userGroupsFlow = _context.Users.Where(x => x.Id == userId)
              .Include(x => x.UsersToGroups)
              .ThenInclude(x => x.Group)
              .ThenInclude(x => x.GroupsToFlows)
              .ThenInclude(x => x.Flow)
              .ThenInclude(x => x.FlowsToVideos)
              .ThenInclude(x => x.Video)
              .SelectMany(x => x.UsersToVideos.Select(x => new { x.Video.Name, x.Priority }))
              .ToList();

            var userGroupFlowResult = userGroupsFlow.Select(x => new VideoViewModel(x.Name, x.Priority)).ToList();

            result.AddRange(userFlowResult);
            result.AddRange(userGroupVideoResult);
            result.AddRange(userGroupFlowResult);

            if(priority == PriorityDto.DESC)
            {
                return result.GroupBy(x => x.Name)
               .Select(x => new VideoViewModel(x.Key, x.Max(x => x.Priority)))
               .OrderByDescending(x => x.Priority)
               .ThenByDescending(x => x.Name).ToList();
            }

            return result.GroupBy(x => x.Name)
             .Select(x => new VideoViewModel(x.Key, x.Max(x => x.Priority)))
             .OrderBy(x => x.Priority)
             .ThenBy(x => x.Name).ToList();
        }

        public List<PathViewModel> GetPaths(int userId,int videoId, PriorityDto priority)
        {

            //var userToVideo = _context.Users.Where(x => x.Id == userId)
            //    .Include(x => x.UsersToVideos)
            //    .ThenInclude(y => y.Video)
            //    .SelectMany(x => x.UsersToVideos.Select(x => new { Path = $"users/{x.User.Id}/videos/{x.VideoId}", x.Priority }))
            //    .ToList();

            var userVideosPath = _context.Users.SelectMany(u =>
                u.UsersToVideos.Where(u => u.UserId == userId && u.VideoId == videoId)
                    .Select(s => new {  Path = $"users/{s.UserId}/videos/{s.VideoId}", s.Priority }))
                .ToList();


            var userFlowsPriority = _context.Users.Where(x => x.Id == userId)
                .Include(x => x.UsersToFlows).SelectMany(x=> x.UsersToFlows).Select(x=> new { x.FlowId, x.Priority });

            var videoFlows = _context.Videos.Where(x => x.Id == videoId)
                .Include(x => x.FlowsToVideos).SelectMany(x => x.FlowsToVideos).Select(x => new { x.FlowId, x.VideoId });

            var joinedVideosFlow = videoFlows.Join(userFlowsPriority, x => x.FlowId, x => x.FlowId, (x1, x2) => new { x2.Priority, userId, x1.FlowId, x1.VideoId });

            var userGroupsVideos = _context.Users.SelectMany(u => u.UsersToGroups.Where(u => u.UserId == userId).Select(s => s.GroupId)).ToList();

            var groupFlows = _context.Flows.SelectMany(x => x.GroupsToFlows.Where(f => userGroupsVideos.Contains(f.GroupId)).Select(f => new { f.Priority, f.GroupId, f.FlowId }))
                .ToList();

            var groupFlowVideos = _context.Flows.SelectMany(f =>
                f.FlowsToVideos.Where(f => groupFlows.Select(s => s.FlowId).Contains(f.FlowId))
                    .Select(s => new { s.FlowId, s.VideoId }))
                .ToList();

            var joinedFlowGroupVideos = groupFlows.Join(groupFlowVideos, s => s.FlowId, s => s.FlowId, (x1, x2) =>
            new {  Path = $"users/{userId}/groups/{x1.GroupId}/flows/{x1.FlowId}/videos/{x2.VideoId}", x1.Priority });

            var groupVideosPath = _context.Groups.SelectMany(g => g.GroupsToVideos.Where(g => g.VideoId == videoId && userGroupsVideos.Contains(g.GroupId))
                .Select(s => new { Path = $"users/{userId}/groups/{s.GroupId}/videos/{s.VideoId}", s.Priority }))
                .ToList();

            var flowsWithPath = joinedVideosFlow.Select(s => new {  Path = $"users/{userId}/flows/{s.FlowId}/videos/{s.VideoId}", s.Priority }).ToList();

            userVideosPath.AddRange(joinedFlowGroupVideos);
            userVideosPath.AddRange(flowsWithPath);
            userVideosPath.AddRange(groupVideosPath);

            if (priority == PriorityDto.DESC)
            {
                return userVideosPath.Select(s => new PathViewModel(s.Path, s.Priority)).OrderByDescending(x => x.Priority).ToList();
            }

            return userVideosPath.Select(s => new PathViewModel(s.Path, s.Priority)).OrderBy(x=>x.Priority).ToList();
        }
    }

    public class VideoViewModel
    {
        public VideoViewModel(string name, Priority priority)
        {
            Name = name;
            Priority = priority;
        }
        public string Name { get; set; }
        public Priority Priority { get; set; }
    }

    public class PathViewModel
    {
        public PathViewModel(string path, Priority priority)
        {
            Path = path;
            Priority = priority;
        }
        public string Path { get; set; }
        public Priority Priority { get; set; }
    }
}
