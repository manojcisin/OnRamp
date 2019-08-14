using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.BusinessLayer {
	public static class AutoMapperHelper {
		/// <summary>
		/// Ignores properties that are not already mapped in the IMappingExpression passed to this method
		/// </summary>
		/// <param name="expression">IMappingExpression with the properties that you want mapped already configured</param>
		public static IMappingExpression<TSource, TDestination> IgnoreUnmappedProperties<TSource, TDestination>(
			this IMappingExpression<TSource, TDestination> expression) {

			var existingMaps = Mapper.GetAllTypeMaps().First(x => x.SourceType == typeof(TSource)
																  && x.DestinationType == typeof(TDestination));
			foreach (var property in existingMaps.GetUnmappedPropertyNames()) {
				expression.ForMember(property, opt => opt.Ignore());
			}

			return expression;
		}

		public static void CreateMapping<TModel, TRequestModel>() {
			Mapper.CreateMap<TModel, TRequestModel>().IgnoreUnmappedProperties();
			Mapper.CreateMap<TRequestModel, TModel>().IgnoreUnmappedProperties();
		}

		public static void CreateMapping<TDto, TViewModel>(out IMappingExpression<TDto, TViewModel> fromExpression, out IMappingExpression<TViewModel, TDto> toExpression) {
			fromExpression = Mapper.CreateMap<TDto, TViewModel>().IgnoreUnmappedProperties();
			toExpression = Mapper.CreateMap<TViewModel, TDto>().IgnoreUnmappedProperties();
		}

	}
}
