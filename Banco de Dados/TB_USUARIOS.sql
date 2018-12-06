CREATE TABLE TB_USUARIOS (
	[id] integer identity primary key,
	[nome] varchar(100) not null,
	[login] varchar(50) not null,
	[senha] varchar(50) not null
)