use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Consumibles
PRINT 'Migrando Consumibles...'
insert into Consumibles (
						con_id,
						con_desc,
						con_precio)
select distinct Consumible_Codigo,Consumible_Descripcion,Consumible_Precio from gd_esquema.Maestra
where Consumible_Codigo is not null
GO
PRINT 'Consumibles Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/