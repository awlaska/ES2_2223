CREATE TABLE public.talentos (
          id              uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
          name            VARCHAR(250) UNIQUE NOT NULL,
          id_categoria    uuid,
          Foreign Key (id_categoria) references categoria (id)
);