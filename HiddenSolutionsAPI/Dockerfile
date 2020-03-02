FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY HiddenSolutionsAPI.csproj ./
RUN dotnet restore "HiddenSolutionsAPI.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "HiddenSolutionsAPI.csproj" -c Release -o /app/build
RUN dotnet publish "HiddenSolutionsAPI.csproj" -c Release -o /app/publish


# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://*:$PORT

#ENTRYPOINT ["dotnet", "HiddenSolutionsAPI.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT ASPNETCORE_ENVIRONMENT=Development dotnet HiddenSolutionsAPI.dll