# Database

## Quick description
This folder contains scripts for creating database schema only (without data) (files with prefix <code>**FullDatabaseSchema**</code>) and files creating database schema with seeded data (files with prefix <code>**FullDatabaseSchemaAndData**</code>). The rest of the files names is SSMS version for which these files were created. 

## How to use

1. Open **SQL Server Management Studio**, connect to your server and then use **New Database...** on your **Databases** directory
2. Create empty database with name <code>**MojaBiblioteka.Data**</code>
3. Copy the context inside one of two files:
   * If you want empty database with schema only: <code>**FullDatabaseSchema<year>.sql**</code>
   * If you want database with schema and data: <code>**FullDatabaseSchemaAndData<year>.sql**</code>
5. Select **New Query** and paste copied content
6. Execute the query

**Remember!** If you want to create empty database and test it without any data, make sure you commented <code>SeedDatabase databaseSeeder = new SeedDatabase(services);</code> and <code>databaseSeeder.Initialize();</code> inside <code>**Program.cs**</code> file.
