﻿using AutoMapper;
using TRIDENT_Project.Data;
using TRIDENT_Project.Models;
using TRIDENT_Project.Repositories;
using TRIDENT_Project.ViewModel;

namespace TRIDENT_Project.Services
{
    public class ProfessorsService : IProfessorsService
    {
        private readonly ICRUDRepository<Professor> _repository;
        private IMapper _mapper;

        public ProfessorsService(ICRUDRepository<Professor> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }


        /// <summary>
        /// 授課講師列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Professor>> GetAllProfessorsAsync()
        {
            return await _repository.FindAsync(_ => true);
        }

        /// <summary>
        /// 建立新講師
        /// </summary>
        /// <param name="postProfessor"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Professor> CreateProfessorAsync(ProfessorParamenter postProfessor)
        {
            Professor professor = _mapper.Map<Professor>(postProfessor);

            Professor? createdProfessor = await _repository.CreateAsync(professor);
            if (createdProfessor == null) throw new Exception("新增失敗");

            return professor;
        }

    }
}
