-------------------------------ROLLBACK SCRIPT------------------------------------------------------------------
PRINT 'DELETING Images table';
IF OBJECT_ID (N'Images', N'U') IS NOT NULL 
	BEGIN
		USE BayviewDB
		PRINT 'Using BayviewDBDB';
		DROP TABLE Images;
	END
PRINT 'Images table no longer present';

GO

PRINT 'DELETING BayviewDBDB';
IF DB_ID('BayviewDB') IS NOT NULL
	BEGIN
		DROP DATABASE BayviewDB;
	END
PRINT 'BayviewDB no longer present';