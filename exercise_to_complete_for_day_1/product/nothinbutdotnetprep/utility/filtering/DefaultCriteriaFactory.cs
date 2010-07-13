﻿using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class Not<ItemToFilter,PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public Not(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }   

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(
                accessor, new IsNotEqualTo<PropertyType>(value));
        }
    }
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public DefaultCriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }
        
        public Not<ItemToFilter,PropertyType> not
        {
            get { return new Not<ItemToFilter, PropertyType>(accessor); }
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

        public Criteria<ItemToFilter> not_equal_to(PropertyType value)
        {
            return new NotCriteria<ItemToFilter>(equal_to(value));
        }

    }
}