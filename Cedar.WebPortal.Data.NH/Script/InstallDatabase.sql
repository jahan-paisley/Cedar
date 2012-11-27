CREATE DATABASE [Cedar] ON  PRIMARY 
	( NAME = N'Cedar1', FILENAME = N'@DatabasePath\Cedar.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB ), 
    FILEGROUP [CedarFileStreamGroup] CONTAINS FILESTREAM  DEFAULT 
    ( NAME = N'Cedar2', FILENAME = N'@DatabasePath\Cedar_filestream' )
    LOG ON 
    ( NAME = N'Cedarlog1', FILENAME = N'@DatabasePath\Cedar_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
    ALTER DATABASE [Cedar] SET COMPATIBILITY_LEVEL = 100;
