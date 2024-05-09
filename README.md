# RichillCapital.TraderStudio.Web

## Build & Publish

### .NET Build

```bash
dotnet cake --target publish
```

### Docker Build

```bash
docker build -t trader-studio-web:latest .
```

## Run

### Run as Development on <https://localhost:9998> or <http://localhost:10998>

```bash
dotnet watch run

```

### Run as Production on <http://localhost:5000>

```bash
dotnet ./publish/RichillCapital.TraderStudio.Web.dll
```

### Run as Docker Image on <http://localhost:9998>

```bash
docker run -d -it -p 9998:8080 --restart=always --name trader-studio-web trader-studio-web:latest
```

### Demo: <https://trader-studio.richillcapital.com>
