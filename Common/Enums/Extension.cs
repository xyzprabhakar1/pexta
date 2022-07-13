using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public static class EnmDescription
    {
        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }
            return null; // could also return string.Empty
        }

        public static Document GetDocumentDetails(this enmDocumentMaster e)
        {
            var type = e.GetType();
            var name = Enum.GetName(type, e);
            var returnData = (Document)type.GetField(name).GetCustomAttributes(typeof(Document), false).FirstOrDefault();
            returnData.Id = (int)e;
            return returnData;
        }

        public static Module GetModuleDetails(this enmModule e)
        {
            var type = e.GetType();
            var name = Enum.GetName(type, e);
            var returnData = (Module)type.GetField(name).GetCustomAttributes(typeof(Module), false).FirstOrDefault();
            returnData.Id = (int)e;
            return returnData;
        }

        public static SubModule GetSubModuleDetails(this enmSubModule e)
        {
            var type = e.GetType();
            var name = Enum.GetName(type, e);
            var returnData = (SubModule)type.GetField(name).GetCustomAttributes(typeof(SubModule), false).FirstOrDefault();
            returnData.Id = (int)e;
            return returnData;
        }

        public static Application GetApplicationDetails(this enmApplication e)
        {
            var type = e.GetType();
            var name = Enum.GetName(type, e);
            var returnData = (Application)type.GetField(name).GetCustomAttributes(typeof(Application), false).FirstOrDefault();
            returnData.Id = (int)e;
            return returnData;
        }
    }
}
