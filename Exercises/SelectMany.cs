﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public static class SelectMany
    {
        //Coding Exercise 1
        /*
        Implement the BuildCartesianProduct method, which given a collection of unique 
        numbers will return the Cartesian product for those numbers as strings.

        For example, for input {1,2,5} the result shall be 
            {"1,1", "1,2", "1,5", "2,1", "2,2", "2,5", "5,1", "5,2", "5,5" }
         */
        public static IEnumerable<string> BuildCartesianProduct(
            HashSet<int> numbers)
        {
            return numbers.SelectMany(_ => numbers, (number1, number2) => $"{number1},{number2}");
        }

        //Coding Exercise 2
        /*
        Imagine you work on a website of a school. On the top of the page, there is 
        a "Hall of fame" panel, with the top 5 marks in the school together with 
        the name of the student who earned this mark.

        Implement the BestMarksAndStudents method, which given a collection of students
        will return a collection of strings with the student's name and the mark. 
        We want to select the top 5 marks in the entire school. 
        Even if a single student has the 5 best marks in the whole school, 
        she should occupy all 5 places in this list.
        
        Let's see an example. For the following students:
            *Lucy has marks {3, 6, 2, 6}
            *Tom has marks {4, 5}
            *Alice has marks {3, 3, 5}
            *Brian has marks {2, 3, 3}
        
        ...the result shall be: 
            *"Lucy: 6"
            *"Lucy: 6"
            *"Alice: 5"
            *"Tom: 5"
            *"Tom: 4"
        
        We order the result from the best mark to the worst. 
        If two students have the same mark (in this case Alice and Tom have a mark of 5)
        we should sort them in alphabetical order by student's name.
         */
        public static IEnumerable<string> BestMarksAndStudents(
            IEnumerable<Student> students)
        {
            throw new NotImplementedException();

        }

        //Refactoring challenge
        //TODO implement this method
        public static Dictionary<string, double> SegmentsLengths_Refactored(
            IEnumerable<Point> starts, IEnumerable<Point> ends)
        {
            return starts.SelectMany(_ => ends,
                (start, end) => new
                {
                    Start = start,
                    End = end,
                    Length = SegmentLength(start, end)
                }).ToDictionary(
                segmentData =>
                    $"Start: ({segmentData.Start})," +
                    $"End: ({segmentData.End})",
                segmentData => segmentData.Length);
        }

        //do not modify this method
        public static Dictionary<string, double> SegmentsLengths(
            IEnumerable<Point> starts, IEnumerable<Point> ends)
        {
            var result = new Dictionary<string, double>();
            foreach (var startPoint in starts)
            {
                foreach (var endPoint in ends)
                {
                    var length = SegmentLength(startPoint, endPoint);
                    var key = $"Start: ({startPoint}), End: ({endPoint})";
                    result[key] = length;
                }
            }
            return result;
        }

        public static double SegmentLength(Point start, Point end)
        {
            return Math.Sqrt((Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2)));
        }

        public class Student
        {
            public string Name { get; set; }
            public IEnumerable<int> Marks { get; set; }

            public override string ToString()
            {
                return $"{Name} with marks ({string.Join(",", Marks)})";
            }
        }

        public struct Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public override string ToString()
            {
                return $"X: {X}, Y: {Y}";
            }
        }
    }
}
