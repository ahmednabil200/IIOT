# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY IiotApis/*.csproj ./IiotApis/
COPY IiotApi.Tests/*.csproj ./IiotApi.Tests/
COPY IiotDomain/*.csproj ./IiotDomain/
COPY IiotInfrastructure/*.csproj ./IiotInfrastructure/
COPY IiotApplication/*.csproj ./IiotApplication/
COPY IiotContract/*.csproj ./IiotContract/
RUN dotnet restore 

# Copy everything else and build
COPY . ./
#
WORKDIR /app/IiotApis
RUN dotnet publish -c Release -o out

#
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app 
COPY --from=build-env /app/IiotApis/out ./
ENTRYPOINT ["dotnet", "IiotApi.dll"]