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
GO
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Posts_Comments_PostId
alter table [dbo].[Comments]
add constraint [Fk_Posts_Comments_PostId] foreign key ([PostId]) references [dbo].[Posts] ([PostId]);