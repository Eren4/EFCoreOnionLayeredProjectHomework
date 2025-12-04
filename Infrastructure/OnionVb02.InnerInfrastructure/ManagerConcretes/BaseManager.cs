using AutoMapper;
using OnionVb02.Application.DTOInterfaces;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace OnionVb02.InnerInfrastructure.ManagerConcretes
{
    public abstract class BaseManager<T, U> : IManager<T, U> where T : class, IDto where U : class, IEntity
    {
        private readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;

        public BaseManager(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Delegates for error handling
        protected async Task<TResult> ExecuteSafeAsync<TResult>(Func<Task<TResult>> action)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                throw new Exception($"Manager error: {ex.Message}", ex);
            }
        }

        protected async Task ExecuteSafeAsync(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                throw new Exception($"Manager error: {ex.Message}", ex);
            }
        }

        protected T ExecuteSafe<T>(Func<T> action)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while executing operation.", ex);
            }
        }

        public async Task CreateAsync(T entity)
        {
            await ExecuteSafeAsync(async () =>
            {
                U domainEntity = _mapper.Map<U>(entity)!;

                domainEntity.CreatedDate = DateTime.Now;
                domainEntity.Status = Domain.Enums.DataStatus.Inserted;

                await _repository.CreateAsync(domainEntity);
            });
        }

        public List<T> GetActives()
        {
            return ExecuteSafe(() =>
            {
                List<U> values = _repository.Where(x => x.Status != Domain.Enums.DataStatus.Deleted).ToList();

                return _mapper.Map<List<T>>(values)!;
            });
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await ExecuteSafeAsync(async () =>
            {
                List<U> values = await _repository.GetAllAsync();

                return _mapper.Map<List<T>>(values)!;
            });
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                U value = await _repository.GetByIdAsync(id);

                if (value == null || value.Status == Domain.Enums.DataStatus.Deleted)
                {
                    throw new Exception("Error while retrieving value");
                }

                return _mapper.Map<T>(value)!;
            });
        }

        public List<T> GetPassives()
        {
            return ExecuteSafe(() =>
            {
                List<U> values = _repository.Where(x => x.Status == Domain.Enums.DataStatus.Deleted).ToList();

                return _mapper.Map<List<T>>(values)!;
            });
        }

        public List<T> GetUpdateds()
        {
            return ExecuteSafe(() =>
            {
                List<U> values = _repository.Where(x => x.Status == Domain.Enums.DataStatus.Updated).ToList();

                return _mapper.Map<List<T>>(values)!;
            });
        }

        public async Task<string> HardDeleteAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                U value = await _repository.GetByIdAsync(id);

                if (value == null || value.Status != Domain.Enums.DataStatus.Deleted)
                    return "Veri silinebilmesi icin pasif olmalı veya bulunabilmeli";

                await _repository.DeleteAsync(value);

                return $"{id} id'li veri silindi";
            });
        }

        public async Task<string> SoftDeleteAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                U value = await _repository.GetByIdAsync(id);

                if (value == null || value.Status == Domain.Enums.DataStatus.Deleted)
                    return "Veri zaten pasif veya yok";

                value.Status = Domain.Enums.DataStatus.Deleted;
                value.DeletedDate = DateTime.Now;

                await _repository.SaveChangesAsync();

                return $"{id} id'li veri pasif hale getirildi";
            });
        }

        public async Task UpdateAsync(T entity)
        {
            await ExecuteSafeAsync(async () =>
            {
                U originalValue = await _repository.GetByIdAsync(entity.Id);

                if (originalValue == null || originalValue.Status == Domain.Enums.DataStatus.Deleted)
                {
                    throw new Exception("Error while retrieving value");
                }

                U newValue = _mapper.Map<U>(entity)!;

                newValue.Status = Domain.Enums.DataStatus.Updated;
                newValue.UpdatedDate = DateTime.Now;

                await _repository.UpdateAsync(originalValue, newValue);
            });
        }
    }
}
