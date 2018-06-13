use [GD1C2018]
go

-------------------------------------------------------------------------------
---------- ESQUEMA ------------------------------------------------------------
-------------------------------------------------------------------------------

create schema EN_CASA_ANDABA AUTHORIZATION gdHotel2018
go

-------------------------------------------------------------------------------
---------- FUNCIONES ----------------------------------------------------------
-------------------------------------------------------------------------------

create function EN_CASA_ANDABA.estaReservadaHabitacion 
	(@desde datetime, @hasta datetime, @habitacionId int) RETURNS bit as
	begin
-- Fecha de inicio cae dentro de la solicitada
		if(exists (select RYH.ryh_hab_id from EN_CASA_ANDABA.Reservas_Habitaciones RYH, EN_CASA_ANDABA.Reservas R
			where R.res_inicio > @desde and R.res_inicio < @hasta and R.res_id = RYH.ryh_res_id and 
			RYH.ryh_hab_id = @habitacionId and R.res_id not in (select urc_res_id 
			from EN_CASA_ANDABA.Usuarios_ReservasCancelaciones C)))
			begin
				return 1
			end
-- Fecha fin cae dentro de la solicitada
		if(exists (select RYH.ryh_hab_id from EN_CASA_ANDABA.Reservas_Habitaciones RYH, EN_CASA_ANDABA.Reservas R
			where R.res_fin > @desde and R.res_fin < @hasta and R.res_id = RYH.ryh_res_id and 
			RYH.ryh_hab_id = @habitacionId and R.res_id not in (select urc_res_id 
			from EN_CASA_ANDABA.Usuarios_ReservasCancelaciones C)))
			begin
				return 2
			end
-- Fecha inicio la reserva pedida, esta entre las fechas de la reserva
		if(exists (select RYH.ryh_hab_id from EN_CASA_ANDABA.Reservas_Habitaciones RYH, EN_CASA_ANDABA.Reservas R
			where R.res_inicio < @desde and R.res_fin > @desde and R.res_id = RYH.ryh_res_id and 
			RYH.ryh_hab_id = @habitacionId and R.res_id not in (select urc_res_id 
			from EN_CASA_ANDABA.Usuarios_ReservasCancelaciones C))) 
			begin
				return 3
			end
-- Fecha fin reserva pedida, esta entre las fechas de la reserva
		if(exists (select RYH.ryh_hab_id from EN_CASA_ANDABA.Reservas_Habitaciones RYH, EN_CASA_ANDABA.Reservas R
			where R.res_inicio < @hasta and R.res_fin > @hasta and R.res_id = RYH.ryh_res_id and 
			RYH.ryh_hab_id = @habitacionId and R.res_id not in (select urc_res_id 
			from EN_CASA_ANDABA.Usuarios_ReservasCancelaciones C)))
			begin
				return 4
			end
-- Fechas iguales
		if(exists (select RYH.ryh_hab_id from EN_CASA_ANDABA.Reservas_Habitaciones RYH, EN_CASA_ANDABA.Reservas R
			where R.res_inicio = @desde and R.res_fin = @hasta and R.res_id = RYH.ryh_res_id and 
			RYH.ryh_hab_id = @habitacionId and R.res_id not in (select urc_res_id 
			from EN_CASA_ANDABA.Usuarios_ReservasCancelaciones C))) 
			begin
				return 5
			end
		RETURN 0
	end
go

create function EN_CASA_ANDABA.deudaConsumibles 
	(@estadiaId int) RETURNS numeric(18,2) as
	begin
		declare @deuda numeric(18,2)
		set @deuda = (select sum(iyf_monto) from EN_CASA_ANDABA.Items_Facturas IYF 
			where iyf_est_res_id = @estadiaId
			group by iyf_est_res_id)
		if(@deuda is null)
			begin
				set @deuda = 0
			end
		RETURN @deuda
	end        
go

-------------------------------------------------------------------------------				
---------- STORED PROCEDURES --------------------------------------------------
-------------------------------------------------------------------------------

create procedure EN_CASA_ANDABA.buscarHoteles
	@rolNombre varchar(50), @usuarioId int as
	select H.hot_id 
	from EN_CASA_ANDABA.Hoteles H, EN_CASA_ANDABA.Hoteles_Usuarios HU, EN_CASA_ANDABA.Roles R, 
		EN_CASA_ANDABA.Roles_Usuarios RU
	where HU.hyu_usu_id = @usuarioId and @rolNombre = R.rol_nombre and R.rol_id = RU.ryu_rol_id 
		and H.hot_id = HU.hyu_hot_id
go

create procedure EN_CASA_ANDABA.buscarRegimenesHotel
	@calle varchar(50), @numero int as
	begin
		select distinct R.reg_desc from EN_CASA_ANDABA.Hoteles HO, EN_CASA_ANDABA.Regimenes_Hoteles RYH, 
			EN_CASA_ANDABA.Regimenes R where HO.hot_calle = @calle and HO.hot_calle_nro = @numero and
			RYH.ryh_hot_id = HO.hot_id and RYH.ryh_reg_id = R.reg_id 
	end
go

create procedure EN_CASA_ANDABA.buscarHabitacionesDisponibles
	@hotelCalle varchar(50), @hotelNumero int, @fechaInicio date, @fechaFin date, @regimen nvarchar(255) = null,
	@tipoHabitacion nvarchar(255) as
	begin
		declare @fechaDesde date, @fechaHasta date, @hotelId int, @tipoHabitacionId int
		set @fechaDesde = CONVERT(date,@fechaInicio,121)
		set @fechaHasta = CONVERT(date,@fechaFin,121)
		set @hotelId = (select hot_id from EN_CASA_ANDABA.Hoteles where @hotelCalle = hot_calle and @hotelNumero = hot_calle_nro)
		set @tipoHabitacionId = (select tip_id from EN_CASA_ANDABA.TiposHabitaciones where tip_nombre = @tipoHabitacion)
		if (@regimen is null)
			begin
				select distinct HA.hab_id, HA.hab_vista, (R.reg_precio * TH.tip_personas) + (HO.hot_estrellas * HO.hot_recarga_estrellas) 
					PrecioPorNoche, R.reg_desc
					from EN_CASA_ANDABA.Habitaciones HA, EN_CASA_ANDABA.Hoteles HO, EN_CASA_ANDABA.TiposHabitaciones TH, EN_CASA_ANDABA.Regimenes R
					where HO.hot_id = @hotelId and TH.tip_id = @tipoHabitacionId and HA.hab_hot_id = @hotelId and
					HA.hab_tip_id = @tipoHabitacion and	not exists (select baj_hot_id 
					from EN_CASA_ANDABA.BajasHotel where baj_hot_id = @hotelId and 
					baj_fecha_inicio <= @fechaDesde and baj_fecha_fin >= @fechaDesde) and not exists (select baj_hot_id 
					from EN_CASA_ANDABA.BajasHotel where baj_hot_id = @hotelId and 
					baj_fecha_inicio <= @fechaHasta and baj_fecha_fin >= @fechaHasta) and
					(EN_CASA_ANDABA.estaReservadaHabitacion (@fechaDesde, @fechaHasta, HA.hab_id)) < 1
			end
		else
			begin
				declare @regimenId int
				set @regimenId = (select reg_id from EN_CASA_ANDABA.Regimenes where reg_desc = @regimen)
				select distinct HA.hab_id, HA.hab_vista, (R.reg_precio * TH.tip_personas) + (HO.hot_estrellas * HO.hot_recarga_estrellas) 
					PrecioPorNoche, R.reg_desc
					from EN_CASA_ANDABA.Habitaciones HA, EN_CASA_ANDABA.Hoteles HO, EN_CASA_ANDABA.TiposHabitaciones TH,
					EN_CASA_ANDABA.Regimenes R where R.reg_id = @regimenId and HO.hot_id = @hotelId and 
					TH.tip_id = @tipoHabitacionId and HA.hab_hot_id = @hotelId and HA.hab_tip_id = @tipoHabitacionId and
					not exists (select baj_hot_id from EN_CASA_ANDABA.BajasHotel where baj_hot_id = @hotelId and 
					baj_fecha_inicio <= @fechaDesde and baj_fecha_fin >= @fechaDesde) and 
					not exists (select baj_hot_id from EN_CASA_ANDABA.BajasHotel where baj_hot_id = @hotelId and 
					baj_fecha_inicio <= @fechaHasta and baj_fecha_fin >= @fechaHasta) and
					(EN_CASA_ANDABA.estaReservadaHabitacion (@fechaDesde, @fechaHasta, HA.hab_id)) < 1
			end
	end
go

create procedure EN_CASA_ANDABA.buscarTiposHabitacionesHotel
	@calle varchar(50), @numero int as
	begin
		select distinct TH.tip_nombre from EN_CASA_ANDABA.Hoteles HO, EN_CASA_ANDABA.TiposHabitaciones TH, 
			EN_CASA_ANDABA.Habitaciones H where HO.hot_calle = @calle and HO.hot_calle_nro = @numero 
			and H.hab_hot_id = HO.hot_id and TH.tip_id = H.hab_tip_id
	end
go

create procedure EN_CASA_ANDABA.buscarReservaHabitacion
	@reservaId int as
	begin
		select distinct RYH.ryh_hab_id, (REG.reg_precio * TH.tip_personas) + (HO.hot_estrellas * HO.hot_recarga_estrellas)
			from EN_CASA_ANDABA.Reservas R, EN_CASA_ANDABA.Regimenes REG, EN_CASA_ANDABA.Habitaciones H, 
			EN_CASA_ANDABA.Hoteles HO, EN_CASA_ANDABA.Reservas_habitaciones RYH, EN_CASA_ANDABA.TiposHabitaciones TH
			where R.res_id = @reservaId and R.res_reg_id = REG.reg_id and RYH.ryh_res_id = @reservaId and
			RYH.ryh_hab_id = H.hab_id and H.hab_hot_id = HO.hot_id and H.hab_tip_id = TH.tip_id
	end
go

create procedure EN_CASA_ANDABA.altaUsuario
	@rol varchar(50), @hotelCalle varchar(50), @hotelNumero int, @username varchar(50), @password varchar(50), @nombre varchar(50),
	@apellido varchar(50), @email varchar(50), @tel varchar(50), @tipoDocumento varchar(50), @nroDocumento bigint,
	@fechaNacimiento date, @direccion varchar(50) as
	begin
		declare @tipoDocumentoId int, @rolId int, @hotelId int, @usuarioId int, @respuesta bit
		begin tran tAltaUsuario
			begin try
				set @tipoDocumentoId = (select doc_id from EN_CASA_ANDABA.Documentos where @tipoDocumento = doc_desc)
				set @hotelId = (select hot_id from EN_CASA_ANDABA.Hoteles where @hotelCalle = hot_calle and @hotelNumero = hot_calle_nro)
				if (not exists (select usu_id from EN_CASA_ANDABA.Usuarios where @username = usu_username))
				begin
					insert into EN_CASA_ANDABA.Usuarios (usu_username, usu_password, usu_nombre, usu_apellido, 
						usu_doc_id, usu_documento, usu_fecha_nac, usu_mail, usu_tel, usu_estado, usu_direccion,
						usu_intentos) 
					values (@username, @password, @nombre, @apellido, @tipoDocumentoId, @nroDocumento, @fechaNacimiento,
						@email, @tel, 1, @direccion, 0)
				end 
				set @usuarioId = (select usu_id from EN_CASA_ANDABA.Usuarios where @username = usu_username)
				insert into EN_CASA_ANDABA.Hoteles_Usuarios (hyu_usu_id, hyu_hot_id)
				values (@usuarioId, @hotelId)
				set @rolId = (select rol_id from EN_CASA_ANDABA.Roles where @rol = rol_nombre)
				insert into EN_CASA_ANDABA.Roles_Usuarios (ryu_usu_id, ryu_rol_id)
				values (@usuarioId, @rolId)	
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

create procedure EN_CASA_ANDABA.modificacionUsuario
	@rol varchar(50), @hotelCalle varchar(50), @hotelNumero int, @username varchar(50), @password varchar(50), @nombre varchar(50),
	@apellido varchar(50), @email varchar(50), @tel varchar(50), @tipoDocumento varchar(50), @nroDocumento bigint,
	@fechaNacimiento date, @direccion varchar(50), @estado bit as
	begin
		declare @tipoDocId int, @rolId int, @hotelId int, @userId int, @respuesta bit
		begin tran tModificacionUsuario
			begin try
				set @userId = (select usu_id from EN_CASA_ANDABA.Usuarios where @username = usu_username)
				set @rolId = (select rol_id from EN_CASA_ANDABA.Roles where @rol = rol_nombre)
				set @tipoDocId = (select doc_id from EN_CASA_ANDABA.Documentos where @tipoDocumento = doc_desc)
				set @hotelId = (select hot_id from EN_CASA_ANDABA.Hoteles where @hotelCalle = hot_calle and @hotelNumero = hot_calle_nro)
				UPDATE EN_CASA_ANDABA.Usuarios        
				set usu_username = @username, usu_password = @password, usu_estado = @estado, usu_nombre = @nombre,
					usu_apellido = @apellido, usu_mail = @email, usu_tel = @tel, usu_fecha_nac = @fechaNacimiento,
					usu_documento = @nroDocumento, usu_direccion = @direccion, usu_doc_id = @tipoDocumento 
					where usu_id = @userId
				UPDATE EN_CASA_ANDABA.Hoteles_Usuarios
				set hyu_hot_id = @hotelId where hyu_usu_id = @userId and hyu_hot_id = @hotelId
				UPDATE EN_CASA_ANDABA.Roles_Usuarios
				set ryu_rol_id = @rolId where ryu_usu_id = @userId and ryu_rol_id = @rolId
				set @respuesta = 1
				select @respuesta as respuesta
				commit tran tModificacionUsuario
			end try
			begin catch
				rollback tran tModificacionUsuario
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.altaHotel
	@nombre varchar(50), @cantEstrellas int, @calle varchar(50), @numero int, @ciudad varchar(50), 
	@pais varchar(50), @email nvarchar(50), @telefono varchar(50), @fecha datetime,
	@recargaEstrellas int as
	begin
		declare @fechaCreacion datetime, @respuesta bit
		set @fechaCreacion = CONVERT(datetime,@fecha,121)
		begin tran tAltaHotel
			begin try
				insert into EN_CASA_ANDABA.Hoteles (hot_nombre, hot_estrellas, hot_calle, hot_calle_nro,
					hot_ciudad, hot_pais, hot_mail, hot_telefono, hot_fecha_cre, hot_habilitado, hot_recarga_estrellas) 
				values (@nombre, @cantEstrellas, @calle, @numero, @ciudad, @pais, @email, @telefono, @fechaCreacion,
					1, @recargaEstrellas)        
				set @respuesta = (select SCOPE_IDENTITY());
				select @respuesta as respuesta
				commit tran tAltaHotel
			end try
			begin catch
				rollback tran tAltaHotel
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.modificacionHotel
	@hotelId int, @nombre varchar(50), @cantEstrellas int, @calle varchar(50), @calleNro int, @ciudad varchar(50),
	@pais varchar(50), @email varchar(50), @telefono varchar(50), @fecha datetime, @habilitado bit,
	@recargaEstrellas int as
	begin
		declare @fechaCreacion datetime, @respuesta bit
		set @fechaCreacion = CONVERT(datetime,@fecha,121)
		begin tran tModificacionHotel
			begin try
				UPDATE EN_CASA_ANDABA.Hoteles
				set hot_nombre = @nombre, hot_estrellas = @cantEstrellas, hot_calle = @calle, 
				hot_calle_nro = @calleNro, hot_ciudad = @ciudad, hot_pais = @pais, hot_mail = @email,
				hot_telefono = @telefono, hot_fecha_cre = @fechaCreacion, hot_habilitado = @habilitado,
				hot_recarga_estrellas = @recargaEstrellas where hot_id = @hotelId
				set @respuesta = @hotelId
				select @respuesta as respuesta
				commit tran tModificacionHotel
			end try
			begin catch
				rollback tran tModificacionHotel
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
GO

create procedure EN_CASA_ANDABA.altaHabitacion
	@numero int, @piso int, @vista char(1), @tipoHabitacion varchar(50), @hotelId int,
	@descripcion varchar(50) = NULL as
	begin
		declare @tipoHabitacionId int, @respuesta bit
		begin tran tAltaHabitacion
			begin try
				set @tipoHabitacionId =(select tip_id from EN_CASA_ANDABA.TiposHabitaciones 
					where @tipoHabitacion = tip_nombre)
				insert into EN_CASA_ANDABA.Habitaciones (hab_numero, hab_piso, hab_vista, hab_tip_id, hab_hot_id,
					hab_desc, hab_habilitado) 
				values (@numero, @piso, @vista, @tipoHabitacionId, @hotelId, @descripcion, 1)
				set @respuesta = (select hab_id from EN_CASA_ANDABA.Habitaciones 
					where @numero = hab_numero and @piso = hab_piso and @tipoHabitacionId = hab_tip_id 
					and @hotelId = hab_hot_id)
				select @respuesta as respuesta
				commit tran tAltaHabitacion
			end try
			begin catch
				rollback tran tAltaHabitacion
					set @respuesta = 0
					select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.modificacionHabitacion
	@habitacionId int, @numero int, @piso int, @vista char(1), @tipoHabitacion varchar(50), @hotelId int,
	@descripcion varchar(50) = NULL, @habilitado bit as
	begin
		declare @tipoHabitacionId int, @respuesta bit
		begin tran tModificacionHabitacion
			begin try
				set @tipoHabitacionId = (select tip_id from EN_CASA_ANDABA.TiposHabitaciones 
					where @tipoHabitacion = tip_nombre)
				UPDATE EN_CASA_ANDABA.Habitaciones 
				set hab_numero = @numero, hab_piso = @piso, hab_vista = @vista, hab_tip_id = @tipoHabitacionId,
					hab_hot_id = @hotelId, hab_desc = @descripcion, hab_habilitado = @habilitado 
					where hab_id = @habitacionId
				set @respuesta = (select hab_id from EN_CASA_ANDABA.Habitaciones where hab_id = @habitacionId)
				select @respuesta as respuesta
				commit tran tModificacionHabitacion
			end try
			begin catch
				rollback tran tModificacionHabitacion
					set @respuesta = 0
					select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.altaCliente
	@documento bigint, @tipoDocumento varchar(50), @nombre varchar(50), @apellido varchar(50), @email varchar(50),
	@nacionalidad varchar(50), @fechaNac date, @calle varchar(50), @numeroCalle int, @piso nvarchar(10),
	@depto nvarchar(10), @localidad varchar(50), @pais varchar(50), @tel nvarchar(50) as
	begin
		declare @fechaNacimiento date
		set @fechaNacimiento = CONVERT(date,@fechaNac,121)
		declare @tipoDocumentoId int
		declare @respuesta bit
		begin tran tAltaCliente
			begin try
				set @tipoDocumentoId =(select doc_id from EN_CASA_ANDABA.Documentos
				where @tipoDocumento = doc_desc)
				if(not exists (select cli_doc_id, cli_documento from EN_CASA_ANDABA.Clientes 
					where cli_doc_id = @tipoDocumentoId and cli_documento = @documento))
					begin
						insert into EN_CASA_ANDABA.Clientes (cli_nombre, cli_apellido, cli_doc_id, cli_documento,
							cli_fecha_nac, cli_mail, cli_telefono, cli_habilitado, cli_nacionalidad, cli_calle,
							cli_calle_nro, cli_piso, cli_depto, cli_dir_localidad, cli_dir_pais)
						values (@nombre, @apellido, @tipoDocumentoId, @documento, @fechaNacimiento, @email, @tel,
							1, @nacionalidad, @calle, @numerocalle, @piso, @depto, @localidad, @pais)
					set @respuesta = 1;
					end
				else
					begin
						set @respuesta = 2;
					end
					select @respuesta as respuesta
					commit tran tAltaCliente
			end try
			begin catch
				rollback tran tAltaCliente
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.modificacionCliente
	@documento bigint, @nombre varchar(50), @apellido varchar(50), @email varchar(50),
	@nacionalidad varchar(50), @fechaNac date, @calle varchar(50), @numeroCalle int, @piso nvarchar(10),
	@depto nvarchar(10), @localidad varchar(50), @pais varchar(50), @tel nvarchar(50), @habilitado bit as	
	begin
		declare @fechaNacimiento date, @tipoDocumentoId int, @respuesta bit
		set @fechaNacimiento = CONVERT(date,@fechaNac,121)
		begin tran tModificacionCliente
			begin try
				set @tipoDocumentoId = (select cli_doc_id from EN_CASA_ANDABA.Clientes where cli_documento = @documento)
				UPDATE EN_CASA_ANDABA.Clientes
				set cli_nombre = @nombre, cli_apellido = @apellido, cli_doc_id = @tipoDocumentoId,
					cli_documento = @documento, cli_fecha_nac = @fechaNacimiento, cli_mail = @email,
					cli_telefono = @tel, cli_nacionalidad = @nacionalidad, cli_calle = @calle,
					cli_calle_nro = @numeroCalle, cli_piso = @piso, cli_depto = @depto,
					cli_dir_localidad = @localidad, cli_dir_pais = @pais, cli_habilitado = @habilitado
				where cli_doc_id = @tipoDocumentoId and cli_documento = @documento
				set @respuesta = 1
				select @respuesta as respuesta
				commit tran tModificacionCliente
			end try
			begin catch
			rollback tran tModificacionCliente
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.altaRol
	@rol varchar(50) as
	begin
		declare @respuesta bit
		begin tran tAltaRol
			begin try
				insert into EN_CASA_ANDABA.Roles (rol_nombre,rol_estado) 
				values (@rol, 1)
				set @respuesta = (select rol_id from EN_CASA_ANDABA.Roles where rol_nombre = @rol)
				select @respuesta as respuesta
				commit tran tAltaRol
			end try
			begin catch
				rollback tran tAltaRol
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.altaFuncionalidadRol
	@rol int, @funcionalidad int as
	begin
		declare @respuesta bit
		begin tran tAltaFuncionalidadRol
			begin try
				insert into EN_CASA_ANDABA.Funcionalidades_Roles (fyr_rol_id,fyr_fun_id) 
				values (@rol, @funcionalidad)
				set @respuesta = 1
				select @respuesta as respuesta
				commit tran tAltaFuncionalidadRol
			end try
			begin catch
				rollback tran tAltaFuncionalidadRol
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.altaRegimenesHotel
	@regimenId int, @hotelId int as
	begin
		declare @respuesta bit
		begin tran tAltaRegimenesHotel
			begin try
				insert into EN_CASA_ANDABA.Regimenes_Hoteles (ryh_hot_id, ryh_reg_id) 
				values(@hotelId, @regimenId)
				set @respuesta = (select SCOPE_IDENTITY())
				select @respuesta as respuesta
				commit tran tAltaRegimenesHotel
			end try
			begin catch
				rollback tran tAltaRegimenesHotel
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.bajaRegimenesHotel
	@hotelId int as
	begin
		declare @respuesta bit
		begin tran tBajaRegimenesHotel
			begin try
				delete from EN_CASA_ANDABA.Regimenes_Hoteles where ryh_hot_id = @hotelId
				set @respuesta = 1
				select @respuesta as respuesta
				commit tran tBajaRegimenesHotel
			end try
			begin catch
				rollback tran tBajaRegimenesHotel
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.bajaReservasVencidas
	@fecha date as
	begin
		declare @hoy date, @estadoId int, @respuesta bit
		set @hoy = CONVERT(date,@fecha,121)
		begin tran tBajaReservasVencidas
			begin try
				set @estadoId = (select estados_id from EN_CASA_ANDABA.Estados 
				where estados_desc = 'Reserva CANCELADA POR NO-SHOW')
				UPDATE EN_CASA_ANDABA.Reservas 
				set res_estados_id = @estadoId 
				where res_id in (select distinct R.res_id from EN_CASA_ANDABA.Reservas R 
					where R.res_inicio < @hoy and R.res_id not in (select distinct est_res_id 
					from EN_CASA_ANDABA.Estadias))
				insert into EN_CASA_ANDABA.Usuarios_ReservasCancelaciones (urc_usu_id, urc_res_id, urc_motivo, 
					urc_fecha)
				select distinct 1, res_id, 'Reserva CANCELADA POR NO-SHOW', res_inicio 
				from EN_CASA_ANDABA.Reservas 
				where res_estados_id = @estadoId
				set @respuesta = 1
				select @respuesta as respuesta
				commit tran tBajaReservasVencidas
			end try
			begin catch
				rollback tran tBajaReservasVencidas
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.altaReserva
	@fecha datetime, @inicio date, @fin date, @tipoHabitacion varchar(50), @regimen varchar(50),
	@documento bigint, @tipoDocumento varchar(50), @usuarioId int as
	begin
		declare @fechaInicio date, @fechaFin date, @fechaR datetime, @regimenId int, @tipoHabitacionId int,
			@estadoId int, @tipoDocumentoId int, @respuesta bit
		set @fechaInicio = CONVERT(date,@inicio,121)		
		set @fechaFin = CONVERT(date,@fin,121)
		set @fechaR = CONVERT(datetime,@fecha,121)
		begin tran tAltaReserva
			begin try
				set @regimenId = (select reg_id from EN_CASA_ANDABA.Regimenes where @regimen = reg_desc)
				set @tipoHabitacionId = (select tip_id from EN_CASA_ANDABA.TiposHabitaciones 
					where @tipoHabitacion = tip_nombre)
				set @estadoId = (select estados_id from EN_CASA_ANDABA.Estados 
					where 'Reserva CORRECTA' = estados_desc)
				set @tipoDocumentoId =(select doc_id from EN_CASA_ANDABA.Documentos where @tipoDocumento = doc_desc)
				insert into EN_CASA_ANDABA.Reservas (res_inicio, res_reg_id, res_fin, res_fecha, res_estados_id,
					res_usu_id, res_tip_id, res_cli_doc_id, res_cli_documento)
				values (@fechaInicio, @regimenId, @fechaFin, @fechaR, @estadoId, @usuarioId, @tipoHabitacionId, 
					@tipoDocumentoId, @documento)
				set @respuesta = (select SCOPE_IDENTITY())
				select @respuesta as respuesta
				commit tran tAltaReserva
			end try
			begin catch
				rollback tran tAltaReserva
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.modificacionReserva
	@reservaId int, @fecha datetime, @inicio date, @fin date, @tipoHabitacion varchar(50), @regimen varchar(50),
	@documento bigint, @usuarioId int, @tipoDocumento int as
	begin
		declare @fechaInicio date, @fechaFin date, @fechaReg datetime, @regimenId int, @tipoHabitacionId int,
			 @estadoId int, @respuesta bit
		set @fechaInicio = CONVERT(date,@inicio,121)
		set @fechaFin = CONVERT(date,@fin,121)
		set @fechaReg = CONVERT(datetime,@fecha,121)
		begin tran tModificacionReserva
			begin try
				set @regimenId = (select reg_id from EN_CASA_ANDABA.Regimenes where @regimen = reg_desc)
				set @tipoHabitacionId = (select tip_id from EN_CASA_ANDABA.TiposHabitaciones
					where @tipoHabitacion = tip_nombre)
				set @estadoId = (select estados_id from EN_CASA_ANDABA.Estados where 'Reserva MODIFICADA' = estados_desc)
				UPDATE EN_CASA_ANDABA.Reservas 
				set res_inicio = @fechaInicio, res_reg_id = @regimenId, res_fin = @fechaFin,
					res_estados_id = @estadoId, res_usu_id= @usuarioId where res_id = @reservaId
				insert into EN_CASA_ANDABA.Usuarios_ReservasModificaciones (urm_usu_id, urm_res_id, urm_fecha)
				values (@usuarioId, @reservaId, @fechaReg)
				set @respuesta = 1
				select @respuesta as respuesta
				commit tran tModificacionReserva
			end try
			begin catch
				rollback tran tModificacionReserva
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.bajaReserva
	@reservaId int, @usuarioId int, @estadoId int, @fechaI datetime, @motivo varchar(50) as
	begin
		declare @fecha datetime, @respuesta bit
		set @fecha = CONVERT(datetime,@fechaI,121)
		begin tran tBajaReserva
			begin try
				UPDATE EN_CASA_ANDABA.Reservas 
				set res_estados_id = @estadoId where res_id = @reservaId;
				insert into EN_CASA_ANDABA.Usuarios_ReservasCancelaciones (urc_usu_id, urc_res_id, urc_motivo,
					urc_fecha)
				values (@usuarioId, @reservaId, @motivo, @fecha)
				set @respuesta = 1
				select @respuesta as respuesta
				commit tran tBajaReserva
			end try
			begin catch
				rollback tran tBajaReserva
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.altaReservaHabitacion
	@reservaId int, @habitacionId int, @hotelId int as
	begin
		declare @respuesta bit
		begin tran tAltaReservaHabitacion
			begin try
				insert into EN_CASA_ANDABA.Reservas_Habitaciones (ryh_res_id, ryh_hab_id, ryh_hab_hot_id) 
				values (@reservaId, @habitacionId, @hotelId)
				set @respuesta = (select ryh_res_id, ryh_hab_id, ryh_hab_hot_id 
					from EN_CASA_ANDABA.Reservas_Habitaciones 
					where ryh_res_id = @reservaId and ryh_hab_id = @habitacionId and ryh_hab_hot_id = @hotelId)
				select @respuesta as respuesta
				commit tran tAltaReservaHabitacion
			end try
		begin catch
			rollback tran tAltaReservaHabitacion
			set @respuesta = 0
			select @respuesta as respuesta
		end catch
	end
go

create procedure EN_CASA_ANDABA.bajaReservaHabitacion
	@reservaId int, @habitacionId int, @hotelId int as
	begin
		declare @respuesta bit
		begin tran tBajaReservaHabitacion
			begin try
				delete from EN_CASA_ANDABA.Reservas_Habitaciones where RYH_res_id = @reservaId and 
					ryh_hab_id = @habitacionId and RYH_hab_hot_id = @hotelId
				set @respuesta = 1
				select @respuesta as respuesta
				commit tran tBajaReservaHabitacion
			end try
			begin catch
				rollback tran tBajaReservaHabitacion
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.altaClientes_Estadias
	@documento int, @tipoDocumento int, @estadiaId int, @habitacionId int, @habitacionHotelId int as 
	begin
		declare @respuesta bit
		begin tran tAltaClientes_Estadias
			begin try
				insert into EN_CASA_ANDABA.Clientes_Estadias (cye_cli_documento, cye_est_res_id, cye_hab_id, 
					cye_hab_hot_id, cye_cli_doc_id) 
				values (@documento, @estadiaId, @habitacionId, @habitacionHotelId, @tipoDocumento)
				set @respuesta = 1
				select @respuesta as respuesta
				commit tran tAltaClientes_Estadias
			end try
			begin catch
				rollback tran tAltaClientes_Estadias
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.modificacionClientes_Estadias
	@documento int, @tipoDocumento int, @estadiaId int, @habitacionId int, @habitacionHotelId int as
	begin
		declare @respuesta bit
		begin tran tModificacionClientes_Estadias
			begin try
				UPDATE EN_CASA_ANDABA.Clientes_Estadias
				set cye_hab_id = @habitacionId, cye_hab_hot_id = @HabitacionHotelId
					where cye_est_res_id = @estadiaId and cye_cli_documento = @documento  and cye_cli_doc_id = @tipoDocumento
				set @respuesta = 1
				select @respuesta as respuesta
				commit tran tModificacionClientes_Estadias
			end try
			begin catch
				rollback tran tModificacionClientes_Estadias
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.altaTarjeta 
	@facturaId int, @banco varchar(50), @emisor varchar(50), @numero bigint, @titular varchar(50) as
	begin
		declare @resultado bit
		begin tran tAltaTarjeta
		begin try
			insert into EN_CASA_ANDABA.Tarjetas(tar_emisor, tar_numero, tar_banco, tar_titular) 
			values (@emisor, @numero, @banco, @titular)
			UPDATE EN_CASA_ANDABA.Facturas set fac_tar_id = (select SCOPE_IDENTITY()) where fac_id = @facturaId
			set @resultado = 1
			select @resultado as resultado
			commit tran tAltaTarjeta
		end try
		begin catch
			rollback tran tAltaTarjeta
			set @resultado = 0
			select @resultado as resultado
		end catch
	end
go

create procedure EN_CASA_ANDABA.altaCheckInEstadia
	@reservaId int, @usuarioId int, @fechaI date as
	begin
	declare @fecha date, @estadoId int, @cantidadNoches int, @precio int, @respuesta bit
	set @fecha = CONVERT(date,@fechaI,121)
		begin tran tAltaCheckInEstadia
			begin try
				set @estadoId = (select estados_id 
				from EN_CASA_ANDABA.Estados 
				where estados_desc = 'Reserva CON INGRESO')
				set @cantidadNoches = (select datediff(day, res_inicio, res_fin) from EN_CASA_ANDABA.Reservas 
					where res_id = @reservaId)
				set @precio = (select((REG.reg_precio * HA.hab_tipo_porcentual) + ((HO.hot_estrellas * HO.hot_recarga_estrellas) * @cantidadNoches)) 
				from EN_CASA_ANDABA.Regimenes REG, EN_CASA_ANDABA.reservas R, EN_CASA_ANDABA.habitaciones HA, 
					EN_CASA_ANDABA.hoteles HO, EN_CASA_ANDABA.reservas_habitaciones RYH
				where R.res_id = @reservaId and REG.reg_id = R.res_reg_id and ryh_res_id = R.res_id 
					and ryh_hab_hot_id = HA.hab_hot_id and RYH.ryh_hab_id = HA.hab_id and HA.hab_hot_id = HO.hot_id)
				insert into EN_CASA_ANDABA.Estadias (est_res_id, est_checkin, est_usu_alta, est_precio,
					est_cant_noches)
				values (@reservaId, @fecha, @usuarioId, @precio, @cantidadNoches)
				UPDATE EN_CASA_ANDABA.Reservas 
				set res_estados_id = @estadoId where res_id = @reservaId
				set @respuesta = (select est_res_id from EN_CASA_ANDABA.Estadias 
					where est_res_id = @reservaId and est_checkin = @fecha)
				select @respuesta as respuesta
				commit tran tAltaCheckInEstadia
			end try
			begin catch
				rollback tran tAltaCheckInEstadia
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.altaCheckOutEstadia
	@estadiaId int, @fechaI date, @usuarioId int as
	begin
		declare @fecha date, @cantidadNoches int, @diasSobra int, @numeroReserva int, @finReserva date,
			 @respuesta bit 
		set @fecha = CONVERT(date,@fechaI,121)
		begin tran tAltaCheckOutEstadia
			begin try
				set @cantidadNoches = DATEDIFF(day, (select est_checkin from EN_CASA_ANDABA.Estadias 
					where est_res_id = @estadiaId), @fecha)
				set @numeroReserva = (select est_res_id from EN_CASA_ANDABA.Estadias 
					where est_res_id = @estadiaId)
				set @finReserva = (select res_fin from EN_CASA_ANDABA.Reservas 
					where res_id = @numeroReserva)
				set @diasSobra = DATEDIFF(day, @fecha, @finReserva)
				UPDATE EN_CASA_ANDABA.Estadias
				set est_usu_salida = @usuarioId, est_checkout = @fecha, est_dias_sobrantes = @diasSobra,
					est_cant_noches =  @cantidadNoches where est_res_id = @estadiaId
				commit tran tAltaCheckOutEstadia
			end try
			begin catch
				rollback tran tAltaCheckOutEstadia
				set @respuesta = 0
				select @respuesta as respuesta
			end catch
	end
go

create procedure EN_CASA_ANDABA.altaFactura 
	@estadiaId int, @medioPagoId int, @fechaI date as
	begin
	declare @fecha date, @regimenId int, @reservaId int, @deuda int, @tipoDocumentoId int, @documento bigint,
		@resultado bit 
	set @fecha = CONVERT(date,@fechaI,121)
	begin tran tAltaFactura
		begin try
			set @reservaId = (select est_res_id from EN_CASA_ANDABA.Estadias where est_res_id = @estadiaId)
			set @tipoDocumentoId = (select res_cli_doc_id from EN_CASA_ANDABA.Reservas where res_id = @reservaId)
			set @documento = (select res_cli_documento from EN_CASA_ANDABA.Reservas where res_id = @reservaId)
			set @regimenId = (select res_reg_id from EN_CASA_ANDABA.Reservas where res_id = @reservaId)
			if (@regimenId != 4)
				begin
					set @deuda = (select est_precio from EN_CASA_ANDABA.Estadias 
						where est_res_id = @estadiaId) + EN_CASA_ANDABA.deudaConsumibles(@estadiaId)
					insert into EN_CASA_ANDABA.Facturas (fac_est_res_id, fac_med_id, fac_cli_doc_id, 
						fac_cli_documento, fac_fecha, fac_total)
					values (@estadiaId, @medioPagoId, @tipoDocumentoId, @documento, @fecha, @deuda)
				end
			else
				begin
					set @deuda = (select est_precio from EN_CASA_ANDABA.Estadias where est_res_id = @estadiaId)
					insert into EN_CASA_ANDABA.Facturas (fac_est_res_id, fac_med_id, fac_cli_doc_id, 
						fac_cli_documento, fac_fecha, fac_total)
					values (@estadiaId, @medioPagoId, @tipoDocumentoID, @documento, @fecha, @deuda)
				end
			set @resultado = (select fac_id from EN_CASA_ANDABA.Facturas where fac_est_res_id = @estadiaId 
				and fac_fecha = @fecha)
			select @resultado as resultado
			commit tran	tAltaFactura
		end try
		begin catch
			rollback tran tAltaFactura
			set @resultado = 0
			select @resultado as resultado
		end catch
	end
go

create procedure EN_CASA_ANDABA.modificacionFactura 
	@estadiaId int, @medioPagoId int, @fechaI date as
	begin
	declare @fecha date, @regimenId int, @reservaId int, @deuda int, @tipoDocumentoId int, @documento bigint,
		@facturaId int, @resultado bit 
	set @fecha = CONVERT(date,@fechaI,121)
	begin tran tModificacionFactura
		begin try
			set @reservaId = (select est_res_id from EN_CASA_ANDABA.Estadias where est_res_id = @estadiaId)
			set @tipoDocumentoId = (select res_cli_doc_id from EN_CASA_ANDABA.Reservas where res_id = @reservaId)
			set @documento = (select res_cli_documento from EN_CASA_ANDABA.Reservas where res_id = @reservaId)
			set @regimenId = (select res_reg_id from EN_CASA_ANDABA.Reservas where res_id = @reservaId)
			set @facturaId = (select fac_id from EN_CASA_ANDABA.Facturas where fac_est_res_id = @estadiaId)
			if (@regimenId != 4)
				begin
					set @deuda = (select est_precio from EN_CASA_ANDABA.Estadias 
						where est_res_id = @estadiaId) + EN_CASA_ANDABA.deudaConsumibles(@estadiaId)
					UPDATE EN_CASA_ANDABA.Facturas
					set fac_med_id = @medioPagoId, fac_fecha = @fecha, fac_total = @deuda
						where fac_id = @facturaId
				end
			else
				begin
					set @deuda = (select est_precio from EN_CASA_ANDABA.Estadias where est_res_id = @estadiaId)
					UPDATE EN_CASA_ANDABA.Facturas
					set fac_med_id =@medioPagoId, fac_fecha = @fecha, fac_total = @deuda
						where fac_id = @facturaId
				end
			set @resultado = (select fac_id from EN_CASA_ANDABA.Facturas where fac_est_res_id = @estadiaId 
				and fac_fecha = @fecha)
			select @resultado as resultado
			commit tran	tModificacionFactura
		end try
		begin catch
			rollback tran tModificacionFactura
			set @resultado = 0
			select @resultado as resultado
		end catch
	end
go

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
		select top 5 total.hotel, ho.hot_id ,SUM(total.dias) as dias from  
			(select * from
				(select H.hot_id as hotel, SUM(DATEDIFF(day, B.baj_fecha_inicio, B.baj_fecha_fin)) as dias
					from EN_CASA_ANDABA.BajasHotel B, EN_CASA_ANDABA.Hoteles H
					where B.baj_hot_id = H.hot_id and B.baj_fecha_inicio between @inicio and @fin
						and B.baj_fecha_fin < @fin
					group by H.hot_id ) as antesFin
			UNION ALL
			select * from
				(select H.hot_id as hotel, SUM(DATEDIFF(day, B.baj_fecha_inicio,@fin)) as dias
					from EN_CASA_ANDABA.BajasHotel B, EN_CASA_ANDABA.Hoteles H
					where B.baj_hot_id = H.hot_id and B.baj_fecha_inicio between @inicio and @fin
						and B.baj_fecha_fin > @fin
					group by H.hot_id) as luegoFin) as total, EN_CASA_ANDABA.Hoteles HO
					where HO.hot_id = total.hotel
					group by total.hotel, HO.hot_id
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
		select distinct top 5 HO.hot_id as hotel, HA.hab_numero as numero_habitacion,
				HA.hab_piso as piso_habitacion, cantidad_habitacion.cantVeces as veces,
				cantidad_dias.Dias as dias
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
						order by cantVeces desc
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
		select top 5 C.cli_doc_id as tipo_documento, C.cli_documento as documento, C.cli_nombre as nombre, 
			C.cli_apellido as apellido, puntos_estadias.puntos+puntos_consumibles.puntos as puntos
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
				order by puntos desc
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
	tip_id int identity (1001,1) NOT NULL,
	tip_nombre varchar(50) NOT NULL,
	tip_porcentual int NOT NULL,
	tip_personas int NOT NULL)

create table EN_CASA_ANDABA.Hoteles_Usuarios (
	hyu_usu_id int NOT NULL,
	hyu_hot_id int NOT NULL,
	hyu_id int identity (1, 1) NOT NULL)

create table EN_CASA_ANDABA.Facturas (
	fac_id int identity (2396745,1) NOT NULL,
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
	iyf_monto int NULL,
	iyf_est_res_id int NOT NULL)

create table EN_CASA_ANDABA.Consumibles (
	con_id int identity (2324,1) NOT NULL,
	con_desc varchar(50) NOT NULL,
	con_precio int NOT NULL)

create table EN_CASA_ANDABA.Estadias (
	est_res_id int NOT NULL,
	est_usu_alta int NOT NULL,
	est_checkin date NULL,
	est_checkout date NULL,
	est_cant_noches int NULL,
	est_precio int NOT NULL,
	est_usu_salida int NULL,
	est_dias_sobrantes int NULL)

create table EN_CASA_ANDABA.Reservas (
	res_id int identity (10001,1) NOT NULL,
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
	rol_estado bit NOT NULL)

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
alter table EN_CASA_ANDABA.Items_Facturas
	ADD CONSTRAINT FK_Items_Facturas_Estadias FOREIGN KEY (iyf_est_res_id)
		REFERENCES EN_CASA_ANDABA.Estadias(est_res_id)

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
	('Administrador General', 1)
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
		where R.rol_nombre = 'Administrador General';
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

set IDENTITY_INSERT EN_CASA_ANDABA.TiposHabitaciones ON
insert into EN_CASA_ANDABA.TiposHabitaciones (tip_id, tip_nombre, tip_porcentual, tip_personas)
	select distinct Habitacion_Tipo_codigo, Habitacion_Tipo_descripcion, Habitacion_Tipo_porcentual, 1 from gd_esquema.Maestra
		update EN_CASA_ANDABA.TiposHabitaciones
			set tip_personas = case when tip_nombre = 'Base Simple' Then 1
									when tip_nombre = 'Base Doble' Then 2
									when tip_nombre = 'Base Triple' Then 3
									when tip_nombre = 'Base Cuadruple' Then 4
									else 5 end

set IDENTITY_INSERT EN_CASA_ANDABA.TiposHabitaciones OFF
go
PRINT 'TiposHabitaciones... OK!'

insert into EN_CASA_ANDABA.Regimenes (reg_desc, reg_precio, reg_habilitado)
	select distinct Regimen_Descripcion, Regimen_Precio, 1 
		from gd_esquema.Maestra
go
PRINT 'Regimenes... OK!'

set IDENTITY_INSERT EN_CASA_ANDABA.Consumibles ON
insert into EN_CASA_ANDABA.Consumibles (con_id, con_desc, con_precio)
	select distinct Consumible_Codigo, Consumible_Descripcion, Consumible_Precio 
		from gd_esquema.Maestra
		where Consumible_Codigo is not null
set IDENTITY_INSERT EN_CASA_ANDABA.Consumibles OFF
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
	('admin', hashbytes('SHA2_256', 'w23e'), 1, 'admin', 'admin@enCasaAndaba.com', '4000-0000',
		getdate(), 12345678, 0, 'admin', 'admin', 1)
-- Rol de admin: Administrador General
insert into EN_CASA_ANDABA.Roles_Usuarios (ryu_usu_id, ryu_rol_id)
	select U.usu_id, R.rol_id
		from EN_CASA_ANDABA.Usuarios U, EN_CASA_ANDABA.Roles R 
		where U.usu_username = 'admin' and rol_nombre = 'Administrador General'
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

-- inserta clientes repetidos POR EMAIL
insert into #TemporalClientesRepetidos (pasaporte_repetido)
	select distinct M1.Cliente_Pasaporte_Nro
		from gd_esquema.Maestra M1, gd_esquema.Maestra M2 
		where M1.Cliente_Mail = M2.Cliente_Mail and M1.Cliente_Pasaporte_Nro <> M2.Cliente_Pasaporte_Nro 
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
set IDENTITY_INSERT EN_CASA_ANDABA.Reservas ON
insert into EN_CASA_ANDABA.Reservas (res_id, res_fecha, res_inicio, res_fin, res_tip_id, res_reg_id, 
								res_cli_documento, res_usu_id, res_cli_doc_id)
	select distinct reserva_codigo, getdate(), reserva_fecha_inicio, 
					dateadd(day, reserva_cant_noches, reserva_fecha_inicio),
					Habitacion_Tipo_Codigo, reg_id, C.cli_documento, usu_id, 1
		from gd_esquema.Maestra M, EN_CASA_ANDABA.Regimenes R, EN_CASA_ANDABA.Usuarios U, EN_CASA_ANDABA.Clientes C
		where M.regimen_descripcion = R.reg_desc and U.usu_username = 'admin' and C.cli_documento = M.Cliente_Pasaporte_Nro
set IDENTITY_INSERT EN_CASA_ANDABA.Reservas OFF
go
-- reservas clientesErrores
set IDENTITY_INSERT EN_CASA_ANDABA.Reservas ON
insert into EN_CASA_ANDABA.Reservas (res_id, res_fecha, res_inicio, res_fin, res_tip_id, res_reg_id, 
								res_usu_id, res_cye_id)
	select distinct reserva_codigo, getdate(), reserva_fecha_inicio, 
					dateadd(day, reserva_cant_noches, reserva_fecha_inicio),
					Habitacion_Tipo_Codigo, reg_id, usu_id, C.cye_id
		from gd_esquema.Maestra M, EN_CASA_ANDABA.Regimenes R, EN_CASA_ANDABA.Usuarios U, EN_CASA_ANDABA.ClientesErrores C
		where M.regimen_descripcion = R.reg_desc and U.usu_username = 'admin' 
			and C.cye_documento = M.Cliente_Pasaporte_Nro and C.cye_apellido = m.Cliente_Apellido 
			and C.cye_nombre = M.Cliente_Nombre
set IDENTITY_INSERT EN_CASA_ANDABA.Reservas OFF
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
set IDENTITY_INSERT EN_CASA_ANDABA.Facturas ON
insert into EN_CASA_ANDABA.Facturas (fac_id, fac_cli_documento, fac_fecha, fac_total,fac_est_res_id,fac_med_id,fac_cli_doc_id)
	select distinct M.Factura_Nro, C.cli_documento, M.Factura_Fecha, M.Factura_Total + E.est_precio, 
			E.est_res_id, mp.med_id, c.cli_doc_id
		from gd_esquema.Maestra M, EN_CASA_ANDABA.Clientes C, EN_CASA_ANDABA.Estadias E, 
			EN_CASA_ANDABA.MediosPago MP, EN_CASA_ANDABA.Reservas R
		where M.Factura_Nro is not null and M.Reserva_Codigo = R.res_id and E.est_res_id = R.res_id
			and MP.med_desc = 'Efectivo' and R.res_cli_documento = C.cli_documento 
			and R.res_cli_doc_id = C.cli_doc_id and M.Consumible_Codigo is null
		order by M.Factura_Nro
set IDENTITY_INSERT EN_CASA_ANDABA.Facturas OFF
-- facturas clientesErrores
SET IDENTITY_INSERT EN_CASA_ANDABA.Facturas ON
insert into EN_CASA_ANDABA.Facturas (fac_id, fac_fecha, fac_total,fac_est_res_id,fac_med_id,fac_cye_id)
	select distinct M.Factura_Nro, M.Factura_Fecha, M.Factura_Total + E.est_precio,
			E.est_res_id, MP.med_id, C.cye_id
		from gd_esquema.Maestra M, EN_CASA_ANDABA.ClientesErrores C, EN_CASA_ANDABA.Estadias E, 
			EN_CASA_ANDABA.MediosPago MP, EN_CASA_ANDABA.Reservas R
		where M.Factura_Nro is not null and M.Consumible_Codigo is null and M.Reserva_Codigo = R.res_id 
			and E.est_res_id = R.res_id and MP.med_desc = 'Efectivo' and R.res_cye_id = C.cye_id 
			and M.Cliente_Nombre = cye_nombre
	order by M.Factura_Nro
set IDENTITY_INSERT EN_CASA_ANDABA.Facturas OFF
PRINT 'Facturas... OK!'

insert into EN_CASA_ANDABA.Items_Facturas (iyf_con_id, iyf_fac_id, iyf_cantidad, iyf_monto, iyf_est_res_id)
	select distinct consumible_codigo, factura_nro, sum(item_factura_monto), sum(item_factura_cantidad), Reserva_Codigo
		from gd_esquema.Maestra
		where consumible_codigo is not null
		group by consumible_codigo, factura_nro, reserva_codigo
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