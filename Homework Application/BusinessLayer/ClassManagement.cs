using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkCompanion;

namespace BusinessLayer
{
    public class ClassManagement
    {


        public List<Class> SelectAllClasses()
        {
            List<Class> output = new List<Class>();
            using (var db = new HomeworkCompanionContext())
            {                
                var allClasses = db.Classes.Select(c => c);

                foreach (var item in allClasses)
                {
                    output.Add(item);
                }                
            }

            return output;
        }


        public List<Class> SelectAllClassesForATeacher(int id)
        {
            List<Class> output = new List<Class>();
            using (var db = new HomeworkCompanionContext())
            {                
                var allClassesOfTeacher = db.Classes
                    .Where(c => c.ClassTeacherFk == id)
                    .Select(c => c);

                foreach (var item in allClassesOfTeacher)
                {
                    output.Add(item);
                }                
            }

            return output;
        }




    }
}
