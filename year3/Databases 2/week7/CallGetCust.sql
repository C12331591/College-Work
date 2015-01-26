set serveroutput on
DECLARE
-- Test the procedure GET_CUST
cid customer.customer_id%type:=&Enter_Customer_id;
cnam customer.customer_name%type;
cadd customer.customer_address%type;
BEGIN
GET_CUST(cid, cnam, cadd);
DBMS_OUTPUT.PUT_LINE('Customer_id  Name                   Address');
DBMS_OUTPUT.PUT_LINE(cid||'          '||cnam||'       '||cadd);
EXCEPTION
WHEN OTHERS THEN
  DBMS_OUTPUT.PUT_LINE (SQLCODE||SQLERRM);
END;