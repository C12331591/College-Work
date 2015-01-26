create or replace function staff_exists (stff staff.staff_no%type) return boolean
is
sname staff.staff_name%type;
begin
  select staff_name into sname from staff where staff_no like stff;
  return true;
exception
  when no_data_found then
    return false;
 end staff_exists;