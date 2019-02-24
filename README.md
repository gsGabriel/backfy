# Backfy

[![Build status](https://ci.appveyor.com/api/projects/status/vjta45h76s70l2mg?svg=true)](https://ci.appveyor.com/project/gsGabriel/backfy)

Músicas + dinheiro de volta :D

## Passos iniciais

Essas são as instruções para executar a aplicação sem a dependêcia do visual studio.

### Configuração da aplicação

Devido a dependência com o spotify, é necesário realizar a configuração do clientId e do clientSecret, para isso é necessário ir no diretorio src\Backfy.Api\ e alterar o arquivo appsettings.json. Segue um exemplo do código com a configuração.

```json
"Spotify": {
    "clientId": "<clientid>",
    "clientSecret": "<clientsecret>"
  },
```

### Pré-Requisitos docker

É necessário ter o docker instalado e rodando em sua máquina, caso não tenha siga as instruções contidas no link abaixo

* [Windows](https://docs.docker.com/windows/started)
* [OS X](https://docs.docker.com/mac/started/)
* [Linux](https://docs.docker.com/linux/started/)

#### Executando com DockerFile

Para executar a aplicação utilizando o dockerfile execute os comandos abaixo na raiz do repositório

```shell
docker build -t backfy/api .
docker run -d -p 88:80 backfy/api
```

### Pré-Requisitos Docker-Compose

É necessário ter o docker-compose instalado, caso não tenha siga as instruções contidas no link abaixo

* [Instalação](https://docs.docker.com/compose/install/)

#### Executando com Docker-Compose

Para executar a aplicação utilizando o compose execute os comandos abaixo na raiz do repositório

```shell
ddocker-compose up
```

### Pré-Requisitos dotnet CLI

É necessário ter o .net core 2.2 SDK instalado em sua máquina, caso não tenha siga as instruções contidas no link abaixo

* [Download](https://dotnet.microsoft.com/download/dotnet-core/2.2)

#### Executando com dotnet CLI

Para executar a aplicação utilizando o .net core cli execute os comandos abaixos na raiz do repositório

```shell
cd src\Backfy.Api
dotnet restore
dotnet run
```

## Testes

A aplicação está documentada seguindo a especificação do Swagger, os testes poderão ser realizados acessando a url /swagger. Além disso, foi desenvolvido testes de unidade, para executá-los sem a dependência do visual studio siga os passos abaixo:

### Pré-Requisitos dotnet CLI

É necessário ter o .net core 2.2 SDK instalado em sua máquina, caso não tenha siga as instruções contidas no link abaixo

* [Download](https://dotnet.microsoft.com/download/dotnet-core/2.2)

#### Executando com dotnet CLI

Para executar a aplicação utilizando o .net core cli execute os comandos abaixos na raiz do repositório

```shell
cd test
ForEach ($folder in (Get-ChildItem -Path .\ -Directory -Recurse -Filter *.Tests)) {dotnet test $folder.FullName}
```
