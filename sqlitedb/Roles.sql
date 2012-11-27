DROP TABLE IF EXISTS "Roles";
CREATE TABLE Roles
(
  Rolename Varchar (255) NOT NULL,
  ApplicationName varchar (255) NOT NULL
);
INSERT INTO "Roles" VALUES('Administrator','/');
INSERT INTO "Roles" VALUES('Distributor','/');
INSERT INTO "Roles" VALUES('AdminDistributor','/');
