using System;
using Projektsystem.AppService.Context;
using Projektsystem.AppService.Repository;
using Projektsystem.Model;

namespace Projektsystem.AppService.Services
{
	public class AuditLogService : IAuditLogRepository
    {

        private readonly AppDbContext _dbContext;

        public AuditLogService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AuditLog GetById(Guid id)
        {
            return _dbContext.AuditLog.Find(id);
        }

        public IEnumerable<AuditLog> GetAll()
        {
            return _dbContext.AuditLog.ToList();
        }

        public void Add(AuditLog user)
        {
            _dbContext.AuditLog.Add(user);
            _dbContext.SaveChanges();
        }

        public void Update(AuditLog user)
        {
            _dbContext.AuditLog.Update(user);
            _dbContext.SaveChanges();
        }

        public void Delete(AuditLog user)
        {
            _dbContext.AuditLog.Remove(user);
            _dbContext.SaveChanges();
        }

        public string GetUserLastLogin(Guid guid)
        {
          var loginEvent =  _dbContext.AuditLog.Where(i => i.ForId == guid && i.EventEnum == LogEventType.Login)
                .OrderByDescending(i => i.EventTime).Skip(1).Take(1).FirstOrDefault();
            if (loginEvent == null)
            {
                return "N/a";
            }
            return loginEvent.EventTime.ToString();
        } 
    }
}

