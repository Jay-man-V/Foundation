/****** Object:  Database [SystemTesting]    Script Date: 12/05/2018 23:06:16 ******/
USE [master]

CREATE DATABASE [SystemTesting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SystemTesting', FILENAME = N'C:\Database\SystemTesting.mdf' , SIZE = 1024KB , MAXSIZE = UNLIMITED, FILEGROWTH = 2048KB )
 LOG ON 
( NAME = N'SystemTesting_log', FILENAME = N'C:\Database\SystemTesting_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 2048KB )

ALTER DATABASE [SystemTesting] SET AUTO_CLOSE OFF;
