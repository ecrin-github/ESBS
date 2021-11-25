using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdrService.Interfaces;
using MdrService.Models.DbConnection;
using Microsoft.EntityFrameworkCore;


namespace MdrService.Repositories
{
    public class LinksRepository : ILinksRepository
    {
        private readonly MdrDbConnection _dbConnection;

        public LinksRepository(MdrDbConnection mdrDbConnection)
        {
            _dbConnection = mdrDbConnection ?? throw new ArgumentNullException(nameof(mdrDbConnection));
        }
        
        public async Task<ICollection<int>> GetObjectStudies(int objectId)
        {
            return await _dbConnection.StudyObjectLinks.Where(p => p.ObjectId.Equals(objectId))
                .Select(p => p.StudyId).ToArrayAsync();
        }

        public async Task<ICollection<int>> GetStudyObjects(int studyId)
        {
            return await _dbConnection.StudyObjectLinks.Where(p => p.StudyId.Equals(studyId))
                .Select(p => p.ObjectId).ToArrayAsync();
        }
    }
}