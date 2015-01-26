DROP TABLE Disease_Treatment CASCADE CONSTRAINTS PURGE;

DROP TABLE Animal_Disease CASCADE CONSTRAINTS PURGE;

DROP TABLE Animal CASCADE CONSTRAINTS PURGE;

DROP TABLE Species_Accessory CASCADE CONSTRAINTS PURGE;

DROP TABLE Accessory CASCADE CONSTRAINTS PURGE;

DROP TABLE Enclosure_Disease CASCADE CONSTRAINTS PURGE;

DROP TABLE Enclosure CASCADE CONSTRAINTS PURGE;

DROP TABLE Disease_Species CASCADE CONSTRAINTS PURGE;

DROP TABLE Species CASCADE CONSTRAINTS PURGE;

DROP TABLE Supplier CASCADE CONSTRAINTS PURGE;

DROP TABLE Disease CASCADE CONSTRAINTS PURGE;

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

CREATE TABLE Disease
(
	diseaseId            VARCHAR2(10) NOT NULL ,
	diseaseName          VARCHAR2(20) NULL ,
	diseaseDetectedToday VARCHAR2(1) NULL ,
CONSTRAINT  XPKDisease PRIMARY KEY (diseaseId)
);

CREATE TABLE Supplier
(
	supplierId           VARCHAR2(10) NOT NULL ,
	supplierName         VARCHAR2(20) NULL ,
CONSTRAINT  XPKSupplier PRIMARY KEY (supplierId)
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
CONSTRAINT  XPKSpecies PRIMARY KEY (speciesId),
CONSTRAINT R_27 FOREIGN KEY (supplierId) REFERENCES Supplier (supplierId)
);

CREATE TABLE Disease_Species
(
	diseaseId            VARCHAR2(10) NOT NULL ,
	speciesId            VARCHAR2(10) NOT NULL ,
CONSTRAINT  XPKDisease_Species PRIMARY KEY (diseaseId,speciesId),
CONSTRAINT R_25 FOREIGN KEY (diseaseId) REFERENCES Disease (diseaseId),
CONSTRAINT R_26 FOREIGN KEY (speciesId) REFERENCES Species (speciesId)
);

CREATE TABLE Enclosure
(
	enclosureId          VARCHAR2(10) NOT NULL ,
	enclosureType        VARCHAR2(20) NULL ,
	speciesId            VARCHAR2(10) NULL ,
CONSTRAINT  XPKEnclosure PRIMARY KEY (enclosureId),
CONSTRAINT R_22 FOREIGN KEY (speciesId) REFERENCES Species (speciesId)
);

CREATE TABLE Enclosure_Disease
(
	enclosureId          VARCHAR2(10) NOT NULL ,
	diseaseId            VARCHAR2(10) NOT NULL ,
CONSTRAINT  XPKEnclosure_Disease PRIMARY KEY (enclosureId,diseaseId),
CONSTRAINT R_19 FOREIGN KEY (enclosureId) REFERENCES Enclosure (enclosureId),
CONSTRAINT R_20 FOREIGN KEY (diseaseId) REFERENCES Disease (diseaseId)
);

CREATE TABLE Accessory
(
	accessoryId          VARCHAR2(10) NOT NULL ,
	accessoryDescription VARCHAR2(20) NULL ,
	accessoryCost        DECIMAL(5,2) NULL ,
	accessorySupplyCost  DECIMAL(5,2) NULL ,
	accessoryStock       NUMBER(4) NULL ,
	supplierId           VARCHAR2(10) NULL ,
CONSTRAINT  XPKAccessory PRIMARY KEY (accessoryId),
CONSTRAINT R_12 FOREIGN KEY (supplierId) REFERENCES Supplier (supplierId)
);

CREATE TABLE Species_Accessory
(
	speciesId            VARCHAR2(10) NOT NULL ,
	accessoryId          VARCHAR2(10) NOT NULL ,
CONSTRAINT  XPKSpecies_Accessory PRIMARY KEY (speciesId,accessoryId),
CONSTRAINT R_16 FOREIGN KEY (speciesId) REFERENCES Species (speciesId),
CONSTRAINT R_17 FOREIGN KEY (accessoryId) REFERENCES Accessory (accessoryId)
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
CONSTRAINT R_35 FOREIGN KEY (accessoryId) REFERENCES Accessory (accessoryId),
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
CONSTRAINT R_11 FOREIGN KEY (enclosureId) REFERENCES Enclosure (enclosureId),
CONSTRAINT R_21 FOREIGN KEY (speciesId) REFERENCES Species (speciesId),
CONSTRAINT R_28 FOREIGN KEY (saleDate) REFERENCES Sale (saleDate)
);

CREATE TABLE Animal_Disease
(
	animalId             VARCHAR2(10) NOT NULL ,
	diseaseId            VARCHAR2(10) NOT NULL ,
CONSTRAINT  XPKAnimal_Disease PRIMARY KEY (animalId,diseaseId),
CONSTRAINT R_2 FOREIGN KEY (animalId) REFERENCES Animal (animalId),
CONSTRAINT R_3 FOREIGN KEY (diseaseId) REFERENCES Disease (diseaseId)
);

CREATE TABLE Disease_Treatment
(
	diseaseId            VARCHAR2(10) NOT NULL ,
	speciesId            VARCHAR2(10) NOT NULL ,
	symptoms             VARCHAR2(200) NULL ,
	treatmentCurative    VARCHAR2(200) NULL ,
	treatmentPreventative VARCHAR2(200) NULL ,
CONSTRAINT  XPKDisease_Treatment PRIMARY KEY (diseaseId,speciesId),
CONSTRAINT R_4 FOREIGN KEY (diseaseId) REFERENCES Disease (diseaseId),
CONSTRAINT R_13 FOREIGN KEY (speciesId) REFERENCES Species (speciesId)
);

/*
 * TABLE ACCOUNT
 */
 
insert into ACCOUNT values (((to_date('01-12-2006','dd-mm-yyyy'))),22.2,12.43,43.4 );

insert into ACCOUNT values ((to_date('01-1-2007','dd-mm-yyyy')),22.2,12.43,43.4);

insert into ACCOUNT values (((to_date('01-2-2007','dd-mm-yyyy'))),12.3,32.43,41.3);

/*
 * TABLE DISEASE
 */
 
insert into DISEASE values ('D1','ebola','y');

/*
 * TABLE SUPPLIER
 */
 
  insert into SUPPLIER values ('S001','Wicker Word');
  
  insert into SUPPLIER values ('S002','Luxuru OutDoors');
  
  insert into SUPPLIER values ('S003','Animal Feeders');

/*
 * TABLE SPECIES
 */

insert into SPECIES values ('SP1','Labrador',100.50,'healthy,clean',2,'S001',3);

insert into SPECIES values ('SP2','Abyssian',50.50,'healthy,clean',2,'S002',5);

insert into SPECIES values ('SP3','Campbells Hamster ',20.99,'healthy,clean',1,'S003',10);

/*
 * TABLE Enclosure
 */
 
 insert into ENCLOSURE values ('E1','small','SP1' );

insert into ENCLOSURE values ('E2','big','SP2');

insert into ENCLOSURE values ('E3','medium','SP3');


/*
 * TABLE Enclosure_Disease
 */
 
insert into ENCLOSURE_DISEASE values ('E1','D1' );

 
/*
 * TABLE ACCESSORY
 */
 
insert into ACCESSORY values ('1','basket',49.50,5,'S001' );

insert into ACCESSORY values ('2','kennel',153.35,3,'S002' );

insert into ACCESSORY values ('3','Dry Dog Food 4kg',3.40,10,'S003' );

insert into ACCESSORY values ('4','Leather Collar',12.40,15,'S004' );

insert into ACCESSORY values ('5','Leash',18.80,15,'S005' );

/*
 * TABLE ANIMAL
 */

insert into ANIMAL values ('A1','Deep Brown',24,34,10-10-14,'True','SP1' );

insert into ANIMAL values ('A2','Deep DARK',20,25,23-10-14,'True','SP2' );

insert into ANIMAL values ('A3','Black',29,40,01-10-14,'False','SP3' );

/*
 * TABLE ANIMAL DISEASE
 */

insert into ANIMAL_DISEASE values ('A3','D1');



/*
 * TABLE DISEASE SPECIES
 */
 
insert into DISEASE_SPECIES values ('D1','SP3');

/*
 * TABLE DISEASE TREATMENT
 */
 
insert into DISEASE_TREATMENT values ('SP1','SP3','Flue','paracetamol','hot drink');

/*
 * TABLE SPECIES_ACCESSORY
 */
 
insert into SPECIES_ACCESSORY values ('SP1',1);
 
insert into SPECIES_ACCESSORY values ('SP2',2);
  
insert into SPECIES_ACCESSORY values ('SP1',1);



COMMIT;

GRANT SELECT, INSERT, UPDATE, DELETE ON ACCOUNT TO bwillis;
GRANT SELECT, INSERT, UPDATE, DELETE ON DISEASE TO bwillis;
GRANT SELECT, INSERT, UPDATE, DELETE ON SUPPLIER TO bwillis;
GRANT SELECT, INSERT, UPDATE, DELETE ON SPECIES TO bwillis;
GRANT SELECT, INSERT, UPDATE, DELETE ON Animal_Disease TO bwillis;
GRANT SELECT, INSERT, UPDATE, DELETE ON Disease_Treatment TO bwillis;

GRANT SELECT, INSERT, UPDATE, DELETE ON Disease_Species TO kbektayev;
GRANT SELECT, INSERT, UPDATE, DELETE ON Enclosure TO kbektayev;
GRANT SELECT, INSERT, UPDATE, DELETE ON Enclosure_Disease TO kbektayev;
GRANT SELECT, INSERT, UPDATE, DELETE ON Accessory TO kbektayev;
GRANT SELECT, INSERT, UPDATE, DELETE ON Species_Accessory TO kbektayev;
GRANT SELECT, INSERT, UPDATE, DELETE ON Animal TO kbektayev;
COMMIT;