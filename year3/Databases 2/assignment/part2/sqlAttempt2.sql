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

CREATE TABLE Account
(
	accountMonth         INTERVAL YEAR [2] TO MONTH NOT NULL ,
	accountAnimalSales   DECIMAL(8, 2) NULL ,
	accountAccessorySales DECIMAL(8, 2) NULL ,
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
	speciesRequirements  VARCHAR2(500) NULL ,
	speciesGuarantee     INT NULL ,
	supplierId           VARCHAR2(10) NULL ,
	speciesStock         INT NULL ,
	speciesCertificate   VARCHAR2(100) NULL ,
CONSTRAINT  XPKSpecies PRIMARY KEY (speciesId),
CONSTRAINT R_27 FOREIGN KEY (supplierId) REFERENCES Supplier (supplierId)

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
	accessoryStock       INT NULL ,
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

CREATE TABLE Animal
(
	animalId             VARCHAR2(10) NOT NULL ,
	animalCoat           VARCHAR2(20) NULL ,
	animalHeight         DECIMAL(4,2) NULL ,
	animalWeight         DECIMAL(5,2) NULL ,
	animalSaleDate       DATE NULL ,
	enclosureId          VARCHAR2(10) NULL ,
	speciesId            VARCHAR2(10) NULL ,
CONSTRAINT  XPKAnimal PRIMARY KEY (animalId),
CONSTRAINT R_11 FOREIGN KEY (enclosureId) REFERENCES Enclosure (enclosureId),
CONSTRAINT R_21 FOREIGN KEY (speciesId) REFERENCES Species (speciesId)
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