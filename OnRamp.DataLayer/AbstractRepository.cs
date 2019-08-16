using OnRamp.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnRamp.DataLayer {
	public class AbstractRepository<T> : IRepository<T> where T : class {
		private onrampEntities context;

		private bool isDisposed;

		protected AbstractRepository() {
			context = new onrampEntities();
			context.Configuration.ProxyCreationEnabled = false;
			//context.Configuration.LazyLoadingEnabled = false;
		}
		protected virtual onrampEntities Context
		{
			
			get { return context; }
			set { context = value; }
		}

		public virtual T FindById(int id) {
			return context.Set<T>().Find(id);
		}

		public virtual IEnumerable<T> Get() {
			return context.Set<T>().ToList();
		}
		public virtual IEnumerable<T> Find(Expression<Func<T, bool>> searchExpression) {
			return context.Set<T>().Where(searchExpression);
		}

		public IEnumerable<T> Find<TOrderByKey>(Expression<Func<T, bool>> searchExpression, int pageIndex, int pageSize,
												Expression<Func<T, TOrderByKey>> orderby, out int totalResults, bool descending = false) {
			IQueryable<T> results = context.Set<T>().Where(searchExpression);
			totalResults = results.Count();

			if (descending) return results.OrderByDescending(orderby).Skip((pageIndex - 1) * pageSize).Take(pageSize);

			return results.OrderBy(orderby).Skip((pageIndex - 1) * pageSize).Take(pageSize);
		}


		public virtual void Delete(T entity) {
			context.Set<T>().Remove(entity);
		}


		public virtual void Add(T entity) {
			try {

				context.Set<T>().Add(entity);

			}
			catch (System.Data.Entity.Validation.DbEntityValidationException ex) {

				foreach (var error in ex.EntityValidationErrors) {

					foreach (var validationError in error.ValidationErrors) {

						System.Diagnostics.Trace.TraceWarning(string.Format("{0}, {1}", validationError.PropertyName, validationError.ErrorMessage));
					}
				}
				throw;
			}

		}
		public virtual void Detach(T OldentityToDetach) {
			Context.Entry<T>(OldentityToDetach).State = EntityState.Detached;
		}
		public virtual void Attach(T NewEntityToAttach) {
			if (Context.Entry<T>(NewEntityToAttach).State == EntityState.Detached)
				Context.Set<T>().Attach(NewEntityToAttach);
		}
		public virtual void Update(T entity) {
			context.Entry(entity).State = EntityState.Modified;
		}


		public virtual void Save() {
			try {
				context.SaveChanges();

			}
			catch (Exception ex) {
				HandleException(ex);

			}
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool isDisposing) {
			if (!isDisposed) {
				isDisposed = true;
				if (isDisposing) {
					if (context != null) context.Dispose();
				}
				// Dispose unmanaged resources here
			}
		}
		public virtual void HandleException(Exception exception) {
			DbUpdateConcurrencyException concurrencyEx = exception as DbUpdateConcurrencyException;
			if (concurrencyEx != null) {
				// A custom exception of yours for concurrency issues
				throw new Exception();
			}

			DbUpdateException dbUpdateEx = exception as DbUpdateException;
			if (dbUpdateEx != null) {
				if (dbUpdateEx != null
						&& dbUpdateEx.InnerException != null
						&& dbUpdateEx.InnerException.InnerException != null) {
					SqlException sqlException = dbUpdateEx.InnerException.InnerException as SqlException;
					if (sqlException != null) {
						switch (sqlException.Number) {
							case 2627:  // Unique constraint error                                
								throw new Exception("Record is already exist !");
							case 547:   // Constraint check violation
								throw new Exception("Record is already exist !");
							case 2601:  // Duplicated key row error
								throw new Exception("Record is already exist !");
							default:
								// A custom exception of yours for other DB issues
								throw exception;
						}
					}

					throw exception;
				}
			}
			throw exception;
			// If we're here then no exception has been thrown
			// So add another piece of code below for other exceptions not yet handled...
		}
		public void test() { }

		~AbstractRepository() {
			Dispose(false);
		}
	}
}
