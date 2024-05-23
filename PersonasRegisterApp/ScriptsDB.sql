CREATE DATABASE PersonasDB;
GO

USE PersonasDB;
GO

CREATE TABLE [Personas] (
    [DocumentoIdentidad] nvarchar(450) NOT NULL,
    [Nombres] nvarchar(max) NOT NULL,
    [Apellidos] nvarchar(max) NOT NULL,
    [FechaNacimiento] datetime2 NOT NULL,
    CONSTRAINT [PK_Personas] PRIMARY KEY ([DocumentoIdentidad])
);

CREATE TABLE [Contactos] (
    [ContactoId] int NOT NULL IDENTITY,
    [PersonaDocumentoIdentidad] nvarchar(450) NULL,
    [Email] nvarchar(max),
    [DireccionFisica] nvarchar(max),
    [NumeroTelefonico] nvarchar(max),
    CONSTRAINT [PK_Contactos] PRIMARY KEY ([ContactoId]),
    CONSTRAINT [FK_Contactos_Personas_PersonaDocumentoIdentidad] FOREIGN KEY ([PersonaDocumentoIdentidad]) REFERENCES [Personas] ([DocumentoIdentidad]) ON DELETE CASCADE
);

CREATE INDEX [IX_Personas_DocumentoIdentidad] ON [Personas] ([DocumentoIdentidad]) WHERE [DocumentoIdentidad] IS NOT NULL;
