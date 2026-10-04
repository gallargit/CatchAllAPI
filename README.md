# CatchAllAPI
A small ASP.NET API that catches all kind of requests (GET, POST, PUT, DELETE, etc.) across any route, and then return success (200); built on .NET 4.8 platform

## Requirements

- .NET 4.8 SDK

## Set up in IIS
- Right click project file, select "Web" tab, go down to "Servers".
- In the "Project Url" box type: http://localhost/CatchAllAPI
- Click on "Create Virtual Directory"

## Run the application
- Any URL located under http://localhost/CatchAllAPI will be handled and will return success, you can customize specific URLs at the "CatchAll()" function.

## Examples
```sh
curl -i http://localhost/CatchAllAPI/demo/route?dummyparam=1
curl -i http://localhost/CatchAllAPI/dummyjson/
curl -i http://localhost/CatchAllAPI/demo/other
curl -i -X POST http://localhost/CatchAllAPI/ -H "Content-Type: text/json" --data "{id:1}"
curl -i -X PUT "http://localhost/CatchAllAPI/whatEver?xx=1" --data "update-me"
curl -i -X DELETE http://localhost/CatchAllAPI/blahblah/CatXXX
```
