create procedure [dbo].[spRoute_GetAll]
	@lineId int
as
begin
	select [name], [arrivalTime]
	from [dbo].[Locations]
	left join 
	[dbo].[Routes]
	on 
	[dbo].[Locations].[id] = [dbo].[Routes].[locationId]
	where
	[dbo].[Routes].[lineId] = @lineId;
end