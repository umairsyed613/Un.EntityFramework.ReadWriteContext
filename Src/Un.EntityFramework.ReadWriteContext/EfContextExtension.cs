using System;
using Microsoft.EntityFrameworkCore;

namespace Un.EntityFramework.ReadWriteContext
{
    public static class EfContextExtension
    {
        public static void GetReadyOnlyAsNoTracking(this DbContext context)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }

            context.ChangeTracker.AutoDetectChangesEnabled = false;
            context.ChangeTracker.LazyLoadingEnabled = false;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
