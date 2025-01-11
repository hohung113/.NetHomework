﻿using BusinessObject.Enitty;
using BusinessObject.Entity;
using DataAccess.Repository;
using eStoreAPI.Dtos;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICatetoryRepository _catetoryRepository = new CategoryRepository();
        [HttpGet]
        public ActionResult<List<Category>> GetCategories()
        {
            return _catetoryRepository.GetCategories().Select( x => new Category
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
            }).ToList();
        }
        [HttpPost]
        public ActionResult CreateCategory([FromBody] CategoryDTO cate)
        {
            var dto = cate.Adapt<Category>();
            _catetoryRepository.AddCategory(dto);
            return NoContent();
        }
    }
}