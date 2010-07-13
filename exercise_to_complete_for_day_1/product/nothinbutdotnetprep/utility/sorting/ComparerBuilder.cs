using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ComparerBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        IComparer<ItemToSort> original_comparer;

        public ComparerBuilder(IComparer<ItemToSort> original_comparer)
        {
            this.original_comparer = original_comparer;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return original_comparer.Compare(x, y);
        }

        public ComparerBuilder<ItemToSort> then_by<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return then_using(new PropertyComparer<ItemToSort, PropertyType>(accessor));
        }

        public ComparerBuilder<ItemToSort> then_by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return then_using(new PropertyComparer<ItemToSort, PropertyType>(accessor).reverse());
        }

        ComparerBuilder<ItemToSort> then_using(IComparer<ItemToSort> next_comparer)
        {
            return new ComparerBuilder<ItemToSort>(original_comparer.then_using(next_comparer));
        }
    }
}