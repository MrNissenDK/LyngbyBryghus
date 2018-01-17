using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Factories
{
    public class Share
    {
        public static Object SetValue(object Model,object toModel )
        {
            var props = Model.GetType().GetProperties();
            var pOProps = toModel.GetType();
            foreach (var prop in props)
            {
                string name = prop.Name;
                Type type = prop.PropertyType;
                var value = prop.GetValue(Model);
                toModel.GetType().GetProperty(name).SetValue(toModel, value);
            }
            return toModel;
        }
    }
}
