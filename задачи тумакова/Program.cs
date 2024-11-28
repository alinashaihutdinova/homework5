using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


namespace задачи_тумакова
{
    internal class Program
    {
        static void CountLetters(char[] chars, out int vowels, out int consonants)//метод для подсчета букв для первого задания
        {
            vowels = 0;
            consonants = 0;
            string vowelsString = "АЕЁИОУЫЭЮЯ".ToLower();
            foreach (char c in chars)
            {
                if (char.IsLetter(c))
                {
                    if (vowelsString.Contains(c))
                    {
                        vowels++;
                    }
                    else
                    {
                        consonants++;
                    }
                }
            }
        }

        static void FirstTask()
        {
            /*Написать программу, которая вычисляет число гласных и согласных букв в
            файле. Имя файла передавать как аргумент в функцию Main. Содержимое текстового файла
            заносится в массив символовы. Количество гласных и согласных букв определяется проходом
            по массиву. Предусмотреть метод, входным параметром которого является массив символов.
            Метод вычисляет количество гласных и согласных букв.*/

            Console.WriteLine("Упражнение 6.1");

            string filename = ("Новый текстовый документ.txt");
            char[] chars = File.ReadAllText(filename).ToCharArray();//чтение содержимого файла в массив символов
            int vowelsCount, consonantsCount;
            CountLetters(chars, out vowelsCount, out consonantsCount);
            Console.WriteLine($"Количество гласных: {vowelsCount}");
            Console.WriteLine($"Количество согласных: {consonantsCount}");
        }

        static void PrintMatrix(int[,] matrix) //печать матрицы для второго задания
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static int[,] Multiplication(int[,] matrix1, int[,] matrix2)//умножение матриц для второго задания
        {
            int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.GetLength(1); k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return result;
        }
        static void SecondTask()
        {
            /*Написать программу, реализующую умножению двух матриц, заданных в
            виде двумерного массива. В программе предусмотреть два метода: метод печати матрицы,
            метод умножения матриц (на вход две матрицы, возвращаемое значение– матрица).*/

            Console.WriteLine("Упражнение 6.2");

            Console.WriteLine("Введите количество строк первой матрицы : ");
            int rows1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов первой матрицы: ");
            int cols1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество строк второй матрицы : ");
            int rows2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов второй матрицы: ");
            int cols2 = int.Parse(Console.ReadLine());
            // объявляем две матрицы
            int[,] matrix1 = new int[rows1, cols1];
            int[,] matrix2 = new int[rows2, cols2];
            Console.WriteLine("Введите элементы первой матрицы:");
            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    Console.WriteLine($"Введите элемент для позиции [{i + 1}, {j + 1}]: ");
                    matrix1[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Введите элементы второй матрицы:");
            for (int i = 0; i < rows2; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    Console.WriteLine($"Введите элемент для позиции [{i + 1}, {j + 1}]: ");
                    matrix2[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Первая матрица:");
            PrintMatrix(matrix1);
            Console.WriteLine("Вторая матрица:");
            PrintMatrix(matrix2);
            if (cols1 != rows2)
            {
                Console.WriteLine("Умножение невозможно, так как количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
            }
            else
            {
                Console.WriteLine("Результат умножения двух матриц:");
                PrintMatrix(Multiplication(matrix1, matrix2));
            }
        }

        static double[] CalculateAverageTemperatures(double[,] temperature)//подсчет средней температуры для третьего задания
        {
            double[] averageTemperatures = new double[12];
            for (int month = 0; month < 12; month++)
            {
                double sum = 0;
                for (int day = 0; day < 30; day++)
                {
                    sum += temperature[month, day];
                }
                averageTemperatures[month] = sum / 30;
            }
            return averageTemperatures;
        }
        static void ThirdTask()
        {
            /*Написать программу, вычисляющую среднюю температуру за год. Создать
            двумерный рандомный массив temperature[12, 30], в котором будет храниться температура
            для каждого дня месяца(предполагается, что в каждом месяце 30 дней).Сгенерировать
            значения температур случайным образом. Для каждого месяца распечатать среднюю
            температуру.Для этого написать метод, который по массиву temperature[12, 30] для каждого
            месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив
            средних температур.Полученный массив средних температур отсортировать по
            возрастанию*/

            Console.WriteLine("Упражнение 6.3");

            double[,] temperature = new double[12, 30];
            Random random = new Random();
            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    temperature[month, day] = random.Next(-30, 30);
                }
            }
            Console.WriteLine("Средняя температура для каждого месяца:");
            double[] averageTemperatures = CalculateAverageTemperatures(temperature);
            for (int month = 0; month < 12; month++)
            {
                Console.WriteLine($"Месяц {month + 1}: {averageTemperatures[month]:F2} C");
            }
            Array.Sort(averageTemperatures);
            Console.WriteLine("Средние температуры, отсортированные по возрастанию:");
            foreach (var sortTemp in averageTemperatures)
            {
                Console.WriteLine($"{sortTemp:F2} °C");
            }
        }

        static void CountLetters(List<char> chars, out int vowels, out int consonants)//подсчет букв для четвертого задания
        {
            vowels = 0;
            consonants = 0;
            string vowelsString = "АЕЁИОУЫЭЮЯ".ToLower();
            foreach (char c in chars)
            {
                if (char.IsLetter(c))
                {
                    if (vowelsString.Contains(c))
                    {
                        vowels++;
                    }
                    else
                    {
                        consonants++;
                    }
                }
            }
        }
        static void FourthTask()
        {
            /* Упражнение 6.1 выполнить с помощью коллекции List<T>*/

            Console.WriteLine("Домашнее задание 6.1");

            string filename = "Новый текстовый документ.txt";
            List<char> chars = new List<char>(File.ReadAllText(filename));// Чтение содержимого файла в список символов
            int vowelsCount, consonantsCount;
            CountLetters(chars, out vowelsCount, out consonantsCount);
            Console.WriteLine($"Количество гласных: {vowelsCount}");
            Console.WriteLine($"Количество согласных: {consonantsCount}");
        }
        static void PrintMatrix(LinkedList<LinkedList<int>> matrix)//вывод матрицы для пятого задания
        {
            foreach (LinkedList<int> row in matrix)
            {
                foreach (int element in row)
                {
                    Console.Write(element + "\t");
                }
                Console.WriteLine();
            }
        }
        static LinkedList<LinkedList<int>> Multiplication(LinkedList<LinkedList<int>> matrix1, LinkedList<LinkedList<int>> matrix2)
        {
            LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();

            for (int i = 0; i < matrix1.Count; i++)
            {
                result.AddLast(new LinkedList<int>());
                for (int j = 0; j < matrix2.First.Value.Count; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrix1.First.Value.Count; k++)
                    {
                        sum += matrix1.ElementAt(i).ElementAt(k) * matrix2.ElementAt(k).ElementAt(j);
                    }
                    result.Last.Value.AddLast(sum);
                }
            }
            return result;
        }
        static void FifthTask()
        {
            /*Упражнение 6.2 выполнить с помощью коллекций
            LinkedList<LinkedList<T>>*/

            Console.WriteLine("Домашнее задание 6.2");

            Console.WriteLine("Введите количество строк первой матрицы : ");
            int rows1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов первой матрицы: ");
            int cols1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество строк второй матрицы : ");
            int rows2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов второй матрицы: ");
            int cols2 = int.Parse(Console.ReadLine());
            LinkedList<LinkedList<int>> matrix1 = new LinkedList<LinkedList<int>>();
            LinkedList<LinkedList<int>> matrix2 = new LinkedList<LinkedList<int>>();
            Console.WriteLine("Введите элементы первой матрицы:");
            for (int i = 0; i < rows1; i++)
            {
                matrix1.AddLast(new LinkedList<int>());
                for (int j = 0; j < cols1; j++)
                {
                    Console.WriteLine($"Введите элемент для позиции [{i + 1}, {j + 1}]: ");
                    matrix1.Last.Value.AddLast(int.Parse(Console.ReadLine()));
                }
            }
            Console.WriteLine("Введите элементы второй матрицы:");
            for (int i = 0; i < rows2; i++)
            {
                matrix2.AddLast(new LinkedList<int>());
                for (int j = 0; j < cols2; j++)
                {
                    Console.WriteLine($"Введите элемент для позиции [{i + 1}, {j + 1}]: ");
                    matrix2.Last.Value.AddLast(int.Parse(Console.ReadLine()));
                }
            }
            Console.WriteLine("Первая матрица:");
            PrintMatrix(matrix1);
            Console.WriteLine("Вторая матрица:");
            PrintMatrix(matrix2);
            if (cols1 != rows2)
            {
                Console.WriteLine("Умножение невозможно, так как количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
            }
            else
            {
                Console.WriteLine("Результат умножения двух матриц:");
                PrintMatrix(Multiplication(matrix1, matrix2));
            }
        }
        static double[] CalculateAverageTemperatures(Dictionary<string, double[]> temperature)//средняя температура для 6 задания
        {
            double[] averageTemperatures = new double[12];
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            for (int month = 0; month < 12; month++)
            {
                double[] monthTemperatures = temperature[months[month]];
                double sum = 0;
                foreach (var temp in monthTemperatures)
                {
                    sum += temp;
                }
                averageTemperatures[month] = sum / monthTemperatures.Length; // расчет средней температуры для месяца
            }
            return averageTemperatures;
        }

        static void SixthTask()
        {
            /* Написать программу для упражнения 6.3, использовав класс
             Dictionary<TKey, TValue>. В качестве ключей выбрать строки– названия месяцев, а в
             качестве значений– массив значений температур по дням.*/

            Console.WriteLine("Домашнее задание 6.3");

            Dictionary<string, double[]> temperature = new Dictionary<string, double[]>();
            Random random = new Random();
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            foreach (var month in months)
            {
                double[] monthTemperatures = new double[30];
                for (int i = 0; i < 30; i++)
                {
                    monthTemperatures[i] = random.Next(-30, 30);
                }
                temperature.Add(month, monthTemperatures);
            }
            Console.WriteLine("Средняя температура для каждого месяца:");
            double[] averageTemperatures = CalculateAverageTemperatures(temperature);
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine($"{months[i]}: {averageTemperatures[i]:F2} C");
            }
            Array.Sort(averageTemperatures);
            Console.WriteLine("Средние температуры, отсортированные по возрастанию:");
            foreach (var temp in averageTemperatures)
            {
                Console.WriteLine($"{temp:F2} °C");
            }
        }
        static void Main(string[] args)
        {
            FirstTask();
            SecondTask();
            ThirdTask();
            FourthTask();
            FifthTask();
            SixthTask();
        }
    }
}
