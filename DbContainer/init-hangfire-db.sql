IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'HangfireAlertApp')
BEGIN
	CREATE DATABASE Hangfire;
END