create table [dbo].[Routes] (
	-- identificator of route
	[id] int not null identity(1,1) primary key,
	-- reference to lineid
	[lineId] int not null foreign key references [dbo].[Lines](id),
	-- reference to locationid
	[locationId] int not null foreign key references [dbo].[Locations](id),
	-- specific arrival time of mode transport
	[arrivalTime] time not null,
);