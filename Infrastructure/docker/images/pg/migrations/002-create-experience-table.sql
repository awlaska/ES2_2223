CREATE TABLE public.experience (
                id              uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
                id_company      uuid,
                title           VARCHAR(250) NOT NULL,
                ano_ini         INT NOT NULL,
                ano_fim         INT,
                foreign key (id_company) references company (id)
);