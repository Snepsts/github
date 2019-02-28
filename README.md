# github
### By: Michael Ranciglio
#### Overview:
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
Something with the ktor AND C# HttpClient does not receive the object from github correctly. I cannot figure it out, but I think it has something to do with calling an https endpoint from my http endpoints and other complicated things I do not fully understand.

Here is a sample json object of the request from this api's http client:

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

I will continue to explore this issue but I don't think it's a critical issue as the api still retrieves the users, just not all of their data. If anybody knows what is wrong and feels like sharing I would love to hear the solution.

#### How to run:
I was originally going to set this up on my vps but seeing as I have never deployed my own .NET Core API on it before it'd probably be more trouble than it's worth given the time I wish to have this completed by.

So here's my how to run, I can only confirm this works on Ubuntu 18.04 running a copy of Rider from JetBrains. If you use other environments your results may vary (although I imagine Windows will be fine)

##### Dependencies:
.NET Core 2.1: [Download](https://dotnet.microsoft.com/download/dotnet-core/2.1)

Some kind of IDE to run this in since I do not have binaries provided.

CLI for git (assuming you do not already have it):
  - Windows: [Download](https://git-scm.com/download/win)
  - Linux: install from your package manager, assuming you're running Debian/Ubuntu you'd run this command: `sudo apt install git`

I think it's a safe bet if you're running something other than that you'll either already have it installed or will understand the instructions provided already well enough.

##### Downloading & Running:
- Paste this in your terminal: `git clone https://github.com/Snepsts/github.git`

- Open your IDE of choice (Visual Studio or Rider) and open the sln in the folder it ends up in (should be in a folder called `github` in your terminal's current working directory)

- Attempt to do a build. If it fails do a clean and rebuild.

- Run it either in debug or release mode.

- Open a web browser and access the above mentioned endpoints in this readme.

- Upon satistfaction (or dissatistfaction) that the endpoints return the data wished for, stop the application.

That should be about it. If you have any additional issues running the application feel free to reach out to me.

##### About
This project is licensed under the MIT license.

Copyright 2019 Michael Ranciglio



Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Thank you.
