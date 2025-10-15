using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLab4Andre
{
    partial class ChamplainStudent_Part2 : IGrading
    {

        double averageHelperMethod(List<double> scores)
        {
            double total = 0;
            foreach (double score in scores)
            {
                total += score;
            }
            return total / scores.Count;
        }
        public double CalculateAverage(List<double> scores)
        {
            double average = averageHelperMethod(scores);
            return average;
        }

        public double CalculateGPA(List<double> scores)
        {
            double average = averageHelperMethod(scores);
            if (average >= 90)
                return 4.0;
            else if (average >= 80)
                return 3.0;
            else if (average >= 70)
                return 2.0;
            else if (average >= 60)
                return 1.0;
            else
                return 0.0;
        }

        double AverageIRG(List<double> IRGs) {
            double total = 0;
            foreach (double irg in IRGs)
            {
                total += irg;
            }
            return total / IRGs.Count;
        }

        public double CalculateRScore(List<double> IRGs, double Z)
        {
            double averageIRG = AverageIRG(IRGs);
            return (Z * 5 + averageIRG + 35) / 60 * 20;
        }

        public List<int> ids = new List<int>();
        public Dictionary<int, int> nbOfScores;
        public Dictionary<int, int> nbOfIRGs;

        public void InitializeDictionaries()
        {
            nbOfScores = new Dictionary<int, int>();
            nbOfIRGs = new Dictionary<int, int>();

            foreach (int id in ids)
            {
                nbOfScores[id] = 0;
                nbOfIRGs[id] = 0;
            }
        }

        public Dictionary<int, List<double>> studentScores = new Dictionary<int, List<double>>();
        public Dictionary<int, List<double>> studentIRGs = new Dictionary<int, List<double>>();


        public Dictionary<int, double> zScores = new Dictionary<int, double>();
        public void DisplayingGradesCategories()
        {
            Console.WriteLine("      ID      |      Avg      |     GPA      |    R_score    |");
        }

        public void DisplayingGrades(int studentId)
        {
            //spaces
            StringBuilder sb = new StringBuilder();
            int nbOfSpaces = 14 - studentId.ToString().Length;
            int nbOfSpacesBefore = nbOfSpaces / 2;
            int nbOfSpacesAfter = nbOfSpaces - nbOfSpacesBefore;
            sb.Append(new string(' ', nbOfSpacesBefore) + studentId + new string(' ', nbOfSpacesAfter) + "|");

            nbOfSpaces = 14 - (CalculateAverage(studentScores[studentId])).ToString().Length;
            sb.Append(new string(' ', nbOfSpacesBefore) + CalculateAverage(studentScores[studentId]).ToString("0.00") + new string(' ', nbOfSpacesAfter) + "|");

            nbOfSpaces = 14 - (CalculateGPA(studentScores[studentId])).ToString().Length;
            sb.Append(new string(' ', nbOfSpacesBefore) + CalculateGPA(studentScores[studentId]).ToString("0.00") + new string(' ', nbOfSpacesAfter) + "|");

            nbOfSpaces = 14 - (CalculateRScore(studentIRGs[studentId], zScores[studentId])).ToString().Length;
            sb.Append(new string(' ', nbOfSpacesBefore) + CalculateRScore(studentIRGs[studentId], zScores[studentId]).ToString("0.00") + new string(' ', nbOfSpacesAfter) + "|");

            Console.WriteLine(sb.ToString());

        }
    }
}
