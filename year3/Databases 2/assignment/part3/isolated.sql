DROP TABLE Animal CASCADE CONSTRAINTS PURGE;

DROP TABLE Species CASCADE CONSTRAINTS PURGE;

DROP TABLE Account CASCADE CONSTRAINTS PURGE;

DROP TABLE Sale CASCADE CONSTRAINTS PURGE;

DROP TABLE Customer CASCADE CONSTRAINTS PURGE;

CREATE TABLE Account
(
	accountMonth         DATE NOT NULL ,
	accountAnimalSales   DECIMAL(8, 2) NULL ,
	accountAccessorySales DECIMAL(8, 2) NULL ,
	accountExpenses      DECIMAL(8, 2) NULL ,
CONSTRAINT  XPKAccount PRIMARY KEY (accountMonth)
);

CREATE TABLE Species
(
	speciesId            VARCHAR2(10) NOT NULL ,
	speciesName          VARCHAR2(20) NULL ,
	speciesCost          DECIMAL(5,2) NULL ,
	speciesSupplyCost    DECIMAL(5,2) NULL ,
	speciesRequirements  VARCHAR2(500) NULL ,
	speciesGuarantee     NUMBER(3) NULL ,
	supplierId           VARCHAR2(10) NULL ,
	speciesStock         NUMBER(3) NULL ,
	speciesCertificate   VARCHAR2(100) NULL ,
CONSTRAINT  XPKSpecies PRIMARY KEY (speciesId)
);

CREATE TABLE Customer
(
	customerId           VARCHAR2(10) NOT NULL ,
	customerName         VARCHAR2(20) NULL ,
CONSTRAINT  XPKCustomer PRIMARY KEY (customerId)
);

CREATE TABLE Sale
(
	saleDate             TIMESTAMP NOT NULL ,
	accountMonth         DATE NULL ,
	accessoryId          VARCHAR2(10) NULL ,
  speciesId            VARCHAR(10) NULL,
	customerId           VARCHAR2(10) NULL ,
CONSTRAINT  XPKSale PRIMARY KEY (saleDate),
CONSTRAINT R_33 FOREIGN KEY (accountMonth) REFERENCES Account (accountMonth),
CONSTRAINT R_34 FOREIGN KEY (customerId) REFERENCES Customer (customerId),
CONSTRAINT R_40 FOREIGN KEY (speciesId) REFERENCES Species (speciesId)
);

CREATE TABLE Animal
(
	animalId             VARCHAR2(10) NOT NULL ,
	animalCoat           VARCHAR2(20) NULL ,
	animalHeight         DECIMAL(4,2) NULL ,
	animalWeight         DECIMAL(5,2) NULL ,
	saleDate             TIMESTAMP NULL ,
	enclosureId          VARCHAR2(10) NULL ,
	speciesId            VARCHAR2(10) NULL ,
CONSTRAINT  XPKAnimal PRIMARY KEY (animalId),
CONSTRAINT R_21 FOREIGN KEY (speciesId) REFERENCES Species (speciesId),
CONSTRAINT R_28 FOREIGN KEY (saleDate) REFERENCES Sale (saleDate)
);

insert into SPECIES values ('SP1','Labrador',100.50, 75.0,'healthy,clean',2,'S001', 3, 'blabla');
insert into ANIMAL values ('A1','Deep Brown',24,34, null,'True','SP1' );
insert into ACCOUNT values (((to_date('01-12-2006','dd-mm-yyyy'))),22.2,12.43,43.4 );
insert into ACCOUNT values (sysdate,22.2,12.43,43.4 );
insert into customer values ('C1', 'Bob Bobson');