create database Zapateria
use Zapateria

create table usuarios(
	id int identity primary key,
	usuario varchar(250),
	pass varchar(250),
	nombre varchar(250)

)

create table zapatos(
	id int identity primary key,
	nombre varchar(250),
	descripcion varchar(250),
	precio real,
	foto image,
	categoria int,
	stock int
)

create table colores_zapato(
	idzapato int,
	color varchar(29)
)

create table talla_zapato(
	idzapato int,
	talla varchar(29)
)
