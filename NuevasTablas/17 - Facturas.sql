SET IDENTITY_INSERT Facturas ON

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

select distinct Maestra.Factura_Nro,
				Cli.cli_documento,
				Mp.med_desc,
				Maestra.Factura_Fecha,
				Maestra.Factura_Total+Est.est_precio,
				Est.est_res_id,
				Mp.med_id,
				Tar.tar_id,				
				Cli.cli_doc_id,
				Ce.cye_cli_doc_id

from	gd_esquema.Maestra Maestra,
		Reservas Res,
		Estadias Est,
		Clientes Cli,
		MediosPago Mp,
		Tarjetas Tar,
		Clientes_Estadias Ce
		

where	Maestra.Factura_Nro is not null and
		Maestra.Reserva_Codigo = Res.res_id and
		Est.est_res_id = Res.res_id and
		Cli.cli_doc_id=Res.res_id and
		Mp.med_desc = 'Efectivo'
		
		order by Factura_Nro

SET IDENTITY_INSERT Facturas OFF

/*TRABAJO DE FEDE EN FACTURAS*/
/*
insert into GESTION_DE_GATOS.Factura(
				numero,
				fecha,
				total,
				formaDePago,
				estadia,
				cliente)				

select distinct M.Factura_Nro,
				M.Factura_Fecha,
				M.Factura_Total+R.costoTotal,
				F.idFormaDePago,
				E.idEstadia,
				C.idCli

from	gd_esquema.Maestra M,
		GESTION_DE_GATOS.Reserva R,
		GESTION_DE_GATOS.Estadia E,
		GESTION_DE_GATOS.Cliente C,
		GESTION_DE_GATOS.FormaDePago F 

where	M.Factura_Nro is not null and
		M.Reserva_Codigo = R.idReserva and
		E.reserva = R.idReserva and
		C.idCli=R.cliente and
		F.descripcion = 'Efectivo'
		
		order by Factura_Nro



insert into Facturas
select distinct M.Factura_Nro,M.Factura_Fecha,M.Factura_Total
from gd_esquema.Maestra M,
	Clientes C,
	Estadias E,
	MediosPago MP
where M.Factura_Nro is not null and m.estad
order by M.Factura_Nro


select distinct m1.Factura_Nro
from gd_esquema.Maestra m1, gd_esquema.Maestra m2 
where m1.Factura_Nro = m2.Factura_Nro and m1.Cliente_Nombre <> m2.Cliente_Nombre 
		order by m1.Factura_Nro
		*/
		
