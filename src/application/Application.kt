package rocks.snepsts.github

import io.ktor.application.*
import io.ktor.response.*
import io.ktor.request.*
import io.ktor.features.*
import io.ktor.client.*
import io.ktor.client.engine.apache.*
import io.ktor.client.features.json.*
import io.ktor.client.request.*
import io.ktor.http.HttpHeaders
import io.ktor.http.HttpMethod
import io.ktor.routing.get
import io.ktor.routing.routing
import java.net.URL
import kotlinx.coroutines.*
import io.ktor.gson.*

import domain.*
import models.*

fun main(args: Array<String>): Unit = io.ktor.server.netty.EngineMain.main(args)

@Suppress("unused") // Referenced in application.conf
@kotlin.jvm.JvmOverloads
fun Application.module(testing: Boolean = false) {
    install(CORS) {
        method(HttpMethod.Options)
        method(HttpMethod.Put)
        method(HttpMethod.Delete)
        method(HttpMethod.Patch)
        header(HttpHeaders.Authorization)
        header("MyCustomHeader")
        allowCredentials = true
        anyHost() // @TODO: Don't do this in production if possible. Try to limit it.
    }

    install(ContentNegotiation) {
        gson {
        }
    }

    val baseUrl: String = "/github"

    routing {
        get("$baseUrl/") {
            call.respond(mapOf("test" to "success!"))
        }

        get("$baseUrl/followers/{username}") {
            val username = call.parameters["username"]
            var users: List<User> = listOf()

            if (username != null) {
                users = findFollowersByUsername(username)
            }

            if (users.any()) {
                call.respond(users)
            } else {
                call.respond(mapOf("error" to "no user found by the given username: $username"))
            }
        }
    }

}
