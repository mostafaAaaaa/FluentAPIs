using FluentAPI.ApplicationServices.IServices;
using FluentAPI.DTOs;
using FluentAPI.Inferastructure.IRepositores;
using FluentAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FluentAPI.ApplicationServices.Services
{
    public class VendorServices : IVendorServices
    {
        private readonly IVendorRepository _vendorRepository;


        public VendorServices(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public JsonResult DeleteVendorServices(int id)
        {
            int deleteResult = _vendorRepository.DeleteVendorRepository(id);

            if (deleteResult > 0)
            {
                return new JsonResult(new { HttpStatusCode = HttpStatusCode.OK });
            }
            else
            {
                return new JsonResult(new { HttpStatusCode = HttpStatusCode.InternalServerError });
            }
        }

        public List<TagDto> GetListTagServices()
        {
            throw new NotImplementedException();
        }

        //public List<TagDto> GetListTagServices()
        //{
        //    throw new NotImplementedException();
        //}

        public List<VendorDto> GetListVendorServices()
        {
            var listVendor = _vendorRepository.GetListVendorRepository();
            var listTag = _vendorRepository.GetListTagRepository();

            //  List<TagDto> listTagDtos = new List<TagDto>();
            var listTagDtos = listTag.Select(x => new TagDto
            {
                //  Id = x.Id,
                Name = x.Name,

            }).ToList();

            //   List<VendorDto> listVendorDto = new List<VendorDto>();
            var listVendorDto = listVendor.Select(x => new VendorDto
            {
                //  Id = x.Id,
                Adress = x.Adress,
                Email = x.Email,
                Gender = x.Gender,
                PhoneNumber = x.PhoneNumber,
                Title = x.Title,
                VendorName = x.VendorName,
                Date = x.Date,
                tagDtos = listTagDtos


            }).ToList();





            return listVendorDto;
        }

        public VendorDto GetVendorByIdervices(int id)
        {
            var vendor = _vendorRepository.GetVendorByIdRepository(id);

            var listTag = _vendorRepository.GetTagByIdRepository(id);

            var listTagDto = listTag.Select(x => new TagDto
            {
                Name = x.Name
            }).ToList();


            VendorDto vendorDto = new VendorDto()
            {
                Adress = vendor.Adress,
                Date = vendor.Date,
                Email = vendor.Email,
                Gender = vendor.Gender,
                PhoneNumber = vendor.PhoneNumber,
                Title = vendor.Title,
                VendorName = vendor.VendorName,
                tagDtos = listTagDto
            };
            return vendorDto;
        }

        public JsonResult InsertNewVendorServices(InsertVendorDto vendor)
        {
            List<Tag> listTag = new List<Tag>();

            //TODO get tags from Dto
            for (int i = 0; i < vendor.InseragDtos.Count; i++)
            {
                Tag tag = new Tag();
                tag.Name = vendor.InseragDtos[i].Name;
                listTag.Add(tag);
            }


            //TODO maping Dto to Model Vendor

            Vendor VendorForInsert = new Vendor();
            VendorForInsert.Adress = vendor.Adress;
            VendorForInsert.Email = vendor.Email;
            VendorForInsert.Date = vendor.Date;
            VendorForInsert.Gender = vendor.Gender;
            VendorForInsert.Title = vendor.Title;
            VendorForInsert.PhoneNumber = vendor.PhoneNumber;
            VendorForInsert.VendorName = vendor.VendorName;
            VendorForInsert.Tags = listTag;

            ////TODO process
            int result = _vendorRepository.InsertVendorRepository(VendorForInsert);

            if (result > 0)
            {
                return new JsonResult(new { HttpStatusCode = HttpStatusCode.OK });
            }
            else
            {
                return new JsonResult(new { HttpStatusCode = HttpStatusCode.InternalServerError });
            }
        }

        //    public JsonResult UpdateVendorServices(UpdateVendorDto dto , int id)
        //    {

        //     var  tags= _vendorRepository.GetTagByIdRepository(id);
        //        for (int i=0; i< tags.Count; i++)
        //        {
        //            _vendorRepository.DeleteListTagsRepository(tags[i]);
        //        }


        //        List<Tag> listTag = new List<Tag>();
        //        for (int i = 0; i < dto.InseragDtos.Count; i++)
        //        {
        //            Tag tag = new Tag();
        //            tag.Name = dto.InseragDtos[i].Name;
        //            listTag.Add(tag);
        //        }

        //        Vendor VendorForUpdate = new Vendor();
        //        VendorForUpdate.Id = id;
        //        VendorForUpdate.Adress = dto.Adress;
        //        VendorForUpdate.Email = dto.Email;
        //        VendorForUpdate.Date = dto.Date;
        //        VendorForUpdate.Gender = dto.Gender;
        //        VendorForUpdate.Title = dto.Title;
        //        VendorForUpdate.PhoneNumber = dto.PhoneNumber;
        //        VendorForUpdate.VendorName = dto.VendorName;
        //        VendorForUpdate.Tags = listTag;

        //        int result = _vendorRepository.UpdateVendorRepository(VendorForUpdate);

        //        if (result > 0)
        //        {
        //            return new JsonResult(new { HttpStatusCode = HttpStatusCode.OK });
        //        }
        //        else
        //        {
        //            return new JsonResult(new { HttpStatusCode = HttpStatusCode.InternalServerError });
        //        }

        //    }
        //}


        //public JsonResult UpdateVendorServices(string name, int id)
        //{

        //    var tags = _vendorRepository.GetTagByIdRepository(id);
        //    for (int i = 0; i < tags.Count; i++)
        //    {
        //        _vendorRepository.DeleteListTagsRepository(tags[i]);
        //    }


        //    //List<Tag> listTag = new List<Tag>();
        //    //for (int i = 0; i < dto.InseragDtos.Count; i++)
        //    //{
        //    //    Tag tag = new Tag();
        //    //    tag.Name = dto.InseragDtos[i].Name;
        //    //    listTag.Add(tag);
        //    //}
        //var vendorData =    _vendorRepository.GetVendorByIdRepository(id);
        //    vendorData.VendorName = name;
        //    vendorData.Tags = tags;
        //    //Vendor VendorForUpdate = new Vendor();
        //    //VendorForUpdate.Id = id;
        //    //VendorForUpdate.Adress = dto.Adress;
        //    //VendorForUpdate.Email = dto.Email;
        //    //VendorForUpdate.Date = dto.Date;
        //    //VendorForUpdate.Gender = dto.Gender;
        //    //VendorForUpdate.Title = dto.Title;
        //    //VendorForUpdate.PhoneNumber = dto.PhoneNumber;
        //    //VendorForUpdate.VendorName = dto.VendorName;
        //    //VendorForUpdate.Tags = listTag;

        //    int result = _vendorRepository.UpdateVendorRepository(vendorData);

        //    if (result > 0)
        //    {
        //        return new JsonResult(new { HttpStatusCode = HttpStatusCode.OK });
        //    }
        //    else
        //    {
        //        return new JsonResult(new { HttpStatusCode = HttpStatusCode.InternalServerError });
        //    }

        //}
        public JsonResult UpdateVendorServices(JsonPatchDocument<UpdateVendorDto> vendorDto, int id)
        {
            var vendor = _vendorRepository.GetVendorByIdRepository(id);
            if (vendor == null)
            {
                return new JsonResult(new { message = "اطلاعاتی با این آیدی یافت نشد" });
            }
            UpdateVendorDto updateVendorDto = new UpdateVendorDto();
            updateVendorDto.Adress = vendor.Adress;
            updateVendorDto.Date = vendor.Date;
            updateVendorDto.Email = vendor.Email;
            updateVendorDto.Gender = vendor.Gender;
            updateVendorDto.PhoneNumber = vendor.PhoneNumber;
            updateVendorDto.VendorName = vendor.VendorName;

            vendorDto.ApplyTo(updateVendorDto);


            Vendor vendorUpdate = new Vendor();
            vendorUpdate.Id = id;
            vendorUpdate.Adress = updateVendorDto.Adress;
            vendorUpdate.Date = updateVendorDto.Date;
            vendorUpdate.Email = updateVendorDto.Email;
            vendorUpdate.Gender = updateVendorDto.Gender;
            vendorUpdate.PhoneNumber = updateVendorDto.PhoneNumber;
            vendorUpdate.VendorName = updateVendorDto.VendorName;
            vendorUpdate.Title = updateVendorDto.Title;


            int result = _vendorRepository.UpdateVendorRepository(vendorUpdate);

            if (result > 0)
            {
                return new JsonResult(new { HttpStatusCode = HttpStatusCode.OK });
            }
            else
            {
                return new JsonResult(new { HttpStatusCode = HttpStatusCode.InternalServerError, Message = "عملیات مورد نظر انجام نشد" });
            }

        }
    }
}
