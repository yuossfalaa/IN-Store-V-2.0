﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INStore.Domain.Services
{
    public interface IDataService<T>
    {
        Task<List<T>> GetAll(bool IncludeDeletedItems);
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id,T entity);
        Task<bool> Delete(T entity);

    }
}
