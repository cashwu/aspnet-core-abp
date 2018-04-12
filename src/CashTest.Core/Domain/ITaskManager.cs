using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;
using CashTest.Entities;

namespace CashTest.Domain
{
    public interface ITaskManager : IDomainService
    {
        void AssignTaskToPerson(Task task, Player player);
    }
}
