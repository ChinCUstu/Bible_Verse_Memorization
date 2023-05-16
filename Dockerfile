FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Bible_Verse_Memorization.csproj", "./"]
RUN dotnet restore "Bible_Verse_Memorization.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Bible_Verse_Memorization.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bible_Verse_Memorization.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bible_Verse_Memorization.dll"]
