#!/usr/bin/env bash
dotnet restore && dotnet build **/project.json
dotnet test /Source/FileWR.Tests 
dtonet test /Source/FileWR.Business.Tests