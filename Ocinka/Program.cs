using System;
using System.IO;

namespace Ocinka
{
    class Program
    {
        static double[,] fileData1;
        static double[,] fileData2;
        static double[,] fileData3;
        static double[,] fileData4;
        static string[] fileAuto;
        static string[] fileProp;
        static double[] fileWeight;

        static void Main(string[] args)
        {
            GetData1();
            GetData2();
            GetData3();
            GetData4();
            GetAuto();
            GetProp();
            GetWeight();

            Console.WriteLine("Наявнi автомобiлi:");
            for (int i = 0; i < fileAuto.Length; i++)
            {
                Console.WriteLine($"{i + 1} {fileAuto[i]}");
            }

            Console.WriteLine("\nКритерiї:");
            for (int i = 0; i < fileProp.Length; i++)
            {
                Console.WriteLine($"{i + 1} {fileProp[i]}");
            }

            Console.WriteLine("\nШкала оцiнювання: 1-20");

            double BMW_acceleration = Math.Round(fileWeight[0]*(fileData1[0,0] + fileData2[0, 0] + fileData3[0, 0] + fileData4[0, 0]),1);
            double AUDI_Eacceleration = Math.Round(fileWeight[0] * (fileData1[1,0] + fileData2[1, 0] + fileData3[1, 0] + fileData4[1, 0]), 1);
            double MERCEDES_acceleration = Math.Round(fileWeight[0] * (fileData1[2,0] + fileData2[2, 0] + fileData3[2, 0] + fileData4[2, 0]), 1);
            double Rolls_acceleration = Math.Round(fileWeight[0] * (fileData1[3,0] + fileData2[3, 0] + fileData3[3, 0] + fileData4[3, 0]), 1);

            double BMW_maxspeed = Math.Round(fileWeight[1] * (fileData1[0, 1] + fileData2[0, 1] + fileData3[0, 1] + fileData4[0, 1]), 1);
            double AUDI_maxspeed = Math.Round(fileWeight[1] * (fileData1[1, 1] + fileData2[1, 1] + fileData3[1, 1] + fileData4[1, 1]), 1);
            double MERCEDES_maxspeed = Math.Round(fileWeight[1] * (fileData1[2, 1] + fileData2[2, 1] + fileData3[2, 1] + fileData4[2, 1]), 1);
            double Rolls_maxspeed = Math.Round(fileWeight[1] * (fileData1[3, 1] + fileData2[3, 1] + fileData3[3, 1] + fileData4[3, 1]), 1);

            double BMW_type = Math.Round(fileWeight[2] * (fileData1[0, 2] + fileData2[0, 2] + fileData3[0, 2] + fileData4[0, 2]), 1);
            double AUDI_type = Math.Round(fileWeight[2] * (fileData1[1, 2] + fileData2[1, 2] + fileData3[1, 2] + fileData4[1, 1]), 1);
            double MERCEDES_type = Math.Round(fileWeight[2] * (fileData1[2, 2] + fileData2[2, 2] + fileData3[2, 2] + fileData4[2, 2]), 1);
            double Rolls_type = Math.Round(fileWeight[2] * (fileData1[3, 2] + fileData2[3, 2] + fileData3[3, 2] + fileData4[3, 2]), 1);

            double BMW_seats = Math.Round(fileWeight[3] * (fileData1[0, 3] + fileData2[0, 3] + fileData3[0, 3] + fileData4[0, 3]), 1);
            double AUDI_seats = Math.Round(fileWeight[3] * (fileData1[1, 3] + fileData2[1, 3] + fileData3[1, 3] + fileData4[1, 3]), 1);
            double MERCEDES_seats = Math.Round(fileWeight[3] * (fileData1[2, 3] + fileData2[2, 3] + fileData3[2, 3] + fileData4[2, 3]), 1);
            double Rolls_seats = Math.Round(fileWeight[3] * (fileData1[3, 3] + fileData2[3, 3] + fileData3[3, 3] + fileData4[3, 3]), 1);


            double bmw_summary = Math.Round(BMW_acceleration + BMW_maxspeed + BMW_type + BMW_seats,1);
            double audi_summary = Math.Round(AUDI_Eacceleration + AUDI_maxspeed + AUDI_type + AUDI_seats, 1);
            double mercedes_summary = Math.Round(MERCEDES_acceleration + MERCEDES_maxspeed + MERCEDES_type + MERCEDES_seats, 1);
            double Rolls_summary = Math.Round(Rolls_acceleration + Rolls_maxspeed + Rolls_type + Rolls_seats, 1);

            Console.WriteLine("Результат");

            Console.WriteLine("№ Параметр       | Вага   BMW  Audi  Mercedes  Rolls-Royse ");
            Console.WriteLine($"1 0-100          | {fileWeight[0]}    {BMW_acceleration}   {AUDI_Eacceleration}    {MERCEDES_acceleration}        {Rolls_acceleration} ");
            Console.WriteLine($"2 Макс. швидкiсть| {fileWeight[1]}    {BMW_maxspeed}  {AUDI_maxspeed}    {MERCEDES_maxspeed}         {Rolls_maxspeed}");
            Console.WriteLine($"3 Привiд         | {fileWeight[2]}    {BMW_type}    {AUDI_type}     {MERCEDES_type}      {Rolls_type}");
            Console.WriteLine($"4 К-сть мiсць    | {fileWeight[3]}    {BMW_seats}  {AUDI_seats}    {MERCEDES_seats}      {Rolls_seats}");
            Console.WriteLine($"Сума             |        {bmw_summary} {audi_summary}    {mercedes_summary}        {Rolls_summary} ");



        }
        public static double[,] GetData1() // метод для зчитування і запису чисел в масив 
        {
            string filePath = Path.GetFullPath("1expert.txt");
            int y = 0;
            using var fileReader = new StreamReader(filePath);
            string line;
            fileData1 = new double[4, 4];
            while ((line = fileReader.ReadLine()) != null)
            {
                string[] lines = line.Split(' ');
                double[] mas = new double[4];

                for (int i = 0; i < 4; i++)
                {
                    fileData1[y, i] = Convert.ToDouble(lines[i]);
                    //Console.Write(fileData1[y,i]+" ");                   
                }
                y++;
                // Console.WriteLine();
            }
            return fileData1;
        }


        public static double[,] GetData2() // метод для зчитування і запису чисел в масив 
        {
            string filePath = Path.GetFullPath("2expert.txt");
            int y = 0;
            using var fileReader = new StreamReader(filePath);
            string line;
            fileData2 = new double[4, 4];
            while ((line = fileReader.ReadLine()) != null)
            {
                string[] lines = line.Split(' ');
                double[] mas = new double[4];

                for (int i = 0; i < 4; i++)
                {
                    fileData2[y, i] = Convert.ToDouble(lines[i]);
                    // Console.Write(fileData2[y, i] + " ");
                }
                y++;
                //Console.WriteLine();
            }
            return fileData2;
        }

        public static double[,] GetData3() // метод для зчитування і запису чисел в масив 
        {
            string filePath = Path.GetFullPath("3expert.txt");
            int y = 0;
            using var fileReader = new StreamReader(filePath);
            string line;
            fileData3 = new double[4, 4];
            while ((line = fileReader.ReadLine()) != null)
            {
                string[] lines = line.Split(' ');
                double[] mas = new double[4];

                for (int i = 0; i < 4; i++)
                {
                    fileData3[y, i] = Convert.ToDouble(lines[i]);
                    //  Console.Write(fileData3[y, i] + " ");
                }
                y++;
                // Console.WriteLine();
            }
            return fileData3;
        }

        public static double[,] GetData4() // метод для зчитування і запису чисел в масив 
        {
            string filePath = Path.GetFullPath("4expert.txt");
            int y = 0;
            using var fileReader = new StreamReader(filePath);
            string line;
            fileData4 = new double[4, 4];
            while ((line = fileReader.ReadLine()) != null)
            {
                string[] lines = line.Split(' ');
                double[] mas = new double[4];

                for (int i = 0; i < 4; i++)
                {
                    fileData4[y, i] = Convert.ToDouble(lines[i]);
                    // Console.Write(fileData4[y, i] + " ");
                }
                y++;
                //Console.WriteLine();
            }
            return fileData4;
        }


        public static string[] GetAuto() // метод для зчитування і запису чисел в масив 
        {
            string filePath = Path.GetFullPath("Auto.txt");

            using var fileReader = new StreamReader(filePath);
            string file = fileReader.ReadToEnd();
            string[] lines = file.Split('\n');


            fileAuto = new string[lines.Length];

            for (int i = 0; i < fileAuto.Length; i++)
            {
                fileAuto[i] = lines[i];
                // Console.WriteLine($"{i} {fileAuto[i]}");
            }
            return fileAuto;
        }

        public static string[] GetProp() // метод для зчитування і запису чисел в масив 
        {
            string filePath = Path.GetFullPath("properties.txt");

            using var fileReader = new StreamReader(filePath);
            string file = fileReader.ReadToEnd();
            string[] lines = file.Split('\n');


            fileProp = new string[lines.Length];

            for (int i = 0; i < fileProp.Length; i++)
            {
                fileProp[i] = lines[i];
                //Console.WriteLine($"{i} {fileProp[i]}");
            }
            return fileProp;
        }

        public static double[] GetWeight() // метод для зчитування і запису чисел в масив 
        {
            string filePath = Path.GetFullPath("Weight.txt");

            using var fileReader = new StreamReader(filePath);
            string file = fileReader.ReadToEnd();
            string[] lines = file.Split('\n');


            fileWeight = new double[lines.Length];

            for (int i = 0; i < fileProp.Length; i++)
            {
                fileWeight[i] = Convert.ToDouble(lines[i]);
                //Console.WriteLine($"{i} {fileProp[i]}");
            }
            return fileWeight;
        }



    }
}
