-- Hangfire Database 
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Hangfire')
BEGIN
	CREATE DATABASE Hangfire;
END
GO
-- Hahn Assesment Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'AlertDb')
BEGIN
	CREATE DATABASE AlertDb;
END
GO