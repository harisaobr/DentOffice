#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DentOffice1/DentOffice.WebAPI.csproj", "DentOffice1/"]
COPY ["DentOffice.Model/DentOffice.Model.csproj", "DentOffice.Model/"]
RUN dotnet restore "DentOffice1/DentOffice.WebAPI.csproj"
COPY . .
WORKDIR "/src/DentOffice1"
RUN dotnet build "DentOffice.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DentOffice.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DentOffice.WebAPI.dll"]