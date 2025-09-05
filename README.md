# StudentDetails

1. Clone the repository
git clone https://github.com/your-username/your-repo-name.git

2. Open Solution file
StudentDetails.sln

3. Configure the database
   Open the file: appsettings.json
   Update the connection string with your SQL Server instance:
"ConnectionStrings": {
  ""StudentConnectionString": "Server=your_server_name; Database=StudentDb;Trusted_Connection=True;TrustServerCertificate=Yes"
}

4. Apply Migrations
   Menu bar->Tools->NuGet Package Manager->Package Manager Console

5.  Add the below Command
 Add-Migration "Connection String Changed" then update-database

6. Run the solution
