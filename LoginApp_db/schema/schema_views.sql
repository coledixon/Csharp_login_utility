/* SCHEMA FOR C# LOGIN / HASHING APPLICATION */
/* Copyright 2019 || Cole Dixon || All rights reserved */

USE [db_login]
GO


/* --- VIEWS --- */
-- drop and create in case of master schema changes

-----
--- VIEW for all login users
-----
IF OBJECT_ID('dbo.vlogin_users') is not null DROP VIEW [dbo].[vlogin_users]
GO

	CREATE VIEW [dbo].[vlogin_users]
	AS

	SELECT user_id, first_name, last_name, pass_hash, pass_salt
		FROM user_main u
			LEFT JOIN pass_main pw (NOLOCK) ON u.user_key = pw.user_key
	GO


-----
--- VIEW for all related audit data
-----
IF OBJECT_ID('dbo.vlogin_audit_all') is not null DROP VIEW [dbo].[vlogin_audit_all]
GO

	CREATE VIEW [dbo].[vlogin_audit_all]
	AS

	SELECT u.user_id, 
		CASE WHEN COALESCE(login_status, 0) > COALESCE(logout_status, 0 )
			THEN 'LOGGED IN' ELSE 'LOGGED OUT' END as status, 
		curr_session_id, last_login, last_session_id, last_logout
		FROM login_audit li
			LEFT JOIN logout_audit lo (NOLOCK) ON li.user_key = lo.user_key
			LEFT JOIN user_main u (NOLOCK) ON u.user_key = li.user_key AND u.user_key = lo.user_key


	GO

