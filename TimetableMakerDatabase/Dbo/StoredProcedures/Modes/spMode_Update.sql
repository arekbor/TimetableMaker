create procedure [dbo].[spMode_Update]
	@modeType nvarchar(50),
	@modeModel nvarchar(50),
	@modeSeats int,
	@modeId int
as 
begin 
	update [dbo].[Modes] 
	set 
	[type] = IsNull(@modeType, [type]),
	[model] = IsNull(@modeModel, [model]),
	[seats] = IsNull(@modeSeats, [seats])
	where [id] = @modeId;
end