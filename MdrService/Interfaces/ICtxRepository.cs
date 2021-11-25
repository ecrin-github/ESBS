using System.Collections.Generic;
using System.Threading.Tasks;
using MdrService.Models.Ctx;

namespace MdrService.Interfaces
{
    public interface ICtxRepository
    {
        Task<Organisation> GetOrganisation(int id);
        
        Task<ICollection<OrgAttribute>> GetOrgAttributes(int orgId);
        Task<ICollection<OrgLink>> GetOrgLinks(int orgId);
        Task<ICollection<OrgLocation>> GetOrgLocations(int orgId);
        Task<ICollection<OrgName>> GetOrgNames(int orgId);
        Task<ICollection<OrgRelationship>> GetOrgRelationships(int orgId);
        
        Task<ICollection<People>> GetPeople();
        Task<People> GetPerson(int id);
        Task<ICollection<PeopleLink>> GetPersonLinks(int personId);
        Task<ICollection<PeopleRole>> GetPersonRoles(int personId);
        
        Task<ICollection<Publisher>> GetPublishers();
        Task<Publisher> GetPublisher(int id);
        Task<ICollection<PubEissn>> GetPubEissns(int pubId);
        Task<ICollection<PubJournal>> GetPubJournals(int pubId);
        Task<ICollection<PubPissn>> GetPubPissns(int pubId); 
    }
}