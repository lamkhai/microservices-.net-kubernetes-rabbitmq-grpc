using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using System;
using System.Collections.Generic;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto createDto)
        {
            var model = _mapper.Map<Platform>(createDto);
            _repository.CreatePlatform(model);
            _repository.SaveChanges();

            var readDto = _mapper.Map<PlatformReadDto>(model);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(Guid id)
        {
            var model = _repository.GetPlatformById(id);
            if (model != null) return Ok(_mapper.Map<PlatformReadDto>(model));
            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var models = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(models));
        }
    }
}