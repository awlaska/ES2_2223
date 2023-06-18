CREATE TABLE public.experience (
                                   id          UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                                   id_company  UUID,
                                   title       VARCHAR(250) NOT NULL,
                                   ano_ini     INT NOT NULL,
                                   ano_fim     INT
);