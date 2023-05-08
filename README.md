# C# Project Setup Cheatsheet

### New Console Project
1. Create project folder
2. cd into project folder
3. run `dotnet new console`

OR

1. create new project running `dotnet new console -o ProjectName`
2. cd into ProjectName

4. / 3. `dotnet run`

### New Web Project
1. in your project folder `dotnet new web --no-https -o FirstWeb` 
   - this creates an app that doesn't have the support for https and the security features that comes with.
2. `dotnet run` or `dotnet watch run` (which will open the port for you)
*Note: The port is randomly selected between 5000 and 5300 you can find this in the terminal but also in Properties > launchSettings.json file*