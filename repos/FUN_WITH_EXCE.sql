--VERSION 1.0
--DATE 6th JUN 2022
--@DEV 67562
USE [db_Test]GOIF EXISTS(	SELECT 1 FROM sys.objects WHERE type = 'F' AND OBJECT_ID = OBJECT_ID('[dbo].[fn_checkForExceptions]'))BEGIN	DROP Function [dbo].[fn_checkForExceptions]ENDGOCREATE FUNCTION [dbo].[fn_checkForExceptions](	@num1 INT,	@num2 INT)RETURNS INTASBEGIN 	BEGIN TRY		DECLARE 			@divide INT		SET @divide = @num1/@num2		PRINT @num	END TRY	BEGIN CATCH		PRINT 'error occured'	END CATCHENDGO