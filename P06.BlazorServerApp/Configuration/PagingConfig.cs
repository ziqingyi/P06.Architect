using System;

namespace P06.BlazorServerApp.Configuration
{
    public class PagingConfig
    {
        public bool Enabled { get; set; } = false;

        public int PageSize
        {
            get
            {
                return this.PageSize;
            }
            set
            {
                if (value <= 0)
                    this.PageSize = 0;
                else
                    PageSize = value;
            }

        }
        public int NumOfItemsToSkip(int pageNumber)
        {
            if(Enabled)
            {
                return (pageNumber - 1) * PageSize;
            }
            return 0;
        }

        public int NumOfItemsToTake(int totalItemsCount)
        {
            if (Enabled)
            {
                return PageSize;
            }
            return totalItemsCount;
        }

        public int PrevPageNumber(int currentPageNumber)
        {
            if (currentPageNumber > 1)
                return currentPageNumber - 1;
            else
                return 1;
        }

        public int NextPageNumber(int currentPageNumber, int totoalItemsCount)
        {
            if(currentPageNumber > MaxPageNumber(totoalItemsCount))
            {
                return currentPageNumber + 1;
            }
            else
            {
                return currentPageNumber;
            }

        }
        //calculate the max page number based on total items count and page per size. 
        public int MaxPageNumber(int totoalItemsCount)
        {
            int maxPageNumber = 0;

            double numberOfPages = (double)(totoalItemsCount / PageSize);
            if(numberOfPages == Math.Floor(numberOfPages))
            {
                maxPageNumber = (int)numberOfPages;
            }
            else
            {
                maxPageNumber = (int)numberOfPages + 1;
            }
            return maxPageNumber;
        }

    }
}
