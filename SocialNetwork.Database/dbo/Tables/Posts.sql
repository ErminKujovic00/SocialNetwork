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
GO
-- Relationship Fk_User_Posts_UserId
alter table [dbo].[Posts]
add constraint [Fk_User_Posts_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);
GO
-- Relationship Fk_Friends_Posts_FriendId
alter table [dbo].[Posts]
add constraint [Fk_Friends_Posts_FriendId] foreign key ([FriendId]) references [dbo].[Friends] ([FriendId]);