# MraTaxPayers
Make sure windows Server Hosting is installed  
Enable IIS and related services e.g. FTP server and services, web management tools, www services
Open IIS Manager go to sites
Add a site name:  MraTaxPayers
Create a folder under inetpub/wwwroot name it MraTaxPayers under Physical path
add the hostname and it to the host file
save changes
Open the application in VS as admin
Change the environment variable to Production, before publishing the application
Click on the solution and select publish
Selet where you want to publish your application(Azure, Docker, Web Server, Folder etc)
I will select Folder in my case since am publishing it locally
Choose path
Save changes
Go back to IIS manager
Right click your site and select manage website and select browse
Your application should be running. 
