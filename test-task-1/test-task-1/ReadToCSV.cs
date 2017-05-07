using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace test_task_1
{


    public class ReadToCSV: IReadToCSV
    {
       
        //коструктоp пользовательский_1
        #region 'ReadToCSV'
        public  ReadToCSV(List<TradeRecord> trade_, string patch_CSV_)
        {
            string patch_CSV = patch_CSV_;
            List<TradeRecord> trade = trade_;
        }

        //коструктоp пользовательский_2
        
        public ReadToCSV( string patch_CSV_)
        {
            string patch_CSV = patch_CSV_;
            
        }

        public void toCSV()
        {
            
        }
        #endregion

        //public int s()
        //{

        //    try
        //    {
        //        int a = 1; int b = 1; int c = a + b; 
        //    }

        //    //сообщение о возникшем исключении
        //    #region исключения
        //    catch (Exception m)
        //    {
        //        Console.WriteLine(m.Message);
        //    }
        //    Console.ReadLine();
        //    #endregion
        //    return c;
        //}


        //метод 'toCSV' получает коллекцию структурированных данных  и генерирует из нее конечный файл *.CSV , возвращает во вне количество записаных в файл строк
        #region 'toCSV'
        public int toCSV(List<TradeRecord> trade, string patch_CSV)
        {
            int i = 0;//переменая счетчика
            int i_ = 0;//переменая счетчика

            //секция критичная в части исключений
            //try
            //#region
            //{

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(patch_CSV))
                {

                    foreach (TradeRecord t in trade)
                    {
                        file.Write(t.id);
                        file.Write(";");
                        file.Write(t.account);
                        file.Write(";");
                        file.Write(t.volume);
                        file.Write(";");
                        file.Write(t.comment);

                        file.WriteLine(";");

                        i++;
                        //Console.WriteLine("id: {0}      счет: {1}     уровень: {2}       комментарий: {3} ", t.id, t.account, t.volume, t.comment);
                    }

                    Console.WriteLine();
                    Console.WriteLine("cконвертировано в файл:'D:\\Trade.csv'  : {0} строк ", i);
                    i_ = i;
                    i = 0;

                }
                
            //}
            #endregion
           

            //сообщение о возникшем исключении
            //#region исключения
            //catch (Exception m)
            //{
            //    Console.WriteLine(m.Message);
            //}
            //Console.ReadLine();
            //#endregion


            return i_;//возвращаем во вне количество записаных в файл строк
        }

       
        //#endregion

    }
}
