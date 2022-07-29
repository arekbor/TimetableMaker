create procedure [dbo].[spLine_Update]
	@lineName varchar(10),
	@modeId int,
	@lineId int
as
begin
	update [dbo].[Lines]
	set
	[lineName] = IsNull(@lineName, [lineName]),
	[modeId] = IsNull(@modeId, [modeId])
	where [id] = @lineId;
end