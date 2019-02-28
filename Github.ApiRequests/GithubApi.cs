using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Github.Models;
using Newtonsoft.Json;

namespace Github.ApiRequests
{
    public class GithubApi
    {
        private readonly string _baseUrl = "https://api.github.com";
        private readonly HttpClient _client = new HttpClient();

        public GithubApi()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        }

        public async Task<IEnumerable<User>> FindFiveFollowersByGithubId(long githubId)
        {
            var uri = new Uri($"{_baseUrl}/user/{githubId.ToString()}/followers");
            var response = await _client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(responseString);

            var ret = JsonConvert.DeserializeObject<List<User>>(responseString);

            while (ret.Count > 5)
            {
                ret.RemoveAt(5); // remove 6th entries until there are five
            }

            return ret;
        }
        
        public async Task<IEnumerable<User>> FindFiveFollowersByUsername(string username)
        {
            var uri = new Uri($"{_baseUrl}/users/{username}/followers");
            var response = await _client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(responseString);

            var ret = JsonConvert.DeserializeObject<List<User>>(responseString);

            while (ret.Count > 5)
            {
                ret.RemoveAt(5); // remove 6th entries until there are five
            }
            
            return ret;
        }

        public async Task<IEnumerable<Repo>> FindThreeReposByGithubId(long githubId)
        {
            var uri = new Uri($"{_baseUrl}/user/{githubId.ToString()}/repos");
            var response = await _client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(responseString);

            var ret = JsonConvert.DeserializeObject<List<Repo>>(responseString);

            while (ret.Count > 3)
            {
                ret.RemoveAt(3); // remove 4th entries until there are three
            }
            
            return ret;
        }
        
        public async Task<IEnumerable<User>> FindThreeStargazersByRepoAndUsername(string repo, string username)
        {
            var uri = new Uri($"{_baseUrl}/repos/{username}/{repo}/stargazers");
            var response = await _client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(responseString);

            var ret = JsonConvert.DeserializeObject<List<User>>(responseString);

            while (ret.Count > 3)
            {
                ret.RemoveAt(3); // remove 4th entries until there are three
            }
            
            return ret;
        }
        
        public async Task<IEnumerable<Repo>> FindThreeReposByUsername(string username)
        {
            var uri = new Uri($"{_baseUrl}/users/{username}/repos");
            var response = await _client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(responseString);

            var ret = JsonConvert.DeserializeObject<List<Repo>>(responseString);

            while (ret.Count > 3)
            {
                ret.RemoveAt(3); // remove 4th entries until there are three
            }
            
            return ret;
        }

        public async Task<User> FindUserByGithubId(long githubId)
        {
            var uri = new Uri($"{_baseUrl}/user/{githubId.ToString()}");
            var response = await _client.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            var ret = JsonConvert.DeserializeObject<User>(responseString);

            return ret;
        }
    }
}