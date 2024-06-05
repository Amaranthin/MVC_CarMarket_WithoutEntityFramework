-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Време на генериране:  5 юни 2024 в 10:16
-- Версия на сървъра: 10.4.27-MariaDB
-- Версия на PHP: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данни: `car_market`
--

-- --------------------------------------------------------

--
-- Структура на таблица `cars`
--

CREATE TABLE `cars` (
  `id` int(11) NOT NULL,
  `model` varchar(32) NOT NULL,
  `color` varchar(16) NOT NULL,
  `year` int(4) NOT NULL,
  `price` int(11) NOT NULL,
  `owner_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Схема на данните от таблица `cars`
--

INSERT INTO `cars` (`id`, `model`, `color`, `year`, `price`, `owner_id`) VALUES
(1, 'Audi Q8', 'синьо', 2018, 75000, NULL),
(2, 'BMW X7', 'черно', 2019, 90000, 3),
(3, 'Mercedes-Benz GLE', 'сив', 2020, 65000, NULL),
(4, 'Lexus RX', 'червен', 2021, 55000, NULL),
(5, 'Porsche Cayenne', 'бяло', 2019, 85000, 4),
(6, 'Tesla Model X', 'черна', 2022, 100000, 4),
(7, 'Range Rover Velar', 'сребрист', 2017, 70000, 2),
(8, 'Jaguar F-Pace', 'виолетов', 2016, 60000, 1),
(9, 'Volvo XC90', 'тъмночервено', 2020, 60000, NULL),
(10, 'Lincoln Aviator', 'тъмносин', 2021, 70000, NULL),
(11, 'Lamborghini Urus', 'бяло', 2018, 300000, NULL),
(12, 'Ferrari 488 GTB', 'розово', 2016, 350000, 1),
(13, 'Rolls-Royce Dawn', 'черен', 2015, 400000, NULL),
(14, 'Aston Martin DB11', 'зелен металик', 2017, 275000, NULL),
(15, 'Bentley Bentayga', 'жълто', 2019, 450000, NULL),
(16, 'De Tomaso Pantera GT5-S', 'бяло', 1976, 220000, 5),
(17, 'BMW i8', 'сиво-черно', 2015, 100000, NULL);

-- --------------------------------------------------------

--
-- Структура на таблица `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `first_name` varchar(32) NOT NULL,
  `last_name` varchar(32) NOT NULL,
  `money` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Схема на данните от таблица `users`
--

INSERT INTO `users` (`id`, `first_name`, `last_name`, `money`) VALUES
(1, 'Лео', 'Меси', 4595000),
(2, 'Кристиано', 'Роналдо', 4860000),
(3, 'Сюлейман', 'Писанцалиев', 170000),
(4, 'Хасан', 'Камбуров', 75000),
(5, 'Мартин', 'Катев', 210000);

--
-- Indexes for dumped tables
--

--
-- Индекси за таблица `cars`
--
ALTER TABLE `cars`
  ADD PRIMARY KEY (`id`);

--
-- Индекси за таблица `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cars`
--
ALTER TABLE `cars`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
