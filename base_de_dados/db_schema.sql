@@ -0,0 +1,45 @@
CREATE TABLE public.user (
	id              serial PRIMARY KEY,
	name            VARCHAR(250) UNIQUE NOT NULL,
    password        VARCHAR(250) UNIQUE NOT NULL,
    id_xp           serial
    pais            VARCHAR(250) UNIQUE NOT NULL,
    email           VARCHAR(250) UNIQUE NOT NULL,
    pr_hora         FLOAT UNIQUE NOT NULL,
);

CREATE TABLE public.user_skill (
	id_user         serial PRIMARY KEY,
	id_skill        serial PRIMARY KEY,
    anos_xp         INT UNIQUE NOT NULL,
);

CREATE TABLE public.skills (
	id              serial PRIMARY KEY,
	name            VARCHAR(250) UNIQUE NOT NULL,
    area            VARCHAR(250) UNIQUE NOT NULL,
);

CREATE TABLE public.experiencia (
	id              serial PRIMARY KEY,
	empresa         VARCHAR(250) UNIQUE NOT NULL,
    titulo          VARCHAR(250) UNIQUE NOT NULL,
    ano_ini         INT UNIQUE NOT NULL,
    ano_fim         INT UNIQUE NOT NULL,
);

CREATE TABLE public.talentos (
	id              serial PRIMARY KEY,
	name            VARCHAR(250) UNIQUE NOT NULL,
    id_categoria    serial
);

CREATE TABLE public.talento_skill (
	id_skill              serial PRIMARY KEY,
	id_talento              serial PRIMARY KEY,
);

CREATE TABLE public.categoria (
	id              serial PRIMARY KEY,
	name            VARCHAR(250) UNIQUE NOT NULL,
);