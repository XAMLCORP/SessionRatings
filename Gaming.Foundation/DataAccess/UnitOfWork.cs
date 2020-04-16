using Gaming.Foundation.Interfaces;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaming.Foundation.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        //private bool _disposed;
        private bool _complete;
        private Dictionary<string, object> _repositories;

        public Queue<Task<Action>> RollbackActions { get; set; }

        public UnitOfWork()
        {
            RollbackActions = new Queue<Task<Action>>();
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void CommitTransaction()
        {
            _complete = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        virtual protected void Dispose(bool disposing)
        {
            if (disposing)
                try
                {
                    if (!_complete)
                        RollbackTransaction();
                }
                finally
                {
                    RollbackActions.Clear();
                }
            _complete = false;
        }

        public IRepository<T> Repository<T>() where T : TableEntity
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type))
                return (IRepository<T>)_repositories[type];

            var repositoryType = typeof(Repository<>);

            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)));
            ((IRepository<T>)repositoryInstance).Scope = this;

            _repositories.Add(type, repositoryInstance);
            return (IRepository<T>)_repositories[type];
        }

        private void RollbackTransaction()
        {
            while (RollbackActions.Count > 0)
            {
                var undoAction = RollbackActions.Dequeue();
                undoAction.Result();
            }
        }
    }
}
