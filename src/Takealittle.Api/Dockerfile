#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Takealittle.Api/Takealittle.Api.csproj", "src/Takealittle.Api/"]
COPY ["src/Takealittle.Application/Takealittle.Application.csproj", "src/Takealittle.Application/"]
COPY ["src/Takealittle.Contracts/Takealittle.Contracts.csproj", "src/Takealittle.Contracts/"]
COPY ["src/Takealittle.Domain/Takealittle.Domain.csproj", "src/Takealittle.Domain/"]
COPY ["src/Takealittle.Infrastructure/Takealittle.Infrastructure.csproj", "src/Takealittle.Infrastructure/"]
RUN dotnet restore "src/Takealittle.Api/Takealittle.Api.csproj"
COPY . .
WORKDIR "/src/src/Takealittle.Api"
RUN dotnet build "Takealittle.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Takealittle.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Takealittle.Api.dll"]