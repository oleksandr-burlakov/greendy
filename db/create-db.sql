-- Database: greendy

-- DROP DATABASE IF EXISTS greendy;

CREATE DATABASE greendy
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;


CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Table: public.Role

-- DROP TABLE IF EXISTS public."Role";

CREATE TABLE IF NOT EXISTS public."Role"
(
    "RoleId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Name" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "LastModifiedDate" timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_Role" PRIMARY KEY ("RoleId")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Role"
    OWNER to postgres;

-- Table: public.User

-- DROP TABLE IF EXISTS public."User";

CREATE TABLE IF NOT EXISTS public."User"
(
    "UserId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "FirstName" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "LastName" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "UserName" character varying(100) COLLATE pg_catalog."default",
    "Email" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "PhoneNumber" character varying(20) COLLATE pg_catalog."default",
    "PasswordHash" character varying(128) COLLATE pg_catalog."default" NOT NULL,
    "Salt" bytea NOT NULL,
    "LastModifiedDate" timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_User" PRIMARY KEY ("UserId")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."User"
    OWNER to postgres;

-- Table: public.UserRole

-- DROP TABLE IF EXISTS public."UserRole";

CREATE TABLE IF NOT EXISTS public."UserRole"
(
    "UserRoleId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "UserId" uuid NOT NULL,
    "RoleId" uuid NOT NULL,
    CONSTRAINT "PK_UserRole" PRIMARY KEY ("UserRoleId"),
    CONSTRAINT "FK_UserRole_Role" FOREIGN KEY ("RoleId")
        REFERENCES public."Role" ("RoleId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_UserRole_User" FOREIGN KEY ("UserId")
        REFERENCES public."User" ("UserId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."UserRole"
    OWNER to postgres;
