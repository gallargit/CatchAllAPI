# CatchAllAPI
API to catch all GET, POST, PUT and DELETE calls, and then return success (200); built on .NET 4.8 platform

# Set up in IIS
- Right click project file, select "Web" tab, go down to "Servers".
- In the "Project Url" box type: http://localhost/catchall
- Click on "Create Virtual Directory"

# Run the application
- Any URL located under http://localhost/catchall will be handled and will return success, you can customize specific URLs at the "ProcessAny()" function, for example

http://localhost/catchall/demo/route?dummyparam=1
http://localhost/catchall/dummyjson/other
