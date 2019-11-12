namespace Common
{
    public interface IDomain
    {
        //Result StartGetById(object key);
        public IResult GetById(int key);
    }

    public interface IDomain<TKey, TDto> : IDomain
    {
        //Result<TKey,TDto> ValidateKey(Result<TKey, TDto> result);
        //   Result<TDto, TOut> Validate(Result<TDto, TOut> result);
    }
}
