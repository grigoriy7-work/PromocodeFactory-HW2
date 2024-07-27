CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE TABLE "Customers" (
        "Id" uuid NOT NULL,
        "FirstName" character varying(100) NULL,
        "LastName" character varying(100) NULL,
        "Email" character varying(100) NULL,
        CONSTRAINT "PK_Customers" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE TABLE "Preferences" (
        "Id" uuid NOT NULL,
        "Name" character varying(100) NULL,
        CONSTRAINT "PK_Preferences" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE TABLE "Role" (
        "Id" uuid NOT NULL,
        "Name" character varying(100) NULL,
        "Description" character varying(100) NULL,
        "EmployeeId" uuid NOT NULL,
        CONSTRAINT "PK_Role" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE TABLE "CustomerPreferences" (
        "CustomerId" uuid NOT NULL,
        "PreferenceId" uuid NOT NULL,
        CONSTRAINT "PK_CustomerPreferences" PRIMARY KEY ("CustomerId", "PreferenceId"),
        CONSTRAINT "FK_CustomerPreferences_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_CustomerPreferences_Preferences_PreferenceId" FOREIGN KEY ("PreferenceId") REFERENCES "Preferences" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE TABLE "Employees" (
        "Id" uuid NOT NULL,
        "FirstName" character varying(100) NULL,
        "LastName" character varying(100) NULL,
        "Email" character varying(100) NULL,
        "RoleId" uuid NOT NULL,
        "AppliedPromocodesCount" integer NOT NULL,
        "PreferenceId" uuid NULL,
        CONSTRAINT "PK_Employees" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_Employees_Preferences_PreferenceId" FOREIGN KEY ("PreferenceId") REFERENCES "Preferences" ("Id"),
        CONSTRAINT "FK_Employees_Role_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Role" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE TABLE "PromoCodes" (
        "Id" uuid NOT NULL,
        "Code" character varying(100) NULL,
        "ServiceInfo" character varying(100) NULL,
        "BeginDate" timestamp with time zone NOT NULL,
        "EndDate" timestamp with time zone NOT NULL,
        "PartnerName" character varying(100) NULL,
        "PartnerManagerId" uuid NULL,
        "PreferenceId" uuid NOT NULL,
        "CustomerId" uuid NOT NULL,
        CONSTRAINT "PK_PromoCodes" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_PromoCodes_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_PromoCodes_Employees_PartnerManagerId" FOREIGN KEY ("PartnerManagerId") REFERENCES "Employees" ("Id"),
        CONSTRAINT "FK_PromoCodes_Preferences_PreferenceId" FOREIGN KEY ("PreferenceId") REFERENCES "Preferences" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    INSERT INTO "Customers" ("Id", "Email", "FirstName", "LastName")
    VALUES ('119a2ebc-85e5-43b9-bd7c-097e52196373', 'misato@mail.com', 'Мисато', 'Кацураги');
    INSERT INTO "Customers" ("Id", "Email", "FirstName", "LastName")
    VALUES ('2d56645d-84bb-40f5-adbc-6850c2d30ef9', 'shinji@mail.com', 'Синдзи', 'Икари');
    INSERT INTO "Customers" ("Id", "Email", "FirstName", "LastName")
    VALUES ('794d3f49-6ddf-4a4b-9d6b-5c8e164d87f8', 'ritsuko@mail.com', 'Рицуко', 'Акаги');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    INSERT INTO "Preferences" ("Id", "Name")
    VALUES ('1a40591f-a22c-4300-aefa-29c12a093dd2', 'Театр');
    INSERT INTO "Preferences" ("Id", "Name")
    VALUES ('237e6d2d-519a-42a6-859b-2f70ecacfb71', 'Дети');
    INSERT INTO "Preferences" ("Id", "Name")
    VALUES ('f1346ed6-d126-4cda-be54-8a37b18d87f9', 'Бизнес');
    INSERT INTO "Preferences" ("Id", "Name")
    VALUES ('f6b0e44e-7b9e-4c9c-9fb8-0c86880ebed9', 'Семья');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    INSERT INTO "Role" ("Id", "Description", "EmployeeId", "Name")
    VALUES ('53729686-a368-4eeb-8bfa-cc69b6050d02', 'Администратор', '00000000-0000-0000-0000-000000000000', 'Admin');
    INSERT INTO "Role" ("Id", "Description", "EmployeeId", "Name")
    VALUES ('b0ae7aac-5493-45cd-ad16-87426a5e7665', 'Партнерский менеджер', '00000000-0000-0000-0000-000000000000', 'PartnerManager');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    INSERT INTO "CustomerPreferences" ("CustomerId", "PreferenceId")
    VALUES ('119a2ebc-85e5-43b9-bd7c-097e52196373', '1a40591f-a22c-4300-aefa-29c12a093dd2');
    INSERT INTO "CustomerPreferences" ("CustomerId", "PreferenceId")
    VALUES ('119a2ebc-85e5-43b9-bd7c-097e52196373', '237e6d2d-519a-42a6-859b-2f70ecacfb71');
    INSERT INTO "CustomerPreferences" ("CustomerId", "PreferenceId")
    VALUES ('2d56645d-84bb-40f5-adbc-6850c2d30ef9', '1a40591f-a22c-4300-aefa-29c12a093dd2');
    INSERT INTO "CustomerPreferences" ("CustomerId", "PreferenceId")
    VALUES ('2d56645d-84bb-40f5-adbc-6850c2d30ef9', 'f1346ed6-d126-4cda-be54-8a37b18d87f9');
    INSERT INTO "CustomerPreferences" ("CustomerId", "PreferenceId")
    VALUES ('794d3f49-6ddf-4a4b-9d6b-5c8e164d87f8', '237e6d2d-519a-42a6-859b-2f70ecacfb71');
    INSERT INTO "CustomerPreferences" ("CustomerId", "PreferenceId")
    VALUES ('794d3f49-6ddf-4a4b-9d6b-5c8e164d87f8', 'f6b0e44e-7b9e-4c9c-9fb8-0c86880ebed9');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    INSERT INTO "Employees" ("Id", "AppliedPromocodesCount", "Email", "FirstName", "LastName", "PreferenceId", "RoleId")
    VALUES ('451533d5-d8d5-4a11-9c7b-eb9f14e1a32f', 5, 'owner@somemail.ru', 'Иван', 'Сергеев', NULL, '53729686-a368-4eeb-8bfa-cc69b6050d02');
    INSERT INTO "Employees" ("Id", "AppliedPromocodesCount", "Email", "FirstName", "LastName", "PreferenceId", "RoleId")
    VALUES ('f766e2bf-340a-46ea-bff3-f1700b435895', 10, 'andreev@somemail.ru', 'Петр', 'Андреев', NULL, 'b0ae7aac-5493-45cd-ad16-87426a5e7665');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE INDEX "IX_CustomerPreferences_PreferenceId" ON "CustomerPreferences" ("PreferenceId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE INDEX "IX_Employees_PreferenceId" ON "Employees" ("PreferenceId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE INDEX "IX_Employees_RoleId" ON "Employees" ("RoleId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE INDEX "IX_PromoCodes_CustomerId" ON "PromoCodes" ("CustomerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE INDEX "IX_PromoCodes_PartnerManagerId" ON "PromoCodes" ("PartnerManagerId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    CREATE INDEX "IX_PromoCodes_PreferenceId" ON "PromoCodes" ("PreferenceId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20240724173211_initDb') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20240724173211_initDb', '7.0.18');
    END IF;
END $EF$;
COMMIT;

