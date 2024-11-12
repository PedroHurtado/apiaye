namespace webapi.core{
    public static class ExtensionIEnumerable{
        public static T OrElseThrow<T>(this IEnumerable<T> items, Exception ex){
            var entity = items.FirstOrDefault();
            if(entity == null){
                throw ex;
            }
            return entity;
        }
    }
}