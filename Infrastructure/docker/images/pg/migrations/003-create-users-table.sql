CREATE TABLE public.users (
                              id          UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                              name        VARCHAR(250) NOT NULL,
                              password    VARCHAR(250) NOT NULL,
                              id_xp       UUID,
                              country     VARCHAR(250) NOT NULL,
                              email       VARCHAR(250) UNIQUE NOT NULL,
                              pr_hora     FLOAT NOT NULL
);