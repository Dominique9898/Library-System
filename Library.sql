/*
 Navicat Premium Data Transfer

 Source Server         : 渡边理佐女朋友
 Source Server Type    : MySQL
 Source Server Version : 50718
 Source Host           : cdb-76uuco6h.gz.tencentcdb.com:10132
 Source Schema         : Library

 Target Server Type    : MySQL
 Target Server Version : 50718
 File Encoding         : 65001

 Date: 12/06/2019 14:37:13
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tb_Admin
-- ----------------------------
DROP TABLE IF EXISTS `tb_Admin`;
CREATE TABLE `tb_Admin` (
  `Ano` varchar(20) NOT NULL,
  `Aname` varchar(20) DEFAULT NULL,
  `Asex` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Ano`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_Admin
-- ----------------------------
BEGIN;
INSERT INTO `tb_Admin` VALUES ('A001', '魏芳棂', '女');
INSERT INTO `tb_Admin` VALUES ('A002', 'ヒカリ', '男');
INSERT INTO `tb_Admin` VALUES ('A003', '陈声镕', '男');
COMMIT;

-- ----------------------------
-- Table structure for tb_Announce
-- ----------------------------
DROP TABLE IF EXISTS `tb_Announce`;
CREATE TABLE `tb_Announce` (
  `ano` int(3) NOT NULL AUTO_INCREMENT,
  `content` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ano`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_Announce
-- ----------------------------
BEGIN;
INSERT INTO `tb_Announce` VALUES (10, '这里是渡边理佐女朋友独自开发的平手奶瓶智能图书馆管理系统');
COMMIT;

-- ----------------------------
-- Table structure for tb_Book
-- ----------------------------
DROP TABLE IF EXISTS `tb_Book`;
CREATE TABLE `tb_Book` (
  `Bno` varchar(20) NOT NULL,
  `Bname` varchar(20) DEFAULT NULL,
  `Bauthor` varchar(20) DEFAULT NULL,
  `Blocation` varchar(20) DEFAULT NULL,
  `Bisthere` varchar(10) DEFAULT NULL,
  `Bcnt` int(255) DEFAULT NULL,
  PRIMARY KEY (`Bno`),
  KEY `Bno` (`Bno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_Book
-- ----------------------------
BEGIN;
INSERT INTO `tb_Book` VALUES ('00012513', '谁动了我的奶酪?', '(美)斯宾塞约翰逊', '1-B825/CY1', '不可借', 25);
INSERT INTO `tb_Book` VALUES ('00014818', '谁动了我的奶酪?', '(美)斯宾塞约翰逊', '1-B825/CY1', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00014819', '谁动了我的奶酪?', '(美)斯宾塞约翰逊', '1-B825/CY1', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00060578', '谁动了我的奶酪?', '(美)斯宾塞约翰逊', '1-B825/CY1', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00272509', '做最好的自己', '李开复', '1-B848.4/CL61', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00359019', '追风筝的人', '(美)卡勒德胡赛尼', '1-I712.45/CH15', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00722883', '做最好的自己', '李开复', '1-B848.4/CL61', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00722884', '做最好的自己', '李开复', '1-B848.4/CL61', '不可借', 1);
INSERT INTO `tb_Book` VALUES ('00723592', '追风筝的人', '(美)卡勒德胡赛尼', '1-I712.45/CH15', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00723593', '追风筝的人', '(美)卡勒德胡赛尼', '1-I712.45/CH15', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00723595', '追风筝的人', '(美)卡勒德胡赛尼', '1-I712.45/CH15', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00730056', '群山回唱', '(美)卡勒德胡赛尼', '8-I712.45/CH44', '可借', 13);
INSERT INTO `tb_Book` VALUES ('00730057', '群山回唱', '(美)卡勒德胡赛尼', '8-I712.45/CH44', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00760725', '张爱玲年谱', '张惠苑', '9-K825.6=75/CZ2.24', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00760726', '张爱玲年谱', '张惠苑', '9-K825.6=75/CZ2.24', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00825301', '肖申克的救赎', '(美)斯蒂芬金', '8-I712.45/CJ2.37', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00840841', '肖申克的救赎', '(美)斯蒂芬金', '8-I712.45/CJ2.37', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00881848', '卡罗尔', '(美)帕特里夏.海史密斯', '8-I712.45/CH14.7', '不可借', 5);
INSERT INTO `tb_Book` VALUES ('00921375', '丽赛的故事', '(美)斯蒂芬金', '8-I712.45/CS109.1', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00933367', '我相信中国的前途', '(美)黄仁宇', '9-K207-53/CH4', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00938372', '你的名字', '(日)新海诚', '8-I313.45/CX29.6', '可借', 67);
INSERT INTO `tb_Book` VALUES ('00944347', '你的名字', '(日)新海诚', '8-I313.45/CX29.6', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00958391', '星之声', '(日)新海诚', '8-I313.45/CX29.10', '可借', 233);
INSERT INTO `tb_Book` VALUES ('00959570', '人工智能', '李开复', '7-TP18/CL29', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00967450', '我想吃掉你的胰脏', '(日)住野夜', '8-I313.45/CZ37', '可借', 1);
INSERT INTO `tb_Book` VALUES ('00968862', '放学后', '(日)东野圭吾', '8-I313.45/CD4.11-3', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00968863', '放学后', '(日)东野圭吾', '8-I313.45/CD4.11-3', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00968955', '秒速五厘米', '(日)新海诚', '8-I313.45/CX29.12', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00974536', '人工智能', '李开复', '7-TP18/CL29', '可借', 22);
INSERT INTO `tb_Book` VALUES ('00988360', '万历十五年', '(美)黄仁宇', '9-K248.307/CH1.9', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00988372', '中国大历史', '(美)黄仁宇', '9-K207/CH1.2', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00993711', '人物不打折扣', '老舍', '8-I266/CL6.13', '可借', 11);
INSERT INTO `tb_Book` VALUES ('00994524', '四世同堂', '老舍', '8-I246.5/CL2.9', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00998114', '挪威的森林', '(日)村上春树', '8-I313.45/CC3.68', '可借', 0);
INSERT INTO `tb_Book` VALUES ('00998115', '挪威的森林', '(日)村上春树', '8-I313.45/CC3.68', '可借', 12);
INSERT INTO `tb_Book` VALUES ('01003637', '茶馆', '老舍', '8-I234/CL1.9', '可借', 33);
INSERT INTO `tb_Book` VALUES ('01005075', '了不起的盖茨比', '(美)菲茨杰拉德', '8-I712.45/CF7.4', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01007559', '幻夜', '(日)东野圭吾', '8-I313.45/CD4.6-3', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01017595', '奇鸟行状录', '(日)村上春树', '8-I313.45/CC3.69', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01017596', '奇鸟行状录', '(日)村上春树', '8-I313.45/CC3.69', '可借', 45);
INSERT INTO `tb_Book` VALUES ('01017682', '且听风吟', '(日)村上春树', '8-I313.45/CC3.73', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01017683', '且听风吟', '(日)村上春树', '8-I313.45/CC3.73', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01019574', '潘多拉的盒子', '(日)太宰治', '8-I313.45/CT6.66', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01019575', '潘多拉的盒子', '(日)太宰治', '8-I313.45/CT6.66', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01025973', '哈利·波特与密室', '英）J.K.罗琳', '8-I561.84/CL2.6-2', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01026688', '权力意志', '(德)尼采', '9-B516.47/CN1.79', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01032116', '灿烂千阳', '(美)卡勒德胡赛尼', '8-I712.45/CH44.4', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01039465', '人间失格', '(日)太宰治', '8-I313.45/CT6.75', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01039466', '人间失格', '(日)太宰治', '8-I313.45/CT6.75', '可借', 0);
INSERT INTO `tb_Book` VALUES ('01040680', '言叶之庭', '(日)新海诚', '8-I313.45/CX29.14', '可借', 0);
COMMIT;

-- ----------------------------
-- Table structure for tb_Check
-- ----------------------------
DROP TABLE IF EXISTS `tb_Check`;
CREATE TABLE `tb_Check` (
  `Sno` varchar(20) NOT NULL,
  `Bno` varchar(20) NOT NULL,
  `idate` date DEFAULT NULL,
  `odate` date DEFAULT NULL,
  PRIMARY KEY (`Bno`,`Sno`),
  KEY `Sno` (`Sno`),
  CONSTRAINT `tb_Check_ibfk_1` FOREIGN KEY (`Bno`) REFERENCES `tb_Book` (`Bno`) ON DELETE NO ACTION,
  CONSTRAINT `tb_Check_ibfk_2` FOREIGN KEY (`Sno`) REFERENCES `tb_Student` (`Sno`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_Check
-- ----------------------------
BEGIN;
INSERT INTO `tb_Check` VALUES ('01', '00012513', '2019-06-11', '2019-07-11');
INSERT INTO `tb_Check` VALUES ('3160411021', '00722884', '2019-06-11', '2019-07-11');
INSERT INTO `tb_Check` VALUES ('01', '00881848', '2019-06-11', '2019-07-11');
COMMIT;

-- ----------------------------
-- Table structure for tb_Reservation
-- ----------------------------
DROP TABLE IF EXISTS `tb_Reservation`;
CREATE TABLE `tb_Reservation` (
  `Rno` int(4) NOT NULL AUTO_INCREMENT,
  `Stuno` varchar(20) NOT NULL,
  `Seatno` varchar(20) NOT NULL,
  `Rdate` varchar(20) DEFAULT NULL,
  `Rstart` varchar(255) DEFAULT NULL,
  `Rtime` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Rno`) USING BTREE,
  UNIQUE KEY `Stuno` (`Stuno`),
  UNIQUE KEY `Seatno` (`Seatno`),
  CONSTRAINT `tb_Reservation_ibfk_1` FOREIGN KEY (`Stuno`) REFERENCES `tb_Student` (`Sno`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `tb_Reservation_ibfk_2` FOREIGN KEY (`Seatno`) REFERENCES `tb_Seat` (`Seatno`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_Reservation
-- ----------------------------
BEGIN;
INSERT INTO `tb_Reservation` VALUES (20, '3160411021', 'F2S6', '2019年6月10日', '8:00', '1');
COMMIT;

-- ----------------------------
-- Table structure for tb_Seat
-- ----------------------------
DROP TABLE IF EXISTS `tb_Seat`;
CREATE TABLE `tb_Seat` (
  `Seatno` varchar(255) NOT NULL,
  `Sstate` varchar(255) DEFAULT NULL,
  `Slocation` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Seatno`),
  KEY `Seatno` (`Seatno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_Seat
-- ----------------------------
BEGIN;
INSERT INTO `tb_Seat` VALUES ('F1S1', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S10', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S11', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S12', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S13', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S14', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S15', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S16', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S17', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S18', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S19', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S2', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S20', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S21', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S22', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S23', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S24', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S25', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S26', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S27', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S28', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S3', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S4', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S5', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S6', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S7', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S8', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F1S9', '0', '阅览室');
INSERT INTO `tb_Seat` VALUES ('F2S1', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S10', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S11', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S12', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S13', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S14', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S15', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S16', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S17', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S18', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S19', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S2', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S20', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S21', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S22', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S23', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S24', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S25', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S26', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S27', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S28', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S29', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S3', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S30', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S31', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S32', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S33', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S34', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S35', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S36', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S4', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S5', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S6', '1', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S7', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S8', '0', '考研教室');
INSERT INTO `tb_Seat` VALUES ('F2S9', '0', '考研教室');
COMMIT;

-- ----------------------------
-- Table structure for tb_Student
-- ----------------------------
DROP TABLE IF EXISTS `tb_Student`;
CREATE TABLE `tb_Student` (
  `Sno` varchar(20) NOT NULL,
  `Sname` varchar(20) NOT NULL,
  `Sclass` varchar(20) NOT NULL,
  `Ssex` varchar(10) NOT NULL,
  `Semail` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`Sno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_Student
-- ----------------------------
BEGIN;
INSERT INTO `tb_Student` VALUES ('01', '陈声镕', '软件171', '男', '10086@qq.com');
INSERT INTO `tb_Student` VALUES ('13', '魏芳棂', '软件171', '女', '826931133@qq.com');
INSERT INTO `tb_Student` VALUES ('3160411021', '周帅', '计算机162', '男', '911841790@qq.com');
INSERT INTO `tb_Student` VALUES ('3160411022', '周刚', '计算机162', '男', '15168248202@163.com');
INSERT INTO `tb_Student` VALUES ('3170407001', '螃蟹', '软件171', '女', '123@qq.com');
COMMIT;

-- ----------------------------
-- Table structure for tb_User_admin
-- ----------------------------
DROP TABLE IF EXISTS `tb_User_admin`;
CREATE TABLE `tb_User_admin` (
  `Ano` varchar(20) NOT NULL,
  `Ausr` varchar(20) NOT NULL,
  `Apwd` varchar(20) NOT NULL,
  PRIMARY KEY (`Ausr`,`Apwd`,`Ano`) USING BTREE,
  KEY `tb_User_admin_ibfk_1` (`Ano`),
  CONSTRAINT `tb_User_admin_ibfk_1` FOREIGN KEY (`Ano`) REFERENCES `tb_Admin` (`Ano`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_User_admin
-- ----------------------------
BEGIN;
INSERT INTO `tb_User_admin` VALUES ('A001', 'dominique', 'admin');
INSERT INTO `tb_User_admin` VALUES ('A002', 'demo', 'admin');
INSERT INTO `tb_User_admin` VALUES ('A003', '我想吃烤肉', 'admin');
COMMIT;

-- ----------------------------
-- Table structure for tb_User_student
-- ----------------------------
DROP TABLE IF EXISTS `tb_User_student`;
CREATE TABLE `tb_User_student` (
  `Sno` varchar(20) NOT NULL,
  `Susr` varchar(20) NOT NULL,
  `Spwd` varchar(20) NOT NULL,
  PRIMARY KEY (`Susr`,`Spwd`,`Sno`) USING BTREE,
  KEY `tb_User_student_ibfk_1` (`Sno`),
  CONSTRAINT `tb_User_student_ibfk_1` FOREIGN KEY (`Sno`) REFERENCES `tb_Student` (`Sno`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of tb_User_student
-- ----------------------------
BEGIN;
INSERT INTO `tb_User_student` VALUES ('01', 'demo', 'a7758258');
INSERT INTO `tb_User_student` VALUES ('13', 'dominique', '123456');
INSERT INTO `tb_User_student` VALUES ('3160411021', 'kou', '123456');
INSERT INTO `tb_User_student` VALUES ('3160411022', 'zhou', 'Zhou1212');
INSERT INTO `tb_User_student` VALUES ('3170407001', '蟹老板', '620423');
COMMIT;

-- ----------------------------
-- Procedure structure for NewProc
-- ----------------------------
DROP PROCEDURE IF EXISTS `NewProc`;
delimiter ;;
CREATE PROCEDURE `Library`.`NewProc`()
BEGIN
  #Routine body goes here...

END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for show
-- ----------------------------
DROP PROCEDURE IF EXISTS `show`;
delimiter ;;
CREATE PROCEDURE `Library`.`show`(susr VARCHAR(20))
BEGIN
  #Routine body goes here...
	DECLARE sname varchar(20);
	DECLARE sno varchar(20);
  select S1.Sname into sname from tb_Student AS S1,tb_User_student AS S2 where S1.Sno = S2.Sno and S2.Susr = susr;
  select Sno into sno from tb_Student where Sname = sname;
	select sname,sno;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table tb_Check
-- ----------------------------
DROP TRIGGER IF EXISTS `recommand`;
delimiter ;;
CREATE TRIGGER `recommand` AFTER INSERT ON `tb_Check` FOR EACH ROW BEGIN
	UPDATE tb_Book SET Bcnt = Bcnt+1 where Bno = new.Bno;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table tb_Check
-- ----------------------------
DROP TRIGGER IF EXISTS `checkin`;
delimiter ;;
CREATE TRIGGER `checkin` AFTER INSERT ON `tb_Check` FOR EACH ROW BEGIN
	UPDATE tb_Book SET Bisthere = "不可借" where Bno = new.Bno;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table tb_Check
-- ----------------------------
DROP TRIGGER IF EXISTS `checkout`;
delimiter ;;
CREATE TRIGGER `checkout` AFTER DELETE ON `tb_Check` FOR EACH ROW BEGIN
	UPDATE tb_Book SET Bisthere = "可借" where Bno = old.Bno;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table tb_Reservation
-- ----------------------------
DROP TRIGGER IF EXISTS `order`;
delimiter ;;
CREATE TRIGGER `order` AFTER INSERT ON `tb_Reservation` FOR EACH ROW BEGIN
	UPDATE tb_Seat SET Sstate = 1 where Seatno = new.Seatno;
END
;;
delimiter ;

-- ----------------------------
-- Triggers structure for table tb_Reservation
-- ----------------------------
DROP TRIGGER IF EXISTS `dele`;
delimiter ;;
CREATE TRIGGER `dele` AFTER DELETE ON `tb_Reservation` FOR EACH ROW BEGIN
 UPDATE tb_Seat Set Sstate = 0 where Seatno = old.Seatno;
End
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
