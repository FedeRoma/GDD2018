use GD1C2018


--Facturas para clientes
insert into EN_CASA_ANDABA.Facturas
select distinct M.Factura_Nro,C.cli_documento,M.Factura_Fecha,M.Factura_Total+E.est_precio,E.est_res_id,mp.med_id,null,c.cli_doc_id,null
from gd_esquema.Maestra M,
	EN_CASA_ANDABA.Clientes C,
	EN_CASA_ANDABA.Estadias E,
	EN_CASA_ANDABA.MediosPago MP,
	EN_CASA_ANDABA.Reservas R
where M.Factura_Nro is not null 
AND M.Reserva_Codigo = R.res_id
and E.est_res_id = R.res_id
and MP.med_desc = 'Efectivo'
and R.res_cli_documento = C.cli_documento
and R.res_cli_doc_id = C.cli_doc_id
and M.Consumible_Codigo is null
order by M.Factura_Nro


--Facturas para clientesErrores
insert into EN_CASA_ANDABA.Facturas
select distinct M.Factura_Nro,C.cye_documento,M.Factura_Fecha,M.Factura_Total+E.est_precio,E.est_res_id,mp.med_id,null,C.cye_doc_id,C.cye_id
from gd_esquema.Maestra M,
	EN_CASA_ANDABA.ClientesErrores C,
	EN_CASA_ANDABA.Estadias E,
	EN_CASA_ANDABA.MediosPago MP,
	EN_CASA_ANDABA.Reservas R
where M.Factura_Nro is not null 
AND M.Reserva_Codigo = R.res_id
and E.est_res_id = R.res_id
and MP.med_desc = 'Efectivo'
and R.res_cli_documento = C.cye_documento
and R.res_cli_doc_id = C.cye_doc_id
and M.Consumible_Codigo is null
AND M.Cliente_Nombre = cye_nombre
order by M.Factura_Nro



