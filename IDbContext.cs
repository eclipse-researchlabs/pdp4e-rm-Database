using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.Database
{
    public interface IDbContext
    {
        int SaveChanges();

        Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade Database { get; }

        EntityEntry Entry(object entity);
    }
}
