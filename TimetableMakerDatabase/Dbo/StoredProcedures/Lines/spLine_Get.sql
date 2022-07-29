create procedure [dbo].[spLine_Get]
	@lineId int
as
begin
	select [id], [lineName], [modeId]
	from [dbo].[Lines]
	where [id] = @lineId;
end