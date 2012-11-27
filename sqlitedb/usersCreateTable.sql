BEGIN TRANSACTION;
DROP TABLE IF EXISTS "users";
CREATE TABLE 'users' (
  'PKID' varchar(36)  NOT NULL default '',
  'Username' varchar(255)  NOT NULL default '',
  'ApplicationName' varchar(100) 
                     NOT NULL default '',
  'Email' varchar(100)  NOT NULL default '',
  'Comment' varchar(255)  default NULL,
  'Password' varchar(128)  NOT NULL default '',
  'PasswordQuestion' varchar(255)  default NULL,
  'PasswordAnswer' varchar(255)  default NULL,
  'IsApproved' tinyint(1) default NULL,
  'LastActivityDate' datetime default NULL,
  'LastLoginDate' datetime default NULL,
  'LastPasswordChangedDate' datetime default NULL,
  'CreationDate' datetime default NULL,
  'IsOnLine' tinyint(1) default NULL,
  'IsLockedOut' tinyint(1) default NULL,
  'LastLockedOutDate' datetime default NULL,
  'FailedPasswordAttemptCount' int(11) default NULL,
  'FailedPasswordAttemptWindowStart' datetime default NULL,
  'FailedPasswordAnswerAttemptCount' int(11) default NULL,
  'FailedPasswordAnswerAttemptWindowStart' datetime default NULL,
  PRIMARY KEY  ('PKID')
);
INSERT INTO "users" VALUES('fefbc0ae-4678-4258-a2b4-ec010874a5b0','1','/','a@a.com','','BlTk2DfoOs4iy/oWfg1i+jCrgyM=',NULL,'Hlks2c/NB7vJjMk/cFM4qbeHxxE=',1,'2011-07-06 15:03:37.5509737','2011-09-07 14:07:09.7492212','2011-07-06 15:03:37.5509737','2011-07-06 15:03:37.5509737',NULL,0,'2011-07-06 15:03:37.5509737',1,'2011-09-05 17:14:00.0954218',0,'2011-07-06 15:03:37.5509737');
INSERT INTO "users" VALUES('7535ded5-9782-4db8-bebb-94744e286b0d','2','/','2@2.com','','BlTk2DfoOs4iy/oWfg1i+jCrgyM=',NULL,'Hlks2c/NB7vJjMk/cFM4qbeHxxE=',1,'2011-08-21 10:49:13.05409','2011-09-07 14:51:59.9880941','2011-08-21 10:49:13.05409','2011-08-21 10:49:13.05409',NULL,0,'2011-08-21 10:49:13.05409',1,'2011-08-30 18:22:59.9259308',0,'2011-08-21 10:49:13.05409');
INSERT INTO "users" VALUES('844c9daa-9e0a-4c82-b34e-06fcf9fca159','shahin','/','shahin@ttcom.com','','BlTk2DfoOs4iy/oWfg1i+jCrgyM=',NULL,'Hlks2c/NB7vJjMk/cFM4qbeHxxE=',1,'2011-09-04 10:58:32.7500535','2011-09-07 06:43:14.4891137','2011-09-04 10:58:32.7500535','2011-09-04 10:58:32.7500535',NULL,0,'2011-09-04 10:58:32.7500535',0,'2011-09-04 10:58:32.7500535',0,'2011-09-04 10:58:32.7500535');
INSERT INTO "users" VALUES('ef416fc4-e1f1-46e0-b8f3-7258a3cfe613','amir','/','amir@ttcom.com','','BlTk2DfoOs4iy/oWfg1i+jCrgyM=',NULL,'Hlks2c/NB7vJjMk/cFM4qbeHxxE=',1,'2011-09-04 10:58:58.5545294','2011-09-07 15:36:05.3594006','2011-09-04 10:58:58.5545294','2011-09-04 10:58:58.5545294',NULL,0,'2011-09-04 10:58:58.5545294',0,'2011-09-04 10:58:58.5545294',0,'2011-09-04 10:58:58.5545294');
INSERT INTO "users" VALUES('a0220b6d-51eb-46b8-b1ad-717ce6074bd2','edris','/','edris@ttcom.com','','BlTk2DfoOs4iy/oWfg1i+jCrgyM=',NULL,'Hlks2c/NB7vJjMk/cFM4qbeHxxE=',1,'2011-09-04 10:59:33.2625146','2011-09-07 15:55:29.0849619','2011-09-04 10:59:33.2625146','2011-09-04 10:59:33.2625146',NULL,0,'2011-09-04 10:59:33.2625146',0,'2011-09-04 10:59:33.2625146',0,'2011-09-04 10:59:33.2625146');
INSERT INTO "users" VALUES('9bf5f854-1dbb-4278-b890-2ba70bf451b6','ramin','/','ramin@ttcom.com','','BlTk2DfoOs4iy/oWfg1i+jCrgyM=',NULL,'Hlks2c/NB7vJjMk/cFM4qbeHxxE=',1,'2011-09-04 10:59:56.0468178','2011-09-06 16:16:32.104745','2011-09-04 10:59:56.0468178','2011-09-04 10:59:56.0468178',NULL,0,'2011-09-04 10:59:56.0468178',0,'2011-09-04 10:59:56.0468178',0,'2011-09-04 10:59:56.0468178');
COMMIT;
