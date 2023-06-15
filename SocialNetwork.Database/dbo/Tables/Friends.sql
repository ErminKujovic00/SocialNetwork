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
GO
-- Relationship Fk_User_Friends_UserId
alter table [dbo].[Friends]
add constraint [Fk_User_Friends_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);