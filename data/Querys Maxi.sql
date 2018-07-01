-- SP para cambiar Listados
create procedure EN_CASA_ANDABA.top5_hoteles_reservas_canceladas
	@trimestre numeric(18,0), @anio numeric(18,0) as
	begin
		declare @inicio datetime, @fin datetime, @anioAux char(4)
		set @anioAux = CAST(@anio as char(4))
		if (@trimestre = 1)
			begin
				set @inicio = '01-01-'+@anioAux
				set @fin = '31-03-'+@anioAux
			end
		else if (@trimestre = 2)
			begin
				set @inicio = '01-04-'+@anioAux
				set @fin = '30-06-'+@anioAux
			end
		else if (@trimestre = 3)
			begin 
				set @inicio = '01-07-'+@anioAux
				set @fin = '30-09-'+@anioAux
			end
		else if (@trimestre = 4)
			begin
				set @inicio = '01-10-'+@anioAux
				set @fin = '31-12-'+@anioAux
			end
		else 
			begin
				set @inicio = '01-01-'+@anioAux
				set @fin = '31-12-'+@anioAux
			end
		select top 5 HO.hot_nombre as Hotel, HO.hot_calle as Calle, HO.hot_calle_nro as Numero, count(R.res_estados_id) as [Reservas Canceladas]
			from EN_CASA_ANDABA.reservas R, EN_CASA_ANDABA.hoteles HO, EN_CASA_ANDABA.habitaciones HA,
				EN_CASA_ANDABA.Reservas_habitaciones RH, EN_CASA_ANDABA.Estados E,
				EN_CASA_ANDABA.Usuarios_ReservasCancelaciones U_RC
			where R.res_estados_id = E.estados_id and (E.estados_desc = 'Reserva CANCELADA MAESTRA' or
				E.estados_desc = 'Reserva CANCELADA POR RECEPCION' or
  				E.estados_desc = 'Reserva CANCELADA POR NO-SHOW' or
				E.estados_desc = 'Reserva CANCELADA POR CLIENTE') and
				HA.hab_id = RH.ryh_hab_id and HA.hab_hot_id = HO.hot_id and U_RC.urc_res_id = R.res_id and
				RH.ryh_res_id = R.res_id and U_RC.urc_fecha between @inicio and @fin
			group by HO.hot_nombre, HO.hot_calle, Ho.hot_calle_nro
			order by [Reservas Canceladas] desc				
	end
go

create procedure EN_CASA_ANDABA.top5_hoteles_consumibles_facturados
	@trimestre numeric(18,0), @anio numeric(18,0) as
	begin
		declare @inicio datetime, @fin datetime, @anioAux char(4)
		set @anioAux = CAST(@anio as char(4))
		if (@trimestre = 1)
			begin
				set @inicio = '01-01-'+@anioAux
				set @fin = '31-03-'+@anioAux
			end
		else if (@trimestre = 2)
			begin
				set @inicio = '01-04-'+@anioAux
				set @fin = '30-06-'+@anioAux
			end
		else if (@trimestre = 3)
			begin 
				set @inicio = '01-07-'+@anioAux
				set @fin = '30-09-'+@anioAux
			end
		else if (@trimestre = 4)
			begin
				set @inicio = '01-10-'+@anioAux
				set @fin = '31-12-'+@anioAux
			end
		else 
			begin
				set @inicio = '01-01-'+@anioAux
				set @fin = '31-12-'+@anioAux
			end
		select top 5 H.hot_nombre as Hotel, H.hot_calle as Calle, H.hot_calle_nro as Numero, sum(iyf_cantidad) as [Consumibles Facturados]
			from EN_CASA_ANDABA.Items_Facturas IYF, EN_CASA_ANDABA.facturas F, EN_CASA_ANDABA.Estadias E,
				EN_CASA_ANDABA.Clientes_estadias CYE, EN_CASA_ANDABA.Hoteles H
			where IYF.iyf_fac_id = F.fac_id and F.fac_est_res_id = E.est_res_id 
				and CYE.cye_est_res_id = E.est_res_id and F.fac_fecha between @inicio AND @fin
				and CYE.cye_hab_hot_id = H.hot_id
			group by H.hot_nombre, H.hot_calle, H.hot_calle_nro
			order by [Consumibles Facturados] desc
	end
go

create procedure EN_CASA_ANDABA.top5_hoteles_dias_fuera_de_servicio
	@trimestre numeric(18,0), @anio numeric(18,0) as
	begin
		declare @inicio datetime, @fin datetime, @anioAux char(4)
		set @anioAux = CAST(@anio as char(4))
		if (@trimestre = 1)
			begin
				set @inicio = '01-01-'+@anioAux
				set @fin = '31-03-'+@anioAux
			end
		else if (@trimestre = 2)
			begin
				set @inicio = '01-04-'+@anioAux
				set @fin = '30-06-'+@anioAux
			end
		else if (@trimestre = 3)
			begin 
				set @inicio = '01-07-'+@anioAux
				set @fin = '30-09-'+@anioAux
			end
		else if (@trimestre = 4)
			begin
				set @inicio = '01-10-'+@anioAux
				set @fin = '31-12-'+@anioAux
			end
		else 
			begin
				set @inicio = '01-01-'+@anioAux
				set @fin = '31-12-'+@anioAux
			end
		select top 5 Hotel as Hotel, Calle as Calle, Numero as Numero ,SUM(total.dias) as Dias from  
			(select * from
				(select H.hot_nombre as Hotel, h.hot_calle as Calle, h.hot_calle_nro as Numero, SUM(DATEDIFF(day, B.baj_fecha_inicio, B.baj_fecha_fin)) as dias
					from EN_CASA_ANDABA.BajasHotel B, EN_CASA_ANDABA.Hoteles H
					where B.baj_hot_id = H.hot_id and B.baj_fecha_inicio between @inicio and @fin
						and B.baj_fecha_fin < @fin
					group by H.hot_nombre, h.hot_calle, h.hot_calle_nro) as antesFin
			UNION ALL
			select * from
				(select H.hot_nombre as Hotel, h.hot_calle as Calle, h.hot_calle_nro as Numero, SUM(DATEDIFF(day, B.baj_fecha_inicio,@fin)) as dias
					from EN_CASA_ANDABA.BajasHotel B, EN_CASA_ANDABA.Hoteles H
					where B.baj_hot_id = H.hot_id and B.baj_fecha_inicio between @inicio and @fin
						and B.baj_fecha_fin > @fin
					group by H.hot_nombre, h.hot_calle, h.hot_calle_nro) as luegoFin) as total, EN_CASA_ANDABA.Hoteles HO
					where HO.hot_calle = total.calle
					and ho.hot_calle_nro = total.numero
					and ho.hot_nombre = total.Hotel
					group by Hotel,Calle,Numero
					order by dias desc
	end
go

create procedure EN_CASA_ANDABA.top5_habitaciones_veces_ocupadas
	@trimestre numeric(18,0), @anio numeric(18,0) as
	begin
		declare @inicio datetime, @fin datetime, @anioAux char(4)
		set @anioAux = CAST(@anio as char(4))
		if (@trimestre = 1)
			begin
				set @inicio = '01-01-'+@anioAux
				set @fin = '31-03-'+@anioAux
			end
		else if (@trimestre = 2)
			begin
				set @inicio = '01-04-'+@anioAux
				set @fin = '30-06-'+@anioAux
			end
		else if (@trimestre = 3)
			begin 
				set @inicio = '01-07-'+@anioAux
				set @fin = '30-09-'+@anioAux
			end
		else if (@trimestre = 4)
			begin
				set @inicio = '01-10-'+@anioAux
				set @fin = '31-12-'+@anioAux
			end
		else 
			begin
				set @inicio = '01-01-'+@anioAux
				set @fin = '31-12-'+@anioAux
			end
		select distinct top 5 HO.hot_nombre as Hotel, HO.hot_calle as Calle, HO.hot_calle_nro as Numero, HA.hab_numero as [Numero Habitacion],
				HA.hab_piso as [Piso Habitacion], cantidad_habitacion.cantVeces as [Veces Ocupada],
				cantidad_dias.Dias as [Dias Ocupada]
			from (select hab_id as hab, hab_hot_id as hot, COUNT(hab_id) cantVeces
					from EN_CASA_ANDABA.reservas_habitaciones RYH, EN_CASA_ANDABA.Habitaciones HA,
							EN_CASA_ANDABA.Reservas R, EN_CASA_ANDABA.Hoteles HO, EN_CASA_ANDABA.Estadias E
					where RYH.ryh_hab_id = HA.hab_id and RYH.ryh_hab_hot_id = HA.hab_hot_id 
							and RYH.ryh_res_id = R.res_id and HO.hot_id = HA.hab_hot_id 
							and E.est_res_id = R.res_id and E.est_checkin between @inicio and @fin
					group by hab_id, hab_hot_id) as cantidad_habitacion, 
					(select  HA.hab_id as hab2, HA.hab_hot_id, SUM(DATEDIFF(day, E.est_checkin, E.est_checkout)) Dias
						from EN_CASA_ANDABA.reservas_habitaciones RYH, EN_CASA_ANDABA.Habitaciones HA,
								EN_CASA_ANDABA.Reservas R, EN_CASA_ANDABA.Hoteles HO, EN_CASA_ANDABA.Estadias E
						where RYH.ryh_hab_id = HA.hab_id and RYH.ryh_res_id = R.res_id and
							  HO.hot_id = HA.hab_hot_id and E.est_res_id = R.res_id and 
							  E.est_checkin between @inicio and @fin
						group by HA.hab_id, HA.hab_hot_id) as cantidad_dias,EN_CASA_ANDABA.Hoteles HO,
							EN_CASA_ANDABA.Habitaciones HA, EN_CASA_ANDABA.Estadias E
						where cantidad_habitacion.hot = HO.hot_id and HA.hab_id = cantidad_habitacion.hab and
							cantidad_habitacion.hab = cantidad_dias.hab2 and E.est_checkin between @inicio and @fin
						order by [Veces Ocupada] desc
	end
go

create procedure EN_CASA_ANDABA.top5_clientes_puntos
	@trimestre numeric(18,0), @anio numeric(18,0) as
	begin
		declare @inicio datetime, @fin datetime, @anioAux char(4)
		set @anioAux = CAST(@anio as char(4))
		if (@trimestre = 1)
			begin
				set @inicio = '01-01-'+@anioAux
				set @fin = '31-03-'+@anioAux
			end
		else if (@trimestre = 2)
			begin
				set @inicio = '01-04-'+@anioAux
				set @fin = '30-06-'+@anioAux
			end
		else if (@trimestre = 3)
			begin 
				set @inicio = '01-07-'+@anioAux
				set @fin = '30-09-'+@anioAux
			end
		else if (@trimestre = 4)
			begin
				set @inicio = '01-10-'+@anioAux
				set @fin = '31-12-'+@anioAux
			end
		else 
			begin
				set @inicio = '01-01-'+@anioAux
				set @fin = '31-12-'+@anioAux
			end
		select top 5 C.cli_nombre as Nombre, C.cli_apellido as Apellido,C.cli_doc_id as [Tipo Documento], C.cli_documento as Documento,
		puntos_estadias.puntos+puntos_consumibles.puntos as Puntos
		from (select E.est_res_id, SUM(E.est_precio) as gastos, SUM(E.est_precio) / 20 as puntos
				from EN_CASA_ANDABA.Estadias E, EN_CASA_ANDABA.Reservas R, EN_CASA_ANDABA.Facturas F
		where E.est_res_id = R.res_id and F.fac_est_res_id = E.est_res_id and F.fac_fecha between @inicio and @fin
		group by E.est_res_id) as puntos_estadias, 
			(select E.est_res_id, SUM(CON.con_precio) Gasto, SUM(CON.con_precio) / 10 as puntos
				from EN_CASA_ANDABA.Consumibles CON, EN_CASA_ANDABA.items_facturas IYF, EN_CASA_ANDABA.Facturas F,
					EN_CASA_ANDABA.Estadias E
				where iyf_con_id = con_id and iyf_fac_id = fac_id and fac_est_res_id = est_res_id
					and F.fac_fecha between @inicio and @fin
				group by E.est_res_id) as puntos_consumibles, EN_CASA_ANDABA.Clientes C, EN_CASA_ANDABA.Estadias E,
					EN_CASA_ANDABA.Reservas R
				where R.res_cli_doc_id = C.cli_doc_id and R.res_cli_documento = C.cli_documento 
					and E.est_res_id = R.res_id and puntos_consumibles.est_res_id = E.est_res_id and 
					puntos_estadias.est_res_id = E.est_res_id
				order by Puntos desc
	end
go

----------------------------------------------------------------------------------------------------------------

-- ABM Cliente

--Cambio Password
select usu_password from EN_CASA_ANDABA.Usuarios where usu_id = 1;
update EN_CASA_ANDABA.Usuarios set usu_password = 1234 where usu_id = 2;

-- Archivo alta
--Alta cliente Combo box tipo doc
select distinct doc_desc from EN_CASA_ANDABA.Documentos
-- abm == "altaReservaCli"
select cli_documento, cli_doc_id from EN_CASA_ANDABA.Clientes where cli_mail = ''
-- abm == "altaEstadia"
select cli_documento,cli_doc_id,cli_nombre,cli_apellido from EN_CASA_ANDABA.Clientes where cli_mail = ''
-- abm == "altaReservaUser"
select cli_documento, cli_doc_id from EN_CASA_ANDABA.Clientes where cli_mail = ''

-- Archivo baja
-- Combo box tipo doc
select distinct doc_desc from EN_CASA_ANDABA.Documentos
-- Baja_load
select C.cli_nombre Nombre,C.cli_apellido Apellido,D.doc_id TipoDoc,C.cli_documento NroDoc,C.cli_mail Mail,C.cli_telefono Telefono, C.cli_nacionalidad Nacionalidad,C.cli_fecha_nac Fecha_Nacimiento,C.cli_habilitado Habilitado, C.cli_calle Calle, C.cli_calle_nro Numero_Calle, C.cli_depto Departamento, C.cli_dir_localidad Localidad, C.cli_dir_pais Pais from EN_CASA_ANDABA.Clientes C,EN_CASA_ANDABA.Documentos D where	C.cli_doc_id = D.doc_id
-- Inhabilitar cliente
update EN_CASA_ANDABA.Clientes set cli_habilitado=0 where cli_documento = '' and cli_doc_id = 1

-- Archivo listado y listadoModif
-- Combo box tipo doc
select distinct doc_desc from EN_CASA_ANDABA.Documentos
-- Listado_load
select C.cli_nombre Nombre,C.cli_apellido Apellido,D.doc_id TipoDoc,C.cli_documento NroDoc,C.cli_mail Mail,C.cli_telefono Telefono, C.cli_nacionalidad Nacionalidad,C.cli_fecha_nac Fecha_Nacimiento,C.cli_habilitado Habilitado, C.cli_calle Calle, C.cli_calle_nro Numero_Calle, C.cli_depto Departamento, C.cli_dir_localidad Localidad, C.cli_dir_pais Pais from EN_CASA_ANDABA.Clientes C,EN_CASA_ANDABA.Documentos D where	C.cli_doc_id = D.doc_id

-- ABM Habitacion

-- Alta Hotel
-- Nombre hotel
select hot_nombre from EN_CASA_ANDABA.Hoteles where hot_id = 1;
-- Combo box tipos habitaciones
select distinct tip_nombre from EN_CASA_ANDABA.TiposHabitaciones;
EXEC EN_CASA_ANDABA.AltaHabitacion

-- Baja Hotel
select Ha.hab_numero Numero,Ha.hab_piso Piso,Ha.hab_vista Vista,T.tip_nombre Tipo,Ha.hab_desc Descripcion,Ha.hab_habilitado Habilitado from	EN_CASA_ANDABA.Habitaciones Ha, EN_CASA_ANDABA.Hoteles H, EN_CASA_ANDABA.TiposHabitaciones T where	Ha.hab_hot_id = H.hot_id and T.tip_id = Ha.hab_tip_id and H.hot_id = 1
select tip_id from EN_CASA_ANDABA.TiposHabitaciones where tip_nombre = ''
select hab_id from EN_CASA_ANDABA.Habitaciones where hab_numero = 1 and hab_piso = 1 and hab_hot_id = 1 and hab_tip_id = 1
update EN_CASA_ANDABA.Habitaciones set hab_habilitado=0 where hab_id = 1

-- Listado y listadoModif
-- Combo box tipos habitaciones
select distinct tip_nombre from EN_CASA_ANDABA.TiposHabitaciones;
select hot_nombre from EN_CASA_ANDABA.Hoteles where hot_id = 1;
select Ha.hab_numero Numero,Ha.hab_piso Piso,Ha.hab_vista Vista,T.tip_nombre Tipo,Ha.hab_desc Descripcion,Ha.hab_habilitado Habilitado from	EN_CASA_ANDABA.Habitaciones Ha, EN_CASA_ANDABA.Hoteles H, EN_CASA_ANDABA.TiposHabitaciones T where	Ha.hab_hot_id = H.hot_id and T.tip_id = Ha.hab_tip_id and H.hot_id = 1

-- Modificar Habitacion
EXEC EN_CASA_ANDABA.ModificacionHabitacion

-- ABM Hotel

--Alta Hotel
select distinct reg_id Id,reg_desc Descripcion from EN_CASA_ANDABA.Regimenes
EXEC EN_CASA_ANDABA.altaHotel
EXEC EN_CASA_ANDABA.altaRegimenesHotel

-- Baja Hotel
select EN_CASA_ANDABA.hotelTieneReserva -- ISSUE
Insert into EN_CASA_ANDABA.BajasHotel (hotel, fecha_ini, fecha_hasta, motivo) values... -- ISSUE

-- Listado Hotel y listadoModif
select hot_nombre Nombre,hot_mail Mail,hot_telefono Tel,hot_estrellas Estrellas,hot_recarga_estrellas RecargaEstrella,hot_fecha_cre FechaCreacion, hot_calle Calle, hot_calle_nro Numero_Calle, hot_ciudad Ciudad from EN_CASA_ANDABA.Hoteles

-- Modificacion
select R.reg_id, R.reg_desc from EN_CASA_ANDABA.Regimenes R, EN_CASA_ANDABA.Regimenes_Hoteles RH where RH.ryh_reg_id = R.reg_id and RH.ryh_hot_id = 1

-- ABM Regimen

-- Home Regimen
INSERT INTO EN_CASA_ANDABA.Regimenes (descripcion, precio, estado) VALUES... -- ISSUE
DELETE FROM EN_CASA_ANDABA.Regimenes WHERE reg_id = 1
UPDATE EN_CASA_ANDABA.Regimenes SET

-- Listado Regimen
SELECT * FROM EN_CASA_ANDABA.Regimenes

-- Modificacion Regimen
SELECT IDENT_CURRENT ('EN_CASA_ANDABA.Regimenes')+1

-- ABM Rol

-- Alta Rol
select distinct F.fun_id ID,F.fun_desc Denominacion from EN_CASA_ANDABA.Funcionalidades F
EXEC EN_CASA_ANDABA.AltaRol
EXEC EN_CASA_ANDABA.AltaFuncionalidadRol

-- Baja Rol
select rol_id ID,rol_nombre Descripcion, rol_estado Estado from EN_CASA_ANDABA.Roles
select F.fun_id ID,F.fun_desc Denominacion from EN_CASA_ANDABA.Funcionalidades F, EN_CASA_ANDABA.Funcionalidades_Roles FR where F.fun_id = FR.fyr_fun_id and FR.fyr_rol_id = 1
update EN_CASA_ANDABA.Roles set rol_estado=0 where rol_id = 1

-- Listado Rol y listadoModif
select rol_id ID,rol_nombre Descripcion, rol_estado Estado from EN_CASA_ANDABA.Roles
select F.fun_id ID,F.fun_desc Denominacion from EN_CASA_ANDABA.Funcionalidades F, EN_CASA_ANDABA.Funcionalidades_Roles FR where F.fun_id = FR.fyr_fun_id and FR.fyr_rol_id = 1
                
-- Modificacion
select F.fun_desc from EN_CASA_ANDABA.Funcionalidades_Roles FR,EN_CASA_ANDABA.Funcionalidades F where F.fun_id = FR.fyr_fun_id and FR.fyr_rol_id = 1
select distinct fun_desc from EN_CASA_ANDABA.Funcionalidades except select F.fun_desc from EN_CASA_ANDABA.Funcionalidades_Roles FR,EN_CASA_ANDABA.Funcionalidades F where F.fun_id =FR.fyr_fun_id and FR.rol = 1
update EN_CASA_ANDABA.Roles set rol_nombre = '', rol_estado=1 where rol_id=1
select fun_id from EN_CASA_ANDABA.Funcionalidades where fun_desc = ''
delete from EN_CASA_ANDABA.Funcionalidades_Roles where fyr_fun_id = 1 and fyr_rol_id = 1


-- ABM Usuario

-- Alta usuario
--Alta usuario Combo box tipo doc
select distinct doc_desc from EN_CASA_ANDABA.Documentos
select hot_nombre from EN_CASA_ANDABA.Hoteles where hot_id= 1
select rol_nombre from EN_CASA_ANDABA.Roles where rol_nombre != 'ADMINISTRADOR GENERAL' and rol_nombre != 'GUEST'
EXEC EN_CASA_ANDABA.altaUsuario

-- Baja usuario
--Baja usuario Combo box tipo doc
select distinct doc_desc from EN_CASA_ANDABA.Documentos
select hot_nombre from EN_CASA_ANDABA.Hoteles where hot_id= 1
select rol_nombre from EN_CASA_ANDABA.Roles
select U.usu_username Usuario,R.rol_nombre Rol,U.usu_nombre Nombre,U.usu_apellido Apellido,U.usu_tel Tel,U.usu_mail Mail,U.usu_documento Nro_Doc,T.doc_desc Tipo_Doc,H.hot_nombre Hotel,U.usu_fecha_nac Fecha_Nac,U.usu_estado Estado, U.usu_direccion from EN_CASA_ANDABA.Usuarios U,EN_CASA_ANDABA.Roles R, EN_CASA_ANDABA.Hoteles H,EN_CASA_ANDABA.Documentos T where U.usu_doc_id = T.doc_id and H.hot_id= 1
select usu_id ID from EN_CASA_ANDABA.Usuarios where usu_username = ''
update EN_CASA_ANDABA.Usuarios set usu_estado=0 where usu_id = 1

-- Listado y ListadoModif
--Listado usuario Combo box tipo doc
select distinct doc_desc from EN_CASA_ANDABA.Documentos
select hot_nombre from EN_CASA_ANDABA.Hoteles
select rol_nombre from EN_CASA_ANDABA.Roles
select U.usu_username Usuario,R.rol_nombre Rol,U.usu_nombre Nombre,U.usu_apellido Apellido,U.usu_tel Tel,U.usu_mail Mail,U.usu_documento Nro_Doc,T.doc_desc Tipo_Doc,H.hot_nombre Hotel,U.usu_fecha_nac Fecha_Nac,U.usu_estado Estado, U.usu_direccion from EN_CASA_ANDABA.Usuarios U,EN_CASA_ANDABA.Roles R, EN_CASA_ANDABA.Hoteles H,EN_CASA_ANDABA.Documentos T where U.usu_doc_id = T.doc_id and H.hot_id= 1

-- Modificacion
--Modif usuario Combo box tipo doc
select distinct doc_desc from EN_CASA_ANDABA.Documentos
select hot_nombre from EN_CASA_ANDABA.Hoteles where hot_id= 1
EXEC EN_CASA_ANDABA.modificacionUsuario


-- Cancelar reserva
-- Cancelacion
select estados_id from EN_CASA_ANDABA.Estados where estados_desc = 'RESERVA CANCELADA POR NO-SHOW' 
select estados_id from EN_CASA_ANDABA.Estados where estados_desc = 'RESERVA CANCELADA POR RECEPCION'
select estados_id from EN_CASA_ANDABA.Estados where estados_desc = 'RESERVA CANCELADA POR CLIENTE'
select res_id,res_estados_id,res_inicio from EN_CASA_ANDABA.Reservas where res_id = 1
exec EN_CASA_ANDABA.CancelarReserva -- ISSUE

-- Generar Modificar Reserva

-- Alta Cli
select distinct hot_nombre from EN_CASA_ANDABA.Hoteles
EXEC EN_CASA_ANDABA.buscarTiposHabitacionesHotel
EXEC EN_CASA_ANDABA.buscarRegimenesHotel
select tip_personas from EN_CASA_ANDABA.TiposHabitaciones where tip_nombre = ''
EXEC EN_CASA_ANDABA.buscarHabitacionesDisponibles
select cli_habilitado from EN_CASA_ANDABA.Clientes where cli_doc_id = 1 and cli_documento = 12345678
EXEC EN_CASA_ANDABA.AltaReserva
EXEC EN_CASA_ANDABA.AltaReservaaltaReservaHabitacion

-- Alta User
select hot_nombre from EN_CASA_ANDABA.Hoteles where hot_id= 1
EXEC EN_CASA_ANDABA.buscarTiposHabitacionesHotel
EXEC EN_CASA_ANDABA.buscarRegimenesHotel
select tip_personas from EN_CASA_ANDABA.TiposHabitaciones where tip_nombre = ''
select cli_habilitado from EN_CASA_ANDABA.Clientes where cli_doc_id = 1 and cli_documento = 12345678
EXEC EN_CASA_ANDABA.AltaReservaaltaReservaHabitacion

-- Clientes existentes
--Cliente Combo box tipo doc
select distinct doc_desc from EN_CASA_ANDABA.Documentos
select C.cli_documento doc, C.cli_doc_id ID, C.cli_nombre Nombre,C.cli_apellido Apellido,T.doc_desc TipoDoc, C.cli_mail Mail from EN_CASA_ANDABA.Clientes C,EN_CASA_ANDABA.Documentos T where T.doc_id=C.cli_doc_id

-- Modificacion
select H.hot_nombre,R.res_inicio,R.res_fin,RE.reg_desc,R.res_cli_doc_id, res_cli_documento from EN_CASA_ANDABA.Reservas R,EN_CASA_ANDABA.Hoteles H, EN_CASA_ANDABA.Regimenes RE,EN_CASA_ANDABA.Habitaciones Ha, EN_CASA_ANDABA.Reservas_Habitaciones RH where RE.reg_id = R.res_reg_id and RH.ryh_res_id = R.res_id and RH.ryh_hab_id = Ha.hab_id and Ha.hab_hot_id = H.hot_id and R.res_id = 1 -- GUARDA QUE ACA USA EL PRECIO TOTAL QUE NO TENEMOS
EXEC EN_CASA_ANDABA.buscarTiposHabitacionesHotel
EXEC EN_CASA_ANDABA.buscarRegimenesHotel
EXEC EN_CASA_ANDABA.BuscarHabitacionDeReserva -- ISSUE
select tip_personas from EN_CASA_ANDABA.TiposHabitaciones where tip_nombre = ''
EXEC EN_CASA_ANDABA.buscarHabitacionesDisponibles
select cli_habilitado from EN_CASA_ANDABA.Clientes where cli_doc_id = 1 and cli_documento = 12345678
EXEC EN_CASA_ANDABA.ModificacionReserva
EXEC EN_CASA_ANDABA.bajaReservaHabitacion
select C.cli_nombre,C.cli_apellido,T.doc_id,C.cli_documento,C.cli_mail,C.cli_telefono,C.cli_fecha_nac,C.cli_habilitado,C.cli_calle,C.cli_calle_nro,C.cli_depto,C.cli_dir_localidad,C.cli_dir_pais,C.cli_piso,C.cli_nacionalidad  from EN_CASA_ANDABA.Clientes C,EN_CASA_ANDABA.Documentos T where C.cli_doc_id = T.doc_id and C.cli_doc_id = 1 and C.cli_documento = 12345678

-- ModifRes
select res_id,res_inicio from EN_CASA_ANDABA.Reservas where res_id = 1 

-- Listado Estadistico
EXEC EN_CASA_ANDABA.top5_hoteles_reservas_canceladas
EXEC EN_CASA_ANDABA.top5_hoteles_consumibles_facturados
EXEC EN_CASA_ANDABA.top5_hoteles_dias_fuera_de_servicio
EXEC EN_CASA_ANDABA.top5_clientes_puntos
EXEC EN_CASA_ANDABA.top5_habitaciones_veces_ocupadas


-- Falta carpeta Facturar Estadia, Registrar Consumibles y Registrar Estadia
