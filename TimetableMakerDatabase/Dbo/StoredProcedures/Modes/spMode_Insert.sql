create procedure [dbo].[spMode_Insert]
	@modeType nvarchar(50),
	@modeModel nvarchar(50),
	@modeSeats int
as
begin
	insert into [dbo].[Modes] ([type], [model], [seats])
	values (@modeType, @modeModel, @modeSeats);
end