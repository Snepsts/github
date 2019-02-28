package api_request

import io.ktor.client.HttpClient
import io.ktor.client.engine.apache.Apache
import io.ktor.client.features.json.GsonSerializer
import io.ktor.client.features.json.JsonFeature
import io.ktor.client.request.get
import io.ktor.client.request.headers
import io.ktor.client.request.url
import io.ktor.http.ContentType
import io.ktor.http.contentType
import java.net.URL

import models.*

class GithubClient {
    private val httpClient: HttpClient = HttpClient {
        install(JsonFeature) {
            serializer = GsonSerializer() // allows unpacking json to kotlin object
        }
    }

    private val baseUrl: String = "https://api.github.com"

    suspend fun findUpToFiveFollowersByGithubId(githubId: Long): List<User> {
        val response = httpClient.get<List<User>> {
            url(URL("$baseUrl/user/$githubId/followers"))
            contentType(ContentType.Application.Json)
        }

        var count: Int = 0
        var users: MutableList<User> = mutableListOf() // initialize list

        for (user in response) {
            if (count == 5) { // limit to 5
                break
            }

            users.add(user)

            count++
        }

        return users
    }

    suspend fun findUpToFiveFollowersByGithubUsername(githubName: String): List<User> {
        var response: List<User>

        try {
            response = httpClient.get<List<User>> {
                url(URL("$baseUrl/users/$githubName/followers"))
                contentType(ContentType.Application.Json)
                headers { "Accept: application/vnd.github.v3+json" }
            }
        } catch (e: Exception) {
            println(e.message)
            println(e.stackTrace)
            println("$baseUrl/users/$githubName")
            return listOf()
        }

        var count: Int = 0
        var users: MutableList<User> = mutableListOf() // initialize list

        for (user in response) {
            if (count == 5) { // limit to 5
                break
            }

            users.add(user)

            count++
        }

        return users
    }
}