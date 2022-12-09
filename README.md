# BSM-Disrupt-Prototype
 Decentralised E-Commerce Web Application.

Before running, make sure to install the nessesary packages:

1. Right click on the project under Solution.
2. Click "Manage NuGet Packages...".
3. Then install "Microsoft.EntityFrameworkCore.SqlServer" version 3.1.31.

<img width="892" alt="Screenshot 2022-12-10 at 00 03 51" src="https://user-images.githubusercontent.com/56122446/206745412-4c017db9-7aee-43a1-941a-1dab8c484110.png">

For the database, it is currently using MSSQL, running on a localhost network using Docker. If you want to test out the web app, then you can create your own localhost database on your laptop using Docker and it should immediately work.

Make sure these information are the same:
Database User: "SA" or "sa"
Database Password: "reallyStrongPwd123"

Context for the application database can be seen under "appsettings.json" file:
"Server=localhost;Database=master;User=sa;Password=reallyStrongPwd123;"

After creating the localhost database, make sure to create the Product Table. The SQL Query is provided:
"BSM_DB.sql" file.



