using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace MainLab4Andre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Display student info
            String studentPath = "C:/Users/andre/OneDrive/Inheritance-Lab/students.txt";

            StreamReader srStudent = new StreamReader(studentPath);

            string[] items;

            ChamplainStudent_Part1 student = new ChamplainStudent_Part1();
            ChamplainStudent_Part2 grades = new ChamplainStudent_Part2();
            int counter = 0;
            items = srStudent.ReadLine().Split(',');
            student.addingContent(items);
            while (!srStudent.EndOfStream)
            {
                items = srStudent.ReadLine().Split(',');
                grades.ids.Add(int.Parse(items[0]));
                if (double.TryParse(items.Last(), out double Z))
                {
                    grades.zScores.Add(int.Parse(items[0]), Z);
                }
                counter++;
                student.addingContent(items);
            }
            grades.InitializeDictionaries();

            student.DisplayInfo();
            srStudent.Close();

            String coursePath = "C:\\Users\\andre\\OneDrive\\Inheritance-Lab\\courses.txt";

            StreamReader srCourse = new StreamReader(coursePath);

            grades.DisplayingGradesCategories();
            srCourse.ReadLine();
            int? oldId = null;
            while (!srCourse.EndOfStream)
            {
                items = srCourse.ReadLine().Split(',');
                int studentId = int.Parse(items[0]);
                double newScore = double.Parse(items[3]);
                double newIRG = double.Parse(items[items.Length - 1]);

                if (!grades.studentScores.ContainsKey(studentId))
                    grades.studentScores[studentId] = new List<double>();
                if (!grades.studentIRGs.ContainsKey(studentId))
                    grades.studentIRGs[studentId] = new List<double>();

                grades.studentScores[studentId].Add(newScore);
                grades.studentIRGs[studentId].Add(newIRG);

                if (!grades.nbOfScores.ContainsKey(studentId))
                    grades.nbOfScores[studentId] = 0;
                grades.nbOfScores[studentId]++;

                if (!grades.nbOfIRGs.ContainsKey(studentId))
                    grades.nbOfIRGs[studentId] = 0;
                grades.nbOfIRGs[studentId]++;
            }

            foreach (var studentId in grades.studentScores.Keys.OrderBy(id => id))
            {
                grades.DisplayingGrades(studentId);
            }

        }
    }
}
