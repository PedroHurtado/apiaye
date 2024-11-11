namespace webapi.core{
    public class EntityBase{
        public Guid Id {get; init;}
        protected EntityBase(Guid id){
            Id = id;
        }
        public override bool Equals(object? obj)
        {
            if(obj is EntityBase e){
                return e.Id.Equals(Id);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}