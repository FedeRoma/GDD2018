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
		
