CREATE TABLE public.talento_skill (
        id                    uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
        id_skill              uuid,
        id_talento            uuid,
        FOREIGN Key (id_skill) references skills (id),
        FOREIGN KEY (id_talento) references talentos (id)
);