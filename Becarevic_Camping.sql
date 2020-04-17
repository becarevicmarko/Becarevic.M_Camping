create database db_reservierung collate utf8_general_ci;
use db_reservierung;

create table reservations(
	id int not null auto_increment,
    firstname varchar(100),
    lastname varchar(100) not null,
    gender varchar(100) not null,
	birthdate DATETIME not null,
	username DATETIME not null,
    password INT not null,
    password2 INT not null,
    
    
    constraint id_PK primary key(id)
)engine=InnoDB;

create table login(
	id int not null auto_increment,
    username varchar(100) not null unique,
    password varchar(128) not null,
    
    constraint id_PK primary key(id)
)engine=InnoDB;


create table reservierung(

	id int not null auto_increment, 
    firstname varchar(100) null, 
    lastname varchar(100) null,
    street varchar(100) null,
    phonenumber int not null, 
    birthdate date null, 
	category varchar(100) not null,
    
    
    
    constraint id_PK primary key(id)

)engine=InnoDB; 

INSERT INTO reservierung VALUES();


SELECT * from reservierung