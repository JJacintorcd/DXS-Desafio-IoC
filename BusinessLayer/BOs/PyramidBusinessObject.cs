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
    public class PyramidBusinessObject
    {
        protected readonly PyramidDataAccessObject _dao;

        TransactionOptions transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        public PyramidBusinessObject(PyramidDataAccessObject dao)
        {
            _dao = dao;
        }

        #region Create

        public virtual OperationResult Create(Pyramid pyramid)
        {
            try
            {
                _dao.Create(pyramid);
                return new OperationResult<List<Pyramid>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Pyramid>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> CreateAsync(Pyramid pyramid)
        {
            try
            {
                await _dao.CreateAsync(pyramid);
                return new OperationResult<List<Pyramid>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Pyramid>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Read 
        public virtual OperationResult<Pyramid> Read(Guid id)
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.Read(id);
                transactionScope.Complete();
                return new OperationResult<Pyramid> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<Pyramid>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult<Pyramid>> ReadAsync(Guid id)
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ReadAsync(id);
                transactionScope.Complete();
                return new OperationResult<Pyramid> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<Pyramid>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Update
        public virtual OperationResult Update(Pyramid pyramid)
        {
            try
            {
                _dao.Update(pyramid);
                return new OperationResult<List<Pyramid>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Pyramid>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> UpdateAsync(Pyramid pyramid)
        {
            try
            {
                await _dao.UpdateAsync(pyramid);
                return new OperationResult<List<Pyramid>> { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Pyramid>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region Delete
        public virtual OperationResult Delete(Pyramid pyramid)
        {
            try
            {

                _dao.Update(pyramid);
                return new OperationResult { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult> DeleteAsync(Pyramid pyramid)
        {
            try
            {
                await _dao.DeleteAsync(pyramid);
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
        public virtual OperationResult<List<Pyramid>> List()
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List();
                transactionScope.Complete();
                return new OperationResult<List<Pyramid>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Pyramid>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult<List<Pyramid>>> ListAsync()
        {
            try
            {
                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ListAsync();
                transactionScope.Complete();
                return new OperationResult<List<Pyramid>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Pyramid>>() { Success = false, Exception = e };
            }
        }
        #endregion

        #region List Non-deleted
        public virtual OperationResult<List<Pyramid>> ListNonDeleted()
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = _dao.List();
                result = result.Where(x => !x.IsDeleted).ToList();
                transactionScope.Complete();
                return new OperationResult<List<Pyramid>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Pyramid>>() { Success = false, Exception = e };
            }
        }

        public async virtual Task<OperationResult<List<Pyramid>>> ListNonDeletedAsync()
        {
            try
            {

                using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                var result = await _dao.ListAsync();
                result = result.Where(x => !x.IsDeleted).ToList();
                transactionScope.Complete();
                return new OperationResult<List<Pyramid>> { Result = result, Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult<List<Pyramid>>() { Success = false, Exception = e };
            }
        }
        #endregion
    }
}
