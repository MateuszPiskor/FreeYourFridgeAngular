using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FreeYourFridge.API.Tests.TestAsyncProvider
{
    public class AsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T> //, IAsyncQueryProvider
    {
        public AsyncEnumerable(System.Linq.Expressions.Expression expression)
            : base(expression) { }

        public IAsyncEnumerator<T> GetAsyncEnumerator(
            CancellationToken cancellationToken = new CancellationToken()
            ) => new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());

        //public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = new CancellationToken())
        //{
        //    return Task.FromResult(Execute<TResult>(expression));
        //    //throw new NotImplementedException();
        //}

        //public TResult Execute<TResult>(Expression expression)
        //        => _inner.Execute<TResult>(expression);
    }

    public class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;

        public AsyncEnumerator(IEnumerator<T> enumerator) =>
            _enumerator = enumerator ?? throw new ArgumentNullException();

        public async ValueTask<bool> MoveNextAsync() =>
            await Task.FromResult(_enumerator.MoveNext());

        public T Current
        {
            get => _enumerator.Current;
        }

        public async ValueTask DisposeAsync()
            => await Task.FromResult(_enumerator.MoveNext());

    }
}
