@echo off
setlocal

cd "C:\Users\nguye\source\repos\OregonTrailTesting\OregonTrailTests"
git pull
dotnet build
dotnet test

endlocal