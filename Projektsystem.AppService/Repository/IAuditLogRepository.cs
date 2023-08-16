using System;
using Projektsystem.Model;

namespace Projektsystem.AppService.Repository
{
	public interface IAuditLogRepository
    {
        public AuditLog GetById(Guid id);
        public IEnumerable<AuditLog> GetAll();
        public void Add(AuditLog auditLog);
        public void Update(AuditLog auditLog);
        public void Delete(AuditLog auditLog);
        public string GetUserLastLogin(Guid guid);
    }
}

