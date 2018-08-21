using System;

namespace demo
{
    public interface IRepository<TModel>
    {
        TModel Fetch(Guid id);
        void Save(Guid id, TModel model);
    }
}