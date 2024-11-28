using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace дз._5
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint YearOfBirth { get; set; }
        public string Exam { get; set; }
        public uint Score { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Год рождения: {YearOfBirth}, Экзамены: {Exam}, Баллы: {Score}";
        }
    }
    internal class Program
    {
        static void FirstTask()
        {
            /*Создать List на 64 элемента, скачать из интернета 32 пары картинок(любых). В List
            должно содержаться по 2 одинаковых картинки. Необходимо перемешать List с
            картинками.Вывести в консоль перемешанные номера(изначальный List и полученный
            List).Перемешать любым способом*/

            Console.WriteLine("Задание 1");

            string imagesFolder = "программирование";
            if (!Directory.Exists(imagesFolder))
            {
                Console.WriteLine("Папка не найдена");
                return;
            }
            List<string> images = new List<string>();
            var imageFiles = Directory.GetFiles(imagesFolder, "*.*", SearchOption.TopDirectoryOnly)
                                       .Where(file => file.EndsWith(".jpeg"));

            Random random = new Random();
            var selectedFiles = imageFiles.OrderBy(x => random.Next()).Take(32).ToList(); // выбираем 32 случайных картинки
            foreach (var file in selectedFiles)
            {
                images.Add(file);
                images.Add(file); //добавляем каждую картинку дважды
            }
            Console.WriteLine("Оригинальный список:");
            for (int i = 0; i < images.Count; i++)
            {
                Console.WriteLine($"{i}: {images[i]}");
            }
            List<string> mixedImages = images.OrderBy(x => random.Next()).ToList();
            Console.WriteLine("Перемешанный список:");
            for (int i = 0; i < mixedImages.Count; i++)
            {
                Console.WriteLine($"{i}: {mixedImages[i]}");
            }
        }

        static Dictionary<string, Student> ReadStudentsFromFile(string filename)
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();
            if (File.Exists(filename))//если файл существует программу будет выполнена
            {
                var lines = File.ReadAllLines(filename);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length >= 5)
                    {
                        var student = new Student
                        {
                            FirstName = parts[0],
                            LastName = parts[1],
                            YearOfBirth = uint.Parse(parts[2]),
                            Exam = string.Join(", ", parts.Skip(3).Take(parts.Length - 4)), // Собираем экзамены
                            Score = uint.Parse(parts.Last())
                        };
                        string key = $"{student.LastName} {student.FirstName}".ToLower();
                        students[key] = student;
                    }
                }
            }
            return students;
        }
        static void AddNewStudent(Dictionary<string, Student> students)
        {
            Console.WriteLine("Введите имя: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите год рождения: ");
            uint yearOfBirth = uint.Parse(Console.ReadLine());
            Console.WriteLine("С какими экзаменами поступил: ");
            string exam = Console.ReadLine();
            Console.WriteLine("Введите сумму баллов: ");
            uint score = uint.Parse(Console.ReadLine());
            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                YearOfBirth = yearOfBirth,
                Exam = exam,
                Score = score
            };
            string key = $"{firstName} {lastName}".ToLower();
            students[key] = student; // добавление студента
            Console.WriteLine("Студент добавлен!");
        }
        static void RemoveStudent(Dictionary<string, Student> students)
        {
            Console.WriteLine("Введите имя: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию: ");
            string lastName = Console.ReadLine();
            string key = $"{firstName} {lastName}";
            string lowerKey = key.ToLower();
            var studentKey = students.Keys.FirstOrDefault(k => k.ToLower() == lowerKey);
            if (studentKey != null)
            {
                students.Remove(studentKey);
                Console.WriteLine("Студент удален");
            }
            else
            {
                Console.WriteLine("Студент не найден");
            }
        }
        static void SortStudents(Dictionary<string, Student> students)
        {
            var sortedStudents = students.Values.OrderBy(s => s.Score).ToList();
            Console.WriteLine("Студенты отсортированы по возрастанию баллов:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }

        static void SecondTask()
        {
            Console.WriteLine("Задание 2");

            Dictionary<string, Student> students = ReadStudentsFromFile("студенты.txt");
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Новый студент");
            Console.WriteLine("2. Удалить");
            Console.WriteLine("3. Сортировать");
            Console.WriteLine("4. Выход");
            Console.Write("Укажите выбранную цифру: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddNewStudent(students); break;
                case "2": RemoveStudent(students); break;
                case "3": SortStudents(students); break;
                case "4": return; // завершить программу
                default: Console.WriteLine("Неверный выбор."); break;
            }
        }
        static void Main(string[] args)
        {
            FirstTask();
            SecondTask();
        }
    }
}
