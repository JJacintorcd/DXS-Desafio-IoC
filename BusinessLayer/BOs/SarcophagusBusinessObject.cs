using Recodme.Dxs.DesafioDXS.BusinessLayer.OperationResults;
using Recodme.Dxs.DesafioDXS.DataAccessLayer.DAOs;
using Recodme.Dxs.DesafioDXS.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Dxs.DesafioDXS.BusinessLayer.BOs
{
    public class SarcophagusBusinessObject
    {
        protected readonly SarcophagusDataAccessObject _dao;

        TransactionOptions transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        public SarcophagusBusinessObject(SarcophagusDataAccessObject dao)
        {
            _dao = dao;
        }

        #region Create

        public virtual OperationResult Create(Sarcophagus sarcophagus)
        {
            try
            {
                _dao.Create(sarcophagus);
                return new OperationResult<List<Sarcophagus>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Sarcophagus>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> CreateAsync(Sarcophagus sarcophagus)
        {
            try
            {
                await _dao.CreateAsync(sarcophagus);
                return new OperationResult<List<Sarcophagus>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Sarcophagus>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read 
        public virtual OperationResult<Sarcophagus> Read(Guid id)
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<Sarcophagus> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<Sarcophagus>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult<Sarcophagus>> ReadAsync(Guid id)
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<Sarcophagus> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<Sarcophagus>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public virtual OperationResult Update(Sarcophagus sarcophagus)
        {
            try
            {
                _dao.Update(sarcophagus);
                return new OperationResult<List<Sarcophagus>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Sarcophagus>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> UpdateAsync(Sarcophagus sarcophagus)
        {
            try
            {
                await _dao.UpdateAsync(sarcophagus);
                return new OperationResult<List<Sarcophagus>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Sarcophagus>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public virtual OperationResult Delete(Sarcophagus sarcophagus)
        {
            try
            {

                _dao.Update(sarcophagus);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> DeleteAsync(Sarcophagus sarcophagus)
        {
            try
            {
                await _dao.DeleteAsync(sarcophagus);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public virtual OperationResult Delete(Guid id)
        {
            try
            {
                _dao.Delete(id);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> DeleteAsync(Guid id)
        {
            try
            {
                await _dao.DeleteAsync(id);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }
        #endregion

        #region List
        public virtual OperationResult<List<Sarcophagus>> List()
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List();
                transactionScope.Complete();
                return new OperationResult<List<Sarcophagus>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Sarcophagus>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult<List<Sarcophagus>>> ListAsync()
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ListAsync();
                transactionScope.Complete();
                return new OperationResult<List<Sarcophagus>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Sarcophagus>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region List Non-deleted
        public virtual OperationResult<List<Sarcophagus>> ListNonDeleted()
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List();
                result = result.Where(x => !x.IsDeleted).ToList();
                transactionScope.Complete();
                return new OperationResult<List<Sarcophagus>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Sarcophagus>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult<List<Sarcophagus>>> ListNonDeletedAsync()
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ListAsync();
                result = result.Where(x => !x.IsDeleted).ToList();
                transactionScope.Complete();
                return new OperationResult<List<Sarcophagus>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Sarcophagus>>() { Success = false, Exception = e };
            }
        }
        #endregion
    }
}
