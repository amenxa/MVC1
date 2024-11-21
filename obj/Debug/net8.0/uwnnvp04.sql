CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Category` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    CONSTRAINT `PK_Category` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Items` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `price` int NOT NULL,
    `DateTime` datetime(6) NOT NULL,
    `categoryId` int NOT NULL,
    CONSTRAINT `PK_Items` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Items_Category_categoryId` FOREIGN KEY (`categoryId`) REFERENCES `Category` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Items_categoryId` ON `Items` (`categoryId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20241017114405_renameDEscrption', '8.0.10');

COMMIT;

START TRANSACTION;

ALTER TABLE `Items` MODIFY COLUMN `Name` varchar(55) CHARACTER SET utf8mb4 NOT NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20241105183713_maxlen55', '8.0.10');

COMMIT;

