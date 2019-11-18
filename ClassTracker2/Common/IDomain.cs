namespace Common
{
    public interface IDomain
    {
        //Result StartGetById(object key);
    }

    public interface IDomain<TKey, TDto> : IDomain
    {
         public IResult GetById(TKey key);
    }
}
