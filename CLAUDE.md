# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

MoEmbed is a .NET 10.0 (C#) oEmbed metadata provider service. It extracts embed data from any URL by proxying known oEmbed endpoints, parsing OpenGraph/HTML metadata as fallback, and caching results.

## Build & Test Commands

```bash
# Restore dependencies (use --locked-mode for reproducible builds)
dotnet restore --locked-mode

# Build all projects
dotnet build

# Run all tests
dotnet test --project MoEmbed.Core.Tests && dotnet test --project MoEmbed.Models.Tests

# Run a single test project
dotnet test --project MoEmbed.Core.Tests
dotnet test --project MoEmbed.Models.Tests

# Run a specific test (TUnit filter syntax)
dotnet test --project MoEmbed.Core.Tests -- --filter "/*/*/TwitterMetadataProviderTest/*"

# Alternative: run tests via dotnet run (TUnit projects are Exe)
dotnet run --project MoEmbed.Core.Tests
dotnet run --project MoEmbed.Models.Tests

# Run the application (listens on port 5000)
cd MoEmbed.App && dotnet run

# Regenerate oEmbed proxy providers from registry
cd MoEmbed.CodeGeneration && dotnet script OEmbedProxyMetadataProviders.csx
```

## Architecture

### Solution Structure

- **MoEmbed.App** - ASP.NET Core web application (Kestrel). Entry point: `Program.cs` / `Startup.cs`
- **MoEmbed.Core** - Core business logic: providers, metadata fetching, caching, HTTP handling
- **MoEmbed.Models** - Shared data models (`EmbedData`, `Media`, enums). Serializable to JSON and XML
- **MoEmbed.CodeGeneration** - Script that generates `OEmbedProxyMetadataProvider` subclasses from the `oembed/` submodule registry
- **oembed/** - Git submodule tracking [iamcal/oembed](https://github.com/iamcal/oembed) provider registry

### Request Flow

```
HTTP GET /?url=<encoded_url>&format=json
  → HttpMetadataHandler.HandleAsync()
    → MetadataService.GetDataAsync(ConsumerRequest)
      → MetadataProviderCollection.GetByHost() // host-specific provider lookup
        → IMetadataProvider.GetMetadata() → Metadata object
          → Metadata.FetchAsync(RequestContext) → EmbedData
            → Cache result → IResponseWriter → JSON/XML response
```

### Provider System

Providers implement `IMetadataProvider`. The collection is split into host-specific providers (looked up by domain) and host-agnostic fallback providers.

**Types of providers:**
- **Auto-generated** (`MoEmbed.Core/Providers/Generated Codes/`) - OEmbed proxy providers generated from registry YAML
- **Custom** - Site-specific providers with special handling (Twitter, Amazon, Imgur, Mastodon, Niconico, Pixiv, Gyazo)
- **Fallback** - `UnknownMetadataProvider` parses og:tags and HTML for any URL without a dedicated provider

### Metadata Classes

Each provider returns a `Metadata` subclass (in `MoEmbed.Core/Models/`) with an async `FetchAsync()` method that performs the actual HTTP request and returns `EmbedData`. Key subclasses: `OEmbedProxyMetadata`, `TwitterMetadata`, `TwitterExperimentalMetadata`, `AmazonMetadata`, `UnknownMetadata`.

## Code Style

- 4-space indentation for C# (enforced by `.editorconfig`)
- TUnit for testing with `[Test]` and `[Arguments]` patterns (async Task return type)
- Tests requiring API keys use `dotnet user-secrets` (see `MoEmbed.Core.Tests/README.md`)
