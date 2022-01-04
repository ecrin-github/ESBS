using System.Collections.Generic;
using System.Threading.Tasks;
using ContextService.Models.Ctx;

namespace ContextService.Interfaces
{
    public interface ICtxRepository
    {
        Task<ICollection<Organisation>> GetOrganisations();
        Task<Organisation> GetOrganisation(int id);
        Task<ICollection<Organisation>> GetOrganisationsByName(string name);
        
        Task<ICollection<OrgAttribute>> GetOrgAttributes(int orgId);
        Task<ICollection<OrgLink>> GetOrgLinks(int orgId);
        Task<ICollection<OrgLocation>> GetOrgLocations(int orgId);
        Task<ICollection<OrgName>> GetOrgNames(int orgId);
        Task<ICollection<OrgRelationship>> GetOrgRelationships(int orgId);
        Task<ICollection<OrgTypeMembership>> GetOrgTypeMemberships(int orgId);
        
        Task<ICollection<People>> GetPeople();
        Task<People> GetPerson(int id);
        Task<ICollection<PeopleLink>> GetPersonLinks(int personId);
        Task<ICollection<PeopleRole>> GetPersonRoles(int personId);
        
        Task<ICollection<GeogEntity>> GetGeogEntities();
        Task<GeogEntity> GetGeogEntity(int id);

        Task<ICollection<PublishedJournal>> GetPublishedJournals();
        Task<PublishedJournal> GetPublishedJournal(int id);
    }
}