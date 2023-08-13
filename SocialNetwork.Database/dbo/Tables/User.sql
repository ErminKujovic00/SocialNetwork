-- Table dbo.User
-- Table dbo.User
-- Table dbo.User
-- Table dbo.User
-- Table dbo.User
-- Table dbo.User
-- Table dbo.User
create table
	[dbo].[User]
(
	[UserId] uniqueidentifier not null
	, [FirstName] nvarchar(100) not null
	, [LastName] nvarchar(100) not null
	, [UserEmail] nvarchar(100) not null
	, [Username] nvarchar(100) not null
	, [Age] int not null
	, [Gender] nvarchar(50) not null
	, [Adress] nvarchar(200) not null
	, [PasswordHash] varbinary(max) not null
	, [PhoneNumber] nvarchar(100) not null
	, [PasswordSalt] varbinary(max) not null
	, [Jwt] nvarchar(max) null
	, [Expiry] datetime2(7) null
,
constraint [Pk_User_UserId] primary key clustered
(
	[UserId] asc
)
);