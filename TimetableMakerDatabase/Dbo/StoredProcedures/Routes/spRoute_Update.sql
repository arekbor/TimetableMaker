create procedure [dbo].[spRoute_Update]
	@lineId int,
	@locationId int,
	@arrivalTime time,
	@routeId int
as
begin
	update [dbo].[Routes]
	set
	[lineId] = IsNull(@lineId, [lineId]),
	[locationId] = IsNull(@locationId, [locationId]),
	[arrivalTime] = IsNull(@arrivalTime, [arrivalTime])
	where [id] = @routeId;
end