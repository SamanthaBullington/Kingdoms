CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

/* Schema : Table 
Creating a Table
  We only need to this at the start of the database the very first time
   Required : NOT NULL
 */
CREATE TABLE castles (
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  name varchar(255) NOT NULL comment 'castle name',
  location varchar(255) NOT NULL comment 'castle location'
) default charset utf8;
/* REVIEW */
CREATE TABLE knights (
  id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
  name varchar(255) NOT NULL comment 'knight name',
  weapon varchar(255) comment 'weapon type',
  roundtable TINYINT comment 'knight is part of the Round Table',
  castleId int NOT NULL,
  FOREIGN KEY (castleId) REFERENCES castles(id) ON DELETE CASCADE
);
INSERT INTO
  knights (name, weapon, roundtable, castleId)
VALUES
  ('Lancelot', 'longsword', true, 1);
SELECT
  *
FROM
  knights
WHERE
  castleId = 1;
  /* 
    SECTION AlterTable 
    */
  /* ALTER TABLE
    ALTER COLUMN name varchar(255) comment 'artist name'; */
  /* SECTION CREATE */
INSERT INTO
  castles (name, location)
VALUES
  ('Edinburgh Castle', 'Edinburgh');
  /* SECTION READ
'*' is all columns
                     */
  /* getALL */
SELECT
  *
FROM
  castles;
  /* getBy */
SELECT
  *
from
  castles
WHERE
  id = 2
LIMIT
  1;
  /* UPDATE */
UPDATE
  castles
SET
  name = "Lancelot"
WHERE
  id = 4;
  /* DESTROY */
DELETE FROM
  castles
WHERE
  id = 2
LIMIT
  1;
  /* DANGER ZONE */
  /* Removes all rows if not provided a where */
DELETE FROM
  castles;
  /* Removes whole table */
  DROP TABLE castles;
  /* Removes entire Database */
  DROP DATABASE Classroom;