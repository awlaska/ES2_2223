CREATE TABLE public.user_skill (
        id_user         uuid,
        id_skill        uuid,
        PRIMARY KEY (id_user, id_skill),
        anos_xp         INT NOT NULL,
        Foreign Key (id_skill) references skills (id),
        FOREIGN Key (id_user) references users(id)
);
