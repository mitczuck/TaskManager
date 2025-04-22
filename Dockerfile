# The VERSION is used to declare the dotnet version and linux runtime used
ARG VERSION=8.0-alpine3.18

#--------------------------------------------------------------------------------------------------------------------------
# Construction of the building image
FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build-env
WORKDIR /app
       
# Copy Source code into a layer
COPY . .

RUN dotnet restore ./src/TaskManager.API/TaskManager.API.csproj --configfile ./Nuget.config
# Build and publish the application and dependencies, self contained with alpine runtime
RUN dotnet publish -r linux-musl-x64 --self-contained true -c Release -o ./output ./src/TaskManager.API/TaskManager.API.csproj


#--------------------------------------------------------------------------------------------------------------------------
# Construction of application image
FROM mcr.microsoft.com/dotnet/runtime-deps:$VERSION
ENV TZ=America/Sao_Paulo

WORKDIR /app

RUN apk update && apk add --no-cache icu tzdata \
    && rm -rf /var/cache/apk/* \
    && cp /usr/share/zoneinfo/${TZ} /etc/localtime \
    && echo "${TZ}" > /etc/timezone \
    && adduser --disabled-password --home /app --gecos '' apps \
    && chown -R apps:apps /app

USER apps

# Copy the publish result from the image alias build-env
COPY --from=build-env /app/output .

# Declare the environment variables required to the runtime and application
ENV URLS=http://+:4000
ENV TZ=America/Sao_Paulo
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_ENVIRONMENT=Development


# Define the required exposed ports
EXPOSE 4000

# Start process when the container start running.
ENTRYPOINT ["./TaskManager.API"]