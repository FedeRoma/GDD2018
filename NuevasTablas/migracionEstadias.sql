--Hay que correr primero Reservas y Usuario
CREATE SCHEMA EN_CASA_ANDABA 
go

CREATE FUNCTION EN_CASA_ANDABA.calcEstadiaDiasSobran 
	( @finRes datetime, @salidaEs datetime)

	RETURNS numeric(18,0)

AS

BEGIN

	DECLARE @sobranDias numeric(18,0)

	set @sobranDias = DATEDIFF(day,@salidaEs,@finRes)

	RETURN @sobranDias

END
go


insert into Estadias
 (est_res_id, est_usu_alta, est_checkin, est_checkout, est_cant_noches, est_precio, est_usu_salida,est_dias_sobrantes)
 
 ( 
 select distinct 
				maestra.Reserva_Codigo,
				usu.usu_id,
				maestra.Estadia_Fecha_Inicio,				
				maestra.Estadia_Fecha_Inicio + maestra.Estadia_Cant_Noches,
				maestra.Estadia_Cant_Noches,
				--reserv.costoTotal / res.cantNoches,
				maestra.Estadia_Cant_Noches,
				EN_CASA_ANDABA.calcEstadiaDiasSobran( reserv.res_fin,maestra.Estadia_Fecha_Inicio + maestra.Estadia_Cant_Noches)				
				
from Reservas reserv,
	 gd_esquema.Maestra maestra,
	 Usuarios usu
	 
where maestra.Reserva_Codigo = reserv.res_id and
	usu.usu_id = reserv.res_usu_id and
	maestra.Estadia_Fecha_Inicio is not null
)

order by maestra.Reserva_Codigo
GO




