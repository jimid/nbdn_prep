using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class DescendingComparer<ItemToSort> : IComparer<ItemToSort>
    {
        private IComparer<ItemToSort> inner;

        public DescendingComparer(IComparer<ItemToSort> inner)
        {
            this.inner = inner;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return 0 - inner.Compare(x, y);
        }
    }
}