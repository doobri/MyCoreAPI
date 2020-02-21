using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPI
{
    public class MyTypeInfo
    {
        public int TypeSize { get; set; }

        public string TypeName { get; set; }

        public string TypeDescription { get; set; }

        public MyTypeInfo(int typeSize, string typeName, string typeDescription)
        {
            TypeSize = typeSize;
            TypeName = typeName;
            TypeDescription = typeDescription;
        }

        public override string ToString()
        {
            return $"{nameof(TypeName)}: {TypeName}{Environment.NewLine}" +
                    $"{nameof(TypeDescription)}: {TypeDescription}{Environment.NewLine}" +
                     $"{nameof(TypeSize)}: {TypeSize}{Environment.NewLine}";
        }
    }
}
