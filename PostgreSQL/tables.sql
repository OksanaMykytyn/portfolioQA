CREATE TABLE region
(
id_region INTEGER PRIMARY KEY,
name_region VARCHAR(40) NOT NULL
);

CREATE TABLE state
(
id_state INTEGER PRIMARY KEY,
name_state VARCHAR(30) NOT NULL
);

CREATE TABLE deposit
(
id_deposit INTEGER PRIMARY KEY,
name_deposit VARCHAR(30) NOT NULL,
address_deposit VARCHAR(50),
year_of_commissioning INTEGER,
number_of_wells INTEGER
);

CREATE TABLE production
(
id_region INTEGER REFERENCES region(id_region),
id_state INTEGER REFERENCES state(id_state),
id_deposit INTEGER REFERENCES deposit(id_deposit),
date_of_data_submission DATE NOT NULL,
production_per_day INTEGER NOT NULL
);

