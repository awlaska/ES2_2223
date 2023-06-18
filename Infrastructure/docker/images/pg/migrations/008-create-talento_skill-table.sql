CREATE TABLE public.talento_skill (
                                      id         UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                                      id_skill   UUID,
                                      id_talento UUID
);