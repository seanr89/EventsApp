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

## Docker Build and Push Steps

run `docker build -t docnetpost .`

### Docker Compose

run `docker-compose up -d`

# Postgre Migrations

run cmd

```

```
