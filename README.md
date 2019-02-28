# github
### By: Michael Ranciglio

#### Overview

This is an api to interact with the github api per CenturyLink's requirements for me via their test:

```
CenturyLink Coding Challenge

Overview: The purpose of this coding challenge is to test your ability to develop software for
the CenturyLink Cloud organization. For this coding challenge, you’re free to use any coding
language you’d like.

Requirements:

1. Write an API endpoint that accepts a GitHub ID and returns Follower GitHub ID’s (up to
5 Followers total) associated with the passed in GitHub ID. Retrieve data up to 3 levels
deep, repeating the process of retrieving Followers (up to 5 Followers total) for each
Follower found. Data should be returned in JSON format.

2. Code should be checked into a public GitHub repository, so that the CenturyLink team
members can review your code at any time.

3. A readme file should be included and checked into GitHub with instructions on how to
execute and test your API.

4. Bonus credit: API endpoint is publicly accessible and fully functional, so that CenturyLink
team members can execute and test your API at any time.

Bonus Challenge:
The bonus challenge NOT required!

1. Write an API endpoint that accepts a GitHub ID and retrieves the Repository names (up
to 3 Repositories total) associated with the passed in GitHub ID, along with the Stargazer
GitHub ID’s (up to 3 Stargazers total) associated with each Repository. Retrieve data up
to 3 levels deep, repeating the process of retrieving the associated Repositories (up to 3
Repositories total) for each Stargazer (up to 3 Stargazers total) found. Data should be
returned in JSON format.

2. See requirements 2, 3, and 4 above.

Tips:

1. You’ll need a GitHub account (which are free) to complete this coding challenge.

2. GitHub provides API’s for retrieving Followers, Repositories, and Stargazers. Please see
the following GitHub API documentation:

    a. https://developer.github.com/v3/users/followers/
    
    b. https://developer.github.com/v3/repos/
    
    c. https://developer.github.com/v3/activity/starring/
```

#### Endpoints:

// TODO

#### Known Issues:

Something with the ktor client does not receive the object from github correctly. I cannot figure it out, here is a sample json object of the request from this api's http client:

```json
{
  "login": "Snepsts",
  "id": 8688876,
  "node_id": "MDQ6VXNlcjg2ODg4NzY=",
  "avatar_url": "https://avatars3.githubusercontent.com/u/8688876?v=4",
  "url": "https://api.github.com/users/Snepsts",
  "html_url": "https://github.com/Snepsts",
  "followers_url": "https://api.github.com/users/Snepsts/followers",
  "following_url": "https://api.github.com/users/Snepsts/following{/other_user}",
  "gists_url": "https://api.github.com/users/Snepsts/gists{/gist_id}",
  "starred_url": "https://api.github.com/users/Snepsts/starred{/owner}{/repo}",
  "subscriptions_url": "https://api.github.com/users/Snepsts/subscriptions",
  "organizations_url": "https://api.github.com/users/Snepsts/orgs",
  "repos_url": "https://api.github.com/users/Snepsts/repos",
  "events_url": "https://api.github.com/users/Snepsts/events{/privacy}",
  "received_events_url": "https://api.github.com/users/Snepsts/received_events",
  "type": "User",
  "site_admin": false
}
```

Here is what Axios returns from a skeleton Vue project (What it should look like):

```json
{
  "login": "Snepsts",
  "id": 8688876,
  "node_id": "MDQ6VXNlcjg2ODg4NzY=",
  "avatar_url": "https://avatars3.githubusercontent.com/u/8688876?v=4",
  "gravatar_id": "",
  "url": "https://api.github.com/users/Snepsts",
  "html_url": "https://github.com/Snepsts",
  "followers_url": "https://api.github.com/users/Snepsts/followers",
  "following_url": "https://api.github.com/users/Snepsts/following{/other_user}",
  "gists_url": "https://api.github.com/users/Snepsts/gists{/gist_id}",
  "starred_url": "https://api.github.com/users/Snepsts/starred{/owner}{/repo}",
  "subscriptions_url": "https://api.github.com/users/Snepsts/subscriptions",
  "organizations_url": "https://api.github.com/users/Snepsts/orgs",
  "repos_url": "https://api.github.com/users/Snepsts/repos",
  "events_url": "https://api.github.com/users/Snepsts/events{/privacy}",
  "received_events_url": "https://api.github.com/users/Snepsts/received_events",
  "type": "User",
  "site_admin": false,
  "name": "Michael Ranciglio",
  "company": "N/A",
  "blog": "",
  "location": "St. Louis, Missouri",
  "email": null,
  "hireable": true,
  "bio": "Software Developer",
  "public_repos": 41,
  "public_gists": 0,
  "followers": 26,
  "following": 40,
  "created_at": "2014-09-07T19:59:56Z",
  "updated_at": "2019-02-28T02:54:37Z"
}
```

I will continue to explore this issue but I don't think it's a critical issue as the api still retrieves the users.

#### How to run:

// TODO
