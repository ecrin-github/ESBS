using System.Collections.Generic;
using System.Linq;
using rms_services.DTO;
using rms_services.Interfaces;
using rms_services.Models;

namespace rms_services.Helpers
{
    public class DataMapper : IDataMapper
    {
        public ICollection<DtaDto> DtaDtoBuilder(ICollection<Dta> dtas)
        {
            return dtas is not { Count: > 0 } ? null : dtas.Select(DtaDtoMapper).ToList();
        }

        public DtaDto DtaDtoMapper(Dta dta)
        {
            if (dta == null) return null;
            
            var dtaDto = new DtaDto
            {
                Id = dta.Id,
                DtpId = dta.DtpId,
                CreatedOn = dta.CreatedOn,
                ConformsToDefault = dta.ConformsToDefault,
                Variations = dta.Variations,
                RepoSignatory1 = dta.RepoSignatory1,
                RepoSignatory2 = dta.RepoSignatory2,
                ProviderSignatory1 = dta.ProviderSignatory1,
                ProviderSignatory2 = dta.ProviderSignatory2,
                Notes = dta.Notes
            };

            return dtaDto;
        }

        public ICollection<DtpDto> DtpDtoBuilder(ICollection<Dtp> dtps)
        {
            return dtps is not { Count: > 0 } ? null : dtps.Select(DtpDtoMapper).ToList();
        }

        public DtpDto DtpDtoMapper(Dtp dtp)
        {
            if (dtp == null) return null;
            
            var dtpDto = new DtpDto
            {
                Id = dtp.Id,
                CreatedOn = dtp.CreatedOn,
                OrgId = dtp.OrgId,
                DisplayName = dtp.DisplayName,
                StatusId = dtp.StatusId,
                InitialContactDate = dtp.InitialContactDate,
                SetUpCompleted = dtp.SetUpCompleted,
                MdAccessGranted = dtp.MdAccessGranted,
                MdCompleteDate = dtp.MdCompleteDate,
                DtaAgreedDate = dtp.DtaAgreedDate,
                UploadAccessRequested = dtp.UploadAccessRequested,
                UploadAccessConfirmed = dtp.UploadAccessConfirmed,
                UploadsComplete = dtp.UploadsComplete,
                QcChecksCompleted = dtp.QcChecksCompleted,
                MdIntegratedWithMdr = dtp.MdIntegratedWithMdr,
                AvailabilityRequested = dtp.AvailabilityRequested,
                AvailabilityConfirmed = dtp.AvailabilityConfirmed
            };

            return dtpDto;
        }

        public ICollection<DtpDatasetDto> DtpDatasetDtoBuilder(ICollection<DtpDataset> dtpDatasets)
        {
            return dtpDatasets is not { Count: > 0 } ? null : dtpDatasets.Select(DtpDatasetDtoMapper).ToList();
        }

        public DtpDatasetDto DtpDatasetDtoMapper(DtpDataset dtpDataset)
        {
            if (dtpDataset == null) return null;
            
            var dtpDatasetDto = new DtpDatasetDto
            {
                Id = dtpDataset.Id,
                ObjectId = dtpDataset.ObjectId,
                CreatedOn = dtpDataset.CreatedOn,
                LegalStatusId = dtpDataset.LegalStatusId,
                LegalStatusText = dtpDataset.LegalStatusText,
                LegalStatusPath = dtpDataset.LegalStatusPath,
                DescmdCheckBy = dtpDataset.DescmdCheckBy,
                DescmdCheckDate = dtpDataset.DescmdCheckDate,
                DescmdCheckStatusId = dtpDataset.DescmdCheckStatusId,
                DeidentCheckBy = dtpDataset.DeidentCheckBy,
                DeidentCheckDate = dtpDataset.DeidentCheckDate,
                DeidentCheckStatusId = dtpDataset.DeidentCheckStatusId,
                Notes = dtpDataset.Notes
            };

            return dtpDatasetDto;
        }

        public ICollection<DtpObjectDto> DtpObjectDtoBuilder(ICollection<DtpObject> dtpObjects)
        {
            return dtpObjects is not { Count: > 0 } ? null : dtpObjects.Select(DtpObjectDtoMapper).ToList();
        }

        public DtpObjectDto DtpObjectDtoMapper(DtpObject dtpObject)
        {
            if (dtpObject == null) return null;
            
            var dtpObjectDto = new DtpObjectDto
            {
                Id = dtpObject.Id,
                DtpId = dtpObject.DtpId,
                ObjectId = dtpObject.ObjectId,
                CreatedOn = dtpObject.CreatedOn,
                IsDataset = dtpObject.IsDataset,
                AccessTypeId = dtpObject.AccessTypeId,
                DownloadAllowed = dtpObject.DownloadAllowed,
                AccessDetails = dtpObject.AccessDetails,
                RequiresEmbargoPeriod = dtpObject.RequiresEmbargoPeriod,
                EmbargoEndDate = dtpObject.EmbargoEndDate,
                EmbargoStillApplies = dtpObject.EmbargoStillApplies,
                AccessCheckStatusId = dtpObject.AccessCheckStatusId,
                AccessCheckDate = dtpObject.AccessCheckDate,
                AccessCheckBy = dtpObject.AccessCheckBy,
                MdCheckStatusId = dtpObject.MdCheckStatusId,
                MdCheckBy = dtpObject.MdCheckBy,
                MdCheckDate = dtpObject.MdCheckDate,
                Notes = dtpObject.Notes
            };

            return dtpObjectDto;
        }

        public ICollection<DtpStudyDto> DtpStudyDtoBuilder(ICollection<DtpStudy> dtpStudies)
        {
            return dtpStudies is not { Count: > 0 } ? null : dtpStudies.Select(DtpStudyDtoMapper).ToList();
        }

        public DtpStudyDto DtpStudyDtoMapper(DtpStudy dtpStudy)
        {
            if (dtpStudy == null) return null;
            
            var dtpStudyDto = new DtpStudyDto
            {
                Id = dtpStudy.Id,
                DtpId = dtpStudy.DtpId,
                StudyId = dtpStudy.StudyId,
                CreatedOn = dtpStudy.CreatedOn,
                MdCheckStatusId = dtpStudy.MdCheckStatusId,
                MdCheckBy = dtpStudy.MdCheckBy,
                MdCheckDate = dtpStudy.MdCheckDate
            };

            return dtpStudyDto;
        }

        public ICollection<DuaDto> DuaDtoBuilder(ICollection<Dua> duas)
        {
            return duas is not { Count: > 0 } ? null : duas.Select(DuaDtoMapper).ToList();
        }

        public DuaDto DuaDtoMapper(Dua dua)
        {
            if (dua == null) return null;
            
            var duaDto = new DuaDto
            {
                Id = dua.Id,
                DupId = dua.DupId,
                CreatedOn = dua.CreatedOn,
                ConformsToDefault = dua.ConformsToDefault,
                Variations = dua.Variations,
                RepoAsProxy = dua.RepoAsProxy,
                RepoSignatory1 = dua.RepoSignatory1,
                RepoSignatory2 = dua.RepoSignatory2,
                ProviderSignatory1 = dua.ProviderSignatory1,
                ProviderSignatory2 = dua.ProviderSignatory2,
                RequesterSignatory1 = dua.RequesterSignatory1,
                RequesterSignatory2 = dua.RequesterSignatory2,
                Notes = dua.Notes
            };

            return duaDto;
        }

        public ICollection<DupDto> DupDtoBuilder(ICollection<Dup> dups)
        {
            return dups is not { Count: > 0 } ? null : dups.Select(DupDtoMapper).ToList();
        }

        public DupDto DupDtoMapper(Dup dup)
        {
            if (dup == null) return null;
            
            var dupDto = new DupDto
            {
                Id = dup.Id,
                CreatedOn = dup.CreatedOn,
                OrgId = dup.OrgId,
                DisplayName = dup.DisplayName,
                StatusId = dup.StatusId,
                InitialContactDate = dup.InitialContactDate,
                SetUpCompleted = dup.SetUpCompleted,
                PrereqsMet = dup.PrereqsMet,
                DuaAgreedDate = dup.DuaAgreedDate,
                AvailabilityRequested = dup.AvailabilityRequested,
                AvailabilityConfirmed = dup.AvailabilityConfirmed,
                AccessConfirmed = dup.AccessConfirmed
            };

            return dupDto;
        }

        public ICollection<DupObjectDto> DupObjectDtoBuilder(ICollection<DupObject> dupObjects)
        {
            return dupObjects is not { Count: > 0 } ? null : dupObjects.Select(DupObjectDtoMapper).ToList();
        }

        public DupObjectDto DupObjectDtoMapper(DupObject dupObject)
        {
            if (dupObject == null) return null;
            
            var dupObjectDto = new DupObjectDto
            {
                Id = dupObject.Id,
                DupId = dupObject.DupId,
                CreatedOn = dupObject.CreatedOn,
                ObjectId = dupObject.ObjectId,
                AccessTypeId = dupObject.AccessTypeId,
                AccessDetails = dupObject.AccessDetails,
                Notes = dupObject.Notes
            };

            return dupObjectDto;
        }

        public ICollection<DupPrereqDto> DupPrereqDtoBuilder(ICollection<DupPrereq> dupPrereqs)
        {
            return dupPrereqs is not { Count: > 0 } ? null : dupPrereqs.Select(DupPrereqDtoMapper).ToList();
        }

        public DupPrereqDto DupPrereqDtoMapper(DupPrereq dupPrereq)
        {
            if (dupPrereq == null) return null;
            
            var dupPrereqDto = new DupPrereqDto
            {
                Id = dupPrereq.Id,
                DupId = dupPrereq.DupId,
                CreatedOn = dupPrereq.CreatedOn,
                ObjectId = dupPrereq.ObjectId,
                MetNotes = dupPrereq.MetNotes,
                PreRequisiteId = dupPrereq.PreRequisiteId,
                PrerequisiteMet = dupPrereq.PrerequisiteMet
            };

            return dupPrereqDto;
        }
        
        public ICollection<SecondaryUseDto> SecondaryUseDtoBuilder(ICollection<SecondaryUse> secondaryUses)
        {
            return secondaryUses is not { Count: > 0 } ? null : secondaryUses.Select(SecondaryUseDtoMapper).ToList();
        }

        public SecondaryUseDto SecondaryUseDtoMapper(SecondaryUse secondaryUse)
        {
            if (secondaryUse == null) return null;
            
            var secondaryUseDto = new SecondaryUseDto
            {
                Id = secondaryUse.Id,
                DupId = secondaryUse.DupId,
                CreatedOn = secondaryUse.CreatedOn,
                SecondaryUseType = secondaryUse.SecondaryUseType,
                Publication = secondaryUse.Publication,
                Doi = secondaryUse.Doi,
                AttributionPresent = secondaryUse.AttributionPresent,
                Notes = secondaryUse.Notes
            };

            return secondaryUseDto;
        }
        
        
        
        public ICollection<AccessPrereqDto> AccessPrereqDtoBuilder(ICollection<AccessPrereq> accessPrereq)
        {
            return accessPrereq is not { Count: > 0 } ? null : accessPrereq.Select(AccessPrereqDtoMapper).ToList();
        }

        public AccessPrereqDto AccessPrereqDtoMapper(AccessPrereq accessPrereq)
        {
            if (accessPrereq == null) return null;
            
            var accessPrereqDto = new AccessPrereqDto
            {
                Id = accessPrereq.Id,
                ObjectId = accessPrereq.ObjectId,
                PreRequisiteId = accessPrereq.PreRequisiteId,
                PreRequisiteNotes = accessPrereq.PreRequisiteNotes,
                CreatedOn = accessPrereq.CreatedOn
            };
            return accessPrereqDto;
        }
        
        public ICollection<ProcessNoteDto> ProcessNoteDtoBuilder(ICollection<ProcessNote> processNotes)
        {
            return processNotes is not { Count: > 0 } ? null : processNotes.Select(ProcessNoteDtoMapper).ToList();
        }

        public ProcessNoteDto ProcessNoteDtoMapper(ProcessNote processNote)
        {
            if (processNote == null) return null;
            
            var processNoteDto = new ProcessNoteDto
            {
                Id = processNote.Id,
                ProcessId = processNote.ProcessId,
                ProcessType = processNote.ProcessType,
                CreatedOn = processNote.CreatedOn
            };
            return processNoteDto;
        }

        public ICollection<ProcessPeopleDto> ProcessPeopleDtoBuilder(ICollection<ProcessPeople> processPeople)
        {
            return processPeople is not { Count: > 0 } ? null : processPeople.Select(ProcessPeopleDtoMapper).ToList();
        }

        public ProcessPeopleDto ProcessPeopleDtoMapper(ProcessPeople processPeople)
        {
            if (processPeople == null) return null;
            
            var processPeopleDto = new ProcessPeopleDto
            {
                Id = processPeople.Id,
                PersonId = processPeople.PersonId,
                ProcessId = processPeople.ProcessId,
                ProcessType = processPeople.ProcessType,
                IsAUser = processPeople.IsAUser,
                CreatedOn = processPeople.CreatedOn
            };
            return processPeopleDto;
        }
    }
}