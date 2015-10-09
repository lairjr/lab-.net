using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Numbers
{
    public class Search
    {
        public SearchResults StartSearch(BasedNumber startNumber, BasedNumber endNumber)
        {
            var searchResults = new SearchResults();
            for (var number = startNumber; number <= endNumber; number++)
            {
                searchResults.TotalNumbers++;
                if (BasedNumberVerifier.HasSequentialSumMoreThen(number, 2))
                {
                    searchResults.NumbersWithDuplicatedDigit++;
                    if (!BasedNumberVerifier.HasDuplicate(number))
                    {
                        searchResults.NumbersWithNoDuplicatedDigit++;
                    }
                }
            }
            return searchResults;
        }
    }
}
