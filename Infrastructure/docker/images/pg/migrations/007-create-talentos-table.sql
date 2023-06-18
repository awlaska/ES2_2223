CREATE TABLE public.talentos (
                                 id           UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                                 name         VARCHAR(250) UNIQUE NOT NULL,
                                 id_categoria UUID
);