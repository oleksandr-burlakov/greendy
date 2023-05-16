-- Table: public.TrackItemCategory

-- DROP TABLE IF EXISTS public."TrackItemCategory";

CREATE TABLE IF NOT EXISTS public."TrackItemCategory"
(
    "TrackItemCategoryId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Name" character varying(80) COLLATE pg_catalog."default" NOT NULL,
    "LastModifiedDate" timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_TrackItemCategory" PRIMARY KEY ("TrackItemCategoryId")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TrackItemCategory"
    OWNER to postgres;

    -- Table: public.TrackItem

-- DROP TABLE IF EXISTS public."TrackItem";

CREATE TABLE IF NOT EXISTS public."TrackItem"
(
    "TrackItemId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Name" character varying(80) COLLATE pg_catalog."default" NOT NULL,
    "Description" text COLLATE pg_catalog."default",
    "TrackItemCategoryId" uuid,
    "ImagePath" character varying(250) COLLATE pg_catalog."default",
    "LastModifiedDate" timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_TrackItem" PRIMARY KEY ("TrackItemId"),
    CONSTRAINT "FK_TrackItem_TrackItemCategory" FOREIGN KEY ("TrackItemCategoryId")
        REFERENCES public."TrackItemCategory" ("TrackItemCategoryId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TrackItem"
    OWNER to postgres;

    -- Table: public.UserTrackItem

-- DROP TABLE IF EXISTS public."UserTrackItem";

CREATE TABLE IF NOT EXISTS public."UserTrackItem"
(
    "UserTrackItemId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "TrackItemId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Quantity" integer NOT NULL DEFAULT 0,
    "LastModifiedDate" timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_UserTrackItem" PRIMARY KEY ("UserTrackItemId"),
    CONSTRAINT "FK_UserTrackItem_TrackItem" FOREIGN KEY ("TrackItemId")
        REFERENCES public."TrackItem" ("TrackItemId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_UserTrackItem_User" FOREIGN KEY ("UserId")
        REFERENCES public."User" ("UserId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."UserTrackItem"
    OWNER to postgres;

-- Table: public.TrackStorage

-- DROP TABLE IF EXISTS public."TrackStorage";

CREATE TABLE IF NOT EXISTS public."TrackStorage"
(
    "TrackStorageId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Name" character varying(80) COLLATE pg_catalog."default" NOT NULL,
    "Description" text COLLATE pg_catalog."default",
    "AuthorId" uuid NOT NULL,
    "LastModifiedDate" timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_TrackStorage" PRIMARY KEY ("TrackStorageId"),
    CONSTRAINT "FK_TrackStorage_User" FOREIGN KEY ("AuthorId")
        REFERENCES public."User" ("UserId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TrackStorage"
    OWNER to postgres;

-- Table: public.TrackStorageItem

-- DROP TABLE IF EXISTS public."TrackStorageItem";

CREATE TABLE IF NOT EXISTS public."TrackStorageItem"
(
    "TrackStorageItemId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "TrackStorageId" uuid NOT NULL,
    "TrackItemId" uuid NOT NULL,
    CONSTRAINT "PK_TrackStorageItem" PRIMARY KEY ("TrackStorageItemId"),
    CONSTRAINT "FK_TrackStorageItem_TrackItem" FOREIGN KEY ("TrackItemId")
        REFERENCES public."TrackItem" ("TrackItemId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_TrackStorageItem_TrackStorage" FOREIGN KEY ("TrackStorageId")
        REFERENCES public."TrackStorage" ("TrackStorageId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TrackStorageItem"
    OWNER to postgres;

    -- Table: public.TrackStorageSubscription

-- DROP TABLE IF EXISTS public."TrackStorageSubscription";

CREATE TABLE IF NOT EXISTS public."TrackStorageSubscription"
(
    "TrackStorageSubscriptionId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "TrackStorageId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    CONSTRAINT "PK_TrackStorageSubscription" PRIMARY KEY ("TrackStorageSubscriptionId"),
    CONSTRAINT "FK_TrackStorageSubscription_TrackStorage" FOREIGN KEY ("TrackStorageId")
        REFERENCES public."TrackStorage" ("TrackStorageId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_TrackStorageSubscription_User" FOREIGN KEY ("UserId")
        REFERENCES public."User" ("UserId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."TrackStorageSubscription"
    OWNER to postgres;

-- Table: public.UserTrackItemHistoryAction

-- DROP TABLE IF EXISTS public."UserTrackItemHistoryAction";

CREATE TABLE IF NOT EXISTS public."UserTrackItemHistoryAction"
(
    "UserTrackItemHistoryActionId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "Name" character varying(50) COLLATE pg_catalog."default" NOT NULL,
    "LastModifiedDate" timestamp without time zone NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT "PK_UserTrackItemHistoryAction" PRIMARY KEY ("UserTrackItemHistoryActionId")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."UserTrackItemHistoryAction"
    OWNER to postgres;

-- Table: public.UserTrackItemHistory

-- DROP TABLE IF EXISTS public."UserTrackItemHistory";

CREATE TABLE IF NOT EXISTS public."UserTrackItemHistory"
(
    "UserTrackItemHistoryId" uuid NOT NULL DEFAULT uuid_generate_v4(),
    "UserTrackItemId" uuid NOT NULL,
    "ExecutionDate" timestamp with time zone NOT NULL,
    "UserTrackItemHistoryActionId" uuid NOT NULL,
    CONSTRAINT "PK_UserTrackItemHistory" PRIMARY KEY ("UserTrackItemHistoryActionId"),
    CONSTRAINT "FK_UserTrackItemHistory_UserTrackItem" FOREIGN KEY ("UserTrackItemId")
        REFERENCES public."UserTrackItem" ("UserTrackItemId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_UserTrackItemHistory_UserTrackItemHistoryAction" FOREIGN KEY ("UserTrackItemHistoryActionId")
        REFERENCES public."UserTrackItemHistoryAction" ("UserTrackItemHistoryActionId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."UserTrackItemHistory"
    OWNER to postgres;