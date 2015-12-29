using System.Collections.Generic;
using Capitalism.Models.Interfaces;

namespace Capitalism.Interfaces
{
    public interface IDatabase
    {
        IEnumerable<IOrganizationalUnit> Companies { get; }
        void AddCompany(IOrganizationalUnit company);
    }
}