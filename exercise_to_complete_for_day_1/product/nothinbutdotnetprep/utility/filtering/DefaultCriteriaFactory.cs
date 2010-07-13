﻿using System;

namespace nothinbutdotnetprep.utility.filtering
{
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public DefaultCriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public NotCriteriaFactory<ItemToFilter, PropertyType> not
        {
            get { return new NotCriteriaFactory<ItemToFilter, PropertyType>(this); }
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] values)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(
                accessor, new IsEqualToAny<PropertyType>(values));
        }

    }
}