# ===============================
# Build Stage
# ===============================
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# copy project file(s) และ restore dependencies
COPY ["WebApplication122222.csproj", "./"]
RUN dotnet restore "WebApplication122222.csproj"

# copy source code ทั้งหมดและ build/publish
COPY . .
RUN dotnet publish "WebApplication122222.csproj" -c Release -o /app/publish

# ===============================
# Runtime Stage
# ===============================
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# copy output จาก build stage
COPY --from=build /app/publish/ .

# expose port ของ API
EXPOSE 80
EXPOSE 443

# entrypoint
ENTRYPOINT ["dotnet", "WebApplication122222.dll"]
