CREATE TABLE public.talento_skill (
        id_skill              uuid,
        id_talento            uuid,
        PRIMARY Key (id_talento, id_skill),
        FOREIGN Key (id_skill) references skills (id),
        FOREIGN KEY (id_talento) references talentos (id)
);