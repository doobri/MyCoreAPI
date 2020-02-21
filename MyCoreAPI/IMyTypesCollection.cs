namespace MyCoreAPI
{
    public interface IMyTypesCollection
    {
		void AddType(MyTypeInfo typeInfo);

        MyTypeInfo FindType(string typeName);

        bool RemoveType(string typeName);

        bool UpdateType(MyTypeInfo newType);
    }
}