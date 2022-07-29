create procedure [dbo].[spRoute_Insert]
	@lineId int,
	@locationId int,
	@arrivalTime time
as
begin
	insert into [dbo].[Routes] ([lineId], [locationId], [arrivalTime])
	values
	(@lineId, @locationId, @arrivalTime);
end