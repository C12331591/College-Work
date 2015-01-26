set serveroutput on
declare
  aid animal.animalId%type:='&enter_animalId';
  sid species.speciesid%type;
begin
  select speciesid into sid
  from animal
  where not animal_already_sold(aid);
end;

create or replace function animal_already_sold (anml animal.animalId%type)
return boolean as
aSale animal.saleDate%type;
begin
	select saleDate into aSale from animal where animalId like anml and saleDate is not null;
  dbms_output.put_line ('Sold on '||aSale);
	return true;
exception
	when no_data_found then
		dbms_output.put_line ('Not sold');
    return false;
end animal_already_sold;