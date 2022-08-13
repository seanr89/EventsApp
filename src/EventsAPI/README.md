useful link here: [link](https://geshan.com.np/blog/2021/12/docker-postgres/)

## Postgres - Docker

First run cmd `docker pull postgres`

### 1. Create a folder in a known location for you

`mkdir ${HOME}/postgres-data/`

### 2. run the postgres image

`docker run -d --name dev-postgres -e POSTGRES_PASSWORD=Pass2020! -v ${HOME}/postgres-data/:/var/lib/postgresql/data -p 5432:5432 postgres`
or:
`docker run --name basic-postgres --rm -e POSTGRES_USER=postgres_user -e POSTGRES_PASSWORD=4y7sV96vA9wv46VR -e PGDATA=/var/lib/postgresql/data/pgdata -v /tmp:/var/lib/postgresql/data -p 5432:5432 -it postgres`

1. First, the name basic-posgres is given to the running container, and --rm will clean up the container and remove the file system when the container exits. Some environment variables have been added to make things easier.

2. The last 3 parameters are interesting, -v adds a volume to store data, for this example, it has been mapped to /tmp so all data will be lost when the machine restarts. Next, we use the -p parameter to map the host port 5432 to the container port 5432.

3. The last parameter to the command is -it to have the tty available. When we run the command we will see an output like the below:

### 3. check that the container is running

run `docker ps`

### 4. Spin down container

run `docker stop <container>`

## Docker Build and Push Steps

run `docker build -t eventsapi .`

## Run container
run `docker run -d -p 8080:80 --name myapi eventsapi`

### Docker Compose

run `docker-compose up -d`
or `docker compose -f docker-compose.dev.yml up -d`
postgres only `docker compose -f docker-compose.post.yml up -d`
for scaling use: `docker-compose up --scale web=4 --build`. This will scale out 4 implementations of the web items

# Postgres Migrations

run the following command to create a DB migration (N.B. as context etc is all here we dont need to worry too much)

```
dotnet ef migrations add <name> --context ApplicationContext
```
