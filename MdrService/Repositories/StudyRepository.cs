using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdrService.Interfaces;
using MdrService.Models.DbConnection;
using MdrService.Models.Study;
using Microsoft.EntityFrameworkCore;

namespace MdrService.Repositories
{
    public class StudyRepository : IStudyRepository
    {
        private readonly MdrDbConnection _dbConnection;

        public StudyRepository(MdrDbConnection mdrDbConnection)
        {
            _dbConnection = mdrDbConnection;
        }
        
        public async Task<Study> GetStudyById(int? id)
        {
            if (id == null) return null;
            return await _dbConnection.Studies.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<Study>> GetStudies(ICollection<int> ids)
        {
            return await _dbConnection.Studies.Where(p => ids.Contains(p.Id)).ToListAsync();
        }

        public async Task<ICollection<StudyContributor>> GetStudyContributors(int studyId)
        {
            return await _dbConnection.StudyContributors.Where(p => p.StudyId == studyId).ToArrayAsync();
        }

        public async Task<ICollection<StudyFeature>> GetStudyFeatures(int studyId)
        {
            return await _dbConnection.StudyFeatures.Where(p => p.StudyId == studyId).ToArrayAsync();
        }

        public async Task<ICollection<StudyIdentifier>> GetStudyIdentifiers(int studyId)
        {
            return await _dbConnection.StudyIdentifiers.Where(p => p.StudyId == studyId).ToArrayAsync();
        }

        public async Task<ICollection<StudyRelationship>> GetStudyRelationships(int studyId)
        {
            return await _dbConnection.StudyRelationships.Where(p => p.StudyId == studyId).ToArrayAsync();
        }

        public async Task<ICollection<StudyTitle>> GetStudyTitles(int studyId)
        {
            return await _dbConnection.StudyTitles.Where(p => p.StudyId == studyId).ToArrayAsync();
        }

        public async Task<ICollection<StudyTopic>> GetStudyTopics(int studyId)
        {
            return await _dbConnection.StudyTopics.Where(p => p.StudyId == studyId).ToArrayAsync();
        }
    }
}