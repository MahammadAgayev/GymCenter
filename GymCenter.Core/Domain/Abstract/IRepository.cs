﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Core.Domain.Abstract
{
    public interface IRepository <T>
    {
        void Add(T entity);
        void Update(T entity);
        T Get(int id);
        List<T> Get();
    }
}
