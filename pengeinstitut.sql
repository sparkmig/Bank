-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Vært: 127.0.0.1
-- Genereringstid: 27. 08 2021 kl. 11:27:52
-- Serverversion: 10.4.20-MariaDB
-- PHP-version: 8.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pengeinstitut`
--

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `accounts`
--

CREATE TABLE `accounts` (
  `Id` int(11) NOT NULL,
  `Owner` int(11) NOT NULL,
  `Amount` double NOT NULL,
  `Name` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Data dump for tabellen `accounts`
--

INSERT INTO `accounts` (`Id`, `Owner`, `Amount`, `Name`) VALUES
(1, 1, 90001, 'Opsparing'),
(5, 2, 1000, 'Opsparing'),
(6, 3, 990, 'Peter fra teknisk afdeling'),
(10, 4, 910000, 'Opsparing'),
(14, 6, 128047, 'Kurts første konto');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `customers`
--

CREATE TABLE `customers` (
  `Id` int(11) NOT NULL,
  `FirstName` text DEFAULT NULL,
  `LastName` text DEFAULT NULL,
  `Birthday` datetime NOT NULL,
  `Password` text DEFAULT NULL,
  `CPR` text DEFAULT NULL,
  `Phone` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Data dump for tabellen `customers`
--

INSERT INTO `customers` (`Id`, `FirstName`, `LastName`, `Birthday`, `Password`, `CPR`, `Phone`) VALUES
(1, 'Mikkel', 'Gundersen', '2021-08-25 14:05:22', '123456789', '123456-7890', NULL),
(3, 'Matteo', 'Vanggaard', '2003-02-04 00:00:00', 'skiftmig', '040203-9998', '88888888'),
(4, 'Rokas', 'S', '2012-12-12 00:00:00', 'skiftmig', '121212-1212', '12345678');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `transactions`
--

CREATE TABLE `transactions` (
  `Id` int(11) NOT NULL,
  `From` int(11) NOT NULL,
  `To` int(11) NOT NULL,
  `Amount` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Data dump for tabellen `transactions`
--

INSERT INTO `transactions` (`Id`, `From`, `To`, `Amount`) VALUES
(1, 6, -1, 1000),
(2, 6, -2, 10),
(3, 1, -2, 100),
(4, 1, -1, 100000),
(5, 1, -2, 1000),
(6, 1, 1, 100),
(7, 1, 14, 128047),
(8, 10, 1, 90000);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `UserName` text DEFAULT NULL,
  `Password` text DEFAULT NULL,
  `Name` text DEFAULT NULL,
  `UserRight` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Data dump for tabellen `users`
--

INSERT INTO `users` (`Id`, `UserName`, `Password`, `Name`, `UserRight`) VALUES
(1, 'user', 'pass', 'Kurt Jensen', 1),
(5, 'Mikkel', '1234', 'Mikkel', 1),
(6, 'Matteo', '1234', 'Matteo', 0);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Data dump for tabellen `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20210825105424_Added Account', '5.0.9'),
('20210825105616_removed sslmode', '5.0.9'),
('20210825110454_Added Users', '5.0.9'),
('20210825121759_ChangedNameOfAccount', '5.0.9'),
('20210825122004_Changed Name Of Customer', '5.0.9'),
('20210825122321_Add Account', '5.0.9'),
('20210826080917_AddedPhone', '5.0.9'),
('20210827084540_Added Transaction', '5.0.9');

--
-- Begrænsninger for dumpede tabeller
--

--
-- Indeks for tabel `accounts`
--
ALTER TABLE `accounts`
  ADD PRIMARY KEY (`Id`);

--
-- Indeks for tabel `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`Id`);

--
-- Indeks for tabel `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`Id`);

--
-- Indeks for tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- Indeks for tabel `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- Brug ikke AUTO_INCREMENT for slettede tabeller
--

--
-- Tilføj AUTO_INCREMENT i tabel `accounts`
--
ALTER TABLE `accounts`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Tilføj AUTO_INCREMENT i tabel `customers`
--
ALTER TABLE `customers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tilføj AUTO_INCREMENT i tabel `transactions`
--
ALTER TABLE `transactions`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Tilføj AUTO_INCREMENT i tabel `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
