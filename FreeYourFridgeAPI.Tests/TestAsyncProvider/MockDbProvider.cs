using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FreeYourFridge.API.Tests.TestAsyncProvider
{
    internal class MockDbProvider<TEntity> where TEntity : class
    {
        internal static ClaimsIdentity identity
        {
            get
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, "username"),
                    new Claim(ClaimTypes.NameIdentifier, "11"),
                };
                return new ClaimsIdentity(claims, "JWT");
            }
        }


        internal static Mock<DbSet<TEntity>> ProvideMockDb(IQueryable<TEntity> data, Mock<DbSet<TEntity>> mockSet)
        {
            var token = new CancellationToken();
            mockSet.As<IAsyncEnumerable<TEntity>>()
                .Setup(dm => dm.GetAsyncEnumerator(token))
                .Returns(new AsyncEnumerator<TEntity>(data.GetEnumerator()));
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet;
        }
    }
}
