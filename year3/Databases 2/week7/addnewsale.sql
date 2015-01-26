--select * from stock;
set serveroutput on
declare
 stno sale.staff_no%type:=&Enter_Staff_No;
 stcd sale.stock_code%type:='&Enter_Stock_Code';
 qty sale.quantity%type:=&Enter_Quantity;
 qstk stock.quantityinstock%type;
 snam staff.staff_name%type;
 stnam stock.stock_name%type;
 not_enough   exception;
begin
  if staff_exists(stno) then
    if stock_exists (stcd) then 
      add_sale(stno, stcd, qty);
    else
      dbms_output.put_line('No such stock code - transaction terminated');
    end if;
  else
    dbms_output.put_line('No such staff no - transaction terminated');
 end if;
 exception
 when others then
  dbms_output.put_line('Error occurred '||SQLCODE||'  meaning '||SQLERRM);
end;