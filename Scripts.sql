create table Transportadoras(
Id int not null identity,
Descricao varchar(100) not null,
primary key(Id)
)

create table Classificacoes(
Id int not null identity,
Descricao varchar(100) not null,
primary key(Id)
)

create table Avaliacoes(
Id int not null identity,
UsuarioId int not null,
TransportadoraId int not null,
ClassificacaoId int not null,
primary key(Id),
FOREIGN KEY (UsuarioId) REFERENCES usuarios(UserId),
FOREIGN KEY (TransportadoraId) REFERENCES transportadoras(Id),
FOREIGN KEY (ClassificacaoId) REFERENCES classificacoes(Id)
)
