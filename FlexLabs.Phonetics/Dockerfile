FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["FlexLabs.Phonetics/FlexLabs.Phonetics.csproj", "FlexLabs.Phonetics/"]
RUN dotnet restore "FlexLabs.Phonetics/FlexLabs.Phonetics.csproj"
COPY . .
WORKDIR "/src/FlexLabs.Phonetics"
RUN dotnet build "FlexLabs.Phonetics.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FlexLabs.Phonetics.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FlexLabs.Phonetics.dll"]