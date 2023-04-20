namespace DummyApi.Model
{
    public class UserAuditcheck
    {
        public Guid userAuditCheckID { get; set; }
        public bool isActive { get; set; }
        public bool isUpdated { get; set; }
        public string userProficiencyCode { get; set; }
        public string userProficiencyName { get; set; }
        public Guid auditCheckID { get; set; }
    }
}
