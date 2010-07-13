using System;
using System.Collections.Generic;
using nothinbutdotnetprep.utility.filtering;
using nothinbutdotnetprep.utility.sorting;

namespace nothinbutdotnetprep.utility
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }

        static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Predicate<T> criteria)
        {
            foreach (var item in items) if (criteria(item)) yield return item;
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Criteria<T> criteria)
        {
            return all_items_matching(items, criteria.is_satisfied_by);
        }

        public static IEnumerable<T> sort_all_using<T>(this IEnumerable<T> items, IComparer<T> comparer)
        {
            var list = new List<T>(items);
            list.Sort(comparer);
            return list.one_at_a_time();
        }

        public static ComparableEnumerable<T> sort_by<T, PropertyType>(this IEnumerable<T> items, Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparableEnumerable<T>(items, new ComparerBuilder<T>(
                                                          new PropertyComparer<T, PropertyType>(accessor, new ComparableComparer<PropertyType>())));
        }

        public static ComparableEnumerable<T> sort_by<T, PropertyType>(this IEnumerable<T> items, Func<T, PropertyType> accessor, SortDirection direction)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparableEnumerable<T>(items,
                );
        }
    }
}