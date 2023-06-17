CREATE TABLE skills (
                id              PRIMARY KEY DEFAULT uuid_generate_v4(),
                name            VARCHAR(250) UNIQUE NOT NULL,
                area            VARCHAR(250) UNIQUE NOT NULL,
);