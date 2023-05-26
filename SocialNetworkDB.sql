-- Model New Model
-- Updated 5/26/2023 3:09:20 PM
-- DDL Generated 5/26/2023 3:09:27 PM

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Comments
create table
	[dbo].[Comments]
(
	[CommentId] uniqueidentifier not null
	, [CommentText] nvarchar(200) not null
	, [CommentDate] datetime2(7) not null
	, [PostId] uniqueidentifier not null
	, [UserId] uniqueidentifier not null
,
constraint [Pk_Comments_CommentId] primary key clustered
(
	[CommentId] asc
)
);

-- Table dbo.Friends
create table
	[dbo].[Friends]
(
	[FriendId] uniqueidentifier not null
	, [FriendEmail] nvarchar(100) not null
	, [UserId] uniqueidentifier not null
	, [PostId] uniqueidentifier not null
,
constraint [Pk_Friends_FriendId] primary key clustered
(
	[FriendId] asc
)
);

-- Table dbo.Posts
create table
	[dbo].[Posts]
(
	[PostId] uniqueidentifier not null
	, [PostDate] datetime2(7) not null
	, [PostPhoto] nvarchar(200) not null
	, [PostText] nvarchar(200) not null
	, [PostLikes] int not null
	, [PostComments] int not null
	, [UserId] uniqueidentifier not null
	, [FriendId] uniqueidentifier not null
,
constraint [Pk_Posts_PostId] primary key clustered
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
	, [Adress] nvarchar(100) not null
	, [Password] nvarchar(100) not null
	, [PhoneNumber] nvarchar(100) not null
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

-- Relationship Fk_Posts_Comments_PostId
alter table [dbo].[Comments]
add constraint [Fk_Posts_Comments_PostId] foreign key ([PostId]) references [dbo].[Posts] ([PostId]);


-- Relationship Fk_User_Friends_UserId
alter table [dbo].[Friends]
add constraint [Fk_User_Friends_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);


-- Relationship Fk_User_Posts_UserId
alter table [dbo].[Posts]
add constraint [Fk_User_Posts_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);


-- Relationship Fk_Friends_Posts_FriendId
alter table [dbo].[Posts]
add constraint [Fk_Friends_Posts_FriendId] foreign key ([FriendId]) references [dbo].[Friends] ([FriendId]);



