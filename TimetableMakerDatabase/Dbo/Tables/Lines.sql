create table [dbo].[Lines] (
	-- identificator of line
	[id] int not null identity(1,1) primary key,
	-- name of line
	[lineName] varchar(10) not null,
	-- reference transport modeid
	[modeId] int not null foreign key references [dbo].[Modes](id),
);