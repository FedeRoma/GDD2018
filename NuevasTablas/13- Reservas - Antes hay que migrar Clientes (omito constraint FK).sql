use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Reservas
ALTER TABLE Reservas NOCHECK CONSTRAINT all -- Omito constraint para res_cli_doc_id
ALTER TABLE Reservas
ALTER COLUMN res_estados_id int NULL
PRINT 'Migrando Reservas...'
insert into Reservas(
					res_id,
					res_fecha,
					res_inicio,
					res_fin,
					res_tip_id, -- Tipo de habitacion
					res_reg_id, -- Regimen
					res_cli_documento, -- numero doc
					res_usu_id,
					res_cli_doc_id -- tipo doc
					)
select				distinct reserva_codigo,
					getdate(),
					reserva_fecha_inicio,
					dateadd(day,reserva_cant_noches,reserva_fecha_inicio),
					Habitacion_Tipo_Codigo,
					reg_id,
					Cliente_Pasaporte_Nro,
					usu_id,
					1-- (select top 1 cli_doc_id from clientes)
from 		gd_esquema.Maestra M,
			regimenes R,
			Usuarios U
where		M.regimen_descripcion = R.reg_desc
and			U.usu_username = 'admin'
GO
PRINT 'Reservas Migrados Papaaaa...'

-- Pongo el estado de las reservas
update Reservas
	set res_estados_id =
				CASE WHEN (res_id in (select distinct reserva_codigo from gd_esquema.maestra
									where factura_nro is not null and estadia_fecha_inicio is not null) )
				THEN
					(select estados_id from estados	
					where 	estados_desc='RESERVA CON INGRESO')
				ELSE 
					(select estados_id from estados 
					where 	estados_desc='RESERVA CANCELADA MAESTRA')
				end
-- Vuelvo a poner como NOT NULL el estado de la reserva
ALTER TABLE Reservas
ALTER COLUMN res_estados_id int NOT NULL
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/