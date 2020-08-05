using Microsoft.EntityFrameworkCore;
using Recodme.Dxs.DesafioDXS.DataAccessLayer.Contexts;
using Recodme.Dxs.DesafioDXS.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Dxs.DesafioDXS.DataAccessLayer.DAOs
{
    public class SarcophagusDataAccessObject
    {
        private readonly PyramidContext _db;
        public SarcophagusDataAccessObject(PyramidContext context)
        {
            _db = context;
        }

        #region Create
        public void Create(Sarcophagus sarcophagus)
        {
            _db.Sarcophagi.Add(sarcophagus);
            _db.SaveChanges();
        }

        public async Task CreateAsync(Sarcophagus sarcophagus)
        {
            await _db.Sarcophagi.AddAsync(sarcophagus);
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Sarcophagus Read(Guid id)
        {
            return _db.Sarcophagi.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Sarcophagus> ReadAsync(Guid id)
        {
            return await _db.Sarcophagi.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Update
        public void Update(Sarcophagus sarcophagus)
        {
            _db.Entry(sarcophagus).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public async Task UpdateAsync(Sarcophagus sarcophagus)
        {
            _db.Entry(sarcophagus).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Sarcophagus sarcophagus)
        {
            sarcophagus.IsDeleted = true;
            Update(sarcophagus);
        }

        public async Task DeleteAsync(Sarcophagus sarcophagus)
        {
            sarcophagus.IsDeleted = true;
            await UpdateAsync(sarcophagus);
        }

        public void Delete(Guid id)
        {
            var sarcophagus = Read(id);
            if (sarcophagus == null) return;
            Delete(sarcophagus);
        }

        public async Task DeleteAsync(Guid id)
        {
            var sarcophagus = await ReadAsync(id);
            await DeleteAsync(sarcophagus);
        }
        #endregion

        #region List
        public List<Sarcophagus> List()
        {
            return _db.Sarcophagi.ToList();
        }

        public async Task<List<Sarcophagus>> ListAsync()
        {
            return await _db.Sarcophagi.ToListAsync();
        }
        #endregion
    }
}
