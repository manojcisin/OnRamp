using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.DataLayer {
	public interface IRepository<T> : IDisposable where T : class {
		IEnumerable<T> Get();

		T FindById(int id);

		IEnumerable<T> Find(Expression<Func<T, bool>> searchExpression);

		IEnumerable<T> Find<TOrderByKey>(Expression<Func<T, bool>> searchExpression, int pageIndex, int pageSize,
												Expression<Func<T, TOrderByKey>> orderby, out int totalResults, bool descending = false);

		void Delete(T entity);

		void Add(T entity);

		/// <summary>
		/// Adds an existising entity and makes it ready to start updating
		/// </summary>
		/// <param name="entity"></param>
		void Update(T entity);
		void Detach(T OldentityToDetach);
		void Attach(T NewEntityToAttach);
		void Save();
	}
}
