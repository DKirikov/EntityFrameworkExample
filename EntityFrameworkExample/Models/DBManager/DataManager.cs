using EntityFrameworkExample.Models.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample
{
    public class DataManager
    {
        public DataManager()
        {
            Npgsql.NpgsqlConnectionStringBuilder ssb = new Npgsql.NpgsqlConnectionStringBuilder();
            ssb.Host = "localhost";
            ssb.Port = 5432;
            ssb.Username = "postgres";
            ssb.Password = "postgres";
            ssb.Database = "test_db";
            ssb.CommandTimeout = 30;
            ssb.Pooling = true;
            ssb.MaxPoolSize = 20;
            ssb.MinPoolSize = 1;

            var cond = new Npgsql.NpgsqlConnection(ssb.ToString());

            database = new Database(cond.ConnectionString);
        }

        public PersonManager PersonManager { get { return personManager ?? (personManager = new PersonManager(database.people)); } }
        public TeacherManager TeacherManager { get { return teacherManager ?? (teacherManager = new TeacherManager(database.teachers)); } }
        public StudentManager StudentManager { get { return studentManager ?? (studentManager = new StudentManager(database.students)); } }
        public PhoneManager PhoneManager { get { return phoneManager ?? (phoneManager = new PhoneManager(database.phones)); } }

        public void SaveChanges()
        {
            database.SaveChanges();
        }

        private PersonManager personManager;
        private TeacherManager teacherManager;
        private StudentManager studentManager;
        private PhoneManager phoneManager;

        private Database database;
    }
}
