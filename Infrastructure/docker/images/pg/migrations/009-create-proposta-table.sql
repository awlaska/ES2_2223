CREATE TABLE public.proposta (
                                 id          UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                                 id_company  UUID,
                                 id_cat      UUID,
                                 id_user     UUID,
                                 descricao   VARCHAR(250) NOT NULL
);