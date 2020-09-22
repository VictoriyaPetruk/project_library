CREATE DATABASE  IF NOT EXISTS `library` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `library`;
-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: localhost    Database: library
-- ------------------------------------------------------
-- Server version	8.0.18

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `author`
--

DROP TABLE IF EXISTS `author`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `author` (
  `id_a` int(11) NOT NULL AUTO_INCREMENT,
  `name_a` char(50) NOT NULL,
  `lname` char(50) NOT NULL,
  `country_a` char(100) DEFAULT NULL,
  `Date_b` date NOT NULL,
  `Date_d` date DEFAULT NULL,
  PRIMARY KEY (`id_a`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `author`
--

LOCK TABLES `author` WRITE;
/*!40000 ALTER TABLE `author` DISABLE KEYS */;
INSERT INTO `author` VALUES (1,'Рей',' Брэдбери','США','1920-08-22','2012-06-05'),(2,'Джордж','Оруэлл','Англия','1903-06-25','1950-01-21'),(3,'Михаил','Булгаков','Россия','1981-05-15','1940-03-10'),(4,'Эрих Мария','Ремарк','Германия','1898-06-22','1970-09-25'),(5,'Даниел','Киз','США','1927-08-09','2014-06-15'),(6,'Джером Дэвид','Сэлинджер','США','1919-01-01','2010-01-27'),(7,'Оскар','Уайльд','Англия','1854-10-16','1900-11-30'),(8,'Айн','Рэнд','США','1905-02-02','1982-03-06'),(9,'Николай','Гоголь','Украина','1809-04-01','1852-03-04'),(10,'Лев','Толстой','Россия','1828-09-09','1910-11-20'),(11,'Тарас','Шевченко','Украина','1814-03-09','1861-03-10'),(13,'Мураками','Харуки','япония','1920-04-01','2020-05-30');
/*!40000 ALTER TABLE `author` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `book`
--

DROP TABLE IF EXISTS `book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book` (
  `id_b` int(11) NOT NULL AUTO_INCREMENT,
  `name_b` char(100) NOT NULL,
  `Id_g` int(11) NOT NULL,
  `Id_t` int(11) NOT NULL,
  `place` char(100) NOT NULL,
  `data` int(4) NOT NULL,
  `lang` char(50) DEFAULT NULL,
  `id_p` int(11) NOT NULL,
  PRIMARY KEY (`id_b`),
  UNIQUE KEY `name_b_UNIQUE` (`name_b`),
  UNIQUE KEY `id_b_UNIQUE` (`id_b`),
  KEY `Id_t_idx` (`Id_t`),
  KEY `id_genre_idx` (`Id_g`),
  KEY `id_publish_idx` (`id_p`),
  CONSTRAINT `Id_topic` FOREIGN KEY (`Id_t`) REFERENCES `topic` (`id_t`),
  CONSTRAINT `id_genre` FOREIGN KEY (`Id_g`) REFERENCES `genre` (`id_g`),
  CONSTRAINT `id_publish` FOREIGN KEY (`id_p`) REFERENCES `publisher` (`id_p`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book`
--

LOCK TABLES `book` WRITE;
/*!40000 ALTER TABLE `book` DISABLE KEYS */;
INSERT INTO `book` VALUES (2,'451° по Фаренгейту',2,8,'1 полка',1953,'русский',1),(3,'1984',2,3,'2 полка',1949,'английский',2),(4,'Мастер и Маргарита',2,11,'1 полка',1967,'русский',3),(5,'Три товарища',2,3,'1 полка',1936,'немецкий',4),(6,'Цветы для Элджернона',5,8,'2 полка',1959,'русский',5),(7,'Над пропастью во ржи',2,2,'1 полка',1951,'русский',6),(8,'Портрет Дориана Грея',2,12,'3 полка',1890,'английский',1),(9,'Вино из одуванчиков',4,6,'1 полка',1957,'русский',2),(10,'Атлант расправил плечи',2,12,'3 полка',1957,'русский',3),(11,'Анна Каренина',2,13,'2 полка',1877,'русский',4),(12,'Война и мир',2,3,'2 полка',1869,'русский',5),(13,'Мёртвые души',15,12,'3 полка',1842,'украинский',6),(23,'Норвежский Лес',3,3,'2 полка',2000,'английский',2);
/*!40000 ALTER TABLE `book` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `book_author`
--

DROP TABLE IF EXISTS `book_author`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `book_author` (
  `id_ba` int(11) NOT NULL AUTO_INCREMENT,
  `Id_b` int(11) NOT NULL,
  `Id_a` int(11) NOT NULL,
  PRIMARY KEY (`id_ba`),
  KEY `id_a_idx` (`Id_a`),
  KEY `id_b_idx` (`Id_b`),
  CONSTRAINT `Id_book` FOREIGN KEY (`Id_b`) REFERENCES `book` (`id_b`),
  CONSTRAINT `id_author` FOREIGN KEY (`Id_a`) REFERENCES `author` (`id_a`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book_author`
--

LOCK TABLES `book_author` WRITE;
/*!40000 ALTER TABLE `book_author` DISABLE KEYS */;
INSERT INTO `book_author` VALUES (1,2,1),(2,3,2),(3,4,3),(4,5,4),(5,6,5),(6,7,6),(7,8,7),(8,9,1),(9,10,8),(10,11,10),(11,12,10),(12,13,9),(17,23,2);
/*!40000 ALTER TABLE `book_author` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entering`
--

DROP TABLE IF EXISTS `entering`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entering` (
  `Login` char(10) NOT NULL,
  `password` int(10) NOT NULL,
  PRIMARY KEY (`Login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entering`
--

LOCK TABLES `entering` WRITE;
/*!40000 ALTER TABLE `entering` DISABLE KEYS */;
INSERT INTO `entering` VALUES ('burlaka',1234);
/*!40000 ALTER TABLE `entering` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genre`
--

DROP TABLE IF EXISTS `genre`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genre` (
  `id_g` int(11) NOT NULL AUTO_INCREMENT,
  `name_g` char(50) NOT NULL,
  `groupp` char(50) NOT NULL,
  PRIMARY KEY (`id_g`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genre`
--

LOCK TABLES `genre` WRITE;
/*!40000 ALTER TABLE `genre` DISABLE KEYS */;
INSERT INTO `genre` VALUES (2,'роман','эпос'),(3,'роман-эпопея','эпос'),(4,'повесть','эпос'),(5,'рассказ','эпос'),(6,'притча','эпос'),(7,'Лирическое стихотворение','лирика'),(8,'Элегия','лирика'),(9,'Послание','лирика'),(10,'Сонет','лирика'),(11,'Ода','лирика'),(12,'комедия','драма'),(13,'трагедия','драма'),(14,'драма','драма'),(15,'Поэма','лиро-эпос'),(16,'балада','лиро-эпос'),(17,'новелла','лиро-эпос');
/*!40000 ALTER TABLE `genre` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `publisher`
--

DROP TABLE IF EXISTS `publisher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `publisher` (
  `id_p` int(11) NOT NULL AUTO_INCREMENT,
  `name_p` char(150) NOT NULL,
  `country_p` char(100) NOT NULL,
  PRIMARY KEY (`id_p`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `publisher`
--

LOCK TABLES `publisher` WRITE;
/*!40000 ALTER TABLE `publisher` DISABLE KEYS */;
INSERT INTO `publisher` VALUES (1,'Ранок','Украина г.Киев'),(2,'Генеза','Украина г.Киев'),(3,'Освита','Украина г.Киев'),(4,'Грамота','Украина г.Киев'),(5,'Фолио','Украина г.Киев'),(6,'Книжный клуб','Украина  г.Харьков');
/*!40000 ALTER TABLE `publisher` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `topic`
--

DROP TABLE IF EXISTS `topic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `topic` (
  `id_t` int(11) NOT NULL AUTO_INCREMENT,
  `Name_t` char(80) NOT NULL,
  PRIMARY KEY (`id_t`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `topic`
--

LOCK TABLES `topic` WRITE;
/*!40000 ALTER TABLE `topic` DISABLE KEYS */;
INSERT INTO `topic` VALUES (2,'современные'),(3,'исторические'),(4,'художественные'),(5,'публицистические'),(6,'биография'),(7,'научные'),(8,'научная-фантастика'),(9,'фэнтези'),(10,'приключения'),(11,'философия'),(12,'фантастика'),(13,'любовные'),(14,'военные'),(42,'триллер');
/*!40000 ALTER TABLE `topic` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-09-22 15:25:45
