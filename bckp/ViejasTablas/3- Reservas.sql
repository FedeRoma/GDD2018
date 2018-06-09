use GD1C2018
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Reservas
PRINT 'Migrando Reservas...'
ALTER TABLE Reservas
ALTER COLUMN res_usu_encargado int NULL
ALTER TABLE Reservas 
ALTER COLUMN res_fecha datetime NULL
ALTER TABLE Reservas 
ALTER COLUMN res_estados_id int NULL
ALTER TABLE Reservas NOCHECK CONSTRAINT ALL

INSERT INTO Reservas
select distinct reserva_codigo,null,null,reserva_fecha_inicio,dateadd(day,reserva_cant_noches,reserva_fecha_inicio),habitacion_tipo_codigo,
reg_id,(select top 1 cli_tipo_doc from clientes),cliente_pasaporte_nro,null,hab_id,hot_id
from gd_esquema.maestra m INNER JOIN 
(select reg_id,reg_desc from regimenes) r on r.reg_desc=m.Regimen_Descripcion INNER JOIN
(select hot_id,hot_calle,hot_calle_nro from hoteles) ho on ho.hot_calle=m.hotel_calle and ho.hot_calle_nro = m.Hotel_Nro_Calle INNER JOIN
(select hab_id,hab_hot_id,hab_numero from habitaciones) h on h.hab_hot_id=ho.hot_id and h.hab_numero = m.Habitacion_Numero

PRINT 'Reservas Migrados Papaaaa...'
ALTER TABLE Reservas CHECK CONSTRAINT ALL
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/	