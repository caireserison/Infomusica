
CREATE TABLE TB_MUSICAS(
	[idUsuario] INTEGER NOT NULL
	[idFaixa] INTEGER NOT NULL
	[dtInclusao] DATETIME NOT NULL
	PRIMARY KEY(idUsuario,idFaixa,dtInclusao)
	)
	