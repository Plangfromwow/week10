drop database bookclub;
create database bookclub;
use bookclub;

create table person(
id int NOT NULL auto_increment,
firstname varchar(50),
lastname varchar (50),
email varchar(50),
primary key (id)
);

create table presentation(
id int NOT NULL auto_increment,
personid int,
presentationdate datetime,
booktitle varchar(50),
bookauthor varchar(50),
genre varchar(50),
FOREIGN KEY (personid) references person(id),
Primary key (id)
);
