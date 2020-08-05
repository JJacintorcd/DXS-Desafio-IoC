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
    public class PyramidDataAccessObject
    {
        private readonly PyramidContext _db;
        public PyramidDataAccessObject(PyramidContext context)
        {
            _db = context;
        }

        #region Create
        public void Create(Pyramid pyramid)
        {
            _db.Pyramids.Add(pyramid);
            _db.SaveChanges();
        }

        public async Task CreateAsync(Pyramid pyramid)
        {
            await _db.Pyramids.AddAsync(pyramid);
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Read
        public Pyramid Read(Guid id)
        {
            return _db.Pyramids.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Pyramid> ReadAsync(Guid id)
        {
            return await _db.Pyramids.FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion

        #region Update
        public void Update(Pyramid pyramid)
        {
            _db.Entry(pyramid).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public async Task UpdateAsync(Pyramid pyramid)
        {
            _db.Entry(pyramid).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(Pyramid pyramid)
        {
            pyramid.IsDeleted = true;
            Update(pyramid);
        }

        public async Task DeleteAsync(Pyramid pyramid)
        {
            pyramid.IsDeleted = true;
            await UpdateAsync(pyramid);
        }

        public void Delete(Guid id)
        {
            var pyramid = Read(id);
            if (pyramid == null) return;
            Delete(pyramid);
        }

        public async Task DeleteAsync(Guid id)
        {
            var pyramid = await ReadAsync(id);
            await DeleteAsync(pyramid);
        }
        #endregion

        #region List
        public List<Pyramid> List()
        {
            return _db.Pyramids.ToList();
        }

        public async Task<List<Pyramid>> ListAsync()
        {
            return await _db.Pyramids.ToListAsync();
        }
        #endregion
    }
}
