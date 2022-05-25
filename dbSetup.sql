CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS art(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title VARCHAR(255) DEFAULT "Untitled",  
  imgUrl TEXT not NULL,
  creatorId VARCHAR(255) NOT NULL,

  FOREIGN KEY (creatorId) 
    REFERENCES accounts(id)
    ON DELETE CASCADE

)default charset utf8;

CREATE TABLE IF NOT EXISTS cars(
id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
model VARCHAR(255) NOT NULL,
make VARCHAR(255) NOT NULL,
year INT NOT NULL,
color VARCHAR(255) NOT NULL,
price INT NOT NULL,
imgUrl VARCHAR(255) NOT NULL,
creatorId VARCHAR(255) NOT NULL,

FOREIGN KEY(creatorId) 
   REFERENCES accounts(id)
    ON DELETE CASCADE

)default charset utf8;


/* post */
INSERT INTO art
(title, imgUrl, creatorId)
VALUES
("Bacon", "http://thiscatdoesnotexist.com", "sq123");

/* get all */
SELECT * FROM art;

/* get by id */
SELECT * from art WHERE id = 1;

SELECT * FROM art WHERE title = "Lil Jeremy";

SELECT * FROM art WHERE title LIKE "%Jeremy";

SELECT * FROM art WHERE creatorId = "sq123";

/* populate */ 
/*get all */


SELECT
ar.*, ac.name
FROM art ar
JOIN accounts ac ON ar.creatorId = ac.id;


/* populate */ 
/*get by id */
SELECT
ar.*, ac.name
FROM art ar
JOIN accounts ac ON ar.creatorId = ac.id
WHERE id = "sq123";



/* put */

UPDATE art
SET
title = "Felix"
WHERE id = 1;




/* delete */ 

DELETE FROM art WHERE id = 3 LIMIT 1; 

/* add a column (if not required FOREIGN KEY*/


/* playground */ 
/* make an account */ 

INSERT INTO accounts
(id, name) 
VALUES
("sq123", "Squidward");




/*danger zone */
/* remove all data from table */
DELETE FROM art;

/* remove table */
drop Table art;

/* full bad dont do */
DROP DATABASE (DATABASE name here )