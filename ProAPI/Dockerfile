# Use Debian as the base image
FROM debian:12-slim

# Install dependencies
RUN apt-get update && apt-get install -y \
    wget \
    apt-transport-https \
    gnupg \
    && rm -rf /var/lib/apt/lists/*

# Install the Microsoft package signing key and add the package repository
RUN wget https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb -O packages-microsoft-prod.deb \
    && dpkg -i packages-microsoft-prod.deb \
    && rm packages-microsoft-prod.deb

# Install .NET SDK
RUN apt-get update && apt-get install -y dotnet-sdk-8.0

# Set the working directory
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the remaining source code and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Install dotnet-ef tool globally
RUN dotnet tool install --global dotnet-ef

# Add the dotnet tools to the PATH
ENV PATH="$PATH:/root/.dotnet/tools"

# Set the working directory for the runtime
WORKDIR /app/out

# Expose the port the app runs on
EXPOSE 8080

# Set the entry point for the container
ENTRYPOINT ["dotnet", "RestAPI.dll"]
