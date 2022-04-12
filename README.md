# Online Marker Service

## Prerequisite
1. Make sure you have git installed - https://git-scm.com/book/en/v2/Getting-Started-Installing-Git
2. Make sure you have Visual Studio installed
3. Make sure you have .NET 6.0 installed

## CLI Approach
1. Clone repository - ```git clone https://github.com/rantifamilusi/ubt-online-marker.git```
2. cd into OnlineMarker.Api 
3. Update appsettings connection string (OnlineMarkerConnection) to point to local database
4. run ```dotnet run```
5. Click on URL shown in command line e.g. http://localhost:5098
6. Add ```/swagger``` to the end of URL to show Open Api Spec
7. Try the services


## Visual Studio Approach
1. Clone repository - ```git clone https://github.com/rantifamilusi/ubt-online-marker.git```
2. Open OnlineMarker.sln in Visual Studio
3. Expland OnlineMarker.Api
4. Update appsettings connection string (OnlineMarkerConnection) to point to local database
5. Set OnlineMarker.Api as Start Up Project
6. Run API
7. Try the services
