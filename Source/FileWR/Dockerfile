FROM microsoft/dotnet:1.0.1-core
ENTRYPOINT dotnet FileWR.dll
ARG source=.
WORKDIR /app
EXPOSE 80
COPY /app /app
