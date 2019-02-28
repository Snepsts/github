using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Github.Domain;
using Github.Models;
using Microsoft.AspNetCore.Mvc;

namespace Github.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly DomainService _domain = new DomainService();
        
        // GET 3 deep id search
        [HttpGet("/github/follower/{githubId}")]
        public async Task<ActionResult<IEnumerable<User>>> FindFollowersByGithubId(long githubId)
        {
            var followers = (await _domain.FindFollowersByGithubId(githubId, 3)).ToList();

            if (!followers.Any())
            {
                return new List<User> { new User { Login = "Error: User not found", Id = -1 }};
            }
            
            return followers;
        }
        
        // GET 3 deep username search
        [HttpGet("/github/followers/{username}")]
        public async Task<ActionResult<IEnumerable<User>>> FindFollowersByGithubId(string username)
        {
            var followers = (await _domain.FindFollowersByUsername(username, 3)).ToList();

            if (!followers.Any())
            {
                return new List<User> { new User { Login = "Error: User not found", Id = -1 }};
            }
            
            return followers;
        }
        
        // GET 1 deep id search
        [HttpGet("/github/singlefollower/{githubId}")]
        public async Task<ActionResult<IEnumerable<User>>> FindFollowersByGithubIdSingle(long githubId)
        {
            var followers = (await _domain.FindFollowersByGithubId(githubId, 1)).ToList();

            if (!followers.Any())
            {
                return new List<User> { new User { Login = "Error: User not found", Id = -1 }};
            }
            
            return followers;
        }
        
        // GET 1 deep username search
        [HttpGet("/github/singlefollowers/{username}")]
        public async Task<ActionResult<IEnumerable<User>>> FindFollowersByGithubIdSingle(string username)
        {
            var followers = (await _domain.FindFollowersByUsername(username, 1)).ToList();

            if (!followers.Any())
            {
                return new List<User> { new User { Login = "Error: User not found", Id = -1 }};
            }
            
            return followers;
        }
    }
}
