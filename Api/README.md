# Steps to RUN in Development MODE

- Create a network for your development environment


```shell
docker network create docker-dotnet-reactjs-dev

```

- Create the database instance and attach to the network

```shell
docker run --name DevInstancePostgres \
    -e POSTGRES_USER=postgres \
    -e POSTGRES_PASSWORD=YourStrong@Passw0rd \
    -e POSTGRES_DB=DevDB \
    -p 5432:5432 \
    --network docker-dotnet-reactjs-dev \
    -d postgres:15
```
> The command below includes "-o 0:0" this parameter resolves a permissions issue if it appears to you, do not use it if you have no issues running MSSQl Server with the previous command

```shell
docker run --name DevInstancePostgres \
    -u 0:0 \
    -e POSTGRES_USER=postgres \
    -e POSTGRES_PASSWORD=YourStrong@Passw0rd \
    -e POSTGRES_DB=DevDB \
    -p 5432:5432 \
    --network docker-dotnet-reactjs-dev \
    -d postgres:15
```

# Runing using VSCode debug

Go TO > RUN AND DEBUG <  you will have two debug options

- Local .NET Launch
     - This option will run the API using your local .Net SDK

- Docker .NET Launch
     - This option allows you to run the API using Docker. In both cases, the system will automatically perform migrations to update the database.

##### Please remember that: 
if you make any changes to the models, you will need to create a new migration and re-run the debug process to apply the database updates.

# Running in production (using docker-compose)

after run the `docker-compose` you need access the API container and run some sommands to migrate and seed the database.

```shell
dotnet Api.dll /migrate
```

```shell
dotnet Api.dll /seed
```

# Runnig dotNet command using Docker

## Example: Add new Package

```shell
docker run --rm -v $(pwd):/app -w /app mcr.microsoft.com/dotnet/sdk:8.0 dotnet add package Npgsql
```

## Example: Executing a migration

```shell
docker run --rm -v $(pwd):/app -w /app mcr.microsoft.com/dotnet/sdk:8.0 \
    bash -c "dotnet tool install --global dotnet-ef && \
    export PATH=\"$PATH:/root/.dotnet/tools\" && \
    dotnet ef migrations add FirstMigration"
```

## Example: Executing Database Update

```shell
docker run --rm -v $(pwd):/app -w /app \
    --network docker-dotnet-reactjs-dev \
    -e ASPNETCORE_ENVIRONMENT=Development \
    -e "ConnectionStrings__DefaultConnection=Host=DevInstancePostgres;Database=DevDB;Username=postgres;Password=YourStrong@Passw0rd;Port=5432" \
    mcr.microsoft.com/dotnet/sdk:8.0 \
    bash -c "dotnet tool install --global dotnet-ef && \
    export PATH=\"\$PATH:/root/.dotnet/tools\" && \
    dotnet ef database update"
```