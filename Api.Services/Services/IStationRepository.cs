﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Models;

namespace Api.Services.Services
{
    public interface IStationRepository
    {
        Task<IEnumerable<Station>> GetAllAsync(Request request);

        Task<Station> GetByIdAsync(string id);

        Task<Station> GetOneAsync(Request request);

        Task<int> CountAsync(Request request);
    }
}