1) 
delimiter |
DROP PROCEDURE if EXISTS newemploye |
CREATE PROCEDURE newemploye ()
BEGIN
	insert into Employe(emp_nom,emp_prenom,emp_sexe,emp_cadre,emp_salaire,emp_service)
	values('Toto','Tata','M',1,8500,1);
END
|
CALL newemploye()
/*	SELECT @a */
Delimiter ;



