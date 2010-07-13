using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class Sort<ItemToSort> : IComparer<ItemToSort>
    {
        private IComparer<ItemToSort> inner;

        public Sort(IComparer<ItemToSort> inner)
        {
            this.inner = inner;
        }

        public static Sort<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new Sort<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor));
        }

        public static Sort<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor, params PropertyType[] sortList)
        {
            return new Sort<ItemToSort>(new ListComparer<ItemToSort, PropertyType>(accessor, sortList));
        }

        public static Sort<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new Sort<ItemToSort>(new DescendingComparer<ItemToSort>(by(accessor)));
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return inner.Compare(x, y);
        }

        public Sort<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new Sort<ItemToSort>(new ChainedComparer<ItemToSort>(inner, by(accessor)));
        }

        public Sort<ItemToSort> then_by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new Sort<ItemToSort>(new ChainedComparer<ItemToSort>(inner, by_descending(accessor)));
        }
    }
}