using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinstarApp.Data
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        #region Constructor
        public ApplicationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Public Methods

        public async Task<IEnumerable<DataObject>> GetData(DataFilter filter)
        {
            return await _dbContext.DataObjects
                .Where(x => filter.Code == null || x.Code == filter.Code)
                .Where(x => string.IsNullOrEmpty(filter.Value) || x.Value == filter.Value)
                .ToListAsync();
        }

        public async Task PostData(IEnumerable<DataObject> data)
        {
            // Очищаем таблицу
            _dbContext.DataObjects.RemoveRange(_dbContext.DataObjects);

            // сортируем
            data = data.OrderBy(x => x.Code);

            // Добавляем данные
            _dbContext.AddRange(data);

            // Сохраняем
            await _dbContext.SaveChangesAsync();

        }
        #endregion
    }
}
