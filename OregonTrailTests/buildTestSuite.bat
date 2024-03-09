@echo off
setlocal

cd "C:\Users\nguye\source\repos\OregonTrailTesting\OregonTrailTests"
git pull
dotnet build
dotnet test

cls
echo Compiling C# file...
csc.exe /out:sendTestResults.exe sendTestResults.cs
echo Running C# executable...
sendTestResults.exe

endlocal