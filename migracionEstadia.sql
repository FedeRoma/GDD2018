/*select Estadia_Fecha_inicio,Estadia_Cant_Noches from gd_Esquema.Maestra
	where Estadia_Fecha_inicio is not null and Estadia_Cant_Noches is not null*/

	INSERT INTO Estadia
	SELECT 
	(select res_est_id from Reservas),	
	(select res_usu_encargado from Reservas),
	Estadia_Fecha_Inicio, --es la misma que la del check in?
	null, 
	Estadia_Cant_Noches	
    FROM gd_esquema.Maestra

	

