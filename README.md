[![Test](https://github.com/supermomonga/MoEmbed/actions/workflows/test.yaml/badge.svg)](https://github.com/supermomonga/MoEmbed/actions/workflows/test.yaml)

# MoEmbed

MoEmbed is a embed data provider which supports any websites.

# Features and concepts

- Proxying ... Proxy to known websites' oEmbed endpoint. (like Twitter, YouTube, etc...)
- Converting ... Convert proxied oEmbed response to more slim ones. (Replace iframe and JavaScript to simple and lightweight HTML)
- Every URL ... Support any website even if they don't provide oEmbed endpoint. It parses `og:title`, `og:image`, `<title>` tag, and other related elements.
- Caching ... It caches responses for performance.
- Easy use ... Just pass an URL encoded url as a `url` query string, like `http://localhost:5000/?url=https%3A%2F%2Fexample.com%2F`.

# EmbedData data structure

(TBD)

# How to use

## Installation

## Docker

```sh
docker build . -f MoEmbed.App/Dockerfile -t moembed:latest
docker run --rm -it -p 5000:5000 moembed:latest
```

## Requirements

- Redis
- `dotnet tool install --global dotnet-script --version 1.4.0`

## Setup

(TBD)

## Update OEmbed metadata providers

```
cd MoEmbed.CodeGeneration
dotnet script OEmbedProxyMetadataProviders.csx
```

# License

MIT License
