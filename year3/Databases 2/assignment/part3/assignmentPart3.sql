create or replace package assignmentPart3 as
function animal_already_sold (anml animal.animalId%type) return boolean;
procedure sell_animal;
end assignmentPart3;
/

create or replace package body assignmentPart3 as

function animal_already_sold (anml animal.animalId%type) return boolean
is
aSale animal.saleDate%type;
begin
	select saleDate into aSale from animal where animalId like anml and saleDate is not null;
	return true;
exception
	when no_data_found then
		return false;
end animal_already_sold;

procedure sell_animal
is
already_sold exception;
anml animal.animalId%type:=&enter_animalId;
cstr customer.customerId%type:=&enter_customerId;
aId animal.animalId%type;
cId customer.customerId%type;
sId species.speciesId%type;
sCost species.speciesCost%type;
ts timestamp:=current_timestamp;
begin
	--getting the ids out of the tables to make sure the ones entered are valid
	select animalId, speciesId into aId, sId
	from animal
	where animalId = anml;
	
	select speciesCost into sCost
	from species where speciesId = sId;
	
	select customerId into cId
	from customer
	where customer = cstr;
	
	if animal_already_sold(aId) then
		raise already_sold;
	else
		insert into sale values(ts, sysdate, null, sId, cId);
		
		update animal
		set saleDate = ts
		where animalId = aId;
		
		update species
		set speciesStock = speciesStock - 1
		where speciesId = sId;
		
		update account
		set accountAnimalSales = accountAnimalSales + sCost
		where month(accountMonth) = month(sysdate) and year(accountMonth) = year(sysdate);
		
		commit;
	end if;
exception
	when no_data_found then
		raise_application_error(-20001,'An id entered was invalid');
		rollback work;
	when already_sold then
		raise_application_error(-20002,'Animal has already been sold.');
		rollback work;
	when others then
		raise_application_error(SQLCODE, SQLERRM);
		rollback work;
end sell_animal;

end assignmentPart3;
/