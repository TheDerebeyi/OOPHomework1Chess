/****************************************************************************
**	    				    SAKARYA ÜNİVERSİTESİ
**	    			BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**	    			    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**	    			   NESNEYE DAYALI PROGRAMLAMA DERSİ
**		    			    2020-2021 BAHAR DÖNEMİ
**	
**				    ÖDEV NUMARASI..........: Ödev 1 Soru 1
**				    ÖĞRENCİ ADI............: Lütfi Mert Kahraman   
**				    ÖĞRENCİ NUMARASI.......: B201210040
**                  DERSİN ALINDIĞI GRUP...: 1. Öğretim D Grubu
****************************************************************************/


using System;

namespace OOPHomework1Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board myBoard = new Board();
            int counter = 0;
            myBoard.PrintBoard();

            Console.Write("İlk taşı yerleştirmek için ENTER'a basın...");
            Console.ReadKey();
            while (counter < 8)
            {
                while (!myBoard.InsertPiece(RandomInt(8), RandomInt(8))) { }

                Console.Clear();
                myBoard.PrintBoard();
                if (counter != 7)
                {
                    Console.Write((counter + 1) + "/" + (8) + ". Sonraki taşı yerleştirmek için ENTER'a basın...");
                }
                else
                {
                    Console.Write("Tüm taşlar yerleştirildi, sonlandırmak için ENTER'a basın...");
                }
                Console.ReadKey();
                counter++;
            }
        }

        static int RandomInt(int max)           //Rastgele sayılar üretip geri döndürür.
        {
            var random = new Random();
            return random.Next(max);
        }
    }

    class Board
    {
        private int[,] ArrBoard;

        public Board()                          //Varsayılan kurucu fonksiyon
        {
            ArrBoard = new int[8, 8];

            for (int i = 0; i < 8; i++)         //Satranç tahtasını temsil eden matrisin tüm elemanları 0 olarak belirleniyor.
            {
                for (int j = 0; j < 8; j++)     //0 taş yok, 1 kale var.
                {
                    ArrBoard[i, j] = 0;
                }
            }
        }

        public void PrintBoard()                //Tahtayı ekrana çizdirecek method.
        {
            for (int i = 0; i < 8; i++)         //Matris'in tüm elemanları teker teker ekrana yazdırılıyor.
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(ArrBoard[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool CheckAvailability(int row, int column)          //Taşın girilen kareye yerleştirilme durumunda başka taşlar tarafından 
        {                                                           //yenilme durumunun olup olmadığını kontrol eder ve buna göre bir bool değeri döndürür.
            
            if (ArrBoard[row, column] == 0)                         //Girilen karenin dolu olup olmadığı kontrol ediliyor.
            {
                for (int i = 0; i < 8; i++)                         //Girilen kareye ait sütun ve satırın tamamı bu döngüyle taranıyor.
                {
                    if (ArrBoard[row, i] != 0 || ArrBoard[i, column] != 0)    //Eğer sütun veya satırda bir tane bile taş bulunursa false döndürülecek.
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }

        public bool InsertPiece(int row, int column)                //Girilen koordinatlara eğer mümkünse taşı yerleştirir. Başarısız olma durumunda false döndürür.
        {
            if (CheckAvailability(row, column))                     //CheckAvailability(row, column) fonksiyonunun döndüreceği değer kontrol ediliyor. Eğer true döndürürse parça yerleştirilecek.
            {
                ArrBoard[row, column] = 1;
                return true;
            }

            return false;
        }
    }
}
