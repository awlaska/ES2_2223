CREATE TABLE experiencia (
                id              uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
                empresa         VARCHAR(250) NOT NULL,
                titulo          VARCHAR(250) NOT NULL,
                ano_ini         INT NOT NULL,
                ano_fim         INT,
);