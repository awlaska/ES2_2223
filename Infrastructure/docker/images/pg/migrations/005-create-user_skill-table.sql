CREATE TABLE public.user_skill (
        id              uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
        id_user         uuid,
        id_skill        uuid,
        anos_xp         INT NOT NULL,
        Foreign Key (id_skill) references skills (id),
        FOREIGN Key (id_user) references users(id)
);
