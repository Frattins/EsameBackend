-- Creazione tabella Anagrafiche

CREATE TABLE ANAGRAFICHE (
    idanagrafica INT PRIMARY KEY IDENTITY,
    Cognome NVARCHAR(50),
    Nome NVARCHAR(50),
    Indirizzo NVARCHAR(100),
    Città NVARCHAR(50),
    CAP VARCHAR(10),
    Cod_Fisc VARCHAR (16) UNIQUE
);

-- Creazione tabella TIPO_VIOLAZIONE 

CREATE TABLE TIPO_VIOLAZIONE (
    idviolazione INT PRIMARY KEY IDENTITY,
    descrizione NVARCHAR(255)
);

-- Creazione tabella VERBALI

CREATE TABLE VERBALI (
    idverbale INT PRIMARY KEY IDENTITY,
    idanagrafica INT,
    idviolazione INT,
    DataViolazione DATETIME2(7),
    IndirizzoViolazione VARCHAR(100),
    Nominativo_Agente NVARCHAR(50),
    DataTrascrizioneVerbale DATETIME2(7),
    Importo DECIMAL(10, 2),
    DecurtamentoPunti INT,
    FOREIGN KEY (idanagrafica) REFERENCES ANAGRAFICHE(idanagrafica),
    FOREIGN KEY (idviolazione) REFERENCES TIPO_VIOLAZIONE(idviolazione)
);