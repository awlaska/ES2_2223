CREATE TABLE public.proposta (
         id                 uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
         id_company         uuid,
         id_cat              uuid,
         id_user            uuid,
         descricao           VARCHAR(250) NOT NULL,
         foreign key (id_cat) references categoria (id),
         foreign key (id_user) references users (id),
         foreign key (id_company) references company (id)
);