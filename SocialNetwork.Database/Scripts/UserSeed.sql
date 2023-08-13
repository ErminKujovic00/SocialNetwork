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
/*
INSERT INTO [User] (UserId,FirstName,LastName,UserEmail,Username,Age,Gender,Adress,PhoneNumber,PasswordHash,PasswordSalt, Jwt, Expiry)
VALUES (newid(), 'Jhon', 'Wick', 'jhonwick@gmail.com', 'Babaroga', 40, 'Male', 'Killer Lane','000-000-000', 0, 0, NULL, NULL)*/

/*INSERT INTO [dbo].User (UserId,FirstName,LastName,UserEmail,Username,Age,Gender,Adress,Password,PhoneNumber)
VALUES (newid(), 'Jhon', 'Wick', 'jhonwick@gmail.com', 'Babaroga', 40, 'Male', 'Killer Lane', 'sifra', '000-000-000')*/