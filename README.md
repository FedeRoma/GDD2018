# GDD2018

A tener en cuenta:
- El total de la factura no tiene sentido.
- Ver validacion de mail (Unique en el DER pero no en la BD)

------------------------------------------------------------------------
-- Dejo el insert para que se pueda probar el listado de bajas de hoteles

alter table en_casa_andaba.bajashotel nocheck constraint all
alter table en_casa_andaba.bajashotel
alter column baj_motivo varchar null
insert into en_casa_andaba.bajashotel (baj_hot_id,baj_fecha_inicio,baj_fecha_fin)
values
(1,'2018-01-01 00:00:00.000','2018-01-05 00:00:00.000'),
(1,'2018-01-10 00:00:00.000','2018-01-11 00:00:00.000'),
(1,'2018-01-15 00:00:00.000','2018-01-30 00:00:00.000'),
(2,'2018-01-01 00:00:00.000','2018-01-02 00:00:00.000'),
(2,'2018-01-02 00:00:00.000','2018-01-03 00:00:00.000'),
(3,'2018-01-01 00:00:00.000','2018-01-30 00:00:00.000'),
(4,'2018-03-01 00:00:00.000','2018-05-01 00:00:00.000')

exec EN_CASA_ANDABA.top5_hoteles_dias_fuera_de_servicio 1, 2018
------------------------------------------------------------------------
