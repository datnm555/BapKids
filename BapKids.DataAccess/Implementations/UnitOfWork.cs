using BapKids.DataAccess.Interfaces;
using BapKids.Domain.Entities;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BapKids.DataAccess.Implementations
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>, IDisposable where TEntity : class
    {

        private readonly BapKidsContext _context;
        private bool _disposed;
        private DbContextTransaction dbContextTransaction;

        public UnitOfWork(BapKidsContext context)
        {
            _context = context;
        }

        private Repository<Category> categoryRepository;
        public Repository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new Repository<Category>(_context);
                }
                return categoryRepository;
            }
        }

        private Repository<Product> productRepository;
        public Repository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new Repository<Product>(_context);
                }
                return productRepository;
            }
        }

        public void CreateTransaction()
        {
            dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            dbContextTransaction.Commit();
        }

        public void RollBack()
        {
            dbContextTransaction.Rollback();
            dbContextTransaction.Dispose();
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
    }
}
