using System;

namespace P06.BlazorServerApp.Configuration
{
    public class PagingConfig
    {
        public bool Enabled { get; set; } = false;

        private int _pageSize = 10000;
        public int PageSize
        {
            get
            {
                return this._pageSize;
            }
            set
            {
                if (value <= 0)
                    _pageSize = 10000;
                else
                    _pageSize = value;
            }
        } 

        public bool CustomPager { get; set; } = false;


        public int MaxPageNumber { get; }

        public PagingConfig(int totoalItemsCount, int pagesize, bool enable, bool customerpager)
        {
            this.PageSize = pagesize;
            this.Enabled = enable;
            this.CustomPager = customerpager;
            MaxPageNumber = CalculateMaxPageNumber(totoalItemsCount);
        }

        public int NumOfItemsToSkip(int pageNumber)
        {
            if(Enabled && pageNumber >1  )
            {
                 if(pageNumber <= MaxPageNumber)
                {
                    return (pageNumber - 1) * PageSize;
                }
                else
                {
                    return (MaxPageNumber - 1) * PageSize;
                }             
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
            if (currentPageNumber > 1 && Enabled)
                return currentPageNumber - 1;
            else
                return 1;
        }

        public int NextPageNumber(int currentPageNumber)
        {
            if (Enabled == false)
                return 1;

            if(currentPageNumber < MaxPageNumber)
            {
                return currentPageNumber + 1;
            }
            else
            {
                return MaxPageNumber;
            }

        }
        //calculate the max page number based on total items count and page per size. 
        private int CalculateMaxPageNumber(int totoalItemsCount)
        {
            int maxPageNumber = 0;

            double numberOfPages = (double)totoalItemsCount / PageSize;
            if(numberOfPages == Math.Floor(numberOfPages) &&  numberOfPages>0)
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
