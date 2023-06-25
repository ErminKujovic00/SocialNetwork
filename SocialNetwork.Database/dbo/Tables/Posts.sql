-- Table dbo.Post
-- Table dbo.Post
-- Table dbo.Post
-- Table dbo.Post
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
GO
-- Relationship Fk_User_Post_UserId
-- Relationship Fk_User_Post_UserId
-- Relationship Fk_User_Post_UserId
-- Relationship Fk_User_Post_UserId
-- Relationship Fk_User_Post_UserId
alter table [dbo].[Post]
add constraint [Fk_User_Post_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);
GO
-- Relationship Fk_Friends_Post_FriendId
/*alter table [dbo].[Post]
add constraint [Fk_Friends_Post_FriendId] foreign key ([FriendId]) references [dbo].[Friends] ([FriendId]);*/