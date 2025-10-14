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

        public int[] ids = { 1001, 1002, 1003, 1004, 1005 };

        public Dictionary<int, int> nbOfScores = new Dictionary<int, int>{
            {1001,0},
            {1002,0 },
            {1003,0 },
            {1004,0 },
            {1005,0 }
        };

        public Dictionary<int, int> nbOfIRGs = new Dictionary<int, int>{
            {1001,0},
            {1002,0 },
            {1003,0 },
            {1004,0 },
            {1005,0 }
        };

        public Dictionary<int, List<double>> studentScores = new Dictionary<int, List<double>>();
        public Dictionary<int, List<double>> studentIRGs = new Dictionary<int, List<double>>();


        public double[] zScores = new double[5];
        public Dictionary<int, double> zScoresForStudent;

        public ChamplainStudent_Part2()
        {
            zScoresForStudent = new Dictionary<int, double>
    {
        { 1001, zScores[0] },
        { 1002, zScores[1] },
        { 1003, zScores[2] },
        { 1004, zScores[3] },
        { 1005, zScores[4] }
    };
        }

        public void DisplayingGradesCategories()
        {
            Console.WriteLine("ID|Avg|GPA|R_score|");
        }

        public void DisplayingGrades(int studentId)
        {
            Console.WriteLine(studentId + "|" + CalculateAverage(studentScores[studentId]) + "|" + CalculateGPA(studentScores[studentId]) + "|" + CalculateRScore(studentIRGs[studentId], zScoresForStudent[studentId]));
        }
    }
}
