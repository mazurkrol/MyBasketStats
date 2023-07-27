using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.PlayerServices;
using MyBasketStats.API.Services.TeamServices;
using System.Reflection.Metadata;

namespace MyBasketStats.API.Services.Basic
{
    public class BasicService<TDto, TEntity> where TEntity : class where TDto : class
    {
        protected readonly IMapper _mapper;
        private readonly IBasicRepository<TEntity> _basicRepository;
        public BasicService(IMapper mapper, IBasicRepository<TEntity> basicRepository)
        {
            _mapper=mapper;
            _basicRepository=basicRepository;
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var item = await _basicRepository.GetByIdAsync(id);
            var itemToReturn = _mapper.Map<TDto>(item);
            return itemToReturn;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var listToReturn = await _basicRepository.GetAllAsync();
            var finalListToReturn = _mapper.Map<IEnumerable<TDto>>(listToReturn);
            return finalListToReturn;
        }
    }
}
