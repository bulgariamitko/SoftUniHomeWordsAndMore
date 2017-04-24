-- phpMyAdmin SQL Dump
-- version 4.5.4.1deb2ubuntu1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: 19 март 2017 в 14:51
-- Версия на сървъра: 5.7.17-0ubuntu0.16.04.1
-- PHP Version: 7.0.17-2+deb.sury.org~xenial+1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `Ski`
--

-- --------------------------------------------------------

--
-- Структура на таблица `Reservation`
--

CREATE TABLE `Reservation` (
  `ID` int(11) NOT NULL,
  `RoomType` varchar(150) NOT NULL,
  `Children` int(11) NOT NULL,
  `Adults` int(11) NOT NULL,
  `Rooms` int(11) NOT NULL,
  `Deleted` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Схема на данните от таблица `Reservation`
--

INSERT INTO `Reservation` (`ID`, `RoomType`, `Children`, `Adults`, `Rooms`, `Deleted`) VALUES
(1, 'Hotel', 2, 2, 2, 1),
(2, 'Hotel', 3, 3, 3, 1),
(3, 'Hotel', 34, 34, 34, 1),
(4, 'Hotel', 34, 34, 34, 0),
(5, 'Hotel', 1, 1, 1, 0),
(6, 'Hotel', 33, 33, 3333, 0),
(7, 'Hotel', 22, 22, 22, 0);

-- --------------------------------------------------------

--
-- Структура на таблица `Users`
--

CREATE TABLE `Users` (
  `ID` int(11) NOT NULL,
  `FirstName` varchar(150) NOT NULL,
  `LastName` varchar(150) NOT NULL,
  `Phone` int(11) NOT NULL,
  `Email` varchar(250) NOT NULL,
  `Deleted` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Схема на данните от таблица `Users`
--

INSERT INTO `Users` (`ID`, `FirstName`, `LastName`, `Phone`, `Email`, `Deleted`) VALUES
(1, 'Dimitar', 'Klaturov', 889037829, 'bulgaria_mitko@yahoo.com', 1),
(2, 'Dimitar', 'Klaturov', 889037829, 'bulgaria_mitko@yahoo.com', 1),
(3, 'Dimitar', 'Klaturov', 889037829, 'bulgaria_mitko@yahoo.com', 1),
(4, 'Dimitar44', 'Klaturov', 889037829, 'bulgaria_mitko@yahoo.com', 0),
(5, 'Dimitar', 'Klaturov', 889037829, 'bulgaria_mitko@yahoo.com', 0),
(6, 'Dimitar', 'Klaturov', 889037829, 'bulgaria_mitko@yahoo.com', 0),
(7, 'Dimitar', 'Klaturov', 889037829, 'bulgaria_mitko@yahoo.com', 0);

-- --------------------------------------------------------

--
-- Структура на таблица `Vacation`
--

CREATE TABLE `Vacation` (
  `ID` int(11) NOT NULL,
  `CheckIn` datetime NOT NULL,
  `CheckOut` datetime NOT NULL,
  `LiftPass` tinyint(1) NOT NULL,
  `SkiInstructor` tinyint(1) NOT NULL,
  `Deleted` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Схема на данните от таблица `Vacation`
--

INSERT INTO `Vacation` (`ID`, `CheckIn`, `CheckOut`, `LiftPass`, `SkiInstructor`, `Deleted`) VALUES
(1, '2017-03-02 00:00:00', '2017-03-19 00:00:00', 1, 1, 1),
(2, '2017-03-03 00:00:00', '2017-03-19 00:00:00', 0, 0, 1),
(3, '2017-03-10 00:00:00', '2017-03-19 00:00:00', 1, 1, 1),
(4, '2017-03-04 00:00:00', '2017-03-19 00:00:00', 0, 0, 0),
(5, '2017-03-02 00:00:00', '2017-03-19 00:00:00', 0, 1, 0),
(6, '2017-03-04 00:00:00', '2017-03-19 00:00:00', 0, 0, 0),
(7, '2017-03-04 00:00:00', '2017-03-19 00:00:00', 0, 0, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Reservation`
--
ALTER TABLE `Reservation`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `Vacation`
--
ALTER TABLE `Vacation`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Reservation`
--
ALTER TABLE `Reservation`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `Users`
--
ALTER TABLE `Users`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `Vacation`
--
ALTER TABLE `Vacation`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
