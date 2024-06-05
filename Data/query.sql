/* Create table of owners */
CREATE Table Owners(
    Id INTEGER PRIMARY KEY auto_increment,
    Names VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100) UNIQUE,
    Address VARCHAR(100),
    Phone VARCHAR(100),
    Status ENUM("Eliminado","Activo")
);

/* insert date in table  */
INSERT INTO `Owners`(Names,LastName,Email,Address,Phone,Status)VALUES("Camilo","Foronda","Camilo@Gmail.com","Niquia","15454512","Activo");


/* Create table of Pets */

CREATE Table Pets(
    Id INTEGER PRIMARY KEY auto_increment,
    Name VARCHAR(50),
    Specie ENUM("Dog","Cat"),
    Race ENUM("Pitbull","Labrador","Pastor Aleman"),
    DateBirh DATETIME,
    Ownerid INTEGER,
    Photo VARCHAR(20000),
    Status ENUM("Eliminado","Activo")
);

/* insert date a table */
INSERT INTO `Pets`(Name,Specie,Race,DateBirh,Ownerid,Photo,Status)VALUES("Trueno","Dog","Pitbull","2020-02-01",1,"Url de la imagen","Activo");

ALTER Table `Pets` ADD FOREIGN KEY (Ownerid) REFERENCES `Owners`(Id);



/* Create table of quotes */
CREATE Table Quotes(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Date DATETIME,
    Petid INT,
    vetid INT,
    Description VARCHAR(2000),
    Status ENUM("Eliminado","Activo")
);

/* isnert date a table */

INSERT INTO `Quotes`(Date,Petid,vetid,Description,Status)VALUES("2020-02-01",1,1,"Cita para revision de orejas","Activo");

ALTER Table `Quotes` ADD FOREIGN KEY (Petid) REFERENCES `Pets`(Id);

ALTER Table `Quotes` ADD FOREIGN KEY (vetid) REFERENCES `Vets`(Id);




/* Create table of vets */
CREATE Table Vets(
    Id int PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(120),
    Phone VARCHAR(25),
    Address VARCHAR(30),
    Email VARCHAR(100) UNIQUE,
    Status ENUM("Eliminado","Activo")
);

/* insert date in table Vets  */
INSERT INTO Vets(Name,Phone,Address,Email,Status)VALUES("Duvan","3107854221","Niquia","Duvan@gmail.com","Activo");
