# BigBangGame

The repo contains implementation of the game from the “The Big Bang Theory” called Rock, Paper, Scissors, Lizard, Spock.

## Implemented items:

&#9989; Implement game server

&#9989; A scoreboard with the 10 most recent results

&#9989; Allow the scoreboard to be reset

&#9989; Provide a Dockerfile to run a containerized version of your service

&#10060; Implement moder UI 

&#10060; Allow multiple users to play on the same service



# Running and Testing Locally

### Pre-reqs

- Be using Linux, WSL or MacOS, with bash, make etc
- [.NET 6](https://docs.microsoft.com/en-us/dotnet/core/install/linux) - for running locally, linting, running tests etc
- [Docker](https://docs.docker.com/get-docker/) - for running as a container, or image build and push

Clone the project to any directory where you do development work

```
git clone https://github.com/DaniilBoyko/BigBangGame.git
```


# Containers

Go to the ./BigBangGame folder and run

```bash
docker compose up -d
```

Enter http://localhost:8000/swagger in a browser to see the application running


# Local Running

## BigBangGame.Server Running

Go to the ./BigBangGame/BigBangGame.Server folder and run

```bash
dotnet run
```

Enter http://localhost:5095/swagger in a browser to see the application running
