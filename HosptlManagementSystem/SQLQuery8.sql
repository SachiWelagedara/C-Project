create table PatientMore
(
pid bigint,
Symptoms varchar (150),
Diagnosis varchar (150),
Medicines varchar (150),
Ward varchar (15),
Ward_Type varchar (20)
)

select * from PatientMore;

select * from AddPatient inner join PatientMore on AddPatient.pid = PatientMore.pid;