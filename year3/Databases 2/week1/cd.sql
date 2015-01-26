SELECT Coder_Name, Coder_Email, months_between(sysdate, Coder_Date_Of_Birth)/12
FROM CD_ATTENDEE
WHERE Coder_Phone is null;

select Coder_Name, count(*)
from cd_attendee
join cd_attends using (CODER_ID)
group by coder_name
having count(*) > 2;

select distinct organizer_id, loc_name
from cd_organizer
join cd_coding_session using (organizer_id)
join cd_location using (loc_id);

select facilitator_name from cd_facilitator
union
select organizer_name from cd_organizer;

select facilitator_name, facilitator_email from cd_facilitator
minus
select organizer_name, organizer_email from cd_organizer;

select coder_name, badge_earned, spec_name
from cd_attendee join cd_attends using (coder_id)
join cd_session_runs using (s_start,  loc_id, spec_code)
join cd_speciality using (spec_code)
where badge_earned is not null;

insert into cd_facilitator(facilitator_id, facilitator_name, facilitator_email) values
(5044, 'Jenny Hammond', 'jennyhammond33@hmail.com');

update cd_session_runs
set facilitator_id = (select facilitator_id from cd_facilitator where facilitator_name like 'Jenny Hammond')
where facilitator_id in (select facilitator_id from cd_facilitator where facilitator_name like 'Mark Gladstone' and sysdate < s_start);