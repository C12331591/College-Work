create or replace procedure add_sale (stno in staff.staff_no%type,
stcd in stock.stock_code%type, qty in sale.quantity%type) is
qstk number;
not_enough exception ;
BEGIN
  select quantityinstock into qstk
  from stock 
  where stock_code = stcd;
  if (qty > qstk) then 
    raise not_enough;
  else
    update stock
      set quantityinstock = quantityinstock - qty
    where stock_code = stcd;
    update staff
      set sales_made = sales_made + 1
    where staff_no = stno;
    insert into sale values (saleseq.nextval, stcd, stno,sysdate, qty);
    commit;
  end if;
exception
when not_enough then
   raise_application_error(-20001,'Not enough stock.  No sale added');
   rollback work;
when others then
   raise_application_error(SQLCODE, SQLERRM);
   rollback work;
end add_sale;