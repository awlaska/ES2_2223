CREATE TABLE public.experience (
                id              uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
                company         VARCHAR(250) NOT NULL,
                title          VARCHAR(250) NOT NULL,
                ano_ini         INT NOT NULL,
                ano_fim         INT
);