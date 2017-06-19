# Introduction
Test repository created to enable testing of .NET Core memory consumption while uploading a file. In order to allow large file uploads, I have included configuration for Kestrel and IIS Express.

# Usage
Use like this: http://localhost:62774/api/test/UploadFile

# Results
Uploading a 190 MB tiff file:

Visual Studio 2017 (Release): Start 98 MB memory - End 1009,2 MB memory. 
Task Manager (dotnet.exe): Start 18 MB memory - End 664,6 MB memory
