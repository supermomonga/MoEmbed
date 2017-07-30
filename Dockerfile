FROM microsoft/dotnet:1.1.2-sdk

WORKDIR /usr/src/

# Install dependencies for layer cache
COPY ./MoEmbed.sln                            ./MoEmbed.sln
COPY ./MoEmbed.App/MoEmbed.App.csproj         ./MoEmbed.App/MoEmbed.App.csproj
COPY ./MoEmbed.Core/MoEmbed.Core.csproj       ./MoEmbed.Core/MoEmbed.Core.csproj
COPY ./MoEmbed.Tests/MoEmbed.Tests.csproj     ./MoEmbed.Tests/MoEmbed.Tests.csproj
COPY ./MoEmbed.Twitter/MoEmbed.Twitter.csproj ./MoEmbed.Twitter/MoEmbed.Twitter.csproj
RUN dotnet restore

# Copy entire source code
COPY ./MoEmbed.App     ./MoEmbed.App
COPY ./MoEmbed.Core    ./MoEmbed.Core
COPY ./MoEmbed.Tests   ./MoEmbed.Tests
COPY ./MoEmbed.Twitter ./MoEmbed.Twitter

# Build app
WORKDIR /usr/src/MoEmbed.App
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:1.1.2-runtime
WORKDIR /usr/app
COPY --from=0 /usr/src/MoEmbed.App/out/ .
CMD dotnet ./MoEmbed.App.dll
