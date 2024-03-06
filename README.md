I have integrated IdentityServer4 with ASP.NET application and RestFul API. Follow the following steps to inrun the project on you local machine.

1- Clone/Download the code.

2- Open the code in Visual Studio 2022.

3- Set the Db connection string.

4- Set 'StudentApp.IdentityServer' as startup project.

5- Open the 'Package Manager Console' run the following commands to apply IdentityServer's db migrations and Seed intial data:

 update-database -context AspNetIdentityDbContext

 update-database -context ConfigurationDbContext

6- Run the StudentAPP.IdentityServer. You will see the following screen:

![ss1](https://github.com/adnanaldaim/identityserver4/assets/78682361/b9332d94-81ac-4fa9-b785-e7de392ee27e)

Now, you have to apply the migration for Student CRUD operation.

7- Set StudentApp.API as startup project.

8- Set Default as StudentApp.Data in Package Manager Console then the following command:
 
 update-database
 
 to apply migration on the same db.

9- Verify the DB migrations as following:

![ss4](https://github.com/adnanaldaim/identityserver4/assets/78682361/c324e6d0-efbf-400e-afc5-c06a0106dccb)

10- Run the StudentApp.Web and StudentApp.API projects. You can see the following screens:

StudentApp.Web Application:
![ss2](https://github.com/adnanaldaim/identityserver4/assets/78682361/1e912b0c-ec9b-4903-9b03-704cb942ae4f)

StudentApp.API Application:
![ss3](https://github.com/adnanaldaim/identityserver4/assets/78682361/4dc7d6e0-14a5-46c2-960a-5b43f4d99bf7)

Authenticate the above applications using the following credentials:

Username: adnan

Password: Adnan@123

You are now successfully Logged In using IdentityServer4. Enjoy :)

![emoji-smiley](https://github.com/adnanaldaim/identityserver4/assets/78682361/88e888bf-d5e0-4310-a660-885bf92ca3f9)
