select p_id, d_id, appt_date
from doctor
join sees using (d_id)
join patient using (p_id)
where sysdate - appt_date < 21;

select p_name "Patients of Dr. Dredd"
from patient
join sees using (p_id)
join doctor using (d_id)
where d_name like 'Dr. Dredd';

select d_name, appt_date
from doctor
join sees using (d_id)
join patient using (p_id)
where p_name like 'Stanley Kubrick'
order by appt_date;

select p_name
from patient
join sees using (p_id)
group by p_name
having count(*) > 3;

select p_name
from patient
join sees using (p_id)
join doctor using (d_id)
where d_name like 'Dr. Zhivago'
minus
select p_name
from patient
join sees using (p_id)
join doctor using (d_id)
where d_name not like 'Dr. Zhivago';