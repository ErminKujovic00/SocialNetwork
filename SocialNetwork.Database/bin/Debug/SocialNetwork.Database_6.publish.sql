﻿/*
Deployment script for SocialNetworkDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "SocialNetworkDB"
:setvar DefaultFilePrefix "SocialNetworkDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[Post].[FriendId] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Post])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping Foreign Key [dbo].[Fk_Friends_Post_FriendId]...';


GO
ALTER TABLE [dbo].[Post] DROP CONSTRAINT [Fk_Friends_Post_FriendId];


GO
PRINT N'Altering Table [dbo].[Post]...';


GO
ALTER TABLE [dbo].[Post] DROP COLUMN [FriendId];


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/*
INSERT INTO [dbo].Posts(PostId, PostDate, PostText, PostPhoto, PostComments, PostLikes)
VALUES (newid(), GETUTCDATE(), 'text', 'photourl', 17, 100)

INSERT INTO [dbo].Comments(CommentId, CommentDate, CommentText, NumberOfLIkes, PostId, UserId)
VALUES (newid(), GETUTCDATE(), 'text', 50, newid(), newid())*/

/*User is a reserved word*/
INSERT INTO [User] (UserId,FirstName,LastName,UserEmail,Username,Age,Gender,Adress,Password,PhoneNumber)
VALUES (newid(), 'Jhon', 'Wick', 'jhonwick@gmail.com', 'Babaroga', 40, 'Male', 'Killer Lane', 'sifra', '000-000-000')

/*INSERT INTO [dbo].User (UserId,FirstName,LastName,UserEmail,Username,Age,Gender,Adress,Password,PhoneNumber)
VALUES (newid(), 'Jhon', 'Wick', 'jhonwick@gmail.com', 'Babaroga', 40, 'Male', 'Killer Lane', 'sifra', '000-000-000')*/
GO

GO
PRINT N'Update complete.';


GO