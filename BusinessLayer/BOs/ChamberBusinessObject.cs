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
    public class ChamberBusinessObject
    {
        TransactionOptions transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        protected readonly ChamberDataAccessObject _dao;
        public ChamberBusinessObject(ChamberDataAccessObject dao)
        {
            _dao = dao;
        }

        #region Create

        public virtual OperationResult Create(Chamber chamber)
        {
            try
            {
                _dao.Create(chamber);
                return new OperationResult<List<Chamber>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Chamber>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> CreateAsync(Chamber chamber)
        {
            try
            {
                await _dao.CreateAsync(chamber);
                return new OperationResult<List<Chamber>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Chamber>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read 
        public virtual OperationResult<Chamber> Read(Guid id)
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<Chamber> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<Chamber>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult<Chamber>> ReadAsync(Guid id)
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<Chamber> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<Chamber>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public virtual OperationResult Update(Chamber chamber)
        {
            try
            {
                _dao.Update(chamber);
                return new OperationResult<List<Chamber>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Chamber>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> UpdateAsync(Chamber chamber)
        {
            try
            {
                await _dao.UpdateAsync(chamber);
                return new OperationResult<List<Chamber>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Chamber>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public virtual OperationResult Delete(Chamber chamber)
        {
            try
            {

                _dao.Update(chamber);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> DeleteAsync(Chamber chamber)
        {
            try
            {
                await _dao.DeleteAsync(chamber);
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
        public virtual OperationResult<List<Chamber>> List()
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List();
                transactionScope.Complete();
                return new OperationResult<List<Chamber>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Chamber>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult<List<Chamber>>> ListAsync()
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ListAsync();
                transactionScope.Complete();
                return new OperationResult<List<Chamber>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Chamber>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region List Non-deleted
        public virtual OperationResult<List<Chamber>> ListNonDeleted()
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List();
                result = result.Where(x => !x.IsDeleted).ToList();
                transactionScope.Complete();
                return new OperationResult<List<Chamber>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Chamber>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult<List<Chamber>>> ListNonDeletedAsync()
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ListAsync();
                result = result.Where(x => !x.IsDeleted).ToList();
                transactionScope.Complete();
                return new OperationResult<List<Chamber>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Chamber>>() { Success = false, Exception = e };
            }
        }
        #endregion
    }
}
