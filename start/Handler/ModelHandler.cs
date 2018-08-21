using System;

namespace demo
{
    public class ModelHandler<TModel>
    {
        private readonly IRepository<TModel> _repository;
        private readonly IModelFactory<TModel> _modelFactory;

        public ModelHandler(IRepository<TModel> repository, IModelFactory<TModel> modelFactory)
        {
            _repository = repository;
            _modelFactory = modelFactory;
        }

        public void Handle (Guid id)
        {
            TModel model;

            try
            {
                model = _repository.Fetch(id);
            }
            catch (ModelNotFoundException)
            {
                model = _modelFactory.CreateNew();
            }

            DoSomething (model);

            _repository.Save(id, model);
        }

        public void DoSomething (TModel model)
        {

        }
    }
}