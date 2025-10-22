#!/bin/bash
cd StringAnalyzerAPI
dotnet restore
dotnet build --configuration Release
dotnet publish -c Release -o out
cd out
dotnet StringAnalyzerAPI.dll
