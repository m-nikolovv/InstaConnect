# InstaConnect

[![CI](https://github.com/m-nikolovv/InstaConnect/actions/workflows/ci.yml/badge.svg?branch=master)](https://github.com/m-nikolovv/InstaConnect/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
![.NET 10](https://img.shields.io/badge/.NET-10-512BD4)

A microservices-based social media platform for connecting and sharing content.

## Architecture

InstaConnect is made up of four independently deployable services behind an nginx gateway. Services communicate asynchronously through Kafka events.

| Service | Responsibility | Gateway route |
|---|---|---|
| **Identity** | Users, authentication (JWT + refresh tokens), email confirmation, password reset | `/identity/` |
| **Posts** | Posts, comments and likes | `/posts/` |
| **Chats** | Chats and real-time messaging (SignalR) | `/chats/` |
| **Follows** | Follower relationships and real-time follow notifications (SignalR) | `/follows/` |

Each service follows Clean Architecture, split into `Domain`, `Application`, `Infrastructure`, `Presentation` and `Events` projects, with code organised by feature. Shared building blocks live in `src/Common`.

**Tech stack:** ASP.NET Core, MediatR, FluentValidation, Mapster, MassTransit + Kafka, MongoDB, Redis, SignalR, OpenTelemetry + Serilog (Grafana LGTM), xUnit, NSubstitute, FluentAssertions, Testcontainers.

## Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [.NET SDK](https://dotnet.microsoft.com/download) matching [global.json](global.json) (only needed to build or test outside Docker)
- A [Cloudinary](https://cloudinary.com/) account
- An [Anthropic](https://platform.claude.com/) API key
- A [SendGrid](https://sendgrid.com/) account

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/m-nikolovv/InstaConnect.git
   cd InstaConnect
   ```

2. Create a `docker/.env` file from the template and fill in your values:

   ```bash
   cp docker/.env.example docker/.env
   ```

3. Start the application:

   ```bash
   docker compose -f docker/docker-compose.yml up --build
   ```

| Endpoint | URL |
|---|---|
| API gateway | http://localhost |
| Grafana (logs, traces, metrics) | http://localhost:3000 |
| Kafka (SASL/PLAIN, for local tools) | localhost:9094 |

## Development

```bash
dotnet tool restore                # install local tools (dotnet-retest, reportgenerator)
dotnet build InstaConnect.sln
dotnet test InstaConnect.sln       # integration tests need Docker running (Testcontainers)
dotnet format InstaConnect.sln     # apply code style
```

Tests are split into `*.Tests.Unit`, `*.Tests.Integration` and `*.Tests.Functional` projects per layer. Projects ending in just `.Tests` hold shared test utilities.

See [CONTRIBUTING.md](.github/CONTRIBUTING.md) for the contribution workflow.

### Kafka topics

Topics are created on first use. A consumer creates its topics with the `PartitionCount` and `ReplicationFactor` set under `KafkaConfiguration:Consumers` in its `appsettings.json`; a topic created by a producer first gets the broker defaults (`KAFKA_NUM_PARTITIONS`, `KAFKA_DEFAULT_REPLICATION_FACTOR` in `docker-compose.yml`). Keep both in sync. An existing topic is never changed, so raising its partition count means running `kafka-topics.sh --alter --partitions <n>`, which moves existing keys to new partitions.

The connection is set with `KafkaConfiguration:SecurityProtocol` and `SaslMechanism`; use `SaslSsl` to enable TLS.

## Project Structure

```text
src/
  Common/                 Shared building blocks (Domain, Application, Infrastructure, Presentation, Events)
  Services/
    Identity|Posts|Chats|Follows/
      InstaConnect.<Service>.Domain
      InstaConnect.<Service>.Application
      InstaConnect.<Service>.Infrastructure
      InstaConnect.<Service>.Presentation   (API host + Dockerfile)
      InstaConnect.<Service>.Events         (integration events published to other services)
tests/
  Common/                 Shared test utilities
  Services/<Service>/     Unit, integration and functional tests per layer
docker/
  docker-compose.yml      Local stack: infrastructure, services and gateway
  .env.example            Environment template for docker-compose.yml
  mongo/                  MongoDB init scripts
  nginx/                  API gateway configuration
.config/                  .NET local tool manifest
.github/                  CI workflows, Dependabot, issue/PR templates, contributing and security guides
```

## License

This project is licensed under the [MIT License](LICENSE).
