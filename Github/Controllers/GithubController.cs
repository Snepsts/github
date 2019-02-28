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
        
        // GET 3 deep followers id search
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
        
        // GET 3 deep followers username search
        [HttpGet("/github/followers/{username}")]
        public async Task<ActionResult<IEnumerable<User>>> FindFollowersByUsername(string username)
        {
            var followers = (await _domain.FindFollowersByUsername(username, 3)).ToList();

            if (!followers.Any())
            {
                return new List<User> { new User { Login = "Error: User not found", Id = -1 }};
            }
            
            return followers;
        }
        
        // GET 1 deep followers id search
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
        
        // GET 1 deep followers username search
        [HttpGet("/github/singlefollowers/{username}")]
        public async Task<ActionResult<IEnumerable<User>>> FindFollowersByUsernameSingle(string username)
        {
            var followers = (await _domain.FindFollowersByUsername(username, 1)).ToList();

            if (!followers.Any())
            {
                return new List<User> { new User { Login = "Error: User not found", Id = -1 }};
            }
            
            return followers;
        }

        // GET 3 deep repos id search
        [HttpGet("/github/repo/{githubId}")]
        public async Task<ActionResult<IEnumerable<Repo>>> FindReposByGithubId(long githubId)
        {
            var repos = (await _domain.FindReposByGithubId(githubId, 3)).ToList();

            if (!repos.Any())
            {
                return new List<Repo> { new Repo { Name = "Error: User not found", Id = -1 }};
            }
            
            return repos;
        }
        
        // GET 3 deep repos username search
        [HttpGet("/github/repos/{username}")]
        public async Task<ActionResult<IEnumerable<Repo>>> FindReposByUsername(string username)
        {
            var repos = (await _domain.FindReposByUsername(username, 3)).ToList();

            if (!repos.Any())
            {
                return new List<Repo> { new Repo { Name = "Error: User not found", Id = -1 }};
            }
            
            return repos;
        }
        
        // GET 1 deep repos id search
        [HttpGet("/github/singlerepo/{githubId}")]
        public async Task<ActionResult<IEnumerable<Repo>>> FindReposByGithubIdSingle(long githubId)
        {
            var repos = (await _domain.FindReposByGithubId(githubId, 1)).ToList();

            if (!repos.Any())
            {
                return new List<Repo> { new Repo { Name = "Error: User not found", Id = -1 }};
            }
            
            return repos;
        }
        
        // GET 1 deep repos username search
        [HttpGet("/github/singlerepos/{username}")]
        public async Task<ActionResult<IEnumerable<Repo>>> FindReposByUsernameSingle(string username)
        {
            var repos = (await _domain.FindReposByUsername(username, 1)).ToList();

            if (!repos.Any())
            {
                return new List<Repo> { new Repo { Name = "Error: User not found", Id = -1 }};
            }
            
            return repos;
        }
    }
}
