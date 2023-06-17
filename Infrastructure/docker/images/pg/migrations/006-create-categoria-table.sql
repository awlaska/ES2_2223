CREATE TABLE categoria (
        id              uuid PRIMARY KEY DEFAULT uuid_generate_v4(),
        name            VARCHAR(250) UNIQUE NOT NULL,
);