-- Insert initial data into the company table
INSERT INTO company (name)
VALUES ('CompanyA'),
       ('CompanyB'),
       ('CompanyC');

INSERT INTO roles (id,name)
VALUES (0,'Admin'),
       (1,'Manager'),
       (2,'User');

-- Insert initial data into the experience table
INSERT INTO experience (id_company, title, ano_ini, ano_fim)
VALUES ((SELECT id FROM company LIMIT 1 OFFSET 0), 'Gestor', 2020, 2020),
       ((SELECT id FROM company LIMIT 1 OFFSET 0), 'Inspector', 2014, 2020),
       ((SELECT id FROM company LIMIT 1 OFFSET 0), 'Engenheiro', 2003, 2014);

-- Insert initial data into the users table
INSERT INTO users (name, email, password, country, pr_hora, id_xp, role)
VALUES ('João Martins', 'joao.m@ipvc.pt', '.2DXVNkNVuS3W', 'Portugal', 100.00, (SELECT id FROM experience LIMIT 1 OFFSET 0), 1),
       ('Eunice Jordão', 'eunice@email.pt', '123abc', 'USA', 250.00, (SELECT id FROM experience LIMIT 1 OFFSET 1), 2),
       ('Daniel Albuquerque', 'daniel@email.pt', 'b2d34', 'Brasil', 180.00, (SELECT id FROM experience LIMIT 1 OFFSET 2), 2);

-- Insert initial data into the skills table
INSERT INTO skills (name, area)
VALUES ('Programing C#', 'Engenheiro'),
       ('Team Work', 'Gestor'),
       ('Programing Python', 'Developer');

-- Insert initial data into the user_skill table
INSERT INTO user_skill (id_user, id_skill, anos_xp)
VALUES ((SELECT id FROM users LIMIT 1 OFFSET 0), (SELECT id FROM skills LIMIT 1 OFFSET 0), 13),
       ((SELECT id FROM users LIMIT 1 OFFSET 0), (SELECT id FROM skills LIMIT 1 OFFSET 1), 7),
       ((SELECT id FROM users LIMIT 1 OFFSET 0), (SELECT id FROM skills LIMIT 1 OFFSET 2), 18);

-- Insert initial data into the categoria table
INSERT INTO categoria (name)
VALUES ('Computer'),
       ('Social'),
       ('Physical');

-- Insert initial data into the talentos table
INSERT INTO talentos (name, id_categoria)
VALUES ('Programing', (SELECT id FROM categoria LIMIT 1 OFFSET 0)),
       ('Social Interactions', (SELECT id FROM categoria LIMIT 1 OFFSET 0)),
       ('Physical', (SELECT id FROM categoria LIMIT 1 OFFSET 0));

-- Insert initial data into the talento_skill table
INSERT INTO talento_skill (id_talento, id_skill)
VALUES ((SELECT id FROM talentos LIMIT 1 OFFSET 0), (SELECT id FROM skills LIMIT 1 OFFSET 0)),
       ((SELECT id FROM talentos LIMIT 1 OFFSET 0), (SELECT id FROM skills LIMIT 1 OFFSET 1)),
       ((SELECT id FROM talentos LIMIT 1 OFFSET 0), (SELECT id FROM skills LIMIT 1 OFFSET 2));

-- Insert initial data into the proposta table
INSERT INTO proposta (id_company, id_cat, id_user, descricao)
VALUES ((SELECT id FROM company LIMIT 1 OFFSET 0), (SELECT id FROM categoria LIMIT 1 OFFSET 0), (SELECT id FROM users LIMIT 1 OFFSET 0), 'Emprego Incrível!!'),
       ((SELECT id FROM company LIMIT 1 OFFSET 0), (SELECT id FROM categoria LIMIT 1 OFFSET 0), (SELECT id FROM users LIMIT 1 OFFSET 0), 'Emprego bem pago!!'),
       ((SELECT id FROM company LIMIT 1 OFFSET 0), (SELECT id FROM categoria LIMIT 1 OFFSET 0), (SELECT id FROM users LIMIT 1 OFFSET 0), 'Programador Urgente!!');