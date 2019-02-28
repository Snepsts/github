using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Github.ApiRequests;
using Github.Models;

namespace Github.Domain
{
    public class DomainService
    {
        private readonly GithubApi _api = new GithubApi();

        /// <summary>
        /// Finds five followers per githubId per run. I.e: if runs is set to 1 finds 5 users that follow the initial githubId.
        /// If runs is set to 2, finds 5 users that follow the inital githubId and then 5 users that follow each of those users' githubIds.
        /// </summary>
        /// <param name="githubId"> Id that all the followers stem from </param>
        /// <param name="runs"> One-indexed value for how deep the runs go (max 3 required by project) </param>
        /// <returns> A list of users that follow the githubId, sometimes indirectly (following followers of githubId) </returns>
        public async Task<IEnumerable<User>> FindFollowersByGithubId(long githubId, int runs)
        {
            var followers = new List<User>();
            var idsToSearch = new List<long> { githubId }; // initalize with the given githubId
            
            for (int i = 0; i < runs; i++)
            {
                var followersFound = new List<User>();

                foreach (var id in idsToSearch)
                {
                    followersFound.AddRange(await _api.FindFiveFollowersByGithubId(id));
                }
                
                followers.AddRange(followersFound);

                idsToSearch = followersFound.Select(x => x.Id).ToList();
            }

            return followers;
        }
        
        /// <summary>
        /// Finds 5 followers per username per run. I.e: if runs is set to 1 finds 5 users that follow the initial username.
        /// If runs is set to 2, finds 5 users that follow the inital username and then 5 users that follow each of those users' usernames.
        /// </summary>
        /// <param name="username"> username that all followers stem from </param>
        /// <param name="runs"> One-indexed value for how deep the runs go (max 3 required by project) </param>
        /// <returns> A list of users that follow the username, sometimes indirectly (following followers of the username) </returns>
        public async Task<IEnumerable<User>> FindFollowersByUsername(string username, int runs)
        {
            var followers = new List<User>();
            var loginsToSearch = new List<string> { username }; // initalize with the given githubId
            
            for (int i = 0; i < runs; i++)
            {
                var followersFound = new List<User>();

                foreach (var login in loginsToSearch)
                {
                    followersFound.AddRange(await _api.FindFiveFollowersByUsername(login));
                }
                
                followers.AddRange(followersFound);

                loginsToSearch = followersFound.Select(x => x.Login).ToList();
            }

            return followers;
        }

        /// <summary>
        /// Finds 3 repos per githubId per run. I.e: if runs is set to 1 finds 3 repos that belong to the initial githubId.
        /// If runs is set to 2, finds 3 repos that follow the initial githubId and then 3 repos that belong to each of those repos 3 stargazers.
        /// </summary>
        /// <param name="githubId"> githubId that all repos stem from </param>
        /// <param name="runs"> One-indexed value for how deep the runs go (max 3 required by project) </param>
        /// <returns> A list of repos that follow the githubId, sometimes indirectly (repos from stargazers of repos of the githubId) </returns>
        public async Task<IEnumerable<Repo>> FindReposByGithubId(long githubId, int runs)
        {
            var username = (await _api.FindUserByGithubId(githubId)).Login; // grab username

            return await FindReposByUsername(username, runs); // run like you would with usernames
        }

        /// <summary>
        /// Finds three repos per username per run. I.e: if runs is set to 1 finds 3 repos that belong to the initial username.
        /// If runs is set to 2, finds 3 repos that follow the initial username and then 3 repos that belong to each of those repos 3 stargazers.
        /// </summary>
        /// <param name="username"> username that all repos stem from </param>
        /// <param name="runs"> One-indexed value for how deep the runs go (max 3 required by project) </param>
        /// <returns> A list of repos that follow the username, sometimes indirectly (repos from stargazers of repos of the username) </returns>
        public async Task<IEnumerable<Repo>> FindReposByUsername(string username, int runs)
        {
            var repos = new List<Repo>();
            var loginsToSearch = new List<string> {username};

            for (int i = 0; i < runs; i++)
            {
                var reposFound = new List<Repo>();

                foreach (var login in loginsToSearch)
                {
                    reposFound.AddRange(await _api.FindThreeReposByUsername(login));
                }

                loginsToSearch = new List<string>(); // reset the logins to search here
                foreach (var repo in reposFound)
                {
                    var stargazers = (await _api.FindThreeStargazersByRepoAndUsername(repo.Name, repo.Owner.Login))
                        .ToList();
                    repo.Stargazers = stargazers;
                    loginsToSearch.AddRange(stargazers.Select(x =>
                        x.Login)); // as we grab the logins, add them to the logins to be searched
                }

                repos.AddRange(reposFound);
            }

            return repos;
        }
    }
}
