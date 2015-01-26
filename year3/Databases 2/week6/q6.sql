set serveroutput on
declare
	id jobs.job_id%type:='&enter_job_id';
	title jobs.job_title%type;
begin
	select job_title into title
	from jobs
	where job_id like id;
	dbms_output.put_line ('Job Title corresponding to '||id||' is '||title||'.');
	
	exception
	when no_data_found then
		dbms_output.put_line ('No job was found with the id '||id||'.');
end;