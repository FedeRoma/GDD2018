use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Funcionalidades_Roles
PRINT 'Migrando Funcionalidades_Roles...'
insert into Funcionalidades_Roles (fyr_rol_id, fyr_fun_id)
	select distinct R.rol_id, F.fun_id from Roles R,Funcionalidades F
	where R.rol_nombre = 'SYSADMIN';

insert into Funcionalidades_Roles (fyr_rol_id, fyr_fun_id)
	select distinct R.rol_id, F.fun_id from Roles R,Funcionalidades F
	where R.rol_nombre = 'ADMINISTRADOR' and
			F.fun_desc in ('ABM HOTEL','ABM HABITACION','ABM REGIMEN','ABM USUARIO');

insert into Funcionalidades_Roles (fyr_rol_id, fyr_fun_id)
	select distinct R.rol_id, F.fun_id from Roles R,Funcionalidades F
	where R.rol_nombre = 'RECEPCIONISTA' and
			F.fun_desc in ('ABM CLIENTE','GENERAR RESERVA','MODIFICAR RESERVA','BAJA RESERVA','REGISTRAR ESTADIA','REGISTRAR CONSUMIBLES');
			
insert into Funcionalidades_Roles (fyr_rol_id, fyr_fun_id)
	select distinct R.rol_id, F.fun_id from Roles R,Funcionalidades F
	where R.rol_nombre = 'GUEST' and
			F.fun_desc in ('GENERAR RESERVA','MODIFICAR RESERVA','BAJA RESERVA');
GO
PRINT 'Funcionalidades_Roles Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/