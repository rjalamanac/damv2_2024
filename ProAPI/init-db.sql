
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Basic')
BEGIN
    CREATE DATABASE [Basic];
END
GO

USE [master];
GO
IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = 'AppUserLogin')
BEGIN
    CREATE LOGIN [AppUserLogin] WITH PASSWORD = 'e.d_fwm2()~37hz?+LBT4V';
END
GO

USE [Basic];
GO
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = 'AppUser')
BEGIN
    CREATE USER [AppUser] FOR LOGIN [AppUserLogin];
END
GO

-- Step 3: Grant permissions to the user
ALTER ROLE [db_datareader] ADD MEMBER [AppUser];
ALTER ROLE [db_datawriter] ADD MEMBER [AppUser];
GRANT REFERENCES ON SCHEMA::dbo TO AppUser;
GRANT ALTER, CREATE TABLE ON SCHEMA::dbo TO [AppUser];
GO
