create or replace function programme_exists (prog programme.prog_code%type) return boolean
is
pname programme.prog_name%type;
begin
  select prog_name into pname from programme where prog_code like prog;
  return true;
exception
  when no_data_found then
    return false;
end programme_exists;

create or replace function check_stage (prog programme.prog_code%type, stg stage.stage_code%type) return integer
is
remain stage.remaining_places%type;
begin
  select remaining_places into remain 
  from stage
  where prog_code like prog and stage_code like stg;
  return remain;
exception
  when no_data_found then
    return 0;
end check_stage;

create or replace procedure add_student (nm student.studentname%type, ad student.studentaddress%type, cd student.stage_code%type) return boolean
is
places stage.remaining_places%type;
no_places exception;
begin
  select remaining_places into places
  from stage
  where stage_code like cd;
  if (places < 1) then
    raise no_places
  else
    insert into student (studentname, studentaddress, stage_code) values (nm, ad, cd);
    update stage
    set remaining_places = remaining_places - 1
    where stage_code like cd;
    commit;
  end if;
exception
  when no_places then
   raise_application_error(-20001,'No places left.');
   rollback work;
when others then
   raise_application_error(SQLCODE, SQLERRM);
   rollback work;
end add_student;