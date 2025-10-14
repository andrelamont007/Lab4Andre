using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLab4Andre
{
    interface IGrading
    {
        double CalculateAverage(List<double> scores);
        double CalculateGPA(List<double> scores);

        double CalculateRScore(List<double> IRGs, double Z);
    }
}
