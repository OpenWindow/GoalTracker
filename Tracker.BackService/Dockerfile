FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "Tracker.BackService.dll"]

#FROM microsoft/aspnetcore:2.0 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM microsoft/aspnetcore-build:2.0 AS build
#WORKDIR /src
#COPY Tracker.sln ./
#COPY Tracker.BackService/Tracker.BackService.csproj Tracker.BackService/
#RUN dotnet restore -nowarn:msb3202,nu1503
#COPY . .
#WORKDIR /src/Tracker.BackService
#RUN dotnet build -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "Tracker.BackService.dll"]
#