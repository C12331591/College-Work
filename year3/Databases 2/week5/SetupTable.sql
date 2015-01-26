drop table student;
drop table stage;
drop table programme;
create table programme
(
prog_code CHAR(5) PRIMARY KEY,
 prog_name varchar2(34),
 course_chairperson varchar2(25),
 total_students number(4,0) default 0);
--
insert into programme values ('DT228','Degree in Computer Science','Ciarán O''Leary',300);
insert into programme values ('DT211','Degree in Computing','Patricia O''Byrne',160);
insert into programme values ('DT249','Degree in Information Technology','Ciarán O''Leary',300);
--
create table stage
(
stage_code number (4,0) not null,
 prog_code CHAR(5) references programme,
 stage_mentor varchar2(25),
 remaining_places number(4,0),
primary key (prog_code,stage_code));

--
--
insert into stage values (1,'DT228','Art Sloan',10);
insert into stage values (2,'DT228','Oliver O''Connor',10);
insert into stage values (3,'DT228','Richard Lawlor',10);
insert into stage values (4,'DT228','Dr. Fred Mtenzi',10);
insert into stage values (1,'DT211','Denis Manley',6);
insert into stage values (2,'DT211','Ken O''Brien',7);
insert into stage values (3,'DT211','June Barrett',3);
insert into stage values (4,'DT211','Damian Bourke',6);
insert into stage values (1,'DT249','Ronan Fitzpatrick',10);
insert into stage values (2,'DT249','Mark Foley',10);
insert into stage values (3,'DT249','Shane Mulligan',10);
insert into stage values (4,'DT249','Mark Deegan',10);
--
create table student
(
studentNo char(9) primary key,
prog_code char(5) not null,
stage_code number(4,0) not null,
studentname varchar2(40),
studentAddress varchar2(60),
foreign key (prog_code,stage_code) references stage(prog_code,stage_code)
);
insert into student
values ('c88221133','DT228',1,'Joe Bloggs','9 Waintree View, Glasnevin');
insert into student 
values ('c88221141','DT228',1,'Joe O''Reilly','8 Terenure Rd, Terenure');
insert into student 
values ('c88221165','DT228',2,'Paul Bloggs','9 Waintree View, Glasnevin');
insert into student 
values ('c88221122','DT228',1,'Kevin Healy','153 Camden St., Dublin 8');
insert into student 
values ('c88224433','DT228',2,'Peter Cahill','Tallaght Drive, Tallaght');
insert into student 
values ('c88223333','DT228',2,'Antoine Lafoux','Main St., Dundrum');
insert into student 
values ('c88222133','DT228',4,'Ann-Marie Mee','Churchtown Rd., Churchtown');
insert into student 
values ('c88226633','DT228',3,'Pauline Quinn','Dartry Rd, Dartry');
insert into student 
values ('c88286433','DT228',3,'Jerrad Markham','9 Glasnevin Rd, Glasnevin');
insert into student 
values ('c88221364','DT228',4,'Lewis Begg','19 Waintree Drive, Glasnevin');
insert into student 
values ('c88211933','DT228',4,'Bing Wu','Fassaugh Rd, Cabra');
insert into student 
values ('c88865433','DT211',1,'Raj Sunderraman','Main Rd, Blanchardstown');
insert into student 
values ('c88221198','DT211',2,'Colin Ritchie','Doyles Corner, Phibsborough');
insert into student 
values ('c88221186','DT211',3,'Dieter Bruegge','554 Main St, Ranelagh');
insert into student 
values ('c88221144','DT211',4,'Carol Britton','15 The Green, Rathmines');
insert into student 
values ('c88228144','DT249',3,'Arthur Malks','9 the Green, Rathmines');
insert into student 
values ('c88225533','DT249',1,'Alan Dillon','54 Ratra Rd, Templeogue');
insert into student 
values ('c88222233','DT249',2,'Conor McCarthy','21 Henry St, Dublin 1');
insert into student 
values ('c88228833','DT249',4,'Cindy Liu','12 Beaumont Rd, Dalkey');
insert into student 
values ('c88221233','DT211',3,'June Barrett','8 Firtree Drive, Templeogue');
insert into student 
values ('c88221633','DT211',3,'Kuda Dubewashe','14 Main St, Glasnevin');
COMMIT;