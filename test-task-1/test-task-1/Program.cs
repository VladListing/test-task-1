﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace test_task_1  //конвертация бинарных файлов в формат " .*CSV 
{

    class Program
    {
        public const string path_dat = @"D:\\Trade.dat";  //путь и имя бинарного файла со структурами
        public const string path_CSV = @"D:\\Trade.CSV";  //путь и имя  создаваемого файла с разделителями, типа *.CSV

        static void Main(string[] args) // тестовое задание 1:
        {
            
            //секция критичная в части исключений
            try

            {
                //класс 'ReaderFromBinaryFiles' вычитывает данные из бинарного файла и возвращает коллекцию структурированных данных  
                ReaderFromBinaryFiles readerFromBinaryFiles = new ReaderFromBinaryFiles(path_dat);
                List<TradeRecord> Collektion = readerFromBinaryFiles.fromBinaryFile(path_dat);


                //класс 'ReadToCSV' получает коллекцию структурированных данных  и генерирует из нее конечный файл *.CSV 
                ReadToCSV readToCSV = new ReadToCSV(Collektion,path_CSV);//создаем экземпляр классауктур
                readToCSV.toCSV(Collektion, path_CSV);//вызов метода класса 

             }
           
            //сообщения о возникшем исключении
            #region исключения
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
            #endregion
            
        }
    }
}
