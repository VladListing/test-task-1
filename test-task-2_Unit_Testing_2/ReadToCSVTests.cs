using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using test_task_1;
using System.Collections;


namespace test_task_2_Unit_Testing_2
{
    //описание структуры 'TradeRecord' 
    #region 'TradeRecord'

    [StructLayout(LayoutKind.Sequential, Pack = 1)]// размещение в неуправляемый код
    public struct TradeRecord
    {
        public int id;
        public int account;
        public double volume;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] //маршалинг в неуправляемый код
        public string comment;

        //конструктор "TradeRecord"
        public TradeRecord(int a, int b, double c, string d)
        {
            id = a;
            account = b;
            volume = c;
            comment = d;
        }
    }
    #endregion




    [TestClass]
    public class ReadToCSVTests
    {
        string path_CSV = @"D:\\Trade-test.csv";  //путь и имя будующего бинарного файла содержащего  структуры


        [TestMethod]// драйвер

        //--------------------------------------------------------------------------------------------------------------------------------------

        public List<TradeRecord> Created_Collection()
        {

            int lines = 1000000;//на скольких строках протестировать?
            List<TradeRecord> trade = new List<TradeRecord>();

            for (int i = 0; i < lines; i++)
            {
                //trade[i] = new TradeRecord(0 + i, lines, 640 + i, "строка Unit тестового файла");
                trade.Add(new TradeRecord() { id = i, account = 7778, volume = 78888, comment = "Коллекция строка Unit теста 2" });
            }

            return trade;//возвращаем коллекцию c тестовыми данными
        }
        //--------------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------------
        public void Created_Collection_and_Upload_to_CSV()
        {

            List<TradeRecord> collektion__ = Created_Collection();
            List<TradeRecord> collektion___ = (List<test_task_2_Unit_Testing_2.TradeRecord>)collektion__;

           // класс 'ReadToCSV' получает коллекцию структурированных данных и генерирует из нее конечный файл *.CSV    
           ReadToCSV readToCSV = new ReadToCSV(collektion___, path_CSV);//создаем экземпляр класса
            readToCSV.toCSV(collektion___, path_CSV);//вызов метода класса 
        }
        //------------------------------------------------------------------------------------------------------------------------------------






        //2.выполнить действие над той системой которую мы тестируем



    }
}
