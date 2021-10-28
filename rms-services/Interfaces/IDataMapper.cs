using System.Collections.Generic;
using rms_services.DTO;
using rms_services.Models;

namespace rms_services.Interfaces
{
    public interface IDataMapper
    {
        // DTP mappers and builders
        ICollection<AccessPrereqDto> AccessPrereqDtoBuilder(ICollection<AccessPrereq> accessPrereq);
        AccessPrereqDto AccessPrereqDtoMapper(AccessPrereq accessPrereq);

        ICollection<DtaDto> DtaDtoBuilder(ICollection<Dta> dtas);
        DtaDto DtaDtoMapper(Dta dta);

        ICollection<DtpDto> DtpDtoBuilder(ICollection<Dtp> dtps);
        DtpDto DtpDtoMapper(Dtp dtp);

        ICollection<DtpDatasetDto> DtpDatasetDtoBuilder(ICollection<DtpDataset> dtpDatasets);
        DtpDatasetDto DtpDatasetDtoMapper(DtpDataset dtpDataset);

        ICollection<DtpObjectDto> DtpObjectDtoBuilder(ICollection<DtpObject> dtpObjects);
        DtpObjectDto DtpObjectDtoMapper(DtpObject dtpObject);

        ICollection<DtpStudyDto> DtpStudyDtoBuilder(ICollection<DtpStudy> dtpStudies);
        DtpStudyDto DtpStudyDtoMapper(DtpStudy dtpStudy);
        
        
        // DUP mappers and builders
        ICollection<DuaDto> DuaDtoBuilder(ICollection<Dua> duas);
        DuaDto DuaDtoMapper(Dua dua);

        ICollection<DupDto> DupDtoBuilder(ICollection<Dup> dups);
        DupDto DupDtoMapper(Dup dup);

        ICollection<DupObjectDto> DupObjectDtoBuilder(ICollection<DupObject> dupObjects);
        DupObjectDto DupObjectDtoMapper(DupObject dupObject);

        ICollection<DupPrereqDto> DupPrereqDtoBuilder(ICollection<DupPrereq> dupPrereqs);
        DupPrereqDto DupPrereqDtoMapper(DupPrereq dupPrereq);

        ICollection<ProcessNoteDto> ProcessNoteDtoBuilder(ICollection<ProcessNote> processNotes);
        ProcessNoteDto ProcessNoteDtoMapper(ProcessNote processNote);

        ICollection<ProcessPeopleDto> ProcessPeopleDtoBuilder(ICollection<ProcessPeople> processPeople);
        ProcessPeopleDto ProcessPeopleDtoMapper(ProcessPeople processPeople);

        ICollection<SecondaryUseDto> SecondaryUseDtoBuilder(ICollection<SecondaryUse> secondaryUses);
        SecondaryUseDto SecondaryUseDtoMapper(SecondaryUse secondaryUse);
    }
}