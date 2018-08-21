using Handler.Functional;
using System;

namespace demo
{
    public class ModelHandler<TModel>
    {
        private readonly (Func<Guid, Either<IError, TModel>> Fetch, Func<Guid, TModel, Option<IError>> Save) _repository;
        private readonly Func<TModel> WithNewInstance;

        public ModelHandler((Func<Guid, Either<IError, TModel>> Fetch, Func<Guid, TModel, Option<IError>> Save) repository, 
                            Func<TModel> fnNewInstance)
        {
            _repository = repository;
            WithNewInstance = fnNewInstance;
        }

        public Either<IError, Success> Handle (Guid id)
         => _repository.Fetch(id)
                .Reduce(WithNewInstance, WithModelNotFound)
                .Map(DoSomething)
                .Switch(SaveModel(id))
                .Map(Success);
        

        private static Success Success(TModel model)
         => new Success();

        private Func<TModel, Option<IError>> SaveModel(Guid id)
         => (m) => _repository.Save(id, m);

        private static bool WithModelNotFound(IError error)
         => error is ModelNotFound;

        private TModel DoSomething (TModel model) 
            => model;
    }
}