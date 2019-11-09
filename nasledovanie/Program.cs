using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Читать книгу до 7 главы.
//Описать базовый класс Человек.
//поля:
//имя
//возраст
//пол
//вес
//методы:
//get set
//отбразить все данные - toString
//гулять
//голос - у всех разный

//Описать класс наследник Ребёнок
//поля:
//количество молочных зубов
//прививочная карта

//методы:
//делать прививку
//изменить количество молочных зубов
//показать все данные
//гулять: качельки-карусельки

//Описать класс наследник Студент
//поля:
//статическое поле стипендия - 
//название вуза
//курс
//стипендия

//методы:
//подготовка к сессии
//оплатить экзамен
//гулять: пати и изменяется вес рандомно

//сделать класс СтудентКонтрактник
//у него нет стипендии
//есть поле стоимость контракта
//метод оплатить за обучение

//создать список объектов классов наследников.Осуществить возможность взаимодействия.


namespace ConsoleApp3
{


    abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }

        public Person(string name, int age, string gender, double weight)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Gender: {Gender}, Weight: ({Weight})kg";
        }
        public abstract void Walk();
        public abstract void Voice();
    }

    class Child : Person
    {
        public int BabyTeeth { get; private set; }
        struct vaccinationCard
        {
            public string text;
            public DateTime time;
            public vaccinationCard(string text, DateTime time)
            {
                this.text = text;
                this.time = time;
            }
        }
        List<vaccinationCard> cards;

        public Child(string name, int age, string gender, double weight, int babyTeeth) : base(name, age, gender, weight)
        {
            cards = new List<vaccinationCard>();
            BabyTeeth = babyTeeth;
        }
        public void DoVaccination(string text)
        {
            cards.Add(new vaccinationCard(text, DateTime.Now));
        }

        public void ChangeTeeth(int valueTeeth)
        {
            BabyTeeth += valueTeeth;
        }

        public override string ToString()
        {
            return base.ToString() + $", teeth: {BabyTeeth}";
        }

        public void ShowVaccinationCard()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---Vaccination Card---");
            foreach (var item in cards)
            {
                Console.WriteLine("text: " + item.text.ToString() + " Date: " + item.time.ToShortDateString());
            }
            Console.WriteLine("----------------------");
            Console.ResetColor();
        }

        public override void Voice()
        {
            Console.WriteLine("Голос ребенка");
        }
        public override void Walk()
        {
            Console.WriteLine("качельки-карусельки");
        }
    }

    class Student : Person
    {

        //public static double StudentScholarshipStatic { get; set; }//$
        public string NameOfUniversity { get; set; }
        public int Course { get; set; }
        public double StudentScholarship { get; set; }//$
        //static Student()
        //{
        //    StudentScholarshipStatic = 300;
        //}
        protected Student(string name, int age, string gender, double weight) : base(name, age, gender, weight)//этот конструктор служит для передачи аргументов от дочернего класса Student к его базовому Person.
        {
        }
        public Student(string name, int age, string gender, double weight, string university, int course, double studentScholarship) : base(name, age, gender, weight)
        {
            NameOfUniversity = university;
            Course = course;
            StudentScholarship = studentScholarship;
        }
        //подготовка к сессии
        public void SessionPreparation()
        {
            Console.WriteLine("session preparation");
        }
        //оплатить экзамен
        public void PayToExam(double pay)
        {
            Console.WriteLine($"Pay exam: ${pay}");
        }
        public override string ToString()
        {
            return base.ToString() + ", University: " + NameOfUniversity.ToString() + ", Course: " + Course.ToString() + ", Scholarship: $" + StudentScholarship.ToString();
        }
        public override void Voice()
        {
            Console.WriteLine("говорит студент");
        }
        public override void Walk()
        {
            Random random = new Random();
            if (random.Next(1, 3) == 1)
            {
                Console.WriteLine("пати");
            }
            else
            {
                double weightTemp = random.NextDouble();
                if (Weight < 30)
                {
                    Console.WriteLine("Ты уже и так мало весишь, погуляешь в другой раз.");
                    Console.WriteLine($"Твой вес : {Weight:F}kg");
                }
                else
                {
                    if (Weight > weightTemp)
                        Weight -= weightTemp;
                    Console.WriteLine("прогулка на свежем воздухе(положительно влияет на вес)");
                    Console.WriteLine($"Твой вес : {Weight:F}kg");
                }
            }
        }
    }

    class StudentContractor : Student
    {
        //сделать класс СтудентКонтрактник
        //у него нет стипендии
        //есть поле стоимость контракта
        //метод оплатить за обучение
        public new double StudentScholarship { private get; set; } = 0;//скрыли и неиспользуем
        public double CoastContract { get; set; }
        public StudentContractor(string name, int age, string gender, double weight, string university, int course, double coastContract) : base(name, age, gender, weight)
        {
            NameOfUniversity = university;
            Course = course;
            CoastContract = coastContract;
        }
        public void TuitionFee(double money)
        {
            Console.WriteLine($"Плата за обучение: {money}");
        }
        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Gender: {Gender}, Weight: ({Weight})kg, University: " + NameOfUniversity + ", Course: " + Course + ", coastContract: $" + CoastContract;
        }
        public override void Voice()
        {
            base.Voice();
        }
        public override void Walk()
        {
            base.Walk();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //child
            Console.WriteLine("--------------------CHILD");
            Person child = new Child("Aleksandr", 12, "male", 30.250, 16);
            Console.WriteLine(child.ToString());
            ((Child)child).DoVaccination("Malaria");
            ((Child)child).DoVaccination("gepatit b");
            ((Child)child).DoVaccination("Varicella");
            ((Child)child).ShowVaccinationCard();
            child.Voice();
            child.Walk();
            Console.WriteLine("убираем 3 зуба");
            ((Child)child).ChangeTeeth(-3);
            Console.WriteLine(child.ToString());
            Console.WriteLine("добавляем 5 зубов");
            ((Child)child).ChangeTeeth(5);
            Console.WriteLine(child.ToString());

            //Student
            Console.WriteLine("--------------------STUDENT");
            Person student = new Student("Oriana", 18, "female", 51.100, "Harvard", 4, 400);
            Console.WriteLine(student.ToString());
            student.Voice();
            for (int i = 0; i < 5; i++)
            {
                student.Walk();
                Thread.Sleep(1000);
            }
            ((Student)student).PayToExam(200);
            ((Student)student).SessionPreparation();

            //StudentContractor
            Console.WriteLine("--------------------StudentContractor");
            Person studentScholarship = new StudentContractor("Mideia", 18, "female", 50.60, "Harvard", 4, 300);
            Console.WriteLine(studentScholarship.ToString());
            studentScholarship.Voice();
            studentScholarship.Walk();
            for (int i = 0; i < 5; i++)
            {
                studentScholarship.Walk();
                Thread.Sleep(1000);
            }
            ((StudentContractor)studentScholarship).TuitionFee(100);



            //////////////////
            Console.WriteLine("--------------------TEST-------------------");
            StudentContractor student1 = new StudentContractor("Mideia", 18, "female", 50.60, "Harvard", 4, 300);
            //Console.WriteLine(student1.StudentScholarship);  //нельзя просмотреть, private get


        }
    }
}
