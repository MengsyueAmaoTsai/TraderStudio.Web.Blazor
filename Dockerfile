FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Install Dependencies
COPY ./RichillCapital.TraderStudio.Web.sln ./RichillCapital.TraderStudio.Web.csproj ./
RUN dotnet restore ./RichillCapital.TraderStudio.Web.sln 

# Build for Production
COPY . .
RUN dotnet build ./RichillCapital.TraderStudio.Web.sln -c Release --no-restore
RUN dotnet publish ./RichillCapital.TraderStudio.Web.csproj -c Release -o ./publish --no-restore --no-build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS production
WORKDIR /app

COPY --from=build /app/publish ./
EXPOSE 8080
ENTRYPOINT [ "dotnet", "RichillCapital.TraderStudio.Web.dll" ]