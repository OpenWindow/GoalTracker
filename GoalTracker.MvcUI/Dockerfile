FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "GoalTracker.MvcUI.dll"]

#FROM microsoft/aspnetcore:2.0 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM microsoft/aspnetcore-build:2.0 AS build
#WORKDIR /src
#COPY Tracker.sln ./
#COPY GoalTracker.MvcUI/GoalTracker.MvcUI.csproj GoalTracker.MvcUI/
#RUN dotnet restore -nowarn:msb3202,nu1503
#COPY . .
#WORKDIR /src/GoalTracker.MvcUI
#RUN dotnet build -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "GoalTracker.MvcUI.dll"]
