-- Table dbo.Notifications
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
GO
-- Relationship Fk_User_Notifications_UserId
-- Relationship Fk_User_Notifications_UserId
alter table [dbo].[Notifications]
add constraint [Fk_User_Notifications_UserId] foreign key ([UserId]) references [dbo].[User] ([UserId]);