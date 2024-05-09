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

### Development

```bash
dotnet watch run

```

### Production

```bash
dotnet ./publish/RichillCapital.TraderStudio.dll
```

### Docker Run

```bash
docker run -d -it -p 9998:8080 --restart=always --name trader-studio-web trader-studio-web:latest
```

Visit <https://localhost:9998> or <http://localhost:10998>

Visit demo site <https://trader-studio.richillcapital.com>
