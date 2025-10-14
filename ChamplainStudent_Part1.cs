using System;
using System.Text;

namespace MainLab4Andre
{
    partial class ChamplainStudent_Part1 : Person
    {

        StringBuilder sb = new StringBuilder();

        public void addingContent(string[] items)
        {
            foreach (string item in items)
            {
                int nbOfSpaces = 14 - item.Length;
                int nbOfSpacesBefore = nbOfSpaces / 2;
                int nbOfSpacesAfter = nbOfSpaces - nbOfSpacesBefore;
                sb.Append(new string(' ', nbOfSpacesBefore) + item + new string(' ', nbOfSpacesAfter) + "|");
            }
            sb.Append("\n");
        }
        override public void DisplayInfo()
        {
            Console.WriteLine(sb.ToString());
        }
        
        }
    }
