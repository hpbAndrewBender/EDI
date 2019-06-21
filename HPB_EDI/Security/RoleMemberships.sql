EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'reportreader';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'HPB\dist users';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'btprocess';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'HPB\Tracy_Dennis';


GO
EXECUTE sp_addrolemember @rolename = N'db_datawriter', @membername = N'HPB\dist users';


GO
EXECUTE sp_addrolemember @rolename = N'db_datawriter', @membername = N'btprocess';

