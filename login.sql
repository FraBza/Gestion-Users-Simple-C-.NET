-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : jeu. 27 jan. 2022 à 14:19
-- Version du serveur : 10.4.22-MariaDB
-- Version de PHP : 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `login`
--

-- --------------------------------------------------------

--
-- Structure de la table `acces`
--

CREATE TABLE `acces` (
  `accesID` int(11) NOT NULL,
  `groupID` int(11) DEFAULT NULL,
  `ficheID` int(11) DEFAULT NULL,
  `VISIBLE` varchar(255) DEFAULT NULL,
  `MODIFIABLE` varchar(255) DEFAULT NULL
) ENGINE=InnoDB AVG_ROW_LENGTH=8192 DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `acces`
--

INSERT INTO `acces` (`accesID`, `groupID`, `ficheID`, `VISIBLE`, `MODIFIABLE`) VALUES
(1, 1, 1, 'FALSE\r\n', 'FALSE\r\n'),
(2, 2, 1, 'TRUE\r\n', 'TRUE\r\n');

-- --------------------------------------------------------

--
-- Structure de la table `fiche`
--

CREATE TABLE `fiche` (
  `ficheID` int(11) NOT NULL,
  `ficheNOM` varchar(255) DEFAULT NULL
) ENGINE=InnoDB AVG_ROW_LENGTH=8192 DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `fiche`
--

INSERT INTO `fiche` (`ficheID`, `ficheNOM`) VALUES
(1, 'main'),
(2, 'gestDB');

-- --------------------------------------------------------

--
-- Structure de la table `group`
--

CREATE TABLE `group` (
  `groupID` int(11) NOT NULL,
  `groupNom` varchar(255) DEFAULT NULL
) ENGINE=InnoDB AVG_ROW_LENGTH=8192 DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `group`
--

INSERT INTO `group` (`groupID`, `groupNom`) VALUES
(0, 'user\r\n'),
(1, 'admin\r\n');

-- --------------------------------------------------------

--
-- Structure de la table `login`
--

CREATE TABLE `login` (
  `id` int(11) NOT NULL,
  `user` varchar(32) NOT NULL,
  `motpasse` varchar(32) NOT NULL,
  `groupid` int(11) NOT NULL
) ENGINE=InnoDB AVG_ROW_LENGTH=2730 DEFAULT CHARSET=utf8mb4 COMMENT='id et mot de passes utilisateurs';

--
-- Déchargement des données de la table `login`
--

INSERT INTO `login` (`id`, `user`, `motpasse`, `groupid`) VALUES
(11, 'soufiane', 'stage10e*', 0),
(26, 'Mohamed', 'motpasse5', 1);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `acces`
--
ALTER TABLE `acces`
  ADD PRIMARY KEY (`accesID`);

--
-- Index pour la table `fiche`
--
ALTER TABLE `fiche`
  ADD PRIMARY KEY (`ficheID`);

--
-- Index pour la table `group`
--
ALTER TABLE `group`
  ADD PRIMARY KEY (`groupID`);

--
-- Index pour la table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `user` (`user`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `fiche`
--
ALTER TABLE `fiche`
  MODIFY `ficheID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `group`
--
ALTER TABLE `group`
  MODIFY `groupID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `login`
--
ALTER TABLE `login`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
