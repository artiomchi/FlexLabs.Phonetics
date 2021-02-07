FROM mcr.microsoft.com/dotnet/core/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/core/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["FlexLabs.Phonetics/FlexLabs.Phonetics.csproj", "FlexLabs.Phonetics/"]
RUN dotnet restore "FlexLabs.Phonetics/FlexLabs.Phonetics.csproj"
COPY . .
WORKDIR "/src/FlexLabs.Phonetics"
RUN dotnet build "FlexLabs.Phonetics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FlexLabs.Phonetics.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FlexLabs.Phonetics.dll"]