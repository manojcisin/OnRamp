using AutoMapper;

namespace Volt.Web.Dashboard.Mappers
{
    public class Mapper<TModel, TViewModel> : Common.Mapper<TModel, TViewModel>
    {
        public virtual TModel ToModel(TViewModel viewModel)
        {
            return base.MapFrom(viewModel);
        }

        public virtual TViewModel FromModel(TModel model)
        {
            return base.MapTo(model);
        }
    }

    public static class MapperExtensions
    {
        public static void ToModel<TViewModel, TModel>(this TViewModel viewModel, TModel model)
            where TViewModel : class, new()
        {
            Mapper.Map(viewModel, model);
        }

        public static TViewModel FromModel<TViewModel, TModel>(this TViewModel viewModel, TModel model)
            where TViewModel : class, new()
        {
            var mapper = new Mapper<TModel, TViewModel>();
            return mapper.FromModel(model);
        }
    }
}