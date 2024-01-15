
# Trader Studio Web

## Description

## Development

## Deployment

```powershell
docker build -t richillcapital-trader-studio-web:latest -f Dockerfile .
```

```powershell
docker run -d -p 99:80 -p 9999:443 --name richillcapital-trader-studio-web richillcapital-trader-studio-web:latest
```

## License

This project is licensed under the [GNU General Public License (GPL) version 3.0 or later](LICENSE), see the [LICENSE](LICENSE) file for details.