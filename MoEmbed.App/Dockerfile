#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MoEmbed.App/MoEmbed.App.csproj", "MoEmbed.App/"]
COPY ["MoEmbed.Core/MoEmbed.Core.csproj", "MoEmbed.Core/"]
COPY ["MoEmbed.Models/MoEmbed.Models.csproj", "MoEmbed.Models/"]
COPY ["MoEmbed.CodeGeneration/MoEmbed.CodeGeneration.csproj", "MoEmbed.CodeGeneration/"]
RUN dotnet restore "MoEmbed.App/MoEmbed.App.csproj"
COPY . .
WORKDIR "/src/MoEmbed.App"
RUN dotnet build "MoEmbed.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MoEmbed.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoEmbed.App.dll"]