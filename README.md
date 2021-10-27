# .NET Core Template for IAZI

## Changelog: Version 1.0.0 / 15.09.2020 / TBU

### Instructions how to handle the Service Template

1. Please replace "Service.Template" with the appropriate service name
2. Also set the right name for all project folders
3. Verify and adjust the service configuration in src/RFE.Service.FT.Web (appsettings*.json)
4. In the Core/Repository/Web src projects you can find a sample entity that is used in Service.AuthAdmin and shows the way the service has to be implemented to work with a Stored Procedure based setup
5. The same test entity is also used in the Integration Test project. The .NET Core possibility to run a in-memory based service and to execute test calls to those endpoints ensure that we test all layers
