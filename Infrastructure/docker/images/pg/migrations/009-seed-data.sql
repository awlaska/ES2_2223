-- Insert initial data into the authors table                                                                                                       
INSERT INTO experiencia (empresa, titulo, ano_ini, ano_fim)
VALUES ('Machado', 'Gestor', 2020, 2020),
       ('Clarice', 'Inspector', 2014, 2020),
       ('Jorge', 'Engenheiro', 2003, 2014);

-- Insert initial data into the books table                                                                                                         
INSERT INTO user (name, email, password, pais, pr_hora, id_xp)
VALUES ('Dom Casmurro', "msadasda","abc123" , 'portugal',200.00, (SELECT id FROM experiencia LIMIT 1 OFFSET 0)),
       ('The Hour of the Star', "asdasdasd", "123abc" , 'usa',250.00, (SELECT id FROM experiencia LIMIT 1 OFFSET 0)),
       ('Gabriela, Clove and Cinnamon', "asfegerggerg", "a1b2c3", 'brasil',180.00, (SELECT id FROM experiencia LIMIT 1 OFFSET 0));                                              