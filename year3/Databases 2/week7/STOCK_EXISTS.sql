create or replace function stock_exists (stcd stock.stock_code%type) return boolean
is
sname stock.stock_name%type;
begin
  select stock_name into sname from stock where stock_code like stcd;
  return true;
exception
  when no_data_found then
    return false;
end stock_exists;