CREATE TABLE public.users (
         id              uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
         name            VARCHAR(250) UNIQUE NOT NULL,
         password        VARCHAR(250) UNIQUE NOT NULL,
         id_xp           uuid,
         country            VARCHAR(250) UNIQUE NOT NULL,
         email           VARCHAR(250) UNIQUE NOT NULL,
         pr_hora         FLOAT UNIQUE NOT NULL,
         foreign key (id_xp) references experience (id)
);