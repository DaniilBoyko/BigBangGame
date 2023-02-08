# BigBangGame

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
