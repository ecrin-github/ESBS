using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MdmService.DTO.Study;
using MdmService.Interfaces;
using MdmService.Models.DbConnection;
using MdmService.Models.Study;
using Microsoft.EntityFrameworkCore;

namespace MdmService.Repositories
{
    public class StudyRepository : IStudyRepository
    {
        private readonly MdmDbConnection _dbConnection;
        private readonly IDataMapper _dataMapper;

        public StudyRepository(MdmDbConnection dbConnection, IDataMapper dataMapper)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            _dataMapper = dataMapper ?? throw new ArgumentNullException(nameof(dataMapper));
        }
        
        
        public IQueryable<StudyContributor> GetQueryableStudyContributors()
        {
            return _dbConnection.StudyContributors;
        }

        public async Task<ICollection<StudyContributorDto>> GetStudyContributors(string sdSid)
        {
            var data = _dbConnection.StudyContributors.Where(p => p.SdSid == sdSid);
            return data.Any() ? _dataMapper.StudyContributorDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<StudyContributorDto> GetStudyContributor(int? id)
        {
            var studyContributor = await _dbConnection.StudyContributors.FirstOrDefaultAsync(p => p.Id == id);
            return studyContributor != null ? _dataMapper.StudyContributorDtoMapper(studyContributor) : null;
        }

        public async Task<StudyContributorDto> CreateStudyContributor(string sdSid, StudyContributorDto studyContributorDto)
        {
            var studyContributor = new StudyContributor
            {
                SdSid = sdSid,
                CreatedOn = DateTime.Now
            };
            await _dbConnection.StudyContributors.AddAsync(studyContributor);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyContributorDtoMapper(studyContributor);
        }

        public async Task<StudyContributorDto> UpdateStudyContributor(StudyContributorDto studyContributorDto)
        {
            var dbStudyContributor =
                await _dbConnection.StudyContributors.FirstOrDefaultAsync(p => p.Id == studyContributorDto.Id);

            if (dbStudyContributor == null) return null;
            
            dbStudyContributor.OrcidId = studyContributorDto.OrcidId;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyContributorDtoMapper(dbStudyContributor);
        }

        public async Task<int> DeleteStudyContributor(int id)
        {
            var data = await _dbConnection.StudyContributors.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.StudyContributors.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllStudyContributors(string sdSid)
        {
            var data = _dbConnection.StudyContributors.Where(p => p.SdSid == sdSid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.StudyContributors.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<StudyFeature> GetQueryableStudyFeatures()
        {
            return _dbConnection.StudyFeatures;
        }

        public async Task<ICollection<StudyFeatureDto>> GetStudyFeatures(string sdSid)
        {
            var data = _dbConnection.StudyFeatures.Where(p => p.SdSid == sdSid);
            return data.Any() ? _dataMapper.StudyFeatureDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<StudyFeatureDto> GetStudyFeature(int id)
        {
            var studyFeature = await _dbConnection.StudyFeatures.FirstOrDefaultAsync(p => p.Id == id);
            return studyFeature != null ? _dataMapper.StudyFeatureDtoMapper(studyFeature) : null;
        }

        public async Task<StudyFeatureDto> CreateStudyFeature(string sdSid, StudyFeatureDto studyFeatureDto)
        {
            var studyFeature = new StudyFeature
            {
                SdSid = sdSid,
                FeatureTypeId = studyFeatureDto.FeatureTypeId,
                FeatureValueId = studyFeatureDto.FeatureValueId,
                CreatedOn = DateTime.Now
            };

            await _dbConnection.StudyFeatures.AddAsync(studyFeature);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyFeatureDtoMapper(studyFeature);
        }

        public async Task<StudyFeatureDto> UpdateStudyFeature(StudyFeatureDto studyFeatureDto)
        {
            var dbStudyFeature =
                await _dbConnection.StudyFeatures.FirstOrDefaultAsync(p => p.Id == studyFeatureDto.Id);

            if (dbStudyFeature == null) return null;
            
            dbStudyFeature.FeatureTypeId = studyFeatureDto.FeatureTypeId;
            dbStudyFeature.FeatureValueId = studyFeatureDto.FeatureValueId;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyFeatureDtoMapper(dbStudyFeature);
        }

        public async Task<int> DeleteStudyFeature(int id)
        {
            var data = await _dbConnection.StudyFeatures.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.StudyFeatures.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllStudyFeatures(string sdSid)
        {
            var data = _dbConnection.StudyFeatures.Where(p => p.SdSid == sdSid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.StudyFeatures.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<StudyIdentifier> GetQueryableStudyIdentifiers()
        {
            return _dbConnection.StudyIdentifiers;
        }

        public async Task<ICollection<StudyIdentifierDto>> GetStudyIdentifiers(string sdSid)
        {
            var data = _dbConnection.StudyIdentifiers.Where(p => p.SdSid == sdSid);
            return data.Any() ? _dataMapper.StudyIdentifierDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<StudyIdentifierDto> GetStudyIdentifier(int id)
        {
            var studyIdentifier = await _dbConnection.StudyIdentifiers.FirstOrDefaultAsync(p => p.Id == id);
            return studyIdentifier != null ? _dataMapper.StudyIdentifierDtoMapper(studyIdentifier) : null;
        }

        public async Task<StudyIdentifierDto> CreateStudyIdentifier(string sdSid, StudyIdentifierDto studyIdentifierDto)
        {
            var studyIdentifier = new StudyIdentifier
            {
                SdSid = sdSid,
                CreatedOn = DateTime.Now,
                IdentifierTypeId = studyIdentifierDto.IdentifierTypeId,
                IdentifierValue = studyIdentifierDto.IdentifierValue,
                IdentifierOrgId = studyIdentifierDto.IdentifierOrgId,
                IdentifierOrg = studyIdentifierDto.IdentifierOrg,
                IdentifierOrgRorId = studyIdentifierDto.IdentifierOrgRorId,
                IdentifierDate = studyIdentifierDto.IdentifierDate
            };

            await _dbConnection.StudyIdentifiers.AddAsync(studyIdentifier);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyIdentifierDtoMapper(studyIdentifier);
        }

        public async Task<StudyIdentifierDto> UpdateStudyIdentifier(StudyIdentifierDto studyIdentifierDto)
        {
            var dbStudyIdentifier =
                await _dbConnection.StudyIdentifiers.FirstOrDefaultAsync(p => p.Id == studyIdentifierDto.Id);

            if (dbStudyIdentifier == null) return null;
            
            dbStudyIdentifier.IdentifierTypeId = studyIdentifierDto.IdentifierTypeId;
            dbStudyIdentifier.IdentifierValue = studyIdentifierDto.IdentifierValue;
            dbStudyIdentifier.IdentifierOrgId = studyIdentifierDto.IdentifierOrgId;
            dbStudyIdentifier.IdentifierOrg = studyIdentifierDto.IdentifierOrg;
            dbStudyIdentifier.IdentifierOrgRorId = studyIdentifierDto.IdentifierOrgRorId;
            dbStudyIdentifier.IdentifierDate = studyIdentifierDto.IdentifierDate;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyIdentifierDtoMapper(dbStudyIdentifier);
        }

        public async Task<int> DeleteStudyIdentifier(int id)
        {
            var data = await _dbConnection.StudyIdentifiers.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.StudyIdentifiers.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllStudyIdentifiers(string sdSid)
        {
            var data = _dbConnection.StudyIdentifiers.Where(p => p.SdSid == sdSid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.StudyIdentifiers.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<StudyReference> GetQueryableStudyReferences()
        {
            return _dbConnection.StudyReferences;
        }

        public async Task<ICollection<StudyReferenceDto>> GetStudyReferences(string sdSid)
        {
            var data = _dbConnection.StudyReferences.Where(p => p.SdSid == sdSid);
            return data.Any() ? _dataMapper.StudyReferenceDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<StudyReferenceDto> GetStudyReference(int id)
        {
            var studyReference = await _dbConnection.StudyReferences.FirstOrDefaultAsync(p => p.Id == id);
            return studyReference != null ? _dataMapper.StudyReferenceDtoMapper(studyReference) : null;
        }

        public async Task<StudyReferenceDto> CreateStudyReference(string sdSid, StudyReferenceDto studyReferenceDto)
        {
            var studyReference = new StudyReference
            {
                SdSid = sdSid,
                CreatedOn = DateTime.Now,
                Pmid = studyReferenceDto.Pmid,
                Doi = studyReferenceDto.Doi,
                Citation = studyReferenceDto.Citation,
                Comments = studyReferenceDto.Comments
            };

            await _dbConnection.StudyReferences.AddAsync(studyReference);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyReferenceDtoMapper(studyReference);
        }

        public async Task<StudyReferenceDto> UpdateStudyReference(StudyReferenceDto studyReferenceDto)
        {
            var dbStudyReference =
                await _dbConnection.StudyReferences.FirstOrDefaultAsync(p => p.Id == studyReferenceDto.Id);

            if (dbStudyReference == null) return null;
            
            dbStudyReference.Doi = studyReferenceDto.Doi;
            dbStudyReference.Pmid = studyReferenceDto.Pmid;
            dbStudyReference.Comments = studyReferenceDto.Comments;
            dbStudyReference.Citation = studyReferenceDto.Citation;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyReferenceDtoMapper(dbStudyReference);
        }

        public async Task<int> DeleteStudyReference(int id)
        {
            var data = await _dbConnection.StudyReferences.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.StudyReferences.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllStudyReferences(string sdSid)
        {
            var data = _dbConnection.StudyReferences.Where(p => p.SdSid == sdSid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.StudyReferences.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<StudyRelationship> GetQueryableStudyRelationships()
        {
            return _dbConnection.StudyRelationships;
        }

        public async Task<ICollection<StudyRelationshipDto>> GetStudyRelationships(string sdSid)
        {
            var data = _dbConnection.StudyRelationships.Where(p => p.SdSid == sdSid);
            return data.Any() ? _dataMapper.StudyRelationshipDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<StudyRelationshipDto> GetStudyRelationship(int id)
        {
            var studyRelationship = await _dbConnection.StudyRelationships.FirstOrDefaultAsync(p => p.Id == id);
            return studyRelationship != null ? _dataMapper.StudyRelationshipDtoMapper(studyRelationship) : null;
        }

        public async Task<StudyRelationshipDto> CreateStudyRelationship(string sdSid, StudyRelationshipDto studyRelationshipDto)
        {
            var studyRelationship = new StudyRelationship
            {
                SdSid = sdSid,
                CreatedOn = DateTime.Now,
                RelationshipTypeId = studyRelationshipDto.RelationshipTypeId,
                TargetSdSid = studyRelationshipDto.TargetSdSid
            };

            await _dbConnection.StudyRelationships.AddAsync(studyRelationship);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyRelationshipDtoMapper(studyRelationship);
        }

        public async Task<StudyRelationshipDto> UpdateStudyRelationship(StudyRelationshipDto studyRelationshipDto)
        {
            var dbStudyRelationship = await _dbConnection.StudyRelationships.FirstOrDefaultAsync(p => p.Id == studyRelationshipDto.Id);
            if (dbStudyRelationship == null) return null;
            
            dbStudyRelationship.RelationshipTypeId = studyRelationshipDto.RelationshipTypeId;
            dbStudyRelationship.TargetSdSid = studyRelationshipDto.TargetSdSid;
            
            await _dbConnection.SaveChangesAsync();
            return _dataMapper.StudyRelationshipDtoMapper(dbStudyRelationship);
        }

        public async Task<int> DeleteStudyRelationship(int id)
        {
            var data = await _dbConnection.StudyRelationships.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.StudyRelationships.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllStudyRelationships(string sdSid)
        {
            var data = _dbConnection.StudyRelationships.Where(p => p.SdSid == sdSid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.StudyRelationships.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<StudyTitle> GetQueryableStudyTitles()
        {
            return _dbConnection.StudyTitles;
        }

        public async Task<ICollection<StudyTitleDto>> GetStudyTitles(string sdSid)
        {
            var data = _dbConnection.StudyTitles.Where(p => p.SdSid == sdSid);
            return data.Any() ? _dataMapper.StudyTitleDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<StudyTitleDto> GetStudyTitle(int id)
        {
            var studyTitle = await _dbConnection.StudyTitles.FirstOrDefaultAsync(p => p.Id == id);
            return studyTitle != null ? _dataMapper.StudyTitleDtoMapper(studyTitle) : null;
        }

        public async Task<StudyTitleDto> CreateStudyTitle(string sdSid, StudyTitleDto studyTitleDto)
        {
            var studyTitle = new StudyTitle
            {
                SdSid = sdSid,
                CreatedOn = DateTime.Now,
                IsDefault = studyTitleDto.IsDefault,
                LangCode = studyTitleDto.LangCode,
                TitleText = studyTitleDto.TitleText,
                TitleTypeId = studyTitleDto.TitleTypeId,
                LangUsageId = studyTitleDto.LangUsageId,
                Comments = studyTitleDto.Comments
            };

            await _dbConnection.StudyTitles.AddAsync(studyTitle);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyTitleDtoMapper(studyTitle);
        }

        public async Task<StudyTitleDto> UpdateStudyTitle(StudyTitleDto studyTitleDto)
        {
            var dbStudyTitle = await _dbConnection.StudyTitles.FirstOrDefaultAsync(p => p.Id == studyTitleDto.Id);
            if (dbStudyTitle == null) return null;
            
            dbStudyTitle.IsDefault = studyTitleDto.IsDefault;
            dbStudyTitle.LangCode = studyTitleDto.LangCode;
            dbStudyTitle.TitleText = studyTitleDto.TitleText;
            dbStudyTitle.TitleTypeId = studyTitleDto.TitleTypeId;
            dbStudyTitle.LangUsageId = studyTitleDto.LangUsageId;
            dbStudyTitle.Comments = studyTitleDto.Comments;
                
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyTitleDtoMapper(dbStudyTitle);
        }

        public async Task<int> DeleteStudyTitle(int id)
        {
            var data = await _dbConnection.StudyTitles.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.StudyTitles.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllStudyTitles(string sdSid)
        {
            var data = _dbConnection.StudyTitles.Where(p => p.SdSid == sdSid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.StudyTitles.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }

        public IQueryable<StudyTopic> GetQueryableStudyTopics()
        {
            return _dbConnection.StudyTopics;
        }

        public async Task<ICollection<StudyTopicDto>> GetStudyTopics(string sdSid)
        {
            var data = _dbConnection.StudyTopics.Where(p => p.SdSid == sdSid);
            return data.Any() ? _dataMapper.StudyTopicDtoBuilder(await data.ToArrayAsync()) : null;
        }

        public async Task<StudyTopicDto> GetStudyTopic(int id)
        {
            var studyTopic = await _dbConnection.StudyTopics.FirstOrDefaultAsync(p => p.Id == id);
            return studyTopic != null ? _dataMapper.StudyTopicDtoMapper(studyTopic) : null;
        }

        public async Task<StudyTopicDto> CreateStudyTopic(string sdSid, StudyTopicDto studyTopicDto)
        {
            var studyTopic = new StudyTopic
            {
                SdSid = sdSid,
                CreatedOn = DateTime.Now,
                TopicTypeId = studyTopicDto.TopicTypeId,
                MeshCoded = studyTopicDto.MeshCoded,
                MeshCode = studyTopicDto.MeshCode,
                MeshValue = studyTopicDto.MeshValue,
                MeshQualcode = studyTopicDto.MeshQualcode,
                MeshQualvalue = studyTopicDto.MeshQualvalue,
                OriginalCtId = studyTopicDto.OriginalCtId,
                OriginalCtCode = studyTopicDto.OriginalCtCode,
                OriginalValue = studyTopicDto.OriginalValue,
                Comments = studyTopicDto.Comments
            };

            await _dbConnection.StudyTopics.AddAsync(studyTopic);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyTopicDtoMapper(studyTopic);
        }

        public async Task<StudyTopicDto> UpdateStudyTopic(StudyTopicDto studyTopicDto)
        {
            var dbStudyTopic =
                await _dbConnection.StudyTopics.FirstOrDefaultAsync(p => p.Id == studyTopicDto.Id);
            if (dbStudyTopic == null) return null;
            
            dbStudyTopic.TopicTypeId = studyTopicDto.TopicTypeId;
            dbStudyTopic.MeshCoded = studyTopicDto.MeshCoded;
            dbStudyTopic.MeshCode = studyTopicDto.MeshCode;
            dbStudyTopic.MeshValue = studyTopicDto.MeshValue;
            dbStudyTopic.MeshQualcode = studyTopicDto.MeshQualcode;
            dbStudyTopic.MeshQualvalue = studyTopicDto.MeshQualvalue;
            dbStudyTopic.OriginalCtId = studyTopicDto.OriginalCtId;
            dbStudyTopic.OriginalCtCode = studyTopicDto.OriginalCtCode;
            dbStudyTopic.OriginalValue = studyTopicDto.OriginalValue;
            dbStudyTopic.Comments = studyTopicDto.Comments;
                
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyTopicDtoMapper(dbStudyTopic);
        }

        public async Task<int> DeleteStudyTopic(int id)
        {
            var data = await _dbConnection.StudyTopics.FirstOrDefaultAsync(p => p.Id == id);
            if (data == null) return 0;
            _dbConnection.StudyTopics.Remove(data);
            await _dbConnection.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAllStudyTopics(string sdSid)
        {
            var data = _dbConnection.StudyTopics.Where(p => p.SdSid == sdSid);
            if (!data.Any()) return 0;
            
            var count = data.Count();
            _dbConnection.StudyTopics.RemoveRange(data);
            await _dbConnection.SaveChangesAsync();
            return count;
        }


        // STUDY
        public IQueryable<Study> GetQueryableStudies()
        {
            return _dbConnection.Studies;
        }
        
        public async Task<ICollection<StudyDto>> GetAllStudies()
        {
            if (!_dbConnection.Studies.Any()) return null;
            
            var studyResponses = new List<StudyDto>();
            var studiesList = await _dbConnection.Studies.ToArrayAsync();
            foreach (var study in studiesList)
            {
                studyResponses.Add(await StudyBuilder(study));
            }

            return studyResponses;
        }

        public async Task<StudyDto> GetStudyById(string sdSid)
        {
            var study = await _dbConnection.Studies.FirstOrDefaultAsync(s => s.SdSid == sdSid);
            if (study == null) return null;
            
            return await StudyBuilder(study);
        }

        public async Task<StudyDto> CreateStudy(StudyDto studyDto)
        {
            var study = new Study();
            var studyId = 10001;

            var lastRecord = await _dbConnection.Studies.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastRecord != null)
            {
                studyId = lastRecord.Id + 1;
            }
            study.SdSid = studyId.ToString();
            study.CreatedOn = DateTime.Now;

            study.MdrSdSid = null; 
            study.MdrSourceId = null; 

            study.DisplayTitle = studyDto.DisplayTitle;
            study.TitleLangCode = studyDto.TitleLangCode; // ?
            study.BriefDescription = studyDto.BriefDescription;
            study.DataSharingStatement = studyDto.DataSharingStatement;
            study.StudyStartYear = studyDto.StudyStartYear; // ?
            study.StudyStartMonth = studyDto.StudyStartMonth; // ?
            study.StudyTypeId = studyDto.StudyTypeId;
            study.StudyStatusId = studyDto.StudyStatusId;
            study.StudyEnrolment = studyDto.StudyEnrolment; // ?
            study.StudyGenderEligId = studyDto.StudyGenderEligId;
            study.MinAge = studyDto.MinAge;
            study.MinAgeUnitsId = studyDto.MinAge;
            study.MaxAge = studyDto.MaxAge;
            study.MaxAgeUnitsId = studyDto.MaxAgeUnitsId;

            await _dbConnection.Studies.AddAsync(study);
            await _dbConnection.SaveChangesAsync();

            if (studyDto.StudyContributors is { Count: > 0 })
            {
                foreach (var stc in studyDto.StudyContributors)
                {
                    await CreateStudyContributor(studyId.ToString(), stc);
                }
            }
            
            if (studyDto.StudyFeatures is { Count: > 0 })
            {
                foreach (var stf in studyDto.StudyFeatures)
                {
                    await CreateStudyFeature(studyId.ToString(), stf);
                }
            }
            
            if (studyDto.StudyIdentifiers is { Count: > 0 })
            {
                foreach (var sti in studyDto.StudyIdentifiers)
                {
                    await CreateStudyIdentifier(studyId.ToString(), sti);
                }
            }
            
            if (studyDto.StudyReferences is { Count: > 0 })
            {
                foreach (var str in studyDto.StudyReferences)
                {
                    await CreateStudyReference(studyId.ToString(), str);
                }
            }
            
            if (studyDto.StudyRelationships is { Count: > 0 })
            {
                foreach (var str in studyDto.StudyRelationships)
                {
                    await CreateStudyRelationship(studyId.ToString(), str);
                }
            }
            
            if (studyDto.StudyTitles is { Count: > 0 })
            {
                foreach (var stt in studyDto.StudyTitles)
                {
                    await CreateStudyTitle(studyId.ToString(), stt);
                }
            }
            
            if (studyDto.StudyTopics is { Count: > 0 })
            {
                foreach (var stt in studyDto.StudyTopics)
                {
                    await CreateStudyTopic(studyId.ToString(), stt);
                }
            }
            
            return await StudyBuilder(study);
        }

        public async Task<StudyDto> UpdateStudy(StudyDto studyDto)
        {
            var dbStudy = await _dbConnection.Studies.FirstOrDefaultAsync(p => p.SdSid == studyDto.SdSid);
            if (dbStudy == null) return null;
            
            dbStudy.DisplayTitle = studyDto.DisplayTitle;
            dbStudy.TitleLangCode = studyDto.TitleLangCode; // ?
            dbStudy.BriefDescription = studyDto.BriefDescription;
            dbStudy.DataSharingStatement = studyDto.DataSharingStatement;
            dbStudy.StudyStartYear = studyDto.StudyStartYear; // ?
            dbStudy.StudyStartMonth = studyDto.StudyStartMonth; // ?
            dbStudy.StudyTypeId = studyDto.StudyTypeId;
            dbStudy.StudyStatusId = studyDto.StudyStatusId;
            dbStudy.StudyEnrolment = studyDto.StudyEnrolment; // ?
            dbStudy.StudyGenderEligId = studyDto.StudyGenderEligId;
            dbStudy.MinAge = studyDto.MinAge;
            dbStudy.MinAgeUnitsId = studyDto.MinAgeUnitsId;
            dbStudy.MaxAge = studyDto.MaxAge;
            dbStudy.MaxAgeUnitsId = studyDto.MaxAgeUnitsId;

            await _dbConnection.SaveChangesAsync();
            
            return await StudyBuilder(dbStudy);
        }

        public async Task<int> DeleteStudy(string sdSid)
        {
            var dbStudy = await _dbConnection.Studies.FirstOrDefaultAsync(p => p.SdSid == sdSid);
            if (dbStudy == null) return 0;
            
            await DeleteAllStudyContributors(sdSid);
            await DeleteAllStudyFeatures(sdSid);
            await DeleteAllStudyIdentifiers(sdSid);
            await DeleteAllStudyReferences(sdSid);
            await DeleteAllStudyRelationships(sdSid);
            await DeleteAllStudyTitles(sdSid);
            await DeleteAllStudyTopics(sdSid);

            _dbConnection.Studies.Remove(dbStudy);
            await _dbConnection.SaveChangesAsync();
            
            return 1;
        }

        public async Task<ICollection<StudyDataDto>> GetStudiesData()
        {
            if (!_dbConnection.Studies.Any()) return null;
            
            var studyResponses = new List<StudyDataDto>();
            var studiesList = await _dbConnection.Studies.ToArrayAsync();
            studyResponses.AddRange(studiesList.Select(study => _dataMapper.StudyDataDtoMapper(study)));

            return studyResponses;
        }

        public async Task<StudyDataDto> GetStudyData(string sdSid)
        {
            var study = await _dbConnection.Studies.FirstOrDefaultAsync(s => s.SdSid == sdSid);
            return study != null ? _dataMapper.StudyDataDtoMapper(study) : null;
        }

        public async Task<ICollection<StudyDataDto>> GetRecentStudyData(int limit)
        {
            if (!_dbConnection.Studies.Any()) return null;

            var recentStudies = await _dbConnection.Studies.OrderByDescending(p => p.Id).Take(limit).ToArrayAsync();
            return _dataMapper.StudyDataDtoBuilder(recentStudies);
        }

        public async Task<StudyDataDto> CreateStudyData(StudyDataDto studyData)
        {
            var study = new Study();
            var studyId = 10001;

            var lastRecord = await _dbConnection.Studies.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastRecord != null)
            {
                studyId = lastRecord.Id + 1;
            }

            study.SdSid = studyId.ToString();
            study.CreatedOn = DateTime.Now;

            study.MdrSdSid = null; 
            study.MdrSourceId = null; 

            study.DisplayTitle = studyData.DisplayTitle;
            study.TitleLangCode = studyData.TitleLangCode; // ?
            study.BriefDescription = studyData.BriefDescription;
            study.DataSharingStatement = studyData.DataSharingStatement;
            study.StudyStartYear = studyData.StudyStartYear; // ?
            study.StudyStartMonth = studyData.StudyStartMonth; // ?
            study.StudyTypeId = studyData.StudyTypeId;
            study.StudyStatusId = studyData.StudyStatusId;
            study.StudyEnrolment = studyData.StudyEnrolment; // ?
            study.StudyGenderEligId = studyData.StudyGenderEligId;
            study.MinAge = studyData.MinAge;
            study.MinAgeUnitsId = studyData.MinAge;
            study.MaxAge = studyData.MaxAge;
            study.MaxAgeUnitsId = studyData.MaxAgeUnitsId;

            await _dbConnection.Studies.AddAsync(study);
            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyDataDtoMapper(study);
        }
        
        public async Task<StudyDataDto> UpdateStudyData(StudyDataDto studyData)
        {
            var dbStudy = await _dbConnection.Studies.FirstOrDefaultAsync(p => p.SdSid == studyData.SdSid);
            if (dbStudy == null) return null;
            
            dbStudy.DisplayTitle = studyData.DisplayTitle;
            dbStudy.TitleLangCode = studyData.TitleLangCode; // ?
            dbStudy.BriefDescription = studyData.BriefDescription;
            dbStudy.DataSharingStatement = studyData.DataSharingStatement;
            dbStudy.StudyStartYear = studyData.StudyStartYear; // ?
            dbStudy.StudyStartMonth = studyData.StudyStartMonth; // ?
            dbStudy.StudyTypeId = studyData.StudyTypeId;
            dbStudy.StudyStatusId = studyData.StudyStatusId;
            dbStudy.StudyEnrolment = studyData.StudyEnrolment; // ?
            dbStudy.StudyGenderEligId = studyData.StudyGenderEligId;
            dbStudy.MinAge = studyData.MinAge;
            dbStudy.MinAgeUnitsId = studyData.MinAgeUnitsId;
            dbStudy.MaxAge = studyData.MaxAge;
            dbStudy.MaxAgeUnitsId = studyData.MaxAgeUnitsId;

            await _dbConnection.SaveChangesAsync();
            
            return _dataMapper.StudyDataDtoMapper(dbStudy);
        }


        private async Task<StudyDto> StudyBuilder(Study study)
        {
            return new StudyDto()
            {
                Id = study.Id,
                SdSid = study.SdSid,
                MdrSdSid = study.MdrSdSid,
                MdrSourceId = study.MdrSourceId,
                DisplayTitle = study.DisplayTitle,
                TitleLangCode = study.TitleLangCode,
                BriefDescription = study.BriefDescription,
                DataSharingStatement = study.DataSharingStatement,
                StudyStartYear = study.StudyStartYear,
                StudyStartMonth = study.StudyStartMonth,
                StudyTypeId = study.StudyTypeId,
                StudyStatusId = study.StudyStatusId,
                StudyEnrolment = study.StudyEnrolment,
                StudyGenderEligId = study.StudyGenderEligId,
                MinAge = study.MinAge,
                MinAgeUnitsId = study.MinAgeUnitsId,
                MaxAge = study.MaxAge,
                MaxAgeUnitsId = study.MaxAgeUnitsId,
                CreatedOn = study.CreatedOn.ToString(),
                StudyContributors = await GetStudyContributors(study.SdSid),
                StudyFeatures = await GetStudyFeatures(study.SdSid),
                StudyRelationships = await GetStudyRelationships(study.SdSid),
                StudyIdentifiers = await GetStudyIdentifiers(study.SdSid),
                StudyReferences = await GetStudyReferences(study.SdSid),
                StudyTitles = await GetStudyTitles(study.SdSid),
                StudyTopics = await GetStudyTopics(study.SdSid)
            };
        }
    }
}