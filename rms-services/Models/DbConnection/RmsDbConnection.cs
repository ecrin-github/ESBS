using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;

namespace rms_services.Models.DbConnection
{
    public class RmsDbConnection : DataConnection
    {
        public RmsDbConnection(LinqToDbConnectionOptions<RmsDbConnection> options) 
            : base(options)
        {
            
        }

        public ITable<AccessPrereq> AccessPrereqs => GetTable<AccessPrereq>();
        public ITable<Dta> Dtas => GetTable<Dta>();
        public ITable<Dtp> Dtps => GetTable<Dtp>();
        public ITable<DtpDataset> DtpDatasets => GetTable<DtpDataset>();
        public ITable<DtpObject> DtpObjects => GetTable<DtpObject>();
        public ITable<DtpStudy> DtpStudies => GetTable<DtpStudy>();
        public ITable<Dua> Duas => GetTable<Dua>();
        public ITable<Dup> Dups => GetTable<Dup>();
        public ITable<DupObject> DupObjects => GetTable<DupObject>();
        public ITable<DupPrereq> DupPrereqs => GetTable<DupPrereq>();
        public ITable<ProcessNote> ProcessNotes => GetTable<ProcessNote>();
        public ITable<ProcessPeople> ProcessPeople => GetTable<ProcessPeople>();
        public ITable<SecondaryUse> SecondaryUses => GetTable<SecondaryUse>();
    }
}