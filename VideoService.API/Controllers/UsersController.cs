using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoService.API.Dtos;
using VideoService.API.Services;
using VideoService.Data.Entities;

namespace VideoService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{userId}/videos")]
        public IEnumerable<VideoViewModel> GetUserVideos(int userId, PriorityDto priority)
        {
            var result = _userService.GetUserVideos(userId, priority);
            return result;
        }

        [HttpGet("{userId}/videos/{videoId}/paths")]
        public IEnumerable<PathViewModel> GetUserPaths(int userId, int videoId, PriorityDto priority)
        {
            var result = _userService.GetPaths(userId, videoId, priority);
            return result;
        }
        //
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            var result = _userService.GetUsers();
            return result;
        }
    }
}
