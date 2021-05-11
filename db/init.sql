create schema if not exists MyPets;
use MyPets;

drop table if exists ROUND_TO_INVESTIGATION_DOCUMENT cascade;
drop table if exists INVESTIGATION_TO_ROUND cascade;
drop table if exists ROUND cascade;
drop table if exists INVESTIGATION_TO_INVESTIGATION_DOCUMENT cascade;
drop table if exists INVESTIGATION cascade;
drop table if exists INVESTIGATION_PERSON cascade;
drop table if exists PERSON cascade;
drop table if exists INVESTIGATION_DOCUMENT cascade;

CREATE TABLE PERSON (
    person_id int NOT NULL AUTO_INCREMENT,
    first_name varchar(255) NOT NULL,
    last_name varchar(255) NOT NULL,
    email varchar(255) NOT NULL,
    address varchar(255) NOT NULL,
    zip_code varchar(10) NOT NULL,
    city varchar(255) NOT NULL,
    phone_number varchar(255) NOT NULL,
    hierarchy int NOT NULL,
    zone varchar(255) NOT NULL,
    password varchar(255) NOT NULL,
    PRIMARY KEY (person_id)
);

CREATE TABLE INVESTIGATION_DOCUMENT (
    investigation_document_id int NOT NULL AUTO_INCREMENT,
    file LONGBLOB,
    PRIMARY KEY (investigation_document_id)
);

CREATE TABLE INVESTIGATION_PERSON (
    investigation_person_id int NOT NULL AUTO_INCREMENT,
    first_name varchar(255) NOT NULL,
    last_name varchar(255) NOT NULL,
    email varchar(255) NOT NULL,
    address varchar(255) NOT NULL,
    zip_code varchar(10) NOT NULL,
    city varchar(255) NOT NULL,
    phone_number varchar(255) NOT NULL,
    type int NOT NULL,
    PRIMARY KEY (investigation_person_id)
);

CREATE TABLE ROUND (
    round_id int NOT NULL AUTO_INCREMENT,
    date_round DATE NOT NULL,
    comment_round varchar(500),
    investigator_id int NOT NULL,
    PRIMARY KEY (round_id),
    FOREIGN KEY (investigator_id) REFERENCES PERSON(person_id)
);

CREATE TABLE ROUND_TO_INVESTIGATION_DOCUMENT (
    round_to_investigation_document_id int NOT NULL AUTO_INCREMENT,
    round_id int NOT NULL,
    investigation_document_id int NOT NULL,
    PRIMARY KEY (round_to_investigation_document_id),
    FOREIGN KEY (round_id) REFERENCES ROUND(round_id),
    FOREIGN KEY (investigation_document_id) REFERENCES INVESTIGATION_DOCUMENT(investigation_document_id)
);

CREATE TABLE INVESTIGATION (
    investigation_id int NOT NULL AUTO_INCREMENT,
    holder_investigator_id int NOT NULL,
    investigation_offender_id int NOT NULL,
    investigation_plaintiff_id int not null,
    reason varchar(500) not null,
    breed varchar(500) not null,
    number_of_pets int not null,
    is_finish boolean not null,
    PRIMARY KEY (investigation_id),
    FOREIGN KEY (holder_investigator_id) REFERENCES PERSON(person_id),
    FOREIGN KEY (investigation_offender_id) REFERENCES INVESTIGATION_PERSON(investigation_person_id),
    FOREIGN KEY (investigation_plaintiff_id) REFERENCES INVESTIGATION_PERSON(investigation_person_id)
);

CREATE TABLE INVESTIGATION_TO_INVESTIGATION_DOCUMENT (
    investigation_to_investigation_document_id int NOT NULL AUTO_INCREMENT,
    investigation_id int NOT NULL,
    investigation_document_id int NOT NULL,
    PRIMARY KEY (investigation_to_investigation_document_id),
    FOREIGN KEY (investigation_id) REFERENCES INVESTIGATION(investigation_id),
    FOREIGN KEY (investigation_document_id) REFERENCES INVESTIGATION_DOCUMENT(investigation_document_id)
);

CREATE TABLE INVESTIGATION_TO_ROUND (
    investigation_to_round_id int NOT NULL AUTO_INCREMENT,
    round_id int NOT NULL,
    investigation_id int not null,
    PRIMARY KEY (investigation_to_round_id),
    FOREIGN KEY (round_id) REFERENCES ROUND(round_id),
    FOREIGN KEY (investigation_id) REFERENCES INVESTIGATION(investigation_id)
);