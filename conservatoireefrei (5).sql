-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : mar. 18 avr. 2023 à 10:11
-- Version du serveur : 10.4.28-MariaDB
-- Version de PHP : 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `conservatoireefrei`
--

-- --------------------------------------------------------

--
-- Structure de la table `admin`
--

CREATE TABLE `admin` (
  `login` varchar(100) NOT NULL,
  `mdp` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `admin`
--

INSERT INTO `admin` (`login`, `mdp`) VALUES
('admin', '123');

-- --------------------------------------------------------

--
-- Structure de la table `eleve`
--

CREATE TABLE `eleve` (
  `IDELEVE` int(11) NOT NULL,
  `BOURSE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `eleve`
--

INSERT INTO `eleve` (`IDELEVE`, `BOURSE`) VALUES
(29, 100),
(30, 100),
(31, 100),
(32, 100),
(33, 100),
(34, 100),
(35, 100),
(36, 100),
(37, 100),
(38, 100),
(39, 100),
(40, 100),
(41, 100),
(42, 100),
(43, 100),
(44, 100),
(45, 100),
(46, 100),
(47, 100),
(48, 100),
(49, 100),
(50, 100),
(51, 100),
(52, 100),
(106, 5),
(107, 100),
(108, 100),
(141, 400),
(180, 300);

-- --------------------------------------------------------

--
-- Structure de la table `heure`
--

CREATE TABLE `heure` (
  `TRANCHE` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `heure`
--

INSERT INTO `heure` (`TRANCHE`) VALUES
('10h-12h'),
('14h-15h'),
('18h-19h'),
('9h-13h');

-- --------------------------------------------------------

--
-- Structure de la table `inscription`
--

CREATE TABLE `inscription` (
  `IDPROF` int(11) NOT NULL,
  `IDELEVE` int(11) NOT NULL,
  `NUMSEANCE` int(11) NOT NULL,
  `DATEINSCRIPTION` char(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

-- --------------------------------------------------------

--
-- Structure de la table `instrument`
--

CREATE TABLE `instrument` (
  `LIBELLE` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `instrument`
--

INSERT INTO `instrument` (`LIBELLE`) VALUES
('guitare'),
('piano'),
('violon');

-- --------------------------------------------------------

--
-- Structure de la table `jour`
--

CREATE TABLE `jour` (
  `JOUR` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `jour`
--

INSERT INTO `jour` (`JOUR`) VALUES
('jeudi'),
('lundi'),
('mardi'),
('mercredi'),
('samedi'),
('vendredi');

-- --------------------------------------------------------

--
-- Structure de la table `niveau`
--

CREATE TABLE `niveau` (
  `NIVEAU` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `niveau`
--

INSERT INTO `niveau` (`NIVEAU`) VALUES
(1),
(2),
(3);

-- --------------------------------------------------------

--
-- Structure de la table `payer`
--

CREATE TABLE `payer` (
  `IDELEVE` int(11) NOT NULL,
  `LIBELLE` char(32) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `DATEPAEMENT` char(32) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `PAYE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `payer`
--

INSERT INTO `payer` (`IDELEVE`, `LIBELLE`, `DATEPAEMENT`, `PAYE`) VALUES
(29, 'trimestre1', '25/02/2023', 1),
(29, 'trimestre2', '05/04/2023', 1),
(29, 'trimestre3', '03/08/2023', 1),
(30, 'trimestre1', '12/01/2023', 1);

-- --------------------------------------------------------

--
-- Structure de la table `personne`
--

CREATE TABLE `personne` (
  `ID` int(11) NOT NULL,
  `NOM` char(32) DEFAULT NULL,
  `PRENOM` char(32) DEFAULT NULL,
  `TEL` int(11) DEFAULT NULL,
  `MAIL` char(32) DEFAULT NULL,
  `ADRESSE` char(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `personne`
--

INSERT INTO `personne` (`ID`, `NOM`, `PRENOM`, `TEL`, `MAIL`, `ADRESSE`) VALUES
(2, 'Baitiche', 'Sarah', 5638979, 'setif1311@gmail.com', '22 VOIE DES MOULINS SUD'),
(3, 'AISSAOUI', 'yasmineeeeee', 1235956, 'YAYA@gmail.com', 'PARIS'),
(4, 'BOUMAAZ', 'RAYAN', 2356894, 'RAYOU@gmail.com', 'Marseille'),
(5, 'Aissaoui', 'rahma', 615544778, 'Yasmine', '14 avenue lucien francais, bat 3'),
(6, 'Aissaoui', 'rahma', 1, 'Yasmine', '14 avenue lucien francais, bat 3'),
(7, 'Aissaoui', 'rahma', 1, 'Yasmine', '14 avenue lucien francais, bat 3'),
(8, 'Aissaoui', 'rahma', 1, 'Yasmine', '14 avenue lucien francais, bat 3'),
(9, 'Aissaoui', 'rahma', 1, 'Yasmine', '14 avenue lucien francais, bat 3'),
(10, 'Aissaoui', 'rahma', 1, 'Yasmine', '14 avenue lucien francais, bat 3'),
(11, 'Aissaoui', 'rahma', 1, 'Yasmine', '14 avenue lucien francais, bat 3'),
(12, 'Aissaoui', 'rahma', 1, 'yasmineaissoui@gmail.com', '14 avenue lucien francais, bat 3'),
(13, 'Aissaoui', 'rahma', 1, 'yasmineaissoui@gmail.com', '14 avenue lucien francais, bat 3'),
(14, 'Aissaoui', 'rahma', 1, 'yasmineaissoui@gmail.com', '14 avenue lucien francais, bat 3'),
(15, 'Aissaoui', 'rahma', 1, 'yasmineaissoui@gmail.com', '14 avenue lucien francais, bat 3'),
(16, 'Aissaoui', 'rahma', 1, 'yasmineaissoui@gmail.com', '14 avenue lucien francais, bat 3'),
(17, 'selmani', 'khedoudja', 1, 'yasmineaissoui@gmail.com', '14 avenue Lucien français'),
(18, 'selmani', 'khedoudja', 1, 'yasmineaissoui@gmail.com', '14 avenue Lucien français'),
(19, 'Aissaoui', 'rahma', 1, 'selmanifaty7@gmail.com', '14 avenue lucien francais, bat 3'),
(20, 'Aissaoui', 'rahma', 1, 'selmanifaty7@gmail.com', '14 avenue lucien francais, bat 3'),
(21, 'Aissaoui', 'rahma', 1, 'selmanifaty7@gmail.com', '14 avenue lucien francais, bat 3'),
(22, 'Aissaoui', 'rahma', 1, 'selmanifaty7@gmail.com', '14 avenue lucien francais, bat 3'),
(23, 'Aissaoui', 'rahma', 1, 'selmanifaty7@gmail.com', '14 avenue lucien francais, bat 3'),
(24, 'Aissaoui', 'rahma', 1, 'selmanifaty7@gmail.com', '14 avenue lucien francais, bat 3'),
(25, 'Aissaoui', 'rahma', 1, 'selmanifaty7@gmail.com', '14 avenue lucien francais, bat 3'),
(26, 'Aissaoui', 'rahma', 1, 'selmanifaty7@gmail.com', '14 avenue lucien francais, bat 3'),
(29, 'Aissaoui', 'rahma', 1, 'selmanifaty7@gmail.com', '14 avenue lucien francais, bat 3'),
(30, 'selmani', 'khedoudja', 1, 'Yasmine', '14 avenue Lucien français'),
(31, 'selmani', 'khedoudja', 1, 'Yasmine', '14 avenue Lucien français'),
(32, 'selmani', 'khedoudja', 1, 'Yasmine', '14 avenue Lucien français'),
(33, 'selmani', 'khedoudja', 1, 'Yasmine', '14 avenue Lucien français'),
(34, 'selmani', 'khedoudja', 1, 'Yasmine', '14 avenue Lucien français'),
(35, 'selmani', 'khedoudja', 1, 'Yasmine', '14 avenue Lucien français'),
(36, 'selmani', 'khedoudja', 1, 'Yasmine', '14 avenue Lucien français'),
(37, 'selmani', 'khedoudja', 1, 'Yasmine', '14 avenue Lucien français'),
(38, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(39, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(40, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(41, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(42, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(43, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(44, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(45, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(46, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(47, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(48, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(49, 'selmani', 'khedoudja', 1, 'Yasmine@aa', '14 avenue Lucien français'),
(50, 'Aissaoui', 'rahma', 1, 'Yasmine', '14 avenue lucien francais, bat 3'),
(51, 'Aissaoui', 'rahma', 1, 'Yasmine', '14 avenue lucien francais, bat 3'),
(52, 'Aissaoui', 'rahma', 1, 'Yasmine', '14 avenue lucien francais, bat 3'),
(53, 'Treille', 'Lucas', 645858995, 'lucas@treille.com', '58 av general leclerd'),
(101, 'amara', 'sacha', 612255447, 'sacha@amara.fr', '56 av du b'),
(106, 'zaza', 'zeze', 1, '54788556', '54av'),
(107, 'Aissaoui', 'rahma', 1, 'selmanifaty7@gmail.com', '14 avenue lucien francais, bat 3'),
(108, 'Aissaoui', 'rahma', 1, 'Yasmine', '14 avenue lucien francais, bat 3'),
(109, 'rere', 'rtrt', 555, 'mmm', '1'),
(118, 'julien', 'dorée', 521144555, 'sfy7@gmail.com', '45 rue du morais'),
(123, 'julien', 'dorée', 521144555, 'sfy7@gmail.com', '45 rue du morais'),
(124, 'morais', 'vincent', 1445544455, 'vins@gmail.com', '77 av du luvien'),
(125, 'morais', 'vincent', 1445544455, 'vins@gmail.com', '77 av du luvien'),
(135, 'test', 'test', 0, 'test', 'test'),
(140, 'Terpin', 'Celeste', 715458569, 'CslstTerpin@outlook.fr', '88 rue de Monod'),
(141, 'habib', 'hinda', 712547885, 'hinda@outlook.com', '44 rue du pont'),
(180, 'laufer', 'samuel', 715488996, 'samuellaufer@live.fr', '65 rue des chevaux'),
(181, 'LEGOF', 'Hector', 625447712, 'legofhector@gmail.com', '15 av des rosiers'),
(183, 'Lin', 'Frank', 665588994, 'franklin@outlook.fr', '13 rue du moulin'),
(184, 'Lin', 'Frank', 665588994, 'franklin@outlook.fr', '13 rue du moulin');

-- --------------------------------------------------------

--
-- Structure de la table `prof`
--

CREATE TABLE `prof` (
  `IDPROF` int(11) NOT NULL,
  `INSTRUMENT` char(32) NOT NULL,
  `SALAIRE` double(9,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `prof`
--

INSERT INTO `prof` (`IDPROF`, `INSTRUMENT`, `SALAIRE`) VALUES
(3, 'piano', 1300.00),
(4, 'violon', 1400.00),
(123, 'piano', 1255.00),
(125, 'violon', 1400.00),
(140, 'guitare', 1600.00),
(181, 'violon', 1400.00),
(183, 'piano', 1245.00),
(184, 'piano', 1245.00);

-- --------------------------------------------------------

--
-- Structure de la table `seance`
--

CREATE TABLE `seance` (
  `IDPROF` int(11) NOT NULL,
  `NUMSEANCE` int(11) NOT NULL,
  `TRANCHE` char(32) NOT NULL,
  `JOUR` char(32) NOT NULL,
  `NIVEAU` int(11) NOT NULL,
  `CAPACITE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `seance`
--

INSERT INTO `seance` (`IDPROF`, `NUMSEANCE`, `TRANCHE`, `JOUR`, `NIVEAU`, `CAPACITE`) VALUES
(3, 1, '10h-12h', 'mercredi', 3, 25),
(3, 2, '10h-12h', 'vendredi', 2, 25),
(4, 3, '9h-13h', 'lundi', 2, 25),
(4, 4, '14h-15h', 'jeudi', 3, 27);

-- --------------------------------------------------------

--
-- Structure de la table `trim`
--

CREATE TABLE `trim` (
  `LIBELLE` char(32) NOT NULL,
  `DATEFIN` char(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Déchargement des données de la table `trim`
--

INSERT INTO `trim` (`LIBELLE`, `DATEFIN`) VALUES
('trimestre1', '31/03/2023'),
('trimestre2', '30/06/2023'),
('trimestre3', '30/09/2023'),
('trimestre4', '31/12/2023');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `eleve`
--
ALTER TABLE `eleve`
  ADD PRIMARY KEY (`IDELEVE`);

--
-- Index pour la table `heure`
--
ALTER TABLE `heure`
  ADD PRIMARY KEY (`TRANCHE`);

--
-- Index pour la table `inscription`
--
ALTER TABLE `inscription`
  ADD PRIMARY KEY (`IDPROF`,`IDELEVE`,`NUMSEANCE`),
  ADD KEY `I_FK_INSCRIPTION_ELEVE` (`IDELEVE`),
  ADD KEY `I_FK_INSCRIPTION_SEANCE` (`IDPROF`,`NUMSEANCE`),
  ADD KEY `fk_numSeance` (`NUMSEANCE`);

--
-- Index pour la table `instrument`
--
ALTER TABLE `instrument`
  ADD PRIMARY KEY (`LIBELLE`);

--
-- Index pour la table `jour`
--
ALTER TABLE `jour`
  ADD PRIMARY KEY (`JOUR`);

--
-- Index pour la table `niveau`
--
ALTER TABLE `niveau`
  ADD PRIMARY KEY (`NIVEAU`),
  ADD KEY `NIVEAU` (`NIVEAU`);

--
-- Index pour la table `payer`
--
ALTER TABLE `payer`
  ADD PRIMARY KEY (`IDELEVE`,`LIBELLE`),
  ADD KEY `IDELEVE` (`IDELEVE`),
  ADD KEY `LIBELLE` (`LIBELLE`);

--
-- Index pour la table `personne`
--
ALTER TABLE `personne`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `prof`
--
ALTER TABLE `prof`
  ADD PRIMARY KEY (`IDPROF`),
  ADD KEY `I_FK_PROF_INSTRUMENT` (`INSTRUMENT`);

--
-- Index pour la table `seance`
--
ALTER TABLE `seance`
  ADD PRIMARY KEY (`IDPROF`,`NUMSEANCE`),
  ADD KEY `I_FK_SEANCE_JOUR` (`JOUR`),
  ADD KEY `I_FK_SEANCE_NIVEAU` (`NIVEAU`),
  ADD KEY `I_FK_SEANCE_PROF` (`IDPROF`),
  ADD KEY `fk_tranche` (`TRANCHE`),
  ADD KEY `NUMSEANCE` (`NUMSEANCE`);

--
-- Index pour la table `trim`
--
ALTER TABLE `trim`
  ADD PRIMARY KEY (`LIBELLE`);
ALTER TABLE `trim` ADD FULLTEXT KEY `LIBELLE` (`LIBELLE`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `personne`
--
ALTER TABLE `personne`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=185;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `eleve`
--
ALTER TABLE `eleve`
  ADD CONSTRAINT `fk_idEleve` FOREIGN KEY (`IDELEVE`) REFERENCES `personne` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `inscription`
--
ALTER TABLE `inscription`
  ADD CONSTRAINT `fk_insc_eleve` FOREIGN KEY (`IDELEVE`) REFERENCES `eleve` (`IDELEVE`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_inscr_prof` FOREIGN KEY (`IDPROF`) REFERENCES `prof` (`IDPROF`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_numSeance` FOREIGN KEY (`NUMSEANCE`) REFERENCES `seance` (`NUMSEANCE`);

--
-- Contraintes pour la table `payer`
--
ALTER TABLE `payer`
  ADD CONSTRAINT `fk_paye_eleve` FOREIGN KEY (`IDELEVE`) REFERENCES `eleve` (`IDELEVE`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_paye_lib` FOREIGN KEY (`LIBELLE`) REFERENCES `trim` (`LIBELLE`);

--
-- Contraintes pour la table `prof`
--
ALTER TABLE `prof`
  ADD CONSTRAINT `fk_idProf` FOREIGN KEY (`IDPROF`) REFERENCES `personne` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_refInstrument` FOREIGN KEY (`INSTRUMENT`) REFERENCES `instrument` (`LIBELLE`);

--
-- Contraintes pour la table `seance`
--
ALTER TABLE `seance`
  ADD CONSTRAINT `fk_jour` FOREIGN KEY (`JOUR`) REFERENCES `jour` (`JOUR`),
  ADD CONSTRAINT `fk_prof` FOREIGN KEY (`IDPROF`) REFERENCES `prof` (`IDPROF`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_tranche` FOREIGN KEY (`TRANCHE`) REFERENCES `heure` (`TRANCHE`),
  ADD CONSTRAINT `seance_ibfk_1` FOREIGN KEY (`NIVEAU`) REFERENCES `niveau` (`NIVEAU`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
