CREATE TABLE public.user_skill (
                                   id      UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
                                   id_user UUID,
                                   id_skill UUID,
                                   anos_xp INT NOT NULL
);