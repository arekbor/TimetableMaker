create table [dbo].[Lines] (
	[routeId] int not null identity(1,1) primary key,
	-- identificator of location
	[locationId] int not null foreign key references [dbo].[Locations](id),
	-- identificator of transport mode
	[modeId] int not null foreign key references [dbo].[Modes](id),

	[arrivalTime] datetime not null,
);