using FluentAPI.Contexts;
using FluentAPI.Inferastructure.IRepositores;
using FluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentAPI.Inferastructure.Repositores
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ConvectionContext _ConvectionContext;
        public VendorRepository(ConvectionContext ConvectionContext)
        {
            _ConvectionContext = ConvectionContext;
        }

        public int DeleteListTagsRepository(Tag tags)
        {
            _ConvectionContext.Tags.Remove(tags);
            return _ConvectionContext.SaveChanges();
        }

        public int DeleteVendorRepository(int id)
        {
            var vendor = _ConvectionContext.vendors.Find(id);
            _ConvectionContext.vendors.Remove(vendor);
            return _ConvectionContext.SaveChanges();
        }

        public List<Tag> GetListTagRepository()
        {
            return _ConvectionContext.Tags.ToList();

        }

        public List<Vendor> GetListVendorRepository()
        {
            return _ConvectionContext.vendors.ToList();

        }

        public List<Tag> GetTagByIdRepository(int id)
        {
            return _ConvectionContext.Tags.Where(x => x.VendorId == id).ToList();
        }

        public Vendor GetVendorByIdRepository(int id)
        {

            var entity = _ConvectionContext.Set<Vendor>().Find(id);
            _ConvectionContext.Entry(entity).State = EntityState.Detached;
            return entity;


        }

        public int InsertVendorRepository(Vendor vendor)
        {
            _ConvectionContext.vendors.Add(vendor);
            return _ConvectionContext.SaveChanges();
        }

        public int UpdateVendorRepository(Vendor vendor)
        {
            _ConvectionContext.vendors.Update(vendor);
            return _ConvectionContext.SaveChanges();
        }
    }
}
