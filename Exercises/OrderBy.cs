﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public static class OrderBy
    {
        //Coding Exercise 1
        /*
         Using LINQ, implement the OrderFromLongestToShortest method, which takes 
        a collection of strings, and returns those strings ordered from 
        longest to shortest.
        For example, for {"bb", "a", "ccc"} the result should be {"ccc", "bb", "a"}
         */
        public static IEnumerable<string> OrderFromLongestToShortest(
            IEnumerable<string> words)
        {
            return words.OrderByDescending(s =>s.Length);
        }

        //Coding Exercise 2
        /*
         Using LINQ, implement the FirstEvenThenOddDescending method, 
         which orders numbers like this:
            *first, the even numbers
            *then, the odd numbers
         Then the numbers should be ordered descending. 
         For example, for numbers {1,2,3,4,5,6,7} the result should be: {6,4,2,7,5,3,1}.
         1 3 5 7
         */
        public static IEnumerable<int> FirstEvenThenOddDescending(
            IEnumerable<int> numbers)
        {
           return numbers.OrderBy(number => number % 2 != 0).ThenByDescending(number => number);
        }

        public static IEnumerable<DateTime> OrderByMonth_Refactored(List<DateTime> dates)
        {
            return dates.OrderBy(date => date.Month);
        }

        //do not modify this method
        public static IEnumerable<DateTime> OrderByMonth(List<DateTime> dates)
        {
            dates.Sort((left, right) =>
            {
                return left.Month.CompareTo(right.Month);
            });
            return dates;
        }
    }
}
