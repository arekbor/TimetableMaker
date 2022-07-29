create procedure [dbo].[spMode_Get]
	@modeId int
as
begin
	select [id], [type], [model], [seats] 
	from [dbo].[Modes]
	where [id] = @modeId;
end