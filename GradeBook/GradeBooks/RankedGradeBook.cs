﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {


            if (Students.Count > 4)
            {
                List<double> sortedGrades = getSortedGrades();
                var n = Convert.ToInt32(Math.Round(sortedGrades.Count * 0.2)) - 1;

                if (averageGrade >= sortedGrades[n])
                    return 'A';
                else if (averageGrade >= sortedGrades[n + 1])
                    return 'B';
                else if (averageGrade >= sortedGrades[n + 2])
                    return 'C';
                else if (averageGrade >= sortedGrades[n + 3])
                    return 'D';
                else
                    return 'F';
            }
            else
            {
                throw new InvalidOperationException();
            }

        }
        public override void CalculateStatistics()
        {
            if (Students.Count >= 5)
            {
                base.CalculateStatistics();
            }
            else
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades " +
                    "in order to properly calculate a student's overall grade.");
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count >= 5)
            {
                base.CalculateStudentStatistics(name);
            }
            else
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades " +
                    "in order to properly calculate a student's overall grade.");
            }
        }

        private List<double> getSortedGrades()
        {
            List<double> grades = new List<double>();
            if (Students.Count > 0)
            {
                foreach (var student in Students)
                {
                    grades.Add(student.AverageGrade);
                }
                grades = grades.OrderByDescending(o => o).ToList();
            }

            return grades;

        }
    }
}
