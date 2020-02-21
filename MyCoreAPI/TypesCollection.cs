using System;
using System.Collections.Generic;

namespace MyCoreAPI
{
    public class TypesCollection : IMyTypesCollection
    {
        List<MyTypeInfo> MyTypes = new List<MyTypeInfo>
        {
            new MyTypeInfo(1, "bool", "C# bool type maps to .NET type System.Boolean. Has values true and false." ),
            new MyTypeInfo(1, "sbyte", "sbyte, signed byte, maps to .NET type System.SByte. Has values from -128 to 127." ),
            new MyTypeInfo(2, "short", "short type maps to .NET type System.Short. Has values from -32,768 to 32,767." ),
            new MyTypeInfo(4, "uint", "C# uint type maps to .NET type System.UInt32. Has values ranging from 0 to 4,294,967,295." ),
        };

        public void AddType(MyTypeInfo typeInfo) => MyTypes.Add(typeInfo);

        public MyTypeInfo FindType(string typeName) => MyTypes.Find(ty => ty.TypeName.Equals(typeName, StringComparison.OrdinalIgnoreCase));

        public bool RemoveType(string typeName)
        {
            bool ok = false;

            MyTypeInfo type = FindType(typeName);

            if (type != null)
            {
                MyTypes.Remove(type);
                ok = true;
            }

            return ok;
        }

        public bool UpdateType(MyTypeInfo newType)
        {
            bool ok = false;

            int pos = MyTypes.FindIndex(ty => ty.TypeName.Equals(newType.TypeName, StringComparison.OrdinalIgnoreCase));
            if (pos >= 0)
            {
                MyTypes[pos] = newType;
                ok = true;
            }

            return ok;
        }

        public TypesCollection()
        {
        }
    }
}