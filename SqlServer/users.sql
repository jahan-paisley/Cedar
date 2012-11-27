declare @p12 uniqueidentifier
set @p12='68D23C08-1587-4D6F-BC24-2704E865780E'
exec dbo.aspnet_Membership_CreateUser @ApplicationName=N'/',@UserName=N'1',@Password=N'FVw7oUPCaKN0Y42EP5kZZbvRTSQ=',@PasswordSalt=N'dVkicAxmWNonXKd6mgNZyw==',@Email=N'a@a.com',@PasswordQuestion=NULL,@PasswordAnswer=NULL,@IsApproved=1,@UniqueEmail=0,@PasswordFormat=1,@CurrentTimeUtc='2011-09-25 11:15:31',@UserId=@p12 output
select @p12;

exec dbo.aspnet_UsersInRoles_AddUsersToRoles @ApplicationName=N'/',@RoleNames=N'Administrator',@UserNames=N'1',@CurrentTimeUtc='2011-09-25 11:15:32.083';


declare @p12 uniqueidentifier
set @p12='33ED1957-F577-48C6-85AE-F1A56C772104'
exec dbo.aspnet_Membership_CreateUser @ApplicationName=N'/',@UserName=N'2',@Password=N'WGUiz20uG6DxU6WZZPVPZHpz1e4=',@PasswordSalt=N'LxMAbTkeGcPDZgJk7YVbwQ==',@Email=N'b@b.com',@PasswordQuestion=NULL,@PasswordAnswer=NULL,@IsApproved=1,@UniqueEmail=0,@PasswordFormat=1,@CurrentTimeUtc='2011-09-25 11:18:30',@UserId=@p12 output
select @p12;

exec dbo.aspnet_UsersInRoles_IsUserInRole @ApplicationName=N'/',@UserName=N'2',@RoleName=N'AdminDistributor';
exec dbo.aspnet_UsersInRoles_AddUsersToRoles @ApplicationName=N'/',@RoleNames=N'AdminDistributor',@UserNames=N'2',@CurrentTimeUtc='2011-09-25 11:18:30.550';
exec dbo.aspnet_UsersInRoles_IsUserInRole @ApplicationName=N'/',@UserName=N'2',@RoleName=N'Administrator';
exec dbo.aspnet_UsersInRoles_IsUserInRole @ApplicationName=N'/',@UserName=N'2',@RoleName=N'Distributor'
exec dbo.aspnet_UsersInRoles_AddUsersToRoles @ApplicationName=N'/',@RoleNames=N'Distributor',@UserNames=N'2',@CurrentTimeUtc='2011-09-25 11:18:30.603';
