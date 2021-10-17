#!/bin/bash
set -e

echo "### Create user, database, schema and tables ###"
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "$POSTGRES_DB" <<-EOSQL
    CREATE USER book_user with password 'qzwxec123';
    CREATE DATABASE book;
    GRANT ALL PRIVILEGES ON DATABASE book TO book_user;
    \connect book book_user;
    CREATE SCHEMA book;
    ALTER ROLE book_user SET search_path TO book;

    CREATE TABLE book.users (
	id bigserial NOT NULL,
	login varchar NOT NULL,
	"password" varchar NOT NULL,
	CONSTRAINT users_pk PRIMARY KEY (id)
);
COMMENT ON TABLE book.users IS 'Пользователи';

CREATE TABLE book.users_info (
	id bigserial NOT NULL,
	user_id int8 NOT NULL,
	first_name varchar NOT NULL,
	last_name varchar NOT NULL,
	patronymic varchar NULL,
	CONSTRAINT users_info_pk PRIMARY KEY (id),
	CONSTRAINT users_info_fk FOREIGN KEY (user_id) REFERENCES book.users(id)
);
COMMENT ON TABLE book.users_info IS 'Информация о пользователях';

CREATE TABLE book.books (
	id bigserial NOT NULL,
	"name" text NOT NULL,
	description text NULL,
	rating int2 NULL,
	pages int4 NULL,
	user_id int8 NOT NULL,
	CONSTRAINT books_pk PRIMARY KEY (id),
	CONSTRAINT books_fk FOREIGN KEY (user_id) REFERENCES book.users(id)
);
COMMENT ON TABLE book.books IS 'Книги';

CREATE TABLE book.book_records (
	id bigserial NOT NULL,
	user_id int8 NOT NULL,
	book_id int8 NOT NULL,
	"text" text NOT NULL,
	sort varchar NOT NULL, -- Положение записи в тексте
	CONSTRAINT book_records_pk PRIMARY KEY (id),
	CONSTRAINT book_records_fk FOREIGN KEY (user_id) REFERENCES book.users(id),
	CONSTRAINT book_records_fk_1 FOREIGN KEY (book_id) REFERENCES book.books(id)
);
COMMENT ON TABLE book.book_records IS 'Записи книг (слова, строки и т.д)';
COMMENT ON COLUMN book.book_records.sort IS 'Положение записи в тексте';

CREATE TABLE book.likes (
	id bigserial NOT NULL,
	book_record_id int8 NOT NULL,
	user_id int8 NOT NULL,
	CONSTRAINT likes_pk PRIMARY KEY (id),
	CONSTRAINT likes_fk FOREIGN KEY (user_id) REFERENCES book.users(id),
	CONSTRAINT likes_fk_1 FOREIGN KEY (book_record_id) REFERENCES book.book_records(id)
);
EOSQL