using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Bugtracker.Helpers
{
    public static class ModelHelpers
    {
        public static string GetDisplayName(Type type, PropertyInfo info, bool hasMetaDataAttribute)
        {
            if (!hasMetaDataAttribute)
            {
                object[] attributes = info.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                if(attributes != null && attributes.Length > 0)
                {
                    DisplayNameAttribute displayName = (DisplayNameAttribute)attributes[0];
                    return displayName.DisplayName;
                }
                return info.Name;
            }
            PropertyDescriptor propDesc = TypeDescriptor.GetProperties(type).Find(info.Name, true);
            DisplayNameAttribute displayAttribute = propDesc.Attributes.OfType<DisplayNameAttribute>().FirstOrDefault();
            return displayAttribute != null ? displayAttribute.DisplayName : null;
        }
    }
}