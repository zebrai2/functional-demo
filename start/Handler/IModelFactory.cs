namespace demo
{
    public interface IModelFactory<TModel>
    {
        TModel CreateNew();
    }
}