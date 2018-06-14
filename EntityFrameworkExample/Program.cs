using EntityFrameworkExample.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample
{
    class Program
    {
        private static DataManager dataManager = new DataManager();

        private static void AddNewPerson(string firstName, string lastName, string phoneNumber)
        {
            var person = dataManager.PersonManager.AddOrUpdate(firstName, lastName);
            dataManager.SaveChanges();

            dataManager.PhoneManager.AddIfNeed(person, phoneNumber);
            dataManager.SaveChanges();
        }

        private static Teacher AddNewTeacher(string firstName, string lastName, string phoneNumber)
        {
            var teacherA = dataManager.TeacherManager.AddOrUpdate(firstName, lastName);
            dataManager.SaveChanges();
            Phone teacherPhoneA = dataManager.PhoneManager.AddIfNeed(teacherA, phoneNumber);
            dataManager.SaveChanges();

            return teacherA;
        }

        private static Student AddNewStudent(string firstName, string lastName, string phoneNumber)
        {
            var studentA = dataManager.StudentManager.AddOrUpdate(firstName, lastName);
            dataManager.SaveChanges();
            Phone studentPhoneA = dataManager.PhoneManager.AddIfNeed(studentA, phoneNumber);
            dataManager.SaveChanges();

            return studentA;
        }

        private static void ShowAllPeople()
        {
            List<PersonInfo> data = dataManager.PersonManager.GetAllData();
            Console.WriteLine("Found " + data.Count() + " people:\n");
            foreach (var personInfo in data)
            {
                string phoneNumbers = "";
                foreach (var number in personInfo.phoneNumbers)
                    phoneNumbers += number + "; ";

                Console.WriteLine(personInfo.firstName);
                Console.WriteLine(personInfo.lastName);
                Console.WriteLine(phoneNumbers + "\n");
            }
        }

        static void Main(string[] args)
        {
            AddNewPerson("Dmitriy", "Kirikov", "+7 123 4567890");
            Teacher teacherA = AddNewTeacher("TeacherA", "TeacherALastName", "TeacherAPhone"); //has 2 students - A & B
            Teacher teacherB = AddNewTeacher("TeacherB", "TeacherBLastName", "TeacherBPhone"); //has 1 student - B

            Student studentA = AddNewStudent("StudentA", "StudentALastName", "StudentAPhone"); //has 1 teacher - A
            Student studentB = AddNewStudent("StudentB", "StudentBLastName", "StudentBPhone"); //has 2 teachers - A & B
            teacherA.Students.Add(studentA);
            teacherA.Students.Add(studentB);
            teacherB.Students.Add(studentB);
            dataManager.SaveChanges();

            ShowAllPeople();
            Console.ReadKey();
        }
    }
}
