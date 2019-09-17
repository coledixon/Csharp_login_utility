/* SCHEMA FOR C# LOGIN / HASHING APPLICATION */
/* Copyright 2019 || Cole Dixon || All rights reserved */

USE [db_login]
GO


/* --- PROCS ---*/
-- drop and create in case of master schema changes

-----
--- CREATE PROC for creating new user record (from admin console)
-----
IF OBJECT_ID('dbo.spcreateUser') is not null DROP PROC [dbo].[spcreateUser]
GO

	CREATE PROC [dbo].[spcreateUser]
	@user_id varchar(50),
	@first_name varchar(15),
	@last_name varchar(20),
	@password varchar(MAX),
	@retval int = 0 OUTPUT,
	@errmess varchar(250) = null OUTPUT
	AS

	DECLARE @user_key int, @pw_salt UNIQUEIDENTIFIER = NEWID() -- default salt on proc call

	-- retrieve next userkey in sequence
	EXEC spgetNextUserKey @user_key OUTPUT, @retval OUTPUT, @errmess OUTPUT

	IF (COALESCE(@retval,0) <= 0) OR (COALESCE(@user_key,0) = 0)
	BEGIN
		SELECT @errmess
		GOTO ERROR
	END

	IF (COALESCE(@user_key,0)>0)
	BEGIN
		-- insert new user / pass
		INSERT user_main (user_key, user_id, first_name, last_name, create_date)
		VALUES(@user_key, @user_id, @first_name, @last_name, GETDATE())

		INSERT pass_main (user_key, pass_hash, pass_salt)
		VALUES (@user_key, HASHBYTES('SHA2_512', (@password+CAST(@pw_salt as nvarchar(36)))), @pw_salt)

		IF @@ROWCOUNT = 0
		BEGIN
			SELECT @retval = -1, @errmess = 'error running spcreateUser'
			GOTO ERROR
		END
		ELSE BEGIN
			SELECT @retval = 1, @errmess = ''
			GOTO SPEND
		END
	END

	SPEND:
		SELECT 'SUCCESS', @retval retval, @errmess errmess
		RETURN

	ERROR:
		SELECT 'FAIL', @retval retval, @errmess errmess
		RETURN
		
GO


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
	@user_id varchar(50),
	@user_pass varchar(max),
	@user_pass_hash varchar(max),
	@retval int = 0 OUTPUT,
	@errmess varchar(250) = NULL OUTPUT
	AS

	-- HASHBYTES() pw salt in SQL
GO

-----
--- LOGOUT PROC for performing the basic logout functionality
-----
IF OBJECT_ID('dbo.spuserLogout') is not null DROP PROC [dbo].[spuserLogout]
GO

	CREATE PROC [dbo].[spuserLogout]
	@user_id varchar(50),
	@user_pass varchar(max) = NULL,
	@user_hash varchar(max) = NULL,
	@retval int = 0 OUTPUT,
	@errmess varchar(250) = NULL OUTPUT
	AS

	-- HASHBYTES() pw salt in SQL

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

	SELECT @user_key = MAX(COALESCE(user_key,0))
		FROM user_key_store

	IF (COALESCE(@user_key,0) = 0)
	BEGIN
		INSERT user_key_store (user_key)
		VALUES(1)

		IF @@ROWCOUNT = 0
		BEGIN
			SELECT @retval = -1, @errmess = 'ERROR FETCHING NEXT user_key FROM user_key_store'
			GOTO ERROR
		END

		SELECT @user_key = 1, @retval = 1
		GOTO SPEND
	END
	ELSE BEGIN
		SELECT @user_key = (@user_key + 1) /* increment key */, @retval = 1

		UPDATE user_key_store -- set new user_key base
			SET user_key = @user_key

		GOTO SPEND
	END

	SPEND:
		SELECT 'SUCCESS', @retval retval
		RETURN
	
	ERROR:
		SELECT @retval retval, @errmess errmess
		RETURN


GO