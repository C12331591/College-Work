drop table logtable;
drop table log_update_table;

create table logtable
(
	op char(3),
	tabnam varchar2(15),
	logdate date,
	loguser varchar2(20)
);

create table log_update_table
(
	op char(3),
	tabnam varchar2(15),
	logdate date,
	loguser varchar2(20),
	accnoOld number(8),
	balanceOld number(10, 2),
	accnoNew number(8),
	balanceNew number(10, 2)
);

CREATE OR REPLACE TRIGGER account_auI
AFTER INSERT ON lt_account
BEGIN
INSERT INTO logtable VALUES
(
	'INS', 'lt_account', sysdate, TO_CHAR(USER)
);
END;

CREATE OR REPLACE TRIGGER account_auU
AFTER UPDATE ON lt_account
BEGIN
INSERT INTO logtable VALUES
(
	'UPD', 'lt_account', sysdate, TO_CHAR(USER)
);
END;

CREATE OR REPLACE TRIGGER account_auD
AFTER DELETE ON lt_account
BEGIN
INSERT INTO logtable VALUES
(
	'DEL', 'lt_account', sysdate, TO_CHAR(USER)
);
END;

CREATE OR REPLACE TRIGGER account_auUT
AFTER UPDATE ON lt_account
BEGIN
INSERT INTO log_update_table VALUES
(
	'UPD', 'lt_account', sysdate, TO_CHAR(USER), :old.accNo, :old.balance, :new.accNo, :new.balance
);
END;

CREATE OR REPLACE TRIGGER account_auUTF
AFTER UPDATE ON lt_account FOR EACH row DECLARE pragma autonomous_transaction;
BEGIN
INSERT INTO log_update_table VALUES
(
	'UPD', 'lt_account', sysdate, TO_CHAR(USER), :old.accNo, :old.balance, :new.accNo, :new.balance
);

commit;
END;