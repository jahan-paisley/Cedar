BEGIN TRANSACTION;
DROP TABLE IF EXISTS "UsersInRoles";
CREATE TABLE UsersInRoles
(
  Username Varchar (255) NOT NULL,
  Rolename Varchar (255) NOT NULL,
  ApplicationName Text (255) NOT NULL
);
INSERT INTO "UsersInRoles" VALUES('1','Administrator','/');
INSERT INTO "UsersInRoles" VALUES('2','Distributor','/');
INSERT INTO "UsersInRoles" VALUES('shahin','Distributor','/');
INSERT INTO "UsersInRoles" VALUES('edris','Distributor','/');
INSERT INTO "UsersInRoles" VALUES('amir','Distributor','/');
INSERT INTO "UsersInRoles" VALUES('ramin','Distributor','/');
COMMIT;
