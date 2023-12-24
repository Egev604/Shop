CREATE DATABASE  IF NOT EXISTS `shop` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `shop`;
-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: shop
-- ------------------------------------------------------
-- Server version	8.0.32

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
-- Table structure for table `categoryproduct`
--

DROP TABLE IF EXISTS `categoryproduct`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoryproduct` (
  `id_categoryProduct` int NOT NULL,
  `categoryName` varchar(45) NOT NULL,
  PRIMARY KEY (`id_categoryProduct`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoryproduct`
--

LOCK TABLES `categoryproduct` WRITE;
/*!40000 ALTER TABLE `categoryproduct` DISABLE KEYS */;
INSERT INTO `categoryproduct` VALUES (1,'Когтеточки и домики'),(2,'Груминг и уход'),(3,'Лотки и наполнители'),(4,'Амуниция и дрессировка');
/*!40000 ALTER TABLE `categoryproduct` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `manufacturer`
--

DROP TABLE IF EXISTS `manufacturer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `manufacturer` (
  `id_manufacturer` int NOT NULL,
  `manufacturerName` varchar(45) NOT NULL,
  PRIMARY KEY (`id_manufacturer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `manufacturer`
--

LOCK TABLES `manufacturer` WRITE;
/*!40000 ALTER TABLE `manufacturer` DISABLE KEYS */;
INSERT INTO `manufacturer` VALUES (1,'ФРОСЯ'),(2,'ZOOshop'),(3,'Catidea'),(4,'DNK ZOO'),(5,'Усы Лапы Хвост'),(6,'Rokki'),(7,'БОТАНИКFOX'),(8,'ZooMom'),(9,'Мармариал'),(10,'Pawing'),(11,'PetTails'),(12,'PetMart'),(13,'Savipets'),(14,'МОНИ'),(15,'My Friends'),(16,'Pet-it'),(17,'animal store'),(18,'ЗЛАТИК'),(19,'Woolen'),(20,'Моси-Моси'),(21,'ТопТопЛапы'),(22,'Sleepy pet'),(23,'LONK');
/*!40000 ALTER TABLE `manufacturer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `articul` int NOT NULL,
  `productName` text NOT NULL,
  `description` text,
  `idCategory` int NOT NULL,
  `cost` int NOT NULL,
  `image` text,
  `idManufacturer` int DEFAULT NULL,
  `discount` int DEFAULT NULL,
  `unit` int NOT NULL,
  `countOnStock` int NOT NULL,
  PRIMARY KEY (`articul`),
  KEY `das_idx` (`idManufacturer`),
  KEY `unit_idx` (`unit`),
  KEY `cat_idx` (`idCategory`),
  CONSTRAINT `cat` FOREIGN KEY (`idCategory`) REFERENCES `categoryproduct` (`id_categoryProduct`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `das` FOREIGN KEY (`idManufacturer`) REFERENCES `manufacturer` (`id_manufacturer`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `unit` FOREIGN KEY (`unit`) REFERENCES `unit` (`id_unit`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES (123,'asddas','sadas',1,12,'',18,12,1,12),(213,'saddasdas','sdada',2,123,'',21,12,1,21),(12312,'dasda','adsda',1,12,'001.jpg',21,12,1,12331),(231312,'dasdas','dsadas',1,123,'',2,123,1,123),(14280541,'Когтеточка лежанка для кошки, когтедралка картонная','',1,2059,'14280541.png',1,56,1,6),(19663908,'Перчатка для вычесывания шерсти кошек и собак рукавица','Перчатка щетка для домашних животных для вычесывания шерсти, 23х15 см',2,268,'19663908.png',2,44,1,14),(25988002,'Лоток для кошек с высоким бортиком с совком','Туалет для кошек Catidea, лоток квадратной формы, размером 44х44х25 см, с закрытым высоким бортом.',3,3107,'',3,35,1,21),(42519347,'Расческа для кошек собак, Чесалка, Щетка, Дешеддер, Гребень','Дешеддер - расческа триммер для любых типов шерсти и всех видов животных',2,1534,'42519347.png',4,77,1,6),(43937279,'Намордник для собак тканевый','',4,370,'',5,20,1,8),(51378349,'Когтеточка лежак ГРЕЙСИ','Напольная когтеточка с лежанкой и канатиком - универсальный аксессуар 3 в 1',1,6248,'51378349.png',6,62,1,15),(70550993,'Ошейник от блох и клещей 35 см','БИО Ошейник от блох и клещей полностью безопасен для животного',4,420,'',7,61,1,16),(73675789,'Когтерезка для кошек и для собак, ножницы для кошек','Большой (16 см) и маленький (12 см) когтерез для животных.',2,452,'73675789.png',8,58,1,14),(76289903,'Когтеточка для кошки','Размер основания 40*30 см, размер верхней лежанки 40*30 см, общая высота 55 см. Высота столбика 50 см.',1,1010,'76289903.png',9,12,1,7),(77154305,'Поводок-рулетка, серый, 8 м, для собак весом до 50 кг','Удобный ленточный поводок-рулетка предназначен для выгула собак весом до 50 кг.',4,3998,'77154305.png',10,71,1,16),(81484980,'Туалет для кошек, лоток закрытый домик с дверцей','Размеры 50х38хh37см.',3,4500,'81484980.png',11,64,1,25),(82238142,'Лоток для кошек большой закрытый с совком LC-001','Лоток-домик для кошек',3,8130,'82238142.png',12,65,1,14),(88388817,'Шлейка для собак мелких и средних пород','Шлейка для собак, щенков и кошек с поводком',4,1190,'88388817.png',13,52,1,5),(93357571,'Намордник пластиковый черный, д/мелк., средн. и крупн. собак','Намордники пластиковые PetTails для собак изготовлены из прочной пластиковой сетки черного цвета и синтетических лент',4,1297,'93357571.png',11,1,1,12),(96454514,'Ошейник для собак','',4,1239,'',14,38,1,7),(98480893,'Лежак для собак 55x47x15 см','Размер лежанки для собак - 55x47x15 см.',1,2900,'98480893.png',15,56,1,17),(115162717,'Лоток для кошек с высоким бортом решеткой и совком','',3,2534,'115162717.png',17,56,1,15),(119423642,'Наполнитель для кошачьего туалета 6 кг','Комкующийся наполнитель экопремиум класса',3,1200,'119423642.png',18,50,1,9),(139248503,'Наполнитель соевый для кошачьего туалета комкующийся 3 кг.','Гипоаллергенный биоразлагаемый наполнитель тофу классический',3,2441,'',19,67,1,15),(141586018,'Пеленки для животных одноразовые на липучках 60х45 30 штук','Одноразовые гелевые пеленки для животных с липким фиксатором',3,1390,'141586018.png',12,69,1,17),(148020228,'Наполнитель древесный для кошек впитывающий пеллеты 6мм 45л','Наполнитель древесный впитывающий для кошек 15 кг (впитывает 45 л)',3,1050,'148020228.png',20,58,1,6),(153486024,'Расческа для животных чесалка для кошки для собаки','',2,811,'153486024.png',21,64,1,15),(155966694,'Шлейка с поводком','',4,974,'',22,55,1,19),(160767030,'Наполнитель для кошек 7.6 л 3.2 кг','Силикагелевый наполнитель LONK (ЛОНК)',3,1280,'160767030.png',23,24,1,9);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `id_role` int NOT NULL AUTO_INCREMENT,
  `roleName` varchar(45) NOT NULL,
  PRIMARY KEY (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Администратор'),(2,'Клиент'),(3,'Менеджер');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unit`
--

DROP TABLE IF EXISTS `unit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `unit` (
  `id_unit` int NOT NULL,
  `unitName` varchar(45) NOT NULL,
  PRIMARY KEY (`id_unit`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unit`
--

LOCK TABLES `unit` WRITE;
/*!40000 ALTER TABLE `unit` DISABLE KEYS */;
INSERT INTO `unit` VALUES (1,'шт.');
/*!40000 ALTER TABLE `unit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id_users` int NOT NULL AUTO_INCREMENT,
  `surname` text NOT NULL,
  `name` text NOT NULL,
  `middle_name` text,
  `login` text NOT NULL,
  `passwd` text NOT NULL,
  `date_of_birhday` text,
  `number_phone` text,
  `role` int NOT NULL,
  PRIMARY KEY (`id_users`),
  KEY `roleA_idx` (`role`),
  CONSTRAINT `roleA` FOREIGN KEY (`role`) REFERENCES `role` (`id_role`)
) ENGINE=InnoDB AUTO_INCREMENT=59 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Астафьев','Юрий','Владимирович','loginspYrbnLw','|7s\\lH','1998-03-05','+7(057)075-62-76',1),(2,'Дроздова','Анна','Матвеевна','loginldoGOEoz','(/Gc9d','1979-04-05','+7(426)316-69-21',2),(3,'Леонова','Василиса','Лукинична','loginRhtTWOUL','KhYb+6','1990-12-17','+7(285)107-20-46',3),(4,'Королева','Арина','Константиновна','logingcncrrVt','0s9B?3','1994-08-05','+7(141)494-93-76',1),(5,'Логинов','Леонид','Ильич','loginDzvxLMSh','qmv8Y\'','1994-01-30','+7(076)760-92-28',2),(6,'Рябова','Дарина','Владимировна','loginCYQDuzaQ','Hh!D5o','1999-06-27','+7(279)849-06-08',2),(7,'Лебедев','Матвей','Васильевич','loginzomMHdGF','s9Y[\\o','2000-12-26','+7(962)396-40-31',2),(8,'Петров','Сергей','Николаевич','loginGuWCekZh','7>jA0Q','1992-10-17','+7(072)606-68-69',2),(9,'Беляева','Варвара','Марковна','loginOVzEPXBU','\\2^Kto','1994-03-18','+7(086)579-87-37',3),(10,'Попова','Анна','Леонидовна','loginhipKwVOG','S+48Pi','1998-01-04','+7(787)680-41-50',3),(11,'Прохорова','Светлана','Ярославовна','loginnwlwfWJV',')1gI2A','1974-02-08','+7(177)868-94-56',2),(12,'Соколов','Даниил','Николаевич','loginOVeNFjgE','4n;Xi9','1986-07-11','+7(133)067-44-52',2),(13,'Жукова','Екатерина','Макаровна','loginyOKpgezQ','5Y~LTp','1981-12-13','+7(104)296-41-35',3),(14,'Наумова','Екатерина','Марковна','loginUESqWqzL','3ND`fZ','1983-12-30','+7(074)505-91-83',2),(15,'Лаптев','Святослав','Владиславович','loginaMJsWdgM','5+P(\'m','1978-10-09','+7(970)343-68-57',3),(16,'Маркова','Арина','Вячеславовна','loginvuGEXFKp','(&`4Ae','1985-06-14','+7(269)843-20-33',2),(17,'Мальцева','Ангелина','Степановна','loginUxkGoPcU','ra3H;i','1985-06-21','+7(285)876-18-61',3),(18,'Медведева','Мила','Святославовна','loginnWgEsPpe','3b$)^Q','1971-08-18','+7(006)637-83-97',1),(19,'Шевелева','Алиса','Михайловна','loginTVsxpeMc','3)5tvU','1997-01-06','+7(306)392-88-06',2),(20,'Лебедев','Василий','Артёмович','loginYabOqmdv','y3B:0f','1986-04-18','+7(141)119-28-48',3),(21,'Колпакова','Маргарита','Ивановна','loginGKqwoMPE','js>6iA','1984-05-04','+7(170)152-45-11',2),(22,'Соколова','Варвара','Адамовна','loginGJKRiwnt','DbtN3:','1970-05-13','+7(413)195-24-65',3),(23,'Кожевников','Сергей','Елисеевич','loginVsnulXby','Bb3}?J','1977-04-09','+7(857)068-24-33',1),(24,'Богданова','Мария','Макаровна','loginFMAnHFef','lau0~F','1986-06-12','+7(586)311-54-16',3),(25,'Голубев','Матвей','Маркович','loginjTqOFkyy','/Sn{1(','1995-05-11','+7(798)532-01-90',3),(26,'Александрова','София','Александровна','loginCHyWIOlj',']r%&P8','1995-09-04','+7(720)164-53-59',3),(27,'Коротков','Глеб','Александрович','loginSIkLHbby','J3E}tH','2001-04-01','+7(640)145-02-95',2),(28,'Журавлева','Варвара','Владимировна','loginvcoLQQkN','=7@R&s','1983-01-13','+7(261)699-89-60',3),(29,'Тихомиров','Всеволод','Русланович','loginBdKnwxIN','DO6qK[','1986-08-25','+7(166)530-51-19',2),(30,'Кузин','Никита','Андреевич','loginvSwgUUih','0B7@ac','1974-12-05','+7(227)947-11-40',2),(31,'Соболев','Илья','Егорович','loginisNXixEd','Z{;`6n','1971-10-19','+7(203)368-97-45',3),(32,'Смирнов','Фёдор','Иванович','loginpTETxfiz','r!oY9L','1987-09-28','+7(735)978-70-04',2),(33,'Федоров','Егор','Львович','loginsMOeqMWQ','Rfd6\'J','1995-11-01','+7(027)315-44-61',1),(34,'Петров','Александр','Платонович','loginQHLLmkPO','\\(7Xgc','1982-01-23','+7(070)232-81-26',2),(35,'Богданова','Вероника','Александровна','loginRwzAWqja','7Q(g8V','1980-08-20','+7(964)096-84-90',2),(36,'Егорова','Элина','Степановна','loginWVlnNcct','OB9A~t','1973-10-10','+7(395)539-50-09',2),(37,'Смирнов','Лука','Романович','loginvusfELtV','8ENXz!','1981-07-17','+7(327)557-44-35',3),(38,'Никонова','Мария','Андреевна','loginMGeaHwxR','#FPQd0','1994-06-13','+7(764)335-37-00',2),(39,'Старикова','Диана','Артёмовна','loginZWWWaLcM','.Zp`8f','1974-01-23','+7(440)507-84-99',1),(40,'Исакова','Юлия','Павловна','loginenJEiQfp','1mZBe&','1987-06-04','+7(449)098-67-30',2),(41,'Руднева','Оливия','Сергеевна','loginidXkPJEx','@1DuPH','1978-08-26','+7(668)366-51-63',2),(42,'Кириллов','Иван','Артёмович','loginHKUeAiwB','N=du[5','1998-05-09','+7(704)041-51-65',2),(43,'Иванов','Эрик','Иванович','loginFdVBaklR','}aM^Y2','1980-08-06','+7(664)224-33-19',3),(44,'Ушакова','Анна','Павловна','loginKkgzMnnI','*AZw\\0','1980-12-01','+7(550)144-94-91',2),(45,'Харитонов','Дмитрий','Владимирович','loginhLnuFXRr','!C46nq','1973-12-18','+7(430)058-69-09',2),(46,'Миронов','Фёдор','Матвеевич','loginXPhXgGEx','O[8h;y','2002-11-03','+7(543)635-10-02',2),(47,'Коновалова','Екатерина','Михайловна','loginOUOyKWKd','Dor5:U','1990-01-09','+7(621)226-66-62',1),(48,'Горшкова','Эмилия','Семёновна','loginBwsFEXQF',')5HfU\\','1980-09-03','+7(113)124-65-03',2),(49,'Васильев','Артур','Вячеславович','loginIuXYFJAr','>St*n3','1983-08-13','+7(545)773-98-42',1),(50,'Семенов','Руслан','Миронович','loginUiTtFkpE','*$8s^N','1984-09-06','+7(078)603-81-60',3),(54,'dsadsa','dsa','dsadsa','loginvHfojZnj','zkk9]m','2023-05-22','',1),(55,'ds','ds','ds','loginFEmhdnWb','@]dnus','22.05.2023 15:10:37','',1),(56,'qwe','qwe','qwe','admin','admin','23.05.2023 9:04:12','',1),(57,'qwe2','qwe2','qwe2','user','user','23.05.2023 9:04:12','',2),(58,'qwe3','qwe3','qwe3','user2','user2','23.05.2023 9:04:12','',3);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-23 12:20:42
