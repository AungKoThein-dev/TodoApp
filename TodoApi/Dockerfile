# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

# Copy solution file first
COPY TodoApp.sln ./

# Copy project files (IMPORTANT ORDER)
COPY TodoApi/TodoApi.csproj TodoApi/
COPY Todo.Application/Todo.Application.csproj Todo.Application/
COPY Todo.Domain/Todo.Domain.csproj Todo.Domain/

# Restore dependencies
RUN dotnet restore

# Copy everything else
COPY . .

# Build and publish
RUN dotnet publish TodoApi/TodoApi.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "TodoApi.dll"]