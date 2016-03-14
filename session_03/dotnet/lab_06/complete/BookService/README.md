# BookService

To use:

1. clone this project and import into Visual Studio.
2. Right click on BookService in the project explorer, and select Publish and select the "Cloud Foundry" profile from the dropdown list.
  * There is no magic involved in that publish profile.  It is just pusblishing the project to the local disk at c:\temp\BookService.
3. `cd c:\temp\BookService`
4. Target your CF api endpoint and login.
5. Create a MySQL service in the space you are pushing to called `BookContextService`.
6. `cf push --no-start` and then `cf enable-diego bookservice` if you are on Pivotal Cloud Foundry <1.6, or `cf push` if you are 1.6 or higher.
7. Browse to your app and enjoy!
