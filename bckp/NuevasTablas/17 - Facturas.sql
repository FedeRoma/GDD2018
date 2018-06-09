SET IDENTITY_INSERT Facturas ON
/*
insert into Facturas(
				fac_id,
				fac_cli_documento,
				fac_tipo_pago,
				fac_fecha,
				fac_total,
				fac_est_res_id,
				fac_med_id,
				fac_tar_id,
				fac_cli_doc_id,
				fac_cye_id
				)				
*/

SET IDENTITY_INSERT Facturas OFF

/*TRABAJO DE FEDE EN FACTURAS*/

--Facturas para clientes
insert into EN_CASA_ANDABA.Facturas
select distinct M.Factura_Nro,C.cli_documento,M.Factura_Fecha,M.Factura_Total,E.est_res_id,mp.med_id,null,c.cli_doc_id,null
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
order by M.Factura_Nro

--Facturas para clientesErrores
insert into EN_CASA_ANDABA.Facturas
select distinct M.Factura_Nro,C.cye_documento,M.Factura_Fecha,M.Factura_Total,E.est_res_id,mp.med_id,null,C.cye_doc_id,C.cye_id
from gd_esquema.Maestra M,
	EN_CASA_ANDABA.ClientesErrores C,
	EN_CASA_ANDABA.Estadias E,
	EN_CASA_ANDABA.MediosPago MP,
	EN_CASA_ANDABA.Reservas R
where M.Factura_Nro is not null 
AND M.Reserva_Codigo = R.res_id
and E.est_res_id = R.res_id
and MP.med_desc = 'Efectivo'
and R.res_cli_documento = C.cli_documento
and R.res_cli_doc_id = C.cli_doc_id
order by M.Factura_Nro






select distinct m1.Factura_Nro
from gd_esquema.Maestra m1, gd_esquema.Maestra m2 
where m1.Factura_Nro = m2.Factura_Nro and m1.Cliente_Nombre <> m2.Cliente_Nombre 
		order by m1.Factura_Nro
		
		
