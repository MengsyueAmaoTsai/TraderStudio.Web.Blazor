# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
COPY . ./

RUN dotnet restore
RUN dotnet build -c Release 
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

COPY --from=build /app/out .

RUN apt-get update && \
    apt-get install -y openssl

RUN mkdir /app/ssl
RUN openssl req -x509 -nodes -days 365 -newkey rsa:2048 \
    -keyout /app/ssl/key.pem -out /app/ssl/cert.pem \
    -subj "/C=US/ST=YourState/L=YourCity/O=YourOrganization/CN=yourdomain.com"

ENV CERTIFICATE_PATH=/app/ssl/cert.pem
ENV PRIVATE_KEY_PATH=/app/ssl/key.pem

ENV ASPNETCORE_Kestrel__Certificates__Default__Path=${CERTIFICATE_PATH}
ENV ASPNETCORE_Kestrel__Certificates__Default__KeyPath=${PRIVATE_KEY_PATH}
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=https://+:443;http://+:80


ENTRYPOINT [ "dotnet", "RichillCapital.TraderStudio.Web.dll" ]