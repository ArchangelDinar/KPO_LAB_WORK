﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KPO_4311_ADM.Lib;
using System.Collections.Generic;

namespace KPO_4311_ADM.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFilterOnlyAfter()
        {
            List<Konfiguration> konfigurationList = initializeKonfigurationList();
            
            List<Konfiguration> resultList = (new KonfigurationFilter
            {
                KonfigurationList = konfigurationList,
                After = new DateTime(2016, 1, 1, 0, 0, 0)
            }).Filter();

            Assert.AreEqual(2, resultList.Count);
        }
        [TestMethod]
        public void TestFilterOnlyBefore()
        {
            List<Konfiguration> konfigurationList = initializeKonfigurationList();

            List<Konfiguration> resultList = (new KonfigurationFilter
            {
                KonfigurationList = konfigurationList,
                Before = new DateTime(2017, 1, 1, 0, 0, 0)
            }).Filter();

            Assert.AreEqual(3, resultList.Count);
        }
        [TestMethod]
        public void TestFilterAfterAndBefore()
        {
            List<Konfiguration> konfigurationList = initializeKonfigurationList();

            List<Konfiguration> resultList = (new KonfigurationFilter
            {
                KonfigurationList = konfigurationList,
                After = new DateTime(2011, 1, 1, 0, 0, 0),
                Before = new DateTime(2017, 1, 1, 0, 0, 0)
            }).Filter();

            Assert.AreEqual(1, resultList.Count);
        }       
        

        public string globalStringForTestMethod = "";
        public List<Konfiguration> initializeKonfigurationList()
        {
            List<Konfiguration> konfigurationList = new List<Konfiguration>();
            {
                Konfiguration kon = new Konfiguration()
                {
                    OS = "OS/2",
                    SUBD = "DB2",
                    HD = 130,
                    SD = 22,
                    PRICE = 3343,
                    CREATETIME = new DateTime(2000, 1, 1, 0, 0, 0)
                };
                konfigurationList.Add(kon);
            }
            {
                Konfiguration kon = new Konfiguration()
                {
                    OS = "Windows/NT",
                    SUBD = "SQLServer",
                    HD = 230,
                    SD = 24,
                    PRICE = 2685,
                    CREATETIME = new DateTime(2010, 1, 1, 0, 0, 0)
                };
                konfigurationList.Add(kon);
            }
            {
                Konfiguration kon = new Konfiguration()
                {
                    OS = "SCO/Unix",
                    SUBD = "Oracle",
                    HD = 110,
                    SD = 48,
                    PRICE = 3745,
                    CREATETIME = new DateTime(2016, 1, 1, 0, 0, 0)
                };
                konfigurationList.Add(kon);
            }
            {
                Konfiguration kon = new Konfiguration()
                {
                    OS = "OS/2",
                    SUBD = "DB2",
                    HD = 130,
                    SD = 22,
                    PRICE = 3343,
                    CREATETIME = new DateTime(2020, 1, 1, 0, 0, 0)
                };
                konfigurationList.Add(kon);
            }
            return konfigurationList;
        }
        public void deleteSpaces(string str)
        {
            globalStringForTestMethod = str.Trim(' ');
        }

        [TestMethod]
        public void TestDataFileRowFromArrayToString()
        {
            DataFileRow dfr = new DataFileRow(new int[] { 20, 20, 8, 8, 8, 19 });
            string[] array = { "OS/2", "DB2", "130", "22", "3343", "01.10.2007 11:57:00" };
            string row = dfr.fromArrayToString(array);
            Assert.AreEqual("                OS/2                 DB2     130      22    334301.10.2007 11:57:00", row);
        }
        [TestMethod]
        public void TestDataFileRowFromStringToArray()
        {
            DataFileRow dfr = new DataFileRow(new int[] { 20, 20, 8, 8, 8, 19 });
            string row = "                OS/2                 DB2     130      22    334301.10.2007 11:57:00";
            string[] array = dfr.fromStringToArray(row);
            Assert.AreEqual("OS/2", array[0]);
            Assert.AreEqual("DB2", array[1]);
            Assert.AreEqual("130", array[2]);
            Assert.AreEqual("22", array[3]);
            Assert.AreEqual("3343", array[4]);
            Assert.AreEqual("01.10.2007 11:57:00", array[5]);
        }
    }
}
