﻿using AutoMapper;
using JobBoard.Core;
using JobBoard.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobBoard.AdminApi.Controllers
{
    [AllowAnonymous]
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _unitOfWork.Categories.GetCategoriesAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));

        }
    }
}
