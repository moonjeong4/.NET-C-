-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: firernr_luke
-- ------------------------------------------------------
-- Server version	5.5.5-10.9.3-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `addresses`
--

DROP TABLE IF EXISTS `addresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `addresses` (
  `AddressId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Number` varchar(7) NOT NULL,
  `Street` longtext NOT NULL,
  `Province` longtext NOT NULL,
  `City` longtext NOT NULL,
  `PostalCode` longtext NOT NULL,
  `CountryId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`AddressId`),
  KEY `IX_Addresses_CountryId` (`CountryId`),
  CONSTRAINT `FK_Addresses_Countries_CountryId` FOREIGN KEY (`CountryId`) REFERENCES `countries` (`CountryId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `addresses`
--

LOCK TABLES `addresses` WRITE;
/*!40000 ALTER TABLE `addresses` DISABLE KEYS */;
INSERT INTO `addresses` VALUES (1,'156','Barfield Lane',' IN','Indianapolis','H1P 2G7',2),(2,'1538','August Lane','SK','Shreveport','D1R 4J9',1),(3,'2325','Jadewood Drive','LI','Chicago','V1T 6B4',2),(4,'2052','Cedarstone Drive','OH','Archbold','T2L 3L6',2),(5,'3648','Brooke Street','TX','Houston','P2K 3O9',2),(6,'3753','Feathers Hooves Drive','NY','New York','J5D 8Y7',2),(7,'3997','Douglas Dairy Road','VA','Johnson City','K2F 6P8',2),(8,'179','collegiate Street','BC','Vancouver','D2T 7Y0',1);
/*!40000 ALTER TABLE `addresses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `amenities`
--

DROP TABLE IF EXISTS `amenities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `amenities` (
  `AmenityId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`AmenityId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `amenities`
--

LOCK TABLES `amenities` WRITE;
/*!40000 ALTER TABLE `amenities` DISABLE KEYS */;
INSERT INTO `amenities` VALUES (1,'washer/dryer'),(2,'pool'),(3,'parking'),(4,'workout_facility');
/*!40000 ALTER TABLE `amenities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `countries`
--

DROP TABLE IF EXISTS `countries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `countries` (
  `CountryId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`CountryId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `countries`
--

LOCK TABLES `countries` WRITE;
/*!40000 ALTER TABLE `countries` DISABLE KEYS */;
INSERT INTO `countries` VALUES (1,'Canada'),(2,'USA');
/*!40000 ALTER TABLE `countries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `images`
--

DROP TABLE IF EXISTS `images`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `images` (
  `ImageId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `File` longtext NOT NULL,
  `Caption` longtext DEFAULT NULL,
  `IsThumbnail` tinyint(1) NOT NULL,
  `PropertyId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ImageId`),
  KEY `IX_Images_PropertyId` (`PropertyId`),
  CONSTRAINT `FK_Images_Properties_PropertyId` FOREIGN KEY (`PropertyId`) REFERENCES `properties` (`PropertyId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `images`
--

LOCK TABLES `images` WRITE;
/*!40000 ALTER TABLE `images` DISABLE KEYS */;
INSERT INTO `images` VALUES (1,'https://www.shutterstock.com/image-photo/appartment-houses-berlin-mitte-260nw-597833468.jpg','from outside',1,1),(2,'https://images.rentals.ca/property-pictures/large/ottawa-on/279777/apartment-6742799.jpg','living room',0,1),(3,'https://www.kangalou.com/images/glide/88f7ebf4d05a9890c98ed8ed0a3da071.jpg','from the street',1,2),(4,'https://www.guidehabitation.ca/wp-content/themes/gh/pub/auto/10948/xl-245c787b-f7eb-409e-9042-965e308a3fc6.jpg','inside',0,2),(5,'https://www.coolhouseplans.com/varnish-images/plans/80523/80523-b440.jpg','over all',1,3),(6,'https://media.architecturaldigest.com/photos/571e97ce818277135ff91620/master/w_2626,h_1821,c_limit/modernist-decor-inspiration-07.jpg','for guest',0,3),(7,'https://thumbor.forbes.com/thumbor/fit-in/900x510/https://www.forbes.com/home-improvement/wp-content/uploads/2022/07/download-23.jpg','night view',1,4),(8,'https://www.build-review.com/wp-content/uploads/2021/01/large-house.jpg','whole view',0,4);
/*!40000 ALTER TABLE `images` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `properties`
--

DROP TABLE IF EXISTS `properties`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `properties` (
  `PropertyId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Description` longtext DEFAULT NULL,
  `NumRooms` int(10) unsigned NOT NULL,
  `OwnerUserId` int(10) unsigned NOT NULL,
  `AddressId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`PropertyId`),
  KEY `IX_Properties_AddressId` (`AddressId`),
  KEY `IX_Properties_OwnerUserId` (`OwnerUserId`),
  CONSTRAINT `FK_Properties_Addresses_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `addresses` (`AddressId`) ON DELETE CASCADE,
  CONSTRAINT `FK_Properties_Users_OwnerUserId` FOREIGN KEY (`OwnerUserId`) REFERENCES `users` (`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `properties`
--

LOCK TABLES `properties` WRITE;
/*!40000 ALTER TABLE `properties` DISABLE KEYS */;
INSERT INTO `properties` VALUES (1,'a cozy apartment','a cozy place for a couple',2,1,5),(2,'a nice condo','a nice place with an amazing city view',3,2,6),(3,'a big house','a great place for a family',5,3,7),(4,'a small house','a place for short stay',2,4,8);
/*!40000 ALTER TABLE `properties` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `propertyamenities`
--

DROP TABLE IF EXISTS `propertyamenities`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `propertyamenities` (
  `PropertyAmenityId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Cost` decimal(65,30) DEFAULT NULL,
  `Notes` longtext DEFAULT NULL,
  `AmenityId` int(11) NOT NULL,
  `PropertyId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`PropertyAmenityId`),
  KEY `IX_PropertyAmenities_PropertyId` (`PropertyId`),
  KEY `IX_PropertyAmenities_AmenityId` (`AmenityId`),
  CONSTRAINT `FK_PropertyAmenities_Amenities_AmenityId` FOREIGN KEY (`AmenityId`) REFERENCES `amenities` (`AmenityId`) ON DELETE CASCADE,
  CONSTRAINT `FK_PropertyAmenities_Properties_PropertyId` FOREIGN KEY (`PropertyId`) REFERENCES `properties` (`PropertyId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `propertyamenities`
--

LOCK TABLES `propertyamenities` WRITE;
/*!40000 ALTER TABLE `propertyamenities` DISABLE KEYS */;
INSERT INTO `propertyamenities` VALUES (1,50.000000000000000000000000000000,'new machines',1,2),(2,60.000000000000000000000000000000,'old machines',1,4),(3,110.000000000000000000000000000000,'any time',2,2),(4,130.000000000000000000000000000000,'only in the afternoon',2,1),(5,80.000000000000000000000000000000,'only one',3,3),(6,88.000000000000000000000000000000,'street parking',3,1),(7,96.000000000000000000000000000000,'treadmile',4,3),(8,120.000000000000000000000000000000,'whole set',4,4);
/*!40000 ALTER TABLE `propertyamenities` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ratings`
--

DROP TABLE IF EXISTS `ratings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ratings` (
  `RatingId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Stars` int(10) unsigned NOT NULL,
  `Review` longtext DEFAULT NULL,
  `PropertyId` int(10) unsigned NOT NULL,
  `UserId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`RatingId`),
  KEY `IX_Ratings_PropertyId` (`PropertyId`),
  KEY `IX_Ratings_UserId` (`UserId`),
  CONSTRAINT `FK_Ratings_Properties_PropertyId` FOREIGN KEY (`PropertyId`) REFERENCES `properties` (`PropertyId`) ON DELETE CASCADE,
  CONSTRAINT `FK_Ratings_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ratings`
--

LOCK TABLES `ratings` WRITE;
/*!40000 ALTER TABLE `ratings` DISABLE KEYS */;
INSERT INTO `ratings` VALUES (1,4,'good',1,1),(2,3,'alright',2,2),(3,5,'very good',3,3),(4,2,'not nice',4,4);
/*!40000 ALTER TABLE `ratings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `UserName` longtext NOT NULL,
  `First` longtext DEFAULT NULL,
  `Last` longtext DEFAULT NULL,
  `Email` longtext NOT NULL,
  `LastLogin` datetime(6) NOT NULL,
  `Joined` datetime(6) NOT NULL,
  `ImageFile` longtext NOT NULL,
  `AddressId` int(10) unsigned NOT NULL,
  PRIMARY KEY (`UserId`),
  KEY `IX_Users_AddressId` (`AddressId`),
  CONSTRAINT `FK_Users_Addresses_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `addresses` (`AddressId`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'MJ_1965','Moon','Jeong','moonjeong@gmail.com','2022-09-08 10:21:19.000000','2020-05-09 00:00:00.000000','https://randomuser.me/api/portraits/med/men/20.jpg',1),(2,'TJ_1976','Tony','Johnson','tonyjohnson@hotmail.com','2022-10-01 11:24:21.000000','2020-01-04 00:00:00.000000','https://randomuser.me/api/portraits/med/men/21.jpg',2),(3,'JB_1969','John','Bobason','johnbobason@hotmail.com','2022-09-01 21:29:30.000000','2020-03-03 00:00:00.000000','https://randomuser.me/api/portraits/med/men/22.jpg',3),(4,'BD_1984','Bob','Doody','bobdoody@gmail.com','2022-10-10 09:21:47.000000','2020-02-01 00:00:00.000000','https://randomuser.me/api/portraits/med/men/23.jpg',4);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'firernr_luke'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-16  0:04:21
