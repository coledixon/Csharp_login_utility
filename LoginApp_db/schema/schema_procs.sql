/* SCHEMA FOR C# LOGIN / HASHING APPLICATION */
/* Copyright 2019 || Cole Dixon || All rights reserved */

USE [db_login]
GO


/* --- PROCS ---*/
-- drop and create in case of master schema changes

-----
--- CREATE PROC for establishing a valid user session
-----
IF OBJECT_ID('dbo.spcreateSession') is not null DROP PROC [dbo].[spcreateSession]
GO

	CREATE PROC [dbo].[spcreateSession]
	@user_key int = null,
	@retval int = 0,
	@errmess varchar(250) = null
	AS
	
	-- NEWID() for creating session(s)

GO

-----
--- LOGIN PROC for performing the basic login functionality
-----
IF OBJECT_ID('dbo.spuserLogin') is not null DROP PROC [dbo].[spuserLogin]
GO

	CREATE PROC [dbo].[spuserLogin]
	@user_id varchar(50) = NULL,
	@user_pass varchar(max) = NULL,
	@retval int = 0 OUTPUT,
	@errmess varchar(250) = NULL OUTPUT
	AS

	-- SHA() password hashing??
GO

-----
--- LOGOUT PROC for performing the basic logout functionality
-----
IF OBJECT_ID('dbo.spuserLogout') is not null DROP PROC [dbo].[spuserLogout]
GO

	CREATE PROC [dbo].[spuserLogout]
	@user_id varchar(50) = NULL,
	@user_pass varchar(max) = NULL,
	@retval int = 0 OUTPUT,
	@errmess varchar(250) = NULL OUTPUT
	AS

	-- SHA() password hashing??

GO

-----
--- FETCH PROC for returning next user key
-----
IF OBJECT_ID('dbo.spgetNextUserKey') is not null DROP PROC [dbo].[spgetNextUserKey]
GO

	CREATE PROC [dbo].[spgetNextUserKey]
	@user_key int = 0 OUTPUT,
	@retval int = NULL OUTPUT,
	@errmess varchar(250) = NULL OUTPUT
	AS

	SELECT @user_key = COALESCE(user_key,0)
		FROM user_key_store

		IF (COALESCE(@user_key,0) = 0)
		BEGIN
			SELECT @retval = -1, @errmess = 'ERROR FETCHING NEXT user_key FROM user_key_store'
			GOTO ERROR
		END
		ELSE BEGIN
			SELECT @user_key = (@user_key + 1) /* increment key */, @retval = 1
			GOTO SPEND
		END

	SPEND:
		SELECT 'SUCCESS', @retval retval
		RETURN
	
	ERROR:
		SELECT @retval retval, @errmess errmess
		RETURN

GO