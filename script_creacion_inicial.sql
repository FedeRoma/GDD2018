use [GD1C2018]
go
-------------------------------------------------------------------------------
---------- ESQUEMA ------------------------------------------------------------
-------------------------------------------------------------------------------

create schema EN_CASA_ANDABA AUTHORIZATION gdHotel2018
go

-------------------------------------------------------------------------------				
---------- STORED PROCEDURES --------------------------------------------------
-------------------------------------------------------------------------------

create procedure EN_CASA_ANDABA.top5_hoteles_reservas_canceladas
	@trimestre numeric(18,0), @anio numeric(18,0) as
	begin
		declare @inicio datetime
		declare @fin datetime
		declare @anioAux char(4)
		set @anioAux = CAST(@anio as CHAR(4))
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
		select top 5 HO.hot_id, count(R.res_estados_id) as cancelados
			from EN_CASA_ANDABA.reservas R, EN_CASA_ANDABA.hoteles HO, EN_CASA_ANDABA.habitaciones HA,
				EN_CASA_ANDABA.Reservas_habitaciones RH, EN_CASA_ANDABA.Estados E,
				EN_CASA_ANDABA.Usuarios_ReservasCancelaciones U_RC
			where R.res_estados_id = E.estados_id and (E.estados_desc = 'Reserva CANCELADA MAESTRA' or
				E.estados_desc = 'Reserva CANCELADA POR RECEPCION' or
  				E.estados_desc = 'Reserva CANCELADA POR NO-SHOW' or
				E.estados_desc = 'Reserva CANCELADA POR CLIENTE') and
				HA.hab_id = RH.ryh_hab_id and HA.hab_hot_id = HO.hot_id and U_RC.urc_res_id = R.res_id and
				RH.ryh_res_id = R.res_id and U_RC.urc_fecha between @inicio and @fin
			group by HO.hot_id
			order by cancelados desc				
		end
go

create procedure EN_CASA_ANDABA.top5_hoteles_consumibles_facturados
	@trimestre numeric(18,0), @anio numeric(18,0) as
	begin
		declare @inicio datetime
		declare @fin datetime
		declare @anioAux char(4)
		set @anioAux = CAST(@anio as CHAR(4))
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
		select top 5 CYE.cye_hab_hot_id as hotel, sum(iyf_cantidad) as consumibles_facturados
			from EN_CASA_ANDABA.Items_Facturas IYF, EN_CASA_ANDABA.facturas F, EN_CASA_ANDABA.Estadias E,
				EN_CASA_ANDABA.Clientes_estadias CYE
			where IYF.iyf_fac_id = F.fac_id and F.fac_est_res_id = E.est_res_id 
				and CYE.cye_est_res_id = E.est_res_id and F.fac_fecha between @inicio AND @fin
			group by CYE.cye_hab_hot_id
			order by consumibles_facturados desc
				end
go

create procedure EN_CASA_ANDABA.top5_hoteles_dias_fuera_de_servicio
	@trimestre numeric(18,0), @anio numeric(18,0) as
	begin
		declare @inicio datetime
		declare @fin datetime
		declare @anioAux char(4)
		set @anioAux = CAST(@anio as CHAR(4))
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
		select top 5 total.hotel, ho.hot_id ,SUM(total.dias) as dias from  
			(select * from
				(select H.hot_id as hotel, SUM(DATEDIFF(day, B.baj_fecha_inicio, B.baj_fecha_fin)) as dias
					from EN_CASA_ANDABA.BajasHotel B, EN_CASA_ANDABA.Hoteles H
					where B.baj_hot_id = H.hot_id 
					and B.baj_fecha_inicio between @inicio and @fin
					and B.baj_fecha_fin < @fin
					group by H.hot_id ) as antesFin
			UNION ALL
			select * from
				(select H.hot_id as hotel, SUM(DATEDIFF(day, B.baj_fecha_inicio,@fin)) as dias
					from EN_CASA_ANDABA.BajasHotel B, EN_CASA_ANDABA.Hoteles H
					where B.baj_hot_id = H.hot_id 
					and B.baj_fecha_inicio between @inicio and @fin
					and B.baj_fecha_fin > @fin
					group by H.hot_id) as luegoFin) as total, EN_CASA_ANDABA.Hoteles HO
					where HO.hot_id = total.hotel
					group by total.hotel, HO.hot_id
					order by dias desc
			end
go

create procedure EN_CASA_ANDABA.buscarHoteles
	@rol_nombre NVARCHAR(50), @usuario int as
	select H.hot_id from EN_CASA_ANDABA.Hoteles H, EN_CASA_ANDABA.Hoteles_Usuarios HU, 
		EN_CASA_ANDABA.Roles R, EN_CASA_ANDABA.Roles_Usuarios RU
		where HU.hyu_usu_id = @usuario and @rol_nombre = R.rol_nombre and R.rol_id = RU.ryu_rol_id
			and H.hot_id = HU.hyu_hot_id
go

create procedure EN_CASA_ANDABA.altaUsuario
	@rol varchar(50), @hotel varchar(50), @username varchar(50), @password varchar(50), @nombre varchar(50),
	@apellido varchar(50), @email varchar(50), @tel varchar(50), @tipoDoc varchar(50), @nroDoc bigint,
	@fechaNac date, @direccion varchar(50), @estado bit as
	begin
		declare @tipoDocId int
		declare @rolId int
		declare @hotelId int
		declare @userId int
		declare @respuesta numeric(18,0)
		begin tran tAltaUsuario
			begin try
				set @tipoDocId = (select doc_id from EN_CASA_ANDABA.Documentos where @tipoDoc = doc_desc)
				set @hotelId = (select hot_id from EN_CASA_ANDABA.Hoteles where @hotel = hot_nombre)
				if (not exists (select usu_id from EN_CASA_ANDABA.Usuarios where @username = usu_username))
				begin
					insert into EN_CASA_ANDABA.Usuarios (usu_username, usu_password, usu_nombre, 
						usu_apellido, usu_doc_id, usu_documento, usu_fecha_nac, usu_mail, usu_tel,
						usu_estado, usu_direccion) 
					values (@username, @password, @nombre, @apellido, @tipoDocId, @nroDoc, @fechaNac, 
						@email, @tel, @estado, @direccion)
				end 
				set @userId = (select usu_id from EN_CASA_ANDABA.Usuarios where @username = usu_username)
				insert into EN_CASA_ANDABA.Hoteles_Usuarios (hyu_usu_id, hyu_hot_id)
				values (@userId, @hotelId)
				set @rolId = (select rol_id from EN_CASA_ANDABA.Roles where @rol = rol_nombre)
				insert into EN_CASA_ANDABA.Roles_Usuarios (ryu_usu_id, ryu_rol_id)
				values (@userId, @rolId)	
				set @respuesta = 1
				select @respuesta as respuesta
				commit tran tAltaUsuario
			end try
		begin catch
			rollback tran tAltaUsuario
			set @respuesta = 0
			select @respuesta as respuesta
		end catch
	end
go

-------------------------------------------------------------------------------
---------- CREACION TABLAS ----------------------------------------------------
-------------------------------------------------------------------------------

create table EN_CASA_ANDABA.Clientes (
	cli_documento bigint NOT NULL,
	cli_doc_id int NOT NULL,
	cli_nombre varchar(50) NOT NULL,
	cli_apellido varchar(50) NOT NULL,
	cli_mail varchar(50) NOT NULL,
	cli_nacionalidad varchar(50) NOT NULL,
	cli_fecha_nac date NOT NULL,
	cli_habilitado bit NOT NULL,
	cli_calle varchar(50) NULL,
	cli_calle_nro int NULL,
	cli_piso nvarchar(10) NULL,
	cli_depto nvarchar(10) NULL,
	cli_dir_localidad varchar(50) NULL,
	cli_dir_pais varchar(50) NULL,
	cli_telefono nvarchar(50) NULL)

create table EN_CASA_ANDABA.Clientes_Estadias (
	cye_cli_documento bigint NULL,
	cye_est_res_id int NOT NULL,
	cye_hab_id int NOT NULL,
	cye_hab_hot_id int NOT NULL,
	cye_cli_doc_id int NULL,
	cye_cye_id int NULL)

create table EN_CASA_ANDABA.ClientesErrores (
	cye_doc_id int NOT NULL,
	cye_documento bigint NOT NULL,
	cye_nombre varchar(50) NOT NULL,
	cye_apellido varchar(50) NOT NULL,
	cye_mail varchar(50) NOT NULL,
	cye_nacionalidad varchar(50) NOT NULL,
	cye_fecha_nach date NOT NULL,
	cye_habilitado bit NULL,
	cye_calle varchar(50) NULL,
	cye_calle_nro int NULL,
	cye_piso nvarchar(10) NULL,
	cye_depto nvarchar(10) NULL,
	cye_dir_localidad varchar(50) NULL,
	cye_dir_pais varchar(50) NULL,
	cye_telefono nvarchar(50) NULL,
	cye_error varchar(50) NOT NULL,
	cye_id int identity (1, 1) NOT NULL)

create table EN_CASA_ANDABA.Documentos (
	doc_id int identity (1, 1) NOT NULL,
	doc_desc varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Hoteles (
	hot_id int identity (1, 1) NOT NULL,
	hot_nombre varchar(50) NULL,
	hot_estrellas int NULL,
	hot_calle varchar(50) NULL,
	hot_calle_nro int NULL,
	hot_ciudad varchar(50) NULL,
	hot_pais varchar(50) NULL,
	hot_mail varchar(50) NULL,
	hot_telefono varchar(50) NULL,
	hot_fecha_cre date NULL,
	hot_habilitado bit NULL,
	hot_recarga_estrellas int NULL)

create table EN_CASA_ANDABA.BajasHotel (
	baj_id int identity (1, 1) NOT NULL,
	baj_hot_id int NOT NULL,
	baj_fecha_inicio date NOT NULL,
	baj_fecha_fin date NOT NULL,
	baj_motivo varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Habitaciones (
	hab_id int identity (1, 1) NOT NULL,
	hab_hot_id int NOT NULL,
	hab_tip_id int NOT NULL,
	hab_numero int NOT NULL,
	hab_piso int NOT NULL,
	hab_vista char(1) NOT NULL,
	hab_desc varchar(50) NULL,
	hab_habilitado bit NULL,
	hab_tipo_porcentual int NULL)

create table EN_CASA_ANDABA.TiposHabitaciones (
	tip_id int NOT NULL,
	tip_nombre varchar(50) NOT NULL,
	tip_porcentual int NOT NULL,
	tip_personas int NOT NULL)

create table EN_CASA_ANDABA.Hoteles_Usuarios (
	hyu_usu_id int NOT NULL,
	hyu_hot_id int NOT NULL,
	hyu_id int identity (1, 1) NOT NULL)

create table EN_CASA_ANDABA.Facturas (
	fac_id int NOT NULL,
	fac_cli_documento bigint NULL,
	fac_fecha date NOT NULL,
	fac_total int NOT NULL,
	fac_est_res_id int NOT NULL,
	fac_med_id int NOT NULL,
	fac_tar_id int NULL,
	fac_cli_doc_id int NULL,
	fac_cye_id int NULL)

create table EN_CASA_ANDABA.MediosPago (
	med_id int identity (1, 1) NOT NULL,
	med_desc varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Tarjetas (
	tar_id int identity (1, 1) NOT NULL,
	tar_emisor varchar(50) NOT NULL,
	tar_banco varchar(50) NOT NULL,
	tar_numero bigint NOT NULL,
	tar_titular varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Items_Facturas (
	iyf_id int identity (1, 1) NOT NULL,
	iyf_con_id int NULL,
	iyf_fac_id int NULL,
	iyf_cantidad int NULL,
	iyf_monto int NULL)

create table EN_CASA_ANDABA.Consumibles (
	con_id int NOT NULL,
	con_desc varchar(50) NOT NULL,
	con_precio int NOT NULL)

create table EN_CASA_ANDABA.Estadias (
	est_res_id int NOT NULL,
	est_usu_alta int NOT NULL,
	est_checkin date NULL,
	est_checkout date NULL,
	est_cant_noches int NULL,
	est_precio int NOT NULL,
	est_usu_salida int NOT NULL,
	est_dias_sobrantes int NOT NULL)

create table EN_CASA_ANDABA.Reservas (
	res_id int NOT NULL,
	res_estados_id int NOT NULL,
	res_fecha datetime NOT NULL,
	res_inicio date NOT NULL,
	res_fin date NOT NULL,
	res_tip_id int NOT NULL,
	res_reg_id int NOT NULL,
	res_cli_documento bigint NULL,
	res_usu_id int NOT NULL,
	res_cli_doc_id int NULL,
	res_cye_id int NULL)

create table EN_CASA_ANDABA.Reservas_Habitaciones (
	ryh_hab_id int NOT NULL,
	ryh_hab_hot_id int NOT NULL,
	ryh_res_id int NOT NULL)

create table EN_CASA_ANDABA.Estados (
	estados_id int identity (1, 1) NOT NULL,
	estados_desc varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Regimenes (
	reg_id int identity (1, 1) NOT NULL,
	reg_desc varchar(50) NOT NULL,
	reg_precio int NOT NULL,
	reg_habilitado bit NULL)

create table EN_CASA_ANDABA.Regimenes_Hoteles (
	ryh_hot_id int NOT NULL,
	ryh_reg_id int NOT NULL,
	ryh_id int identity (1, 1) NOT NULL)

create table EN_CASA_ANDABA.Usuarios (
	usu_id int identity (1, 1) NOT NULL,
	usu_username varchar(50) NOT NULL,
	usu_password varchar(50) NOT NULL,
	usu_estado bit NOT NULL,
	usu_nombre varchar(50) NOT NULL,
	usu_apellido varchar(50) NOT NULL,
	usu_mail varchar(50) NOT NULL,
	usu_tel varchar(50) NOT NULL,
	usu_fecha_nac date NOT NULL,
	usu_documento bigint NOT NULL,
	usu_intentos int NOT NULL,
	usu_direccion varchar(50) NOT NULL,
	usu_doc_id int NOT NULL)

create table EN_CASA_ANDABA.Roles_Usuarios (
	ryu_usu_id int NOT NULL,
	ryu_rol_id int NOT NULL)

create table EN_CASA_ANDABA.Roles (
	rol_id int identity (1, 1) NOT NULL,
	rol_nombre varchar(50) NOT NULL,
	rol_estado int NOT NULL)

create table EN_CASA_ANDABA.Funcionalidades_Roles (
	fyr_rol_id int NOT NULL,
	fyr_fun_id int NOT NULL)

create table EN_CASA_ANDABA.Funcionalidades (
	fun_id int identity (1, 1) NOT NULL,
	fun_desc varchar(50) NOT NULL)	

create table EN_CASA_ANDABA.Usuarios_ReservasCancelaciones (
	urc_id int identity (1, 1) NOT NULL,
	urc_res_id int NOT NULL,
	urc_usu_id int NOT NULL,
	urc_fecha date NOT NULL,
	urc_motivo varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Usuarios_ReservasModificaciones (
	urm_id int identity (1, 1) NOT NULL,
	urm_res_id int NOT NULL,
	urm_usu_id int NOT NULL,
	urm_fecha date NOT NULL)

PRINT 'TABLAS CREADAS'

-------------------------------------------------------------------------------
---------- PK -----------------------------------------------------------------
-------------------------------------------------------------------------------

alter table EN_CASA_ANDABA.Clientes
	ADD CONSTRAINT PK_Clientes PRIMARY KEY CLUSTERED (cli_documento ASC, cli_doc_id ASC)

alter table EN_CASA_ANDABA.ClientesErrores
	ADD CONSTRAINT PK_Clientes_Errores PRIMARY KEY CLUSTERED (cye_id ASC)

alter table EN_CASA_ANDABA.Documentos 
	ADD CONSTRAINT PK_Documentos PRIMARY KEY CLUSTERED (doc_id ASC)

alter table EN_CASA_ANDABA.Hoteles
	ADD CONSTRAINT PK_Hoteles PRIMARY KEY CLUSTERED (hot_id ASC)

alter table EN_CASA_ANDABA.BajasHotel
	ADD CONSTRAINT PK_BajasHotel PRIMARY KEY CLUSTERED (baj_id ASC)

alter table EN_CASA_ANDABA.Habitaciones
	ADD CONSTRAINT PK_Habitaciones PRIMARY KEY CLUSTERED (hab_id ASC, hab_hot_id ASC)

alter table EN_CASA_ANDABA.TiposHabitaciones
	ADD CONSTRAINT PK_TiposHabitaciones PRIMARY KEY CLUSTERED (tip_id ASC)

alter table EN_CASA_ANDABA.Hoteles_Usuarios
	ADD CONSTRAINT PK_Hoteles_Usuarios PRIMARY KEY CLUSTERED (hyu_id ASC)

alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT PK_Facturas PRIMARY KEY CLUSTERED (fac_id ASC)

alter table EN_CASA_ANDABA.MediosPago
	ADD CONSTRAINT PK_MediosPago PRIMARY KEY CLUSTERED (med_id ASC)

alter table EN_CASA_ANDABA.Tarjetas
	ADD CONSTRAINT PK_Tarjetas PRIMARY KEY CLUSTERED (tar_id ASC)

alter table EN_CASA_ANDABA.Items_Facturas
	ADD CONSTRAINT PK_Items_Facturas PRIMARY KEY CLUSTERED (iyf_id ASC)

alter table EN_CASA_ANDABA.Consumibles
	ADD CONSTRAINT PK_Consumibles PRIMARY KEY CLUSTERED (con_id ASC)

alter table EN_CASA_ANDABA.Estadias
	ADD CONSTRAINT PK_Estadias PRIMARY KEY CLUSTERED (est_res_id ASC)

alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT PK_Reservas PRIMARY KEY CLUSTERED (res_id ASC)

alter table EN_CASA_ANDABA.Estados
	ADD CONSTRAINT PK_Estados PRIMARY KEY CLUSTERED (estados_id ASC)

alter table EN_CASA_ANDABA.Regimenes
	ADD CONSTRAINT PK_Regimenes PRIMARY KEY CLUSTERED (reg_id ASC)

alter table EN_CASA_ANDABA.Regimenes_Hoteles
	ADD CONSTRAINT PK_Regimenes_Hoteles PRIMARY KEY CLUSTERED (ryh_id ASC)

alter table EN_CASA_ANDABA.Usuarios
	ADD CONSTRAINT PK_Usuarios PRIMARY KEY CLUSTERED (usu_id ASC)

alter table EN_CASA_ANDABA.Roles
	ADD CONSTRAINT PK_Roles PRIMARY KEY CLUSTERED (rol_id ASC)

alter table EN_CASA_ANDABA.Funcionalidades
	ADD CONSTRAINT PK_Funcionalidades PRIMARY KEY CLUSTERED (fun_id ASC)

alter table EN_CASA_ANDABA.Usuarios_ReservasCancelaciones
	ADD CONSTRAINT PK_Usuarios_ReservasCancelaciones PRIMARY KEY CLUSTERED (urc_id ASC)

alter table EN_CASA_ANDABA.Usuarios_ReservasModificaciones
	ADD CONSTRAINT PK_Usuarios_ReservasModificaciones PRIMARY KEY CLUSTERED (urm_id ASC)

PRINT 'PK ASIGNADAS'

-------------------------------------------------------------------------------				
---------- FK -----------------------------------------------------------------
-------------------------------------------------------------------------------

alter table EN_CASA_ANDABA.Clientes
	ADD CONSTRAINT FK_Clientes_Documentos FOREIGN KEY (cli_doc_id)
		REFERENCES EN_CASA_ANDABA.Documentos(doc_id)

alter table EN_CASA_ANDABA.Clientes_Estadias
	ADD CONSTRAINT FK_Clientes_Estadias_Cliente FOREIGN KEY (cye_cli_documento, cye_cli_doc_id)
		REFERENCES EN_CASA_ANDABA.Clientes(cli_documento, cli_doc_id)
alter table EN_CASA_ANDABA.Clientes_Estadias
	ADD CONSTRAINT FK_Clientes_Estadias_Estadias FOREIGN KEY (cye_est_res_id)
		REFERENCES EN_CASA_ANDABA.Estadias(est_res_id)
alter table EN_CASA_ANDABA.Clientes_Estadias
	ADD CONSTRAINT FK_Clientes_Estadias_Habitaciones FOREIGN KEY (cye_hab_id, cye_hab_hot_id)
		REFERENCES EN_CASA_ANDABA.Habitaciones(hab_id, hab_hot_id)

alter table EN_CASA_ANDABA.ClientesErrores
	ADD CONSTRAINT FK_ClientesErrores_Documentos FOREIGN KEY (cye_doc_id) 
		REFERENCES EN_CASA_ANDABA.Documentos(doc_id)

alter table EN_CASA_ANDABA.BajasHotel
	ADD CONSTRAINT FK_BajasHotel_Hoteles FOREIGN KEY (baj_hot_id) 
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)

alter table EN_CASA_ANDABA.Habitaciones
	ADD CONSTRAINT FK_Habitaciones_Hoteles FOREIGN KEY (hab_hot_id)
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)
alter table EN_CASA_ANDABA.Habitaciones
	ADD CONSTRAINT FK_Habitaciones_TiposHabitaciones FOREIGN KEY (hab_tip_id)
		REFERENCES EN_CASA_ANDABA.TiposHabitaciones(tip_id)

alter table EN_CASA_ANDABA.Hoteles_Usuarios
	ADD CONSTRAINT FK_Hoteles_Usuarios_Usuarios FOREIGN KEY (hyu_usu_id)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)
alter table EN_CASA_ANDABA.Hoteles_Usuarios
	ADD CONSTRAINT FK_Hoteles_Usuarios_Hoteles FOREIGN KEY (hyu_hot_id)
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)

alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT FK_Facturas_Clientes FOREIGN KEY (fac_cli_documento, fac_cli_doc_id)
		REFERENCES EN_CASA_ANDABA.Clientes(cli_documento, cli_doc_id)
alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT FK_Facturas_Estadias FOREIGN KEY (fac_est_res_id)
		REFERENCES EN_CASA_ANDABA.Estadias(est_res_id)
alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT FK_Facturas_ClientesErrores FOREIGN KEY (fac_cye_id)
		REFERENCES EN_CASA_ANDABA.ClientesErrores(cye_id)
alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT FK_Facturas_MediosPago FOREIGN KEY (fac_med_id)
		REFERENCES EN_CASA_ANDABA.MediosPago(med_id)
alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT FK_Facturas_Tarjetas FOREIGN KEY (fac_tar_id)
		REFERENCES EN_CASA_ANDABA.Tarjetas(tar_id)

alter table EN_CASA_ANDABA.Items_Facturas
	ADD CONSTRAINT FK_Items_Facturas_Consumibles FOREIGN KEY (iyf_con_id)
		REFERENCES EN_CASA_ANDABA.Consumibles(con_id)
alter table EN_CASA_ANDABA.Items_Facturas
	ADD CONSTRAINT FK_Items_Facturas_Facturas FOREIGN KEY (iyf_fac_id)
		REFERENCES EN_CASA_ANDABA.Facturas(fac_id)

alter table EN_CASA_ANDABA.Estadias
	ADD CONSTRAINT FK_Estadias_Reservas FOREIGN KEY (est_res_id)
		REFERENCES EN_CASA_ANDABA.Reservas(res_id)
alter table EN_CASA_ANDABA.Estadias
	ADD CONSTRAINT FK_Estadias_Usuarios_Alta FOREIGN KEY (est_usu_alta)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)
alter table EN_CASA_ANDABA.Estadias
	ADD CONSTRAINT FK_Estadias_Usuarios_Salida FOREIGN KEY (est_usu_salida)
  REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)
 
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_TiposHabitaciones FOREIGN KEY (res_tip_id)
		REFERENCES EN_CASA_ANDABA.TiposHabitaciones(tip_id)
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_Regimenes FOREIGN KEY (res_reg_id)
		REFERENCES EN_CASA_ANDABA.Regimenes(reg_id)
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_Clientes FOREIGN KEY (res_cli_documento, res_cli_doc_id)
		REFERENCES EN_CASA_ANDABA.Clientes(cli_documento, cli_doc_id)
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_Estados FOREIGN KEY (res_estados_id)
		REFERENCES EN_CASA_ANDABA.Estados(estados_id)
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_Usuarios FOREIGN KEY (res_usu_id)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_ClientesErrores FOREIGN KEY (res_cye_id)
		REFERENCES EN_CASA_ANDABA.ClientesErrores(cye_id)

alter table EN_CASA_ANDABA.Reservas_Habitaciones
	ADD CONSTRAINT FK_Reservas_Habitaciones_Habitaciones FOREIGN KEY (ryh_hab_id, ryh_hab_hot_id)
		REFERENCES EN_CASA_ANDABA.Habitaciones(hab_id, hab_hot_id)
alter table EN_CASA_ANDABA.Reservas_Habitaciones
	ADD CONSTRAINT FK_Reservas_Habitaciones_Reservas FOREIGN KEY (ryh_res_id)
		REFERENCES EN_CASA_ANDABA.Reservas(res_id)

alter table EN_CASA_ANDABA.Regimenes_Hoteles
	ADD CONSTRAINT FK_Regimenes_Hoteles_Hoteles FOREIGN KEY (ryh_hot_id)
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)
alter table EN_CASA_ANDABA.Regimenes_Hoteles
	ADD CONSTRAINT FK_Regimenes_Hoteles_Regimenes FOREIGN KEY (ryh_reg_id)
		REFERENCES EN_CASA_ANDABA.Regimenes(reg_id)

alter table EN_CASA_ANDABA.Usuarios
	ADD CONSTRAINT FK_Usuarios_Documentos FOREIGN KEY (usu_doc_id)
		REFERENCES EN_CASA_ANDABA.Documentos(doc_id)

alter table EN_CASA_ANDABA.Roles_Usuarios
	ADD CONSTRAINT FK_Roles_Usuarios_Usuarios FOREIGN KEY (ryu_usu_id)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)
alter table EN_CASA_ANDABA.Roles_Usuarios
	ADD CONSTRAINT FK_Roles_Usuarios_Roles FOREIGN KEY (ryu_rol_id)
		REFERENCES EN_CASA_ANDABA.Roles(rol_id)

alter table EN_CASA_ANDABA.Funcionalidades_Roles
	ADD CONSTRAINT FK_Funcionalidades_Roles_Roles FOREIGN KEY (fyr_rol_id)
		REFERENCES EN_CASA_ANDABA.Roles(rol_id)
alter table EN_CASA_ANDABA.Funcionalidades_Roles
	ADD CONSTRAINT FK_Funcionalidades_Roles_Funcionalidades FOREIGN KEY (fyr_fun_id)
		REFERENCES EN_CASA_ANDABA.Funcionalidades(fun_id)

alter table EN_CASA_ANDABA.Usuarios_ReservasCancelaciones
	ADD CONSTRAINT FK_Usuarios_ReservasCancelaciones_Reservas FOREIGN KEY (urc_res_id)
		REFERENCES EN_CASA_ANDABA.Reservas(res_id)
alter table EN_CASA_ANDABA.Usuarios_ReservasCancelaciones
	ADD CONSTRAINT FK_Usuarios_ReservasCancelaciones_Usuarios FOREIGN KEY (urc_usu_id)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)

alter table EN_CASA_ANDABA.Usuarios_ReservasModificaciones
	ADD CONSTRAINT FK_Usuarios_Reservas_Modificaciones_Reservas FOREIGN KEY (urm_res_id)
		REFERENCES EN_CASA_ANDABA.Reservas(res_id)
alter table EN_CASA_ANDABA.Usuarios_ReservasModificaciones
	ADD CONSTRAINT FK_Usuarios_ReservasModificaciones_Usuarios FOREIGN KEY (urm_usu_id)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)

PRINT 'FK ASIGNADAS'

-------------------------------------------------------------------------------				
---------- MIGRACIONES ---------------------------------------------------------
-------------------------------------------------------------------------------

insert into EN_CASA_ANDABA.Documentos (doc_desc)
values
	('Pasaporte'),
	('Documento Nacional de Identidad'),
	('Libreta Civica'),
	('Libreta de Enrolamiento')
go
PRINT 'Documentos... OK!'

insert into EN_CASA_ANDABA.Estados (estados_desc)
values
	('Reserva CORRECTA'),
	('Reserva MODIFICADA'),
	('Reserva CANCELADA MAESTRA'),
	('Reserva CANCELADA POR RECEPCION'),
	('Reserva CANCELADA POR CLIENTE'),
	('Reserva CANCELADA POR NO-SHOW'),
	('Reserva CON INGRESO')
go
PRINT 'Estados... OK!'

insert into EN_CASA_ANDABA.MediosPago (med_desc)
values 
	('Efectivo'),
	('Tarjeta')
go
PRINT 'MediosPago... OK!'

insert into EN_CASA_ANDABA.Roles (rol_nombre, rol_estado)
values
	('Administrador', 1),
	('Recepcionista', 1),
	('Guest', 1),
	('SysAdmin', 1)
go
PRINT 'Roles... OK!'

insert into EN_CASA_ANDABA.Funcionalidades (fun_desc)
values
	('ABM Rol'),
	('ABM Usuario'),
	('ABM Cliente'),
	('ABM Hotel'),
	('ABM Habitación'),
	('ABM Régimen'),
	('Generar Reserva'),
	('Modificar Reserva'),
	('Baja Reserva'),
	('Registrar Estadía'),
	('Registar Consumibles'),
	('Listado Estadístico')
go
PRINT 'Funcionalidades... OK!'

insert into EN_CASA_ANDABA.Funcionalidades_Roles (fyr_rol_id, fyr_fun_id)
	select distinct R.rol_id, F.fun_id 
		from EN_CASA_ANDABA.Roles R, EN_CASA_ANDABA.Funcionalidades F
		where R.rol_nombre = 'SysAdmin';
insert into EN_CASA_ANDABA.Funcionalidades_Roles (fyr_rol_id, fyr_fun_id)
	select distinct R.rol_id, F.fun_id 
		from EN_CASA_ANDABA.Roles R, EN_CASA_ANDABA.Funcionalidades F
		where R.rol_nombre = 'Administrador' and F.fun_desc in ('ABM Hotel', 'ABM Habitación', 'ABM Régimen', 'ABM Usuario');
insert into EN_CASA_ANDABA.Funcionalidades_Roles (fyr_rol_id, fyr_fun_id)
	select distinct R.rol_id, F.fun_id 
		from EN_CASA_ANDABA.Roles R, EN_CASA_ANDABA.Funcionalidades F
		where R.rol_nombre = 'Recepcionista' and F.fun_desc in ('ABM Cliente', 'Generar Reserva', 'Modificar Reserva', 'Baja Reserva', 'Registrar Estadía', 'Registar Consumibles');			
insert into EN_CASA_ANDABA.Funcionalidades_Roles (fyr_rol_id, fyr_fun_id)
	select distinct R.rol_id, F.fun_id 
		from EN_CASA_ANDABA.Roles R, EN_CASA_ANDABA.Funcionalidades F
		where R.rol_nombre = 'Guest' and F.fun_desc in ('Generar Reserva', 'Modificar Reserva', 'Baja Reserva');
go
PRINT 'Funcionalidades_Roles... OK!'

insert into EN_CASA_ANDABA.TiposHabitaciones (tip_id, tip_nombre, tip_porcentual, tip_personas)
	select distinct Habitacion_Tipo_codigo, Habitacion_Tipo_descripcion, Habitacion_Tipo_porcentual, 1 from gd_esquema.Maestra
		update EN_CASA_ANDABA.TiposHabitaciones
			set tip_personas = case when tip_nombre = 'Base Simple' Then 1
									when tip_nombre = 'Base Doble' Then 2
									when tip_nombre = 'Base Triple' Then 3
									when tip_nombre = 'Base Cuadruple' Then 4
									else 5 end
go
PRINT 'TiposHabitaciones... OK!'

insert into EN_CASA_ANDABA.Regimenes (reg_desc, reg_precio, reg_habilitado)
	select distinct Regimen_Descripcion, Regimen_Precio, 1 
		from gd_esquema.Maestra
go
PRINT 'Regimenes... OK!'

insert into EN_CASA_ANDABA.Consumibles (con_id, con_desc, con_precio)
	select distinct Consumible_Codigo, Consumible_Descripcion, Consumible_Precio 
		from gd_esquema.Maestra
		where Consumible_Codigo is not null
go
PRINT 'Consumibles... OK!'

insert into EN_CASA_ANDABA.Hoteles (hot_estrellas, hot_calle, hot_calle_nro, hot_ciudad, hot_habilitado, 
								hot_recarga_estrellas)
	select distinct hotel_cantestrella, hotel_calle, hotel_nro_calle, hotel_ciudad,	1, Hotel_Recarga_Estrella 
		from gd_esquema.Maestra
go
PRINT 'Hoteles... OK!'

insert into EN_CASA_ANDABA.Habitaciones (hab_hot_id, hab_tip_id, hab_numero, hab_piso, hab_vista, hab_habilitado,
									hab_tipo_porcentual)
	select distinct H.hot_id, M.habitacion_tipo_codigo, M.Habitacion_Numero, M.Habitacion_Piso, 
						M.Habitacion_Frente, 1, M.Habitacion_Tipo_Porcentual 
		from gd_esquema.Maestra M, EN_CASA_ANDABA.Hoteles H
		where H.hot_calle = M.hotel_calle and H.hot_calle_nro = M.hotel_nro_calle
		order by m.habitacion_tipo_codigo, H.hot_id
go
PRINT 'Habitaciones... OK!'

insert into EN_CASA_ANDABA.Regimenes_Hoteles (ryh_hot_id, ryh_reg_id)
	select distinct 
		(select hot_id from EN_CASA_ANDABA.Hoteles where Hotel_Calle = hot_calle and Hotel_Ciudad = hot_ciudad),
		(select reg_id from EN_CASA_ANDABA.Regimenes where  Regimen_Descripcion = reg_desc and reg_precio = Regimen_Precio )
		from gd_esquema.Maestra
go
PRINT 'Regimenes_Hoteles... OK!'

insert into EN_CASA_ANDABA.Usuarios (usu_nombre, usu_password, usu_estado, usu_apellido, usu_mail, usu_tel, 
								usu_fecha_nac, usu_documento, usu_intentos, usu_direccion, usu_username, usu_doc_id)
values
	('admin', hashbytes('SHA2_256', CAST(12345678 as nvarchar(50))), 1, 'admin', 'admin@en_casa_andaba.com', '4000-0000',
		getdate(), 12345678, 0, 'admin', 'admin', 1)
-- Rol de admin: SysAdmin
insert into EN_CASA_ANDABA.Roles_Usuarios (ryu_usu_id, ryu_rol_id)
	select U.usu_id, R.rol_id
		from EN_CASA_ANDABA.Usuarios U, EN_CASA_ANDABA.Roles R 
		where U.usu_username = 'admin' and rol_nombre = 'SysAdmin'
-- Hoteles del admin: TODOS
insert into EN_CASA_ANDABA.Hoteles_Usuarios (hyu_usu_id, hyu_hot_id)
	select U.usu_id, H.hot_id from EN_CASA_ANDABA.Usuarios U, EN_CASA_ANDABA.Hoteles H 
		where U.usu_username = 'admin'
go
PRINT 'Usuarios... OK!'

-- TABLA TEMPORAL DE CLIENTES REPETIDOS
-- elimina si ya existe
if OBJECT_ID( N'tempdb..#TemporalClientesRepetidos') is not null drop table #TemporalClientesRepetidos;
-- crea tabla temporal
create table #TemporalClientesRepetidos (pasaporte_repetido numeric(18,0))
-- inserta clientes repetidos 
insert into #TemporalClientesRepetidos (pasaporte_repetido)
	select distinct M1.Cliente_Pasaporte_Nro 
		from gd_esquema.Maestra M1, gd_esquema.Maestra M2 
		where M1.Cliente_Pasaporte_Nro = M2.Cliente_Pasaporte_Nro and M1.Cliente_Nombre <> M2.Cliente_Nombre 
		order by M1.Cliente_Pasaporte_Nro
-- FIN TABLA TEMPORAL DE CLIENTES REPETIDOS

insert into EN_CASA_ANDABA.ClientesErrores
	select distinct 1, Cliente_Pasaporte_Nro, Cliente_Nombre, Cliente_Apellido, Cliente_Mail,
		Cliente_Nacionalidad, Cliente_Fecha_Nac, 1, Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso,
		Cliente_Depto, null, null, null, 'Pasaporte Repetido'
		from gd_esquema.Maestra M where M.cliente_pasaporte_nro in (select * from #TemporalClientesRepetidos)
go
PRINT 'ClientesErrores... OK!'

insert into EN_CASA_ANDABA.Clientes
	select distinct Cliente_Pasaporte_Nro, 1, Cliente_Nombre, Cliente_Apellido, Cliente_Mail,
		Cliente_Nacionalidad, Cliente_Fecha_Nac, 1, Cliente_Dom_Calle, Cliente_Nro_Calle, Cliente_Piso,
		Cliente_Depto, null, null, null
		from gd_esquema.Maestra M where M.cliente_pasaporte_nro not in (select * from #TemporalClientesRepetidos)
go
drop table #TemporalClientesRepetidos
PRINT 'Clientes... OK!'

alter table EN_CASA_ANDABA.Reservas
alter column res_estados_id int NULL
-- reservas clientes
insert into EN_CASA_ANDABA.Reservas (res_id, res_fecha, res_inicio, res_fin, res_tip_id, res_reg_id, 
								res_cli_documento, res_usu_id, res_cli_doc_id)
	select distinct reserva_codigo, getdate(), reserva_fecha_inicio, 
					dateadd(day, reserva_cant_noches, reserva_fecha_inicio),
					Habitacion_Tipo_Codigo, reg_id, C.cli_documento, usu_id, 1
		from gd_esquema.Maestra M, EN_CASA_ANDABA.Regimenes R, EN_CASA_ANDABA.Usuarios U, EN_CASA_ANDABA.Clientes C
		where M.regimen_descripcion = R.reg_desc and U.usu_username = 'admin' and C.cli_documento = M.Cliente_Pasaporte_Nro
go
-- reservas clientesErrores
insert into EN_CASA_ANDABA.Reservas (res_id, res_fecha, res_inicio, res_fin, res_tip_id, res_reg_id, 
								res_usu_id, res_cye_id)
	select distinct reserva_codigo, getdate(), reserva_fecha_inicio, 
					dateadd(day, reserva_cant_noches, reserva_fecha_inicio),
					Habitacion_Tipo_Codigo, reg_id, usu_id, C.cye_id
		from gd_esquema.Maestra M, EN_CASA_ANDABA.Regimenes R, EN_CASA_ANDABA.Usuarios U, EN_CASA_ANDABA.ClientesErrores C
		where M.regimen_descripcion = R.reg_desc and U.usu_username = 'admin' 
			and C.cye_documento = M.Cliente_Pasaporte_Nro and C.cye_apellido = m.Cliente_Apellido 
			and C.cye_nombre = M.Cliente_Nombre
go

update EN_CASA_ANDABA.Reservas
	set res_estados_id =
				case when 
					(res_id in (select distinct reserva_codigo from gd_esquema.maestra
										where factura_nro is not null and estadia_fecha_inicio is not null))
				then
					(select estados_id from EN_CASA_ANDABA.Estados	
						where estados_desc='Reserva CON INGRESO')
				else
					(select estados_id from EN_CASA_ANDABA.Estados 
						where estados_desc='Reserva CANCELADA MAESTRA')
				end
-- Vuelvo a poner como NOT NULL el estado de la reserva
alter table EN_CASA_ANDABA.Reservas
alter column res_estados_id int NOT NULL
go
PRINT 'Reservas... OK!'

insert into EN_CASA_ANDABA.Reservas_Habitaciones(ryh_hab_id, ryh_hab_hot_id, ryh_res_id)
	select distinct Ha.hab_id, Ho.hot_id, M.reserva_codigo
		from gd_esquema.Maestra M, EN_CASA_ANDABA.Habitaciones Ha, EN_CASA_ANDABA.Hoteles Ho
		where Ho.hot_calle = M.hotel_calle and Ho.hot_calle_nro = M.hotel_nro_calle
				and Ha.hab_hot_id = Ho.hot_id and Ha.hab_numero = M.Habitacion_Numero
				and Ha.hab_piso = M.Habitacion_Piso
		order by reserva_codigo
go
PRINT 'Reservas_Habitaciones... OK!'

insert into EN_CASA_ANDABA.Usuarios_ReservasCancelaciones (urc_res_id, urc_usu_id, urc_fecha, urc_motivo)
	select distinct res_id, usu_id, res_fecha, 'Cancelación Tabla Maestra'
		from EN_CASA_ANDABA.Reservas R,	EN_CASA_ANDABA.Usuarios U, EN_CASA_ANDABA.Estados E
		where R.res_estados_id = E.estados_id and E.estados_desc = 'Reserva CANCELADA MAESTRA'
				and	U.usu_username = 'admin'
go
PRINT 'Usuarios_ReservasCancelaciones... OK!'

insert into EN_CASA_ANDABA.Estadias (est_res_id, est_usu_alta, est_checkin, est_checkout, est_cant_noches,
								est_precio, est_usu_salida, est_dias_sobrantes)
	select distinct M.Reserva_Codigo, U.usu_id, M.Estadia_Fecha_Inicio, 
					dateadd(day,M.Estadia_Cant_Noches,Estadia_Fecha_Inicio), M.Estadia_Cant_Noches,
					(((M.regimen_precio * M.habitacion_tipo_porcentual) + (hotel_cantEstrella * hotel_recarga_estrella)) * M.Estadia_Cant_Noches),
					U.usu_id, datediff(day,dateadd(day, M.Estadia_Cant_Noches, Estadia_Fecha_Inicio), R.res_fin)				
		from EN_CASA_ANDABA.Reservas R, gd_esquema.Maestra M, EN_CASA_ANDABA.Usuarios U
		where M.Reserva_Codigo = R.res_id and U.usu_id = R.res_usu_id and M.Estadia_Fecha_Inicio is not null
PRINT 'Estadias... OK!'

-- facturas clientes
insert into EN_CASA_ANDABA.Facturas
	select distinct M.Factura_Nro, C.cli_documento, M.Factura_Fecha, M.Factura_Total + E.est_precio, 
			E.est_res_id, mp.med_id, null, c.cli_doc_id, null
		from gd_esquema.Maestra M, EN_CASA_ANDABA.Clientes C, EN_CASA_ANDABA.Estadias E, 
			EN_CASA_ANDABA.MediosPago MP, EN_CASA_ANDABA.Reservas R
		where M.Factura_Nro is not null and M.Reserva_Codigo = R.res_id and E.est_res_id = R.res_id
			and MP.med_desc = 'Efectivo' and R.res_cli_documento = C.cli_documento 
			and R.res_cli_doc_id = C.cli_doc_id and M.Consumible_Codigo is null
		order by M.Factura_Nro
-- facturas clientesErrores
insert into EN_CASA_ANDABA.Facturas
	select distinct M.Factura_Nro, null, M.Factura_Fecha, M.Factura_Total + E.est_precio,
			E.est_res_id, MP.med_id, null, null, C.cye_id
		from gd_esquema.Maestra M, EN_CASA_ANDABA.ClientesErrores C, EN_CASA_ANDABA.Estadias E, 
			EN_CASA_ANDABA.MediosPago MP, EN_CASA_ANDABA.Reservas R
		where M.Factura_Nro is not null and M.Consumible_Codigo is null and M.Reserva_Codigo = R.res_id 
			and E.est_res_id = R.res_id and MP.med_desc = 'Efectivo' and R.res_cye_id = C.cye_id 
			and M.Cliente_Nombre = cye_nombre
	order by M.Factura_Nro
go
PRINT 'Facturas... OK!'

insert into EN_CASA_ANDABA.Items_Facturas (iyf_con_id, iyf_fac_id, iyf_cantidad, iyf_monto)
	select distinct consumible_codigo, factura_nro, sum(item_factura_monto), sum(item_factura_cantidad)
		from gd_esquema.Maestra
		where consumible_codigo is not null
		group by consumible_codigo, factura_nro
		order by factura_nro,consumible_codigo
go
PRINT 'Items_Facturas... OK!'

insert into EN_CASA_ANDABA.Clientes_Estadias (cye_cli_documento, cye_est_res_id, cye_hab_id, 
				cye_hab_hot_id, cye_cli_doc_id)
	select cli_documento, est_res_id, hab_id, hab_hot_id, cli_doc_id
		from gd_esquema.Maestra M, EN_CASA_ANDABA.Clientes C, EN_CASA_ANDABA.Estadias E, 
			EN_CASA_ANDABA.Habitaciones H, EN_CASA_ANDABA.Hoteles HO
		where M.Cliente_Pasaporte_Nro = C.cli_documento and M.reserva_codigo = est_res_id
			and H.hab_numero = M.Habitacion_Numero and H.hab_piso = M.Habitacion_Piso
			and H.hab_hot_id = Ho.hot_id and HO.hot_calle = M.Hotel_Calle
			and HO.hot_calle_nro = M.Hotel_Nro_Calle
			and M.Estadia_Fecha_Inicio is not null and M.consumible_codigo is null 
			and M.factura_nro is not null
insert into EN_CASA_ANDABA.Clientes_Estadias(cye_est_res_id, cye_hab_id, cye_hab_hot_id, cye_cye_id)
	select est_res_id, hab_id, hab_hot_id, cye_id
		from gd_esquema.Maestra M, EN_CASA_ANDABA.ClientesErrores C, EN_CASA_ANDABA.Estadias E, 
			EN_CASA_ANDABA.Habitaciones h, EN_CASA_ANDABA.Hoteles HO
		where M.Cliente_Pasaporte_Nro = C.cye_documento and M.reserva_codigo = est_res_id
			and H.hab_numero = M.Habitacion_Numero and H.hab_piso = M.Habitacion_Piso
			and H.hab_hot_id = HO.hot_id and HO.hot_calle = M.Hotel_Calle
			and HO.hot_calle_nro = M.Hotel_Nro_Calle and m.Estadia_Fecha_Inicio is not null 
			and M.consumible_codigo is null and M.factura_nro is not null
			and C.cye_nombre = M.Cliente_Nombre and C.cye_apellido = M.Cliente_Apellido
go
PRINT 'Clientes_Estadias... OK!'