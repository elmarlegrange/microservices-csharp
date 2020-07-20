# microservices-csharp
![build](https://github.com/elmarlegrange/microservices-csharp/workflows/build/badge.svg)

A simple implementation of RabbitMQ between two services (.Net Core console applications).

## Setup
- .Net Core 3.1
- RabbitMQ
- RabbitMQ Nuget package `dotnet add package RabbitMQ.Client --version 6.1.0`
- Build the apps using `dotnet build`
- Run the apps using `dotnet run`

### Project Structure

```
├── microservices-csharp.sln
├── README.md
├── Consumer.Terminal
│   ├── consumer.cs
│   ├── Consumer.Terminal.csproj
├── Producer.Terminal
│   ├── producer.cs
│   ├── producer.Terminal.csproj
├── RabbitMqHelper.Lib
│   ├── RabbitMqHelper.cs
│   ├── RabbitMqHelper.Lib.csproj
├── Utils.Lib
│   ├── Output
│       ├── consoleOutput.cs
│       ├── IOutput.cs
│   ├── Validation
│       ├── IValidation.cs
│       ├── nameValidator.cs
│   ├── Utils.Lib.csproj
```

If you have any questions or comments, please create an issue.
