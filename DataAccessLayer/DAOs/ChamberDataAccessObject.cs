using Microsoft.EntityFrameworkCore;
using Recodme.Dxs.DesafioDXS.DataAccessLayer.Contexts;
using Recodme.Dxs.DesafioDXS.DataLayer;
using Recodme.Dxs.DesafioDXS.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Dxs.DesafioDXS.DataAccessLayer.DAOs
{
    public class ChamberDataAccessObject
    {
        private readonly PyramidContext _db;
        public ChamberDataAccessObject(PyramidContext context)
        {
            _db = context;
        }


        #region Create
        public void Create(Chamber chamber)
        {
            _db.Chambers.Add(chamber);
            _db.SaveChanges();
        }

        public async Task CreateAsync(Chamber chamber)
        {         
            await _db.Chambers.AddAsync(chamber);
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Chamber Read(Guid id)
        {
            return _db.Chambers.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Chamber> ReadAsync(Guid id)
        {
            return await _db.Chambers.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Update
        public void Update(Chamber chamber)
        {
            _db.Entry(chamber).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public async Task UpdateAsync(Chamber chamber)
        {
            _db.Entry(chamber).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Chamber chamber)
        {
            chamber.IsDeleted = true;
            Update(chamber);
        }

        public async Task DeleteAsync(Chamber chamber)
        {
            chamber.IsDeleted = true;
            await UpdateAsync(chamber);
        }

        public void Delete(Guid id)
        {
            var chamber = Read(id);
            if (chamber == null) return;
            Delete(chamber);
        }

        public async Task DeleteAsync(Guid id)
        {
            var chamber = await ReadAsync(id);
            await DeleteAsync(chamber);
        }
        #endregion

        #region List
        public List<Chamber> List()
        {
            return _db.Chambers.ToList();
        }

        public async Task<List<Chamber>> ListAsync()
        {
            return await _db.Chambers.ToListAsync();
        }
        #endregion
    }
}
