using JobBoard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JobBoard.Persistence.Helpers
{
    public static class ColumnsMap
    {
        public static Dictionary<string, Expression<Func<Job, object>>> CreateColumnsMap()
        {
            return new Dictionary<string, Expression<Func<Job, object>>>
            {
                ["title"] = v => v.Title,
                ["jobboard"] = v => v.JobBoard.JobBoardName,
                ["activationDate"] = v => v.ActivationDate
            };
        }
    }
}
