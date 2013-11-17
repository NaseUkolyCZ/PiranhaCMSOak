PiranhaCMSOak
=============

Quickly create beautiful web applications on the latest technologies: Microsoft .NET 4.5, ASP.NET MVC 4, Oak and Piranha CMS.

To download see https://www.nuget.org/packages/PiranhaCMSOak/

Installation instructions:
--------------------------
1. Create empty MVC 4 Razor project
2. Install PiranhaCMSOak nuget
3. Allow files to be rewritten during the nuget installation
4. Run the web project and configure Piranha CMS
5. Start developing using Oak

Piranha CMS Configuration
--------------------------
1. Install PiranhaCMSOak using the Installation instructions
2. Fix the NewtonSoft.Json 4.5 reference issue if needed (see http://www.slideshare.net/davidpodhola/instalace-balku-piranha-cms-oak)
3. Run the web application to get Piranha CMS "Install new website" page
7. Fill in Username, Password, Confirm (password) and Email and click Install website
8. After successful installation you get the Login page
9. Fill in the Username and Password you entered in 7 and click Login
10. After successfully log in, you get to the manager with Pages opened
11. Piranha CMS is installed, you may check the site clicking on the link below "My site" in manager
12. You see the site running with "Welcome to Piranha - the fun, fast and lightweight framework for developing cms-based web applications with an extra bite."

ASP.NET MVC Development with Oak
--------------------------------
1. Install PiranhaCMSOak using the Installation instructions
2. Configure Piranha CMS using the steps in Piranha CMS Configuration section
3. Open Global.asax.cs and inherit MvcApplication from PiranhaCMSOak.MvcApplication; also type _Application_Start(); at the end of Application_Start() method
4. Start the web application and in the browser navigate to e.g. /Test path. You should see Oak error screen "The controller for path '/Test' was not found or does not implement IController."
5. Add the TestController to Controllers folder
6. Run the application, go to /Test and get the error message about missing view
7. Create Test folder under Views and add Index.cshtml view to the Test folder
8. Now if you navigate to the /Test path, you get your Index.cshtml view rendered in the Piranha CMS

