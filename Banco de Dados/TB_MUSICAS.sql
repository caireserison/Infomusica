﻿CREATE TABLE TB_MUSICAS(
	[idMusica] INTEGER IDENTITY PRIMARY KEY,
	[idUsuario] INTEGER NOT NULL,
	[idFaixa] INTEGER NOT NULL,
	[dtInclusao] DATETIME NOT NULL
)