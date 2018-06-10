insert into Clientes_Estadias 
	(cye_cli_documento,cye_est_res_id,cye_hab_id,cye_hab_hot_id,cye_cli_doc_id)
	
	(
	select distinct 
		cli.cli_documento,		
		est.est_res_id,
		hab_id,
		hab.hab_hot_id,
		cli.cli_doc_id

	from gd_esquema.Maestra m,
		 Clientes cli,
		 Estadias est,
		 Habitaciones hab
	where m.Estadia_Fecha_Inicio is not null and
			m.Cliente_Pasaporte_Nro = cli.cli_documento and
			m.Cliente_Apellido = cli.cli_apellido and
			m.Cliente_Nombre = cli.cli_nombre and
			m.Estadia_Fecha_Inicio = est.est_checkin and
			m.Estadia_Cant_Noches = est.est_cant_noches and
			m.Reserva_Codigo = est.est_res_id
	
	UNION ALL
	
		select distinct 
			NULL,
			cliE.cye_id,
			est.est_res_id
		from gd_esquema.Maestra m,
			 Clientes_Errores cliE,
			 Estadias est
		where m.Estadia_Fecha_Inicio is not null and
			m.Cliente_Pasaporte_Nro = cliE.cye_documento and
			m.Cliente_Apellido = cliE.cye_apellido and
			m.Cliente_Nombre = cliE.cye_nombre and
			m.Estadia_Fecha_Inicio = est.est_checkin and
			m.Estadia_Cant_Noches = est.est_cant_noches and
			m.Reserva_Codigo = est.est_res_id
	)
GO

update Clientes_Estadias
set cye_hab_id = 
(select distinct cye_hab_id
from Estadias Est, Habitaciones Hab,gd_esquema.Maestra M, Hoteles Hot
WHERE
cye_est_res_id = Est.est_res_id and
Est.est_res_id = M.Reserva_Codigo and
Hot.hot_nombre = M.Hotel_Calle+' '+CONVERT(nvarchar(255),M.Hotel_Nro_Calle)  and
Hab.hab_hot_id = Hot.hot_id and
hab_numero= M.Habitacion_Numero and
Hab.hab_piso = M.Habitacion_Piso)