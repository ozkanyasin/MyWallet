using System.Reflection;

namespace MyWallet
{
    public static class ModelToDTOHelper
    {
        public static TResult ModelToDTO<T, TResult>(T model) where TResult :class, new()
        {   
            TResult result = new TResult();
            typeof(T).GetProperties().ToList().ForEach(p =>{
                PropertyInfo property = typeof(TResult).GetProperty(p.Name);
                property.SetValue(result, p.GetValue(model));
            });
            return result;
        }

    }
}