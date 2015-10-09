using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace T1_Numbers
{
    class Program
    {
        private static Stopwatch clock;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("What is the numeric base you want to use:");
                var command = Console.ReadLine();
                if (command.Equals("exit"))
                    break;
                var numberBase = int.Parse(command);
                Console.WriteLine("Use parallel search: (Y/N)");
                var parallelAnswer = Console.ReadLine();
                Console.WriteLine(string.Empty);

                clock = new Stopwatch();

                Console.WriteLine("Searching for matching numbers...");

                var startNumber = new BasedNumber("0", numberBase);
                var endNumber = BasedNumber.GetMaxNumber(numberBase);

                clock.Start();

                var cancellationClockTaskToken = new CancellationTokenSource();
                var clockTask = Task.Factory.StartNew(() => DisplayTimer(), cancellationClockTaskToken.Token);

                var result = new SearchResults();
                if (parallelAnswer.Equals("Y"))
                {
                    result = SearchParallel(startNumber, endNumber);
                }
                else
                {
                    result = SearchSingleCore(startNumber, endNumber);
                }

                cancellationClockTaskToken.Cancel();
                cancellationClockTaskToken.Dispose();
                clock.Stop();

                Console.WriteLine(string.Empty);
                Console.WriteLine(string.Format("Numbers with duplicated digit: {0}", result.NumbersWithDuplicatedDigit));
                Console.WriteLine(string.Format("Numbers with no duplicated digit: {0}", result.NumbersWithNoDuplicatedDigit));
                Console.WriteLine(string.Format("Evaluated numbers: {0}", result.TotalNumbers));
                Console.WriteLine("Press any key to star over again...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static SearchResults SearchSingleCore(BasedNumber startNumber, BasedNumber endNumber)
        {
            var search = new Search();
            return search.StartSearch(startNumber, endNumber);
        }

        static SearchResults SearchParallel(BasedNumber startNumber, BasedNumber endNumber)
        {
            var maxValue = endNumber.ToDecimal();
            var amountByTask = (long)Math.Truncate((double)maxValue / 4);

            var eDecimalValue = startNumber.ToDecimal() + amountByTask;
            var eNumber1 = BasedNumber.Parse(eDecimalValue, startNumber.Base);
            var search1 = new Search();
            Task<SearchResults> thread1 = Task.Factory.StartNew(() => search1.StartSearch(startNumber, eNumber1));

            var sNumber1 = eNumber1 + 1;
            eDecimalValue = sNumber1.ToDecimal() + amountByTask;
            var eNumber2 = BasedNumber.Parse(eDecimalValue, startNumber.Base);
            var search2 = new Search();
            Task<SearchResults> thread2 = Task.Factory.StartNew(() => search2.StartSearch(sNumber1, eNumber2));

            var sNumber2 = eNumber2 + 1;
            eDecimalValue = sNumber2.ToDecimal() + amountByTask;
            var eNumber3 = BasedNumber.Parse(eDecimalValue, startNumber.Base);
            var search3 = new Search();
            Task<SearchResults> thread3 = Task.Factory.StartNew(() => search3.StartSearch(sNumber2, eNumber3));

            var sNumber3 = eNumber3 + 1;
            var search4 = new Search();
            Task<SearchResults> thread4 = Task.Factory.StartNew(() => search4.StartSearch(sNumber3, endNumber));

            Task.WaitAll(thread1, thread2, thread3, thread4);
            var result1 = thread1.Result;
            var result2 = thread2.Result;
            var result3 = thread3.Result;
            var result4 = thread4.Result;

            var result = new SearchResults();
            result.NumbersWithDuplicatedDigit = result1.NumbersWithDuplicatedDigit +
                                                result2.NumbersWithDuplicatedDigit +
                                                result3.NumbersWithDuplicatedDigit +
                                                result4.NumbersWithDuplicatedDigit;
            result.NumbersWithNoDuplicatedDigit = result1.NumbersWithNoDuplicatedDigit +
                                                  result2.NumbersWithNoDuplicatedDigit +
                                                  result3.NumbersWithNoDuplicatedDigit +
                                                  result4.NumbersWithNoDuplicatedDigit;
            result.TotalNumbers = result1.TotalNumbers +
                                  result2.TotalNumbers +
                                  result3.TotalNumbers +
                                  result4.TotalNumbers;
            return result;
        }

        static void DisplayTimer()
        {
            while (clock.IsRunning)
            {   
                Console.Write(string.Format("\r{0} milliseconds", clock.ElapsedMilliseconds));
            }
        }
    }
}
