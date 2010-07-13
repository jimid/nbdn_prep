using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class PropertyComparer<ItemToSort, PropertyType> : IComparer<ItemToSort> where PropertyType : IComparable<PropertyType>
    {
        private readonly Func<ItemToSort, PropertyType> accessor;

        public PropertyComparer(Func<ItemToSort, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            var valX = accessor(x);
            var valY = accessor(y);
            return valX.CompareTo(valY);
        }
    }

    public class ListComparer<ItemToSort, PropertyType> : IComparer<ItemToSort>
    {
        private readonly Func<ItemToSort, PropertyType> accessor;
        private readonly IList<PropertyType> sortList;

        public ListComparer(Func<ItemToSort, PropertyType> accessor, params PropertyType[] sortList)
        {
            this.accessor = accessor;
            this.sortList = new List<PropertyType>(sortList);
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            var indexX = sortList.IndexOf(accessor(x));
            var indexY = sortList.IndexOf(accessor(y));
            return indexX.CompareTo(indexY);
        }
    }
}