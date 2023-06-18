CREATE TABLE public.company (
                                id       UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                                name     VARCHAR(250) UNIQUE NOT NULL
);