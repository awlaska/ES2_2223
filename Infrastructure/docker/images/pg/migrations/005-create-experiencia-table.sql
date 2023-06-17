CREATE TABLE experiencia (
                id              uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
                empresa         VARCHAR(250) UNIQUE NOT NULL,
                titulo          VARCHAR(250) UNIQUE NOT NULL,
                ano_ini         INT UNIQUE NOT NULL,
                ano_fim         INT UNIQUE NOT NULL,
);