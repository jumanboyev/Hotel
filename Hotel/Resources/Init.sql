
CREATE TABLE IF NOT EXISTS Room
(
	id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    "number" smallint NOT NULL,
    status text,
    price real,
    capacity smallint,
    type text NOT NULL,
    describtion text,
    create_at timestamp with time zone,
    update_at timestamp with time zone
);

CREATE TABLE IF NOT EXISTS Client
(
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    first_name character varying(50) NOT NULL,
    last_name character varying(50),
    phone_number character varying(15) NOT NULL,
	ismale bool, 
    birthdate date,
	address text,
    pasport_seria_raqam character varying,
    describtion text,
    create_at timestamp with time zone,
    update_at timestamp with time zone
);
CREATE TABLE IF NOT EXISTS Position
(
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    name character varying(50) NOT NULL,
    describtion text,
    create_at timestamp with time zone,
    update_at timestamp with time zone
);

CREATE TABLE IF NOT EXISTS Employee
(
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    position_id bigint references Position(id) NOT NULL,
    first_name character varying(50) NOT NULL,
    last_name character varying(50),
	ismale bool,
	address text,
    phone_number character varying(15) NOT NULL,
    pasport_seria_raqam character varying(9),
    describtion text,
    create_at timestamp with time zone,
    update_at timestamp with time zone,
    price real,
    birthdate date,
	status text
);

CREATE TABLE IF NOT EXISTS booking
(
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    room_id bigint references Room(id) NOT NULL,
    client_id bigint references Client(id)NOT NULL,
    start_date date,
    end_date date,
    total_price real,
    status text,
    describtion text,
    create_at timestamp with time zone,
    update_at timestamp with time zone
);

CREATE TABLE IF NOT EXISTS Payment
(
    id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY NOT NULL,
    booking_id bigint references booking(id),
    status text,
    describtion text,
    create_at timestamp with time zone,
    update_at timestamp with time zone
);