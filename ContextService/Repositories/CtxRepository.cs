using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContextService.Interfaces;
using ContextService.Models.Ctx;
using ContextService.Models.DbConnection;
using Microsoft.EntityFrameworkCore;

namespace ContextService.Repositories
{
    public class CtxRepository : ICtxRepository
    {
        private readonly ContextDbConnection _dbConnection;

        public CtxRepository(ContextDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task<ICollection<Organisation>> GetOrganisations()
        {
            var organisations = await _dbConnection.Organisations.AnyAsync();
            if (!organisations) return null;
            return await _dbConnection.Organisations.ToArrayAsync();
        }

        public async Task<Organisation> GetOrganisation(int id)
        {
            var organisations = await _dbConnection.Organisations.AnyAsync();
            if (!organisations) return null;
            return await _dbConnection.Organisations.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<OrgAttribute>> GetOrgAttributes(int orgId)
        {
            var orgAttributes = await _dbConnection.OrgAttributes.AnyAsync();
            if (!orgAttributes) return null;
            return await _dbConnection.OrgAttributes.Where(p => p.OrgId == orgId).ToArrayAsync();
        }

        public async Task<ICollection<OrgLink>> GetOrgLinks(int orgId)
        {
            var orgLinks = await _dbConnection.OrgLinks.AnyAsync();
            if (!orgLinks) return null;
            return await _dbConnection.OrgLinks.Where(p => p.OrgId == orgId).ToArrayAsync();
        }

        public async Task<ICollection<OrgLocation>> GetOrgLocations(int orgId)
        {
            var orgLocations = await _dbConnection.OrgLocations.AnyAsync();
            if (!orgLocations) return null;
            return await _dbConnection.OrgLocations.Where(p => p.OrgId == orgId).ToArrayAsync();
        }

        public async Task<ICollection<OrgName>> GetOrgNames(int orgId)
        {
            var orgNames = await _dbConnection.OrgNames.AnyAsync();
            if (!orgNames) return null;
            return await _dbConnection.OrgNames.Where(p => p.OrgId == orgId).ToArrayAsync();
        }

        public async Task<ICollection<OrgRelationship>> GetOrgRelationships(int orgId)
        {
            var orgRels = await _dbConnection.OrgRelationships.AnyAsync();
            if (!orgRels) return null;
            return await _dbConnection.OrgRelationships.Where(p => p.OrgId == orgId).ToArrayAsync();
        }

        public async Task<ICollection<People>> GetPeople()
        {
            var people = await _dbConnection.People.AnyAsync();
            if (!people) return null;
            return await _dbConnection.People.ToArrayAsync();
        }

        public async Task<People> GetPerson(int id)
        {
            var people = await _dbConnection.People.AnyAsync();
            if (!people) return null;
            return await _dbConnection.People.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<PeopleLink>> GetPersonLinks(int personId)
        {
            var personLinks = await _dbConnection.PeopleLinks.AnyAsync();
            if (!personLinks) return null;
            return await _dbConnection.PeopleLinks.Where(p => p.PersonId == personId).ToArrayAsync();
        }

        public async Task<ICollection<PeopleRole>> GetPersonRoles(int personId)
        {
            var personRoles = await _dbConnection.PeopleRoles.AnyAsync();
            if (!personRoles) return null;
            return await _dbConnection.PeopleRoles.Where(p => p.PersonId == personId).ToArrayAsync();
        }

        public async Task<ICollection<OrgTypeMembership>> GetOrgTypeMemberships(int orgId)
        {
            var orgTypeMemberships = await _dbConnection.OrgTypeMemberships.AnyAsync();
            if (!orgTypeMemberships) return null;
            return await _dbConnection.OrgTypeMemberships.Where(p => p.OrgId == orgId).ToArrayAsync();
        }

        public async Task<ICollection<GeogEntity>> GetGeogEntities()
        {
            if (!_dbConnection.GeogEntities.Any()) return null;
            return await _dbConnection.GeogEntities.ToArrayAsync();
        }

        public async Task<GeogEntity> GetGeogEntity(int id)
        {
            if (!_dbConnection.GeogEntities.Any()) return null;
            return await _dbConnection.GeogEntities.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<PublishedJournal>> GetPublishedJournals()
        {
            if (!_dbConnection.PublishedJournals.Any()) return null;
            return await _dbConnection.PublishedJournals.ToArrayAsync();
        }

        public async Task<PublishedJournal> GetPublishedJournal(int id)
        {
            if (!_dbConnection.PublishedJournals.Any()) return null;
            return await _dbConnection.PublishedJournals.FirstOrDefaultAsync(p => p.JournalId == id);
        }
    }
}