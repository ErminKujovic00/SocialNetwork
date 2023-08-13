-- Model New Model
-- Updated 17/02/2012 07:00:00
-- DDL Generated 11/08/2023 16:54:13

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Comment
create table
	[dbo].[Comment]
(
	[CommentId] uniqueidentifier not null
	, [CommentText] nvarchar(200) not null
	, [CommentDate] datetime2(7) not null
	, [NumberOfLikes] int not null
	, [PostId] uniqueidentifier not null
	, [UserId] uniqueidentifier not null
,
constraint [Pk_Comment_CommentId] primary key clustered
(
	[CommentId] asc
)
);

-- Table dbo.Notifications
create table
	[dbo].[Notifications]
(
	[NotificationId] uniqueidentifier not null
	, [NotificationDate] datetime2(7) not null
	, [NotificationText] nvarchar(300) not null
	, [UserId] uniqueidentifier not null
,
constraint [Pk_Notifications_NotificationId] primary key clustered
(
	[NotificationId] asc
)
);

-- Table dbo.Post
create table
	[dbo].[Post]
(
	[PostId] uniqueidentifier not null
	, [PostDate] datetime2(7) not null
	, [PostPhoto] nvarchar(200) not null
	, [PostText] nvarchar(200) not null
	, [PostLikes] int not null
	, [PostComments] int not null
	, [UserId] uniqueidentifier not null
,
constraint [Pk_Post_PostId] primary key clustered
(
	[PostId] asc
)
);

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
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Post_Comment_PostId
alter table [dbo].[Comment]
add constraint [Fk_Post_Comment_PostId] foreign key ([PostId]) references [dbo].[Post] ([PostId]);


-- Relationship Fk_User_Notifications_UserId
alter table [dbo].[Notifications]
add constraint [Fk_User_Notifications_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);


-- Relationship Fk_User_Post_UserId
alter table [dbo].[Post]
add constraint [Fk_User_Post_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);



