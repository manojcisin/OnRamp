using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.BusinessLayer {
	public class Mapper<TSource, TDestination> {
		public virtual TDestination MapTo(TSource source) {

			var destination = Mapper.Map<TDestination>(source);
			return destination;
		}

		public virtual TSource MapFrom(TDestination destination) {
			var source = Mapper.Map<TSource>(destination);
			return source;
		}


	}

	public static class MapperExtensions {
		public static void MapTo<TSource, TDestination>(this TSource source, TDestination destination)
			where TSource : class, new() {
			Mapper.Map(source, destination);
		}

		public static TSource MapFrom<TDestination, TSource>(this TSource source, TDestination destination)
			where TSource : class, new() {
			var mapper = new Mapper<TSource, TDestination>();
			return mapper.MapFrom(destination);
		}
		public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression) {
			var sourceType = typeof(TSource);
			var destinationType = typeof(TDestination);
			var existingMaps = Mapper.GetAllTypeMaps().First(x => x.SourceType.Equals(sourceType)
				&& x.DestinationType.Equals(destinationType));
			foreach (var property in existingMaps.GetUnmappedPropertyNames()) {
				expression.ForMember(property, opt => opt.Ignore());
			}
			return expression;
		}
	}
}
