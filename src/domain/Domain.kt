package domain

import api_request.*
import models.*

val client: GithubClient = GithubClient()

suspend fun findFollowersByUsername(username: String): List<User> {
    var followers: MutableList<User> = mutableListOf()
    var usernamesToSearchFor = mutableListOf<String>(username)

    for (count in 0..2) { // runs 3 times, like the question asked
        var followersFound: MutableList<User> = mutableListOf()

        for (username in usernamesToSearchFor) {
            followersFound.addAll(client.findUpToFiveFollowersByGithubUsername(username))
        }

        followers.addAll(followersFound) // add all to current collection

        usernamesToSearchFor = mutableListOf() // reset searchable usernames

        for (follower in followersFound) {
            if (count == 2) {
                break // optimization, don't need to run through the loop in the last run
            }

            usernamesToSearchFor.add(follower.login)
        }
    }

    return followers
}
