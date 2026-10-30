# Contributing to InstaConnect

## Workflow

1. Branch off `master` using the `feature/<short-description>` naming convention.
2. Make your changes, keeping each commit focused.
3. Make sure the checks below pass locally.
4. Open a pull request against `master` and fill in the template.

CI must pass (the **All Checks Passed** check) before a pull request is merged.

## Local Checks

```bash
dotnet tool restore
dotnet build InstaConnect.sln --configuration Release
dotnet format InstaConnect.sln --verify-no-changes
dotnet test InstaConnect.sln --configuration Release   # requires Docker for Testcontainers
```

The build treats warnings as errors and enforces code style, so a clean build is required.

## Conventions

- **Architecture:** each service is split into `Domain`, `Application`, `Infrastructure`, `Presentation` and `Events` projects. Dependencies point inwards (Presentation → Infrastructure → Application → Domain → Events), and each layer may also reference its `Common` counterpart.
- **Feature folders:** code is grouped by feature (`Features/<Feature>/...`), not by technical type.
- **Cross-service communication:** services never reference each other's internals. Only `<Service>.Events` projects may be shared, and communication goes through Kafka.
- **Packages:** versions are managed centrally in [Directory.Packages.props](../Directory.Packages.props). Don't add `Version` attributes to `PackageReference` items.
- **Tests:** add tests to the matching `*.Tests.Unit`, `*.Tests.Integration` or `*.Tests.Functional` project for the layer you change.
