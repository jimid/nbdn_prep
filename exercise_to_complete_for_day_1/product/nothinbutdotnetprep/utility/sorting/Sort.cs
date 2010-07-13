using System;

namespace nothinbutdotnetprep.utility.sorting
{
    public class Sort<ItemToSort>
    {
        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor));
        }

        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor, params PropertyType[] sortList)
        {
            return new ComparerBuilder<ItemToSort>(new ListComparer<ItemToSort, PropertyType>(accessor, sortList));
        }

        public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new ReverseComparer<ItemToSort>(by(accessor)));
        }
    }
}