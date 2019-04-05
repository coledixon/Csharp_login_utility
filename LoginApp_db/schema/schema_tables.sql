/* SCHEMA FOR C# LOGIN / HASHING APPLICATION */
/* Copyright 2019 || Cole Dixon || All rights reserved */

IF NOT EXISTS(SELECT name FROM sys.databases WHERE name ='db_login')
BEGIN
	CREATE DATABASE [db_login]
END
GO

USE [db_login]
GO


/* --- TABLES --- */

IF OBJECT_ID('dbo.user_main') is null
BEGIN
	-- master user table
	CREATE TABLE user_main (
			[user_key] int, -- IDENTITY(1,1) REMOVED handling with proc (spgetNextUserKey)
			[user_id] varchar(50) not null,
			[first_name] varchar(15) not null,
			[last_name] varchar(20) not null,
			[pass_hash] varchar(max) not null, 
			[create_date] datetime not null,
		PRIMARY KEY NONCLUSTERED 
		(
			[user_key] ASC
		) ON [PRIMARY]
	)

		ALTER TABLE user_main
			ADD CONSTRAINT def_createDate DEFAULT (GETDATE()) FOR [create_date]
END

GO

/* --- AUDIT TABLES --- */

IF OBJECT_ID('dbo.login_audit') is null
BEGIN
	-- login auditing
	CREATE TABLE login_audit (
			[user_key] int not null,
			[login_status] int not null, -- 1 success / 0 fail
			[curr_session_id] varchar(max) not null, -- gen'd using NEWID() with proc (spcreateSession)
			[last_login] datetime not null,
		CONSTRAINT fk_loginAudit FOREIGN KEY (user_key) REFERENCES user_main(user_key)
	)

		CREATE UNIQUE NONCLUSTERED INDEX natKey_loginAudit ON login_audit (
			[user_key]
		)

		ALTER TABLE login_audit
			ADD CONSTRAINT def_lastLoginDate DEFAULT (GETDATE()) FOR [last_login]

		ALTER TABLE login_audit
			ADD CONSTRAINT def_loginStatus DEFAULT (0) FOR [login_status]
END

GO

IF OBJECT_ID('dbo.logout_audit') is null
BEGIN
	-- logout auditing
	CREATE TABLE logout_audit (
			[user_key] int not null,
			[logout_status] int not null, -- 1 success / 0 fail
			[last_logout] datetime not null,
			[last_session_id] varchar(max) not null,
		CONSTRAINT fk_logoutAudit FOREIGN KEY (user_key) REFERENCES user_main(user_key)
	)

		CREATE UNIQUE NONCLUSTERED INDEX natKey_loutAudit ON logout_audit (
			[user_key]
		)

		ALTER TABLE logout_audit
			ADD CONSTRAINT def_lastLogoutDate DEFAULT (GETDATE()) FOR [last_logout]

		ALTER TABLE logout_audit
			ADD CONSTRAINT def_logoutStatus DEFAULT (0) FOR [logout_status]
END

GO

/* KEY TABLES (opting out of using IDENTITY() on user_main PK) */

IF OBJECT_ID('dbo.user_key_store') is null
BEGIN
	-- user key value store
	CREATE TABLE user_key_store (
			[user_key] int not null,
		PRIMARY KEY NONCLUSTERED 
		(
			[user_key] ASC
		) ON [PRIMARY]
	)

	ALTER TABLE user_key_store
		ADD CONSTRAINT def_userKey DEFAULT (0) FOR [user_key]

END

GO
