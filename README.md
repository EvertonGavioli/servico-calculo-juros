# Serviço Cálculo de Juros Compostos

Api's para calcular juros compostos usando .NET Core;

# Steps

- .Net Core 5.0 SDK

```
git clone https://github.com/EvertonGavioli/servico-calculo-juros.git

cd servico-calculo-juros

dotnet restore

docker network create -d bridge sjn-network

docker-compose up

```

### Acessar Swagger pelas seguintes URL's:

---

API Calculadora Juros Compostos: http://localhost:5000/swagger/index.html

API Taxa de Juros: http://localhost:5002/swagger/index.html

---

### Acesso sem uso docker-compose

Executar 2 terminais; ou pelo Visual Studio "MultipleStartup projects"

```

cd /src/SCJ.Calculo.API
dotnet run

cd /src/SCJ.Taxa.API
dotnet run

```
