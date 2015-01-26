DROP TABLE LT_TRANSACTION;
DROP TABLE LT_ACCOUNT;
DROP TABLE LT_CLIENT;
create sequence clientseq start with 88888;
CREATE TABLE LT_CLIENT
  (
    ClientId NUMBER(7) PRIMARY KEY,
    CTitle   VARCHAR2(4),
    CFName   VARCHAR2(30),
    CLName   VARCHAR2(40),
    CAddr    VARCHAR2(50),
    CEMail   VARCHAR2(30),
    CPhone   NUMBER(15)
  );
INSERT
INTO LT_CLIENT VALUES
  (
    6545654,
    'Ms.',
    'Margaret',
    'Bradley',
    '28 Horseshoe Drive',
    'mags@gmail.com',
    08345544311
  );
INSERT
INTO LT_CLIENT VALUES
  (
    9815543,
    'Prof',
    'Jane',
    'Delaney',
    '14 Dairy Close',
    'jd1@viu.com',
    08545544311
  );
INSERT
INTO LT_CLIENT VALUES
  (
    7543356,
    'Dr.',
    'Anabelle',
    'Qiao',
    '83 Nutley Ave',
    'ana@hosp.com',
    08645544311
  );
INSERT
INTO LT_CLIENT VALUES
  (
    5444544,
    'Mr.',
    'John',
    'McDermott',
    '67 Mangrove Hill',
    'jmcd@eircom.net',
    08745544311
  );
INSERT
INTO LT_CLIENT VALUES
  (
    9199337,
    'Dr.',
    'Kevin',
    'Dunne',
    '28 The Dunes',
    'kdunne@gmail.com',
    08845544311
  );
INSERT
INTO LT_CLIENT VALUES
  (
    9874819,
    'Ms.',
    'Sally',
    'Greene',
    '44 Highwell Hill',
    'sgreene@hotmail.com',
    08945544311
  );
CREATE TABLE LT_ACCOUNT
  (
    AccNo NUMBER(8) PRIMARY KEY,
    DateOpened DATE NOT NULL ,
    DateModified DATE,
    Balance  NUMBER(10,2) NOT NULL,
    ClientId NUMBER(7) NOT NULL REFERENCES LT_CLIENT(ClientId)
  );
INSERT
INTO LT_ACCOUNT VALUES
  (
    87334564,
    '23-Jan-1998',
    sysdate-4,
    5644.44,
    6545654
  );
INSERT
INTO LT_ACCOUNT VALUES
  (
    68312334,
    '22-SEP-2008',
    '22-SEP-2008',
    50.00,
    5444544
  );
INSERT
INTO LT_ACCOUNT VALUES
  (
    87654321,
    '22-SEP-2000',
    '22-SEP-2008',
    50.00,
    6545654
  );
INSERT
INTO LT_ACCOUNT VALUES
  (
    40248210,
    '22-SEP-2004',
    '22-SEP-2008',
    50.00,
    9874819
  );
CREATE TABLE LT_TRANSACTION
  (
    TxId     NUMBER(6) PRIMARY KEY,
    AccNo    NUMBER(8) NOT NULL REFERENCES LT_Account,
    TxType   CHAR CHECK (TXType IN ('D','W','T')),
    TXAmount NUMBER(8,2) NULL ,
    TXDate DATE NULL
  );
INSERT INTO LT_TRANSACTION VALUES
  (1, 87334564,'D',500,SYSDATE-50
  );
INSERT INTO LT_TRANSACTION VALUES
  (2, 87334564,'W',50,SYSDATE-43
  );
INSERT INTO LT_TRANSACTION VALUES
  (3, 87334564,'D',500,SYSDATE-36
  );
INSERT INTO LT_TRANSACTION VALUES
  (4, 87334564,'D',500,SYSDATE-29
  );
INSERT INTO LT_TRANSACTION VALUES
  (5, 87334564,'D',500,SYSDATE-4
  );
INSERT INTO LT_TRANSACTION VALUES
  (6, 87654321,'D',500,SYSDATE-50
  );
INSERT INTO LT_TRANSACTION VALUES
  (7, 40248210,'D',500,SYSDATE-50
  );
COMMIT;
