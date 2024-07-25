#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UserService/BlazorSozluk.Projections.User.csproj", "UserService/"]
COPY ["src/Common/BlazorSozluk.Common/BlazorSozluk.Common.csproj", "src/Common/BlazorSozluk.Common/"]
RUN dotnet restore "UserService/BlazorSozluk.Projections.User.csproj"
COPY . .
WORKDIR "/src/UserService"
RUN dotnet build "BlazorSozluk.Projections.User.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorSozluk.Projections.User.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlazorSozluk.Projections.User.dll"]