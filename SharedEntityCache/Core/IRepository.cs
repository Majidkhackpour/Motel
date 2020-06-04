using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PacketParser.Interface;
using PacketParser.Services;

namespace SharedEntityCache.Core
{
    public interface IRepository<T> where T : class, IHasGuid, new()
    {
        Task<T> GetAsync(Guid guid);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, string tranName);
        Task<ReturnedSaveFuncInfo> RemoveAllAsync(string tranName);
        Task<List<T>> GetAllAsync();
        Task<ReturnedSaveFuncInfo> SaveAsync(T item, string tranName);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(IEnumerable<Guid> items, string tranName);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<T> items, string tranName);
    }
}
