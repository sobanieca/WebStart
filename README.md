WebStart
========

WebStart is a simple bootstrapper for ASP.NET MVC applications that allows to simplify any startup tasks by creating new class under "App_Start" folder. Each class needs to inherit from Config class.


Instructions
------------
1. Obtain WebStart via NuGet to your ASP.NET MVC project.

PM> Install-Package WebStart

2. Create a new config, say "MyStartupConfig.cs", under App_Start folder.

3. Make it inheriting from Config class: "public class MyStartupConfig : Config"

4. Implement abstract method "Setup()" - it is going to be executed when your MVC application starts.


Remarks
-------

1. Config class contains following virtual methods/properties:

a) Priority - you can explicitly provide a priority of startup task. Default is Normal
b) AttachEventHandlers(HttpApplication context) - you can attach events handlers like BeginRequest, EndRequest here
c) Setup() - task executed after Application_Start() method
d) Shutdown() - task executed when application is being disposed.
