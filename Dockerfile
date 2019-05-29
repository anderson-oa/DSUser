FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/DSUser.Api/DSUser.Api.csproj", "src/DSUser.Api/"]
#RUN dotnet restore "src/DSUser.Api/DSUser.Api.csproj"
COPY . .
WORKDIR "/src/src/DSUser.Api"
#RUN dotnet build "DSUser.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DSUser.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DSUser.Api.dll"]
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet DSUser.Api.dll