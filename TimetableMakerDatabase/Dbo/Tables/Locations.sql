create table [dbo].[Locations] (
	[id] int not null identity(1,1) primary key,
	-- name of stop 
	[name] varchar(50) not null,
	-- name of city or commune
	[zone] varchar(50) not null
);