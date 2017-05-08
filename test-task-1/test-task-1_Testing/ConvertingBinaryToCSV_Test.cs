using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using test_task_1;
using System.IO;
using System.Collections.Generic;

namespace test_task_1_Testing
{

         //тестируем класс 'ConvertingBinaryToCSV' 

       //Unit test 3: создаем 'заглушку' тестовый бинарный файл 'Tread-test-3.dat' содержащий 1000000 'миллион'строк структуры 'tread'
      //тестирем класс 'ConvertingBinaryToCSV' ,его метод 'fromBinaryFile'и метод 'toCSV' с их помощью вычитываем данные из тестового бинарного файла и размещаим их в коллекцию
     //после чего выгружаем данные в файл 'Trade-test.csv'.
    //далее сверяем колличество строк в 'заглушке'тестовом бинарном файле и колличество  строк выгруженных в файл 'Trade-test.csv', если они равны то тест пройден. 



    [TestClass]
    public class ConvertingBinaryToCSV_Test
    {

        //# 1. Создаем заглушку для тестируемого класса 'ConvertingBinaryToCSV' , в виде тестового бинарного файла 'Tread-test-3.dat'

        [TestMethod(), Timeout(40000)]//максимально возможное время работы теста (40 секунд)
         
        #region

        public void CreatedBinaryFile_and_UpLoad_to_CSV_File()
        {

            string path_dat = @"D:\\Trade-test-3.dat";  //путь и имя будующего бинарного файла содержащего  структуры
            string path_CSV = @"D:\\Trade-test-3.csv";  //путь и имя будующего  файла с разделителями содержащего теже структуры
            int schetchik = 0;//счетчик
            int result1__ = 0;//количество  строк записаных в тестовый бинарный файл
            int result2__ =0;//количество строк вычитаных из бинарого файла в коллекцию 
            int result3__ =0;//количество строк вычитаных из бинарого файла в коллекцию 
            int lines = 1000000;//на скольких строках протестировать?



            //создаем массив структур и присваиваем  значения полям каждой структуры 
            #region 

            TradeRecord[] trade = new TradeRecord[lines]; // создание экземпяра структуры "TradeRecord" на X строк

            for (int i = 0; i < lines; i++)
            {
                trade[i] = new TradeRecord(0 + i, 7777, 88888, "   comment Unit-test 3");
            }
            #endregion


            //создание экземпляра BinaryWriter (запись  в бинарный файл)
            #region BinaryWriter
            using (BinaryWriter writer = new BinaryWriter(File.Open(path_dat, FileMode.OpenOrCreate)))// открывает поток для записи структур в файл
            {
                #region
                foreach (TradeRecord t in trade)
                {
                    writer.Write(t.id);
                    writer.Write(t.account);
                    writer.Write(t.volume);
                    writer.Write(t.comment);

                    schetchik++;
                }
                Console.WriteLine("");
                Console.WriteLine("в бинарный файл 'D:\\Trade-test-3.dat' записано   {0}  строк(и) структуры 'trade'", schetchik);
                result1__ = schetchik;
                schetchik = 0;
                #endregion
            }
            #endregion

            #endregion


            //# 2.выполняем действие над тестируемым классом:'ConvertingBinaryToCSV' 

            ConvertingBinaryToCSV convertingBinaryToCSV = new ConvertingBinaryToCSV(path_dat, path_CSV);

            
            List<TradeRecord> trade_ = convertingBinaryToCSV.fromBinaryFile(path_dat, out result2__);
                            result3__= convertingBinaryToCSV.toCSV(trade_,  path_CSV);


            Assert.AreEqual(result1__+(result1__- result2__), result3__);//сравнение ожидаемого и полученого, если равны то тест пройден

        }
    }
}
