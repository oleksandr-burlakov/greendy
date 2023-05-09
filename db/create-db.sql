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

-- Table: public.Tag

-- DROP TABLE IF EXISTS public."Tag";

CREATE TABLE IF NOT EXISTS public."Tag"
(
    "TagId" uuid NOT NULL,
    "Name" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "LastModifiedDate" timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_Tag" PRIMARY KEY ("TagId")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Tag"
    OWNER to postgres;

-- Table: public.Role

-- DROP TABLE IF EXISTS public."Role";

CREATE TABLE IF NOT EXISTS public."Role"
(
    "RoleId" uuid NOT NULL,
    "Name" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "LastModifiedDate" timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_Role" PRIMARY KEY ("RoleId")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Role"
    OWNER to postgres;

-- Table: public.Category

-- DROP TABLE IF EXISTS public."Category";

CREATE TABLE IF NOT EXISTS public."Category"
(
    "CategoryId" uuid NOT NULL,
    "Name" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "LastModifiedDate" timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_Category" PRIMARY KEY ("CategoryId")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Category"
    OWNER to postgres;

-- Table: public.User

-- DROP TABLE IF EXISTS public."User";

CREATE TABLE IF NOT EXISTS public."User"
(
    "UserId" uuid NOT NULL,
    "FirstName" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "LastName" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "UserName" character varying(100) COLLATE pg_catalog."default",
    "Email" character varying(100) COLLATE pg_catalog."default" NOT NULL,
    "PhoneNumber" character varying(20) COLLATE pg_catalog."default",
    "PasswordHash" character varying(128) COLLATE pg_catalog."default" NOT NULL,
    "Salt" character varying(128) COLLATE pg_catalog."default" NOT NULL,
    "LastModifiedDate" timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_User" PRIMARY KEY ("UserId")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."User"
    OWNER to postgres;

-- Table: public.Workspace

-- DROP TABLE IF EXISTS public."Workspace";

CREATE TABLE IF NOT EXISTS public."Workspace"
(
    "WorkspaceId" uuid NOT NULL,
    "OwnerId" uuid NOT NULL,
    "Name" character varying(255) COLLATE pg_catalog."default" NOT NULL,
    "LastModifiedDate" timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_Workspace" PRIMARY KEY ("WorkspaceId"),
    CONSTRAINT "FK_Workspace_User" FOREIGN KEY ("OwnerId")
        REFERENCES public."User" ("UserId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Workspace"
    OWNER to postgres;

-- Table: public.UserRole

-- DROP TABLE IF EXISTS public."UserRole";

CREATE TABLE IF NOT EXISTS public."UserRole"
(
    "UserRoleId" uuid NOT NULL,
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

-- Table: public.Spending

-- DROP TABLE IF EXISTS public."Spending";

CREATE TABLE IF NOT EXISTS public."Spending"
(
    "SpendingId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "WorkspaceId" uuid NOT NULL,
    "Amount" real NOT NULL,
    "SpendingDate" timestamp with time zone DEFAULT CURRENT_TIMESTAMP,
    "Reason" text COLLATE pg_catalog."default",
    "CategoryId" uuid,
    "LastModifiedDate" timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_Spending" PRIMARY KEY ("SpendingId"),
    CONSTRAINT "FK_Spending_Category" FOREIGN KEY ("CategoryId")
        REFERENCES public."Category" ("CategoryId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT "FK_Spending_User" FOREIGN KEY ("UserId")
        REFERENCES public."User" ("UserId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT "FK_Spending_Workspace" FOREIGN KEY ("WorkspaceId")
        REFERENCES public."Workspace" ("WorkspaceId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Spending"
    OWNER to postgres;

-- Table: public.SpendingTag

-- DROP TABLE IF EXISTS public."SpendingTag";

CREATE TABLE IF NOT EXISTS public."SpendingTag"
(
    "SpendingTagId" uuid NOT NULL,
    "SpendingId" uuid NOT NULL,
    "TagId" uuid NOT NULL,
    CONSTRAINT "PK_SpendingTag" PRIMARY KEY ("SpendingTagId"),
    CONSTRAINT "FK_SpendingTag_Spending" FOREIGN KEY ("SpendingId")
        REFERENCES public."Spending" ("SpendingId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_SpendingTag_Tag" FOREIGN KEY ("TagId")
        REFERENCES public."Tag" ("TagId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."SpendingTag"
    OWNER to postgres;