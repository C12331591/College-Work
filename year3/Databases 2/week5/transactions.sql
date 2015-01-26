--q1
begin
  insert into programme values ('DT832','Degree in Management and Business','Brian Norton',80);
  
  insert into stage values (3,'DT832','Mr Oliver', 5);
  
  insert into student
  values ('C08123456','DT823',3,'Ruth O''Shea','12 Reeve St., Dublin 43');
  
  commit;
end;

--q2
begin
  insert into student
  values ('C08654321','DT823',3,'Mark McMahon','St. John''s Park');
  
  update stage
  set remaining_places = remaing_places - 1
  where prog_code = 'DT832' and stage_code = 3;
  
  update programme
  set total_students = total_students + 1
  where prog_code = 'DT832';
end;