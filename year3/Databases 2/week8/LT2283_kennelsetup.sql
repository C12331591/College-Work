DROP TABLE LT_stay;
DROP TABLE LT_kennel;
DROP TABLE LT_dog;
DROP TABLE LT_owner;
CREATE TABLE LT_Owner (
       OwnerId              number(5) PRIMARY KEY,
       OName                VARCHAR2(20) NULL,
       OAddr                VARCHAR2(40) NULL);

INSERT into LT_owner VALUES (1,'John Smith','8 The View, Glasmarne');
INSERT into LT_owner VALUES (2,'Brian Kelly','234 Rathdown Close, D33');
INSERT into LT_owner VALUES (3,'Faith O''Neill','43 Glengar Rd, Galway');
INSERT into LT_owner VALUES (4,'Martin McDonnell','Valhalla, The Hill, Dungarvan');
INSERT into LT_owner VALUES (5,'Kay Brennan','23 James St., D8');
INSERT into LT_owner VALUES (6,'Ruth Maguire','5 Juniper Way, Firtree');


CREATE TABLE LT_Dog (
       DogId                CHAR(6) PRIMARY KEY,
       OwnerId              NUMBER(5) REFERENCES LT_OWNER,
       DName                VARCHAR2(15) NULL,
       DDoB                 DATE NULL
);
INSERT into LT_dog VALUES (1,1,'Spot','23-feb-09');
INSERT into LT_dog VALUES (2,1,'Mark','23-feb-09');
INSERT into LT_dog VALUES (3,2,'Rover','23-mar-09');
INSERT into LT_dog VALUES (4,3,'Jack','23-feb-09');
INSERT into LT_dog VALUES (5,4,'Madam','23-feb-09');
INSERT into LT_dog VALUES (6,2,'Honey','23-feb-09');

CREATE TABLE LT_Kennel (
       KennelId             NUMBER(4) PRIMARY KEY,
       KPosition            CHAR(18) NULL,
       KSize                CHAR(6) NULL,
       KHeat                SMALLINT NULL,
       DailyRate            NUMBER(6,2) NULL
);
INSERT into LT_kennel VALUES (1,'ROW 1, No. 1','large',1,50.00);
INSERT into LT_kennel VALUES (2,'ROW 1, No. 2','large',0,25.00);
INSERT into LT_kennel VALUES (3,'ROW 1, No. 3','large',1,50.00);
INSERT into LT_kennel VALUES (4,'ROW 2, No. 1','small',1,50.00);
INSERT into LT_kennel VALUES (5,'ROW 2, No. 2','large',1,50.00);
INSERT into LT_kennel VALUES (6,'ROW 2, No. 3','large',1,50.00);

CREATE TABLE LT_Stay (
       KennelId             NUMBER(4) NOT NULL REFERENCES LT_Kennel,
       StartDate            DATE NOT NULL,
       DogId                CHAR(6) REFERENCES LT_DOG,
       ExpectedEndDate      DATE NULL,
       PRIMARY KEY (KennelId, StartDate)
);
INSERT into LT_stay(KENNELID, DOGID,STARTDATE,EXPECTEDENDDATE) VALUES (1,1,'12-jun-2009','26-jun-2009');
INSERT into LT_stay(KENNELID, DOGID,STARTDATE,EXPECTEDENDDATE) VALUES (2,4,'12-jun-2009','26-jun-2009');
INSERT into LT_stay(KENNELID, DOGID,STARTDATE,EXPECTEDENDDATE) VALUES (3,2,'12-jun-2009','26-jun-2009');
INSERT into LT_stay(KENNELID, DOGID,STARTDATE,EXPECTEDENDDATE) VALUES (3,3,'14-jun-2009','26-jun-2009');
INSERT into LT_stay(KENNELID, DOGID,STARTDATE,EXPECTEDENDDATE) VALUES (4,3,'12-jun-2009','26-jun-2009');
INSERT into LT_stay(KENNELID, DOGID,STARTDATE,EXPECTEDENDDATE) VALUES (5,5,'12-jun-2009','26-jun-2009');
INSERT into LT_stay(KENNELID, DOGID,STARTDATE,EXPECTEDENDDATE) VALUES (1,3,'12-jul-2009','26-jul-2009');
INSERT into LT_stay(KENNELID, DOGID,STARTDATE) VALUES (5,1,'12-Nov-2009');

COMMIT;
