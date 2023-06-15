ALTER TABLE IF EXISTS public."TrackItemCategory"
    ADD COLUMN "TrackStorageId" uuid;

ALTER TABLE IF EXISTS public."TrackItemCategory"
    ADD CONSTRAINT "FK_TrackItemCategory_TrackStorage" FOREIGN KEY ("TrackStorageId")
    REFERENCES public."TrackStorage" ("TrackStorageId") MATCH SIMPLE
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT VALID;