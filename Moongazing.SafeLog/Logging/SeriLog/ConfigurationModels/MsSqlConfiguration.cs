using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moongazing.SafeLog.Logging.SeriLog.ConfigurationModels;

public class MsSqlConfiguration
{
    public string ConnectionString { get; set; } = default!;
    public string TableName { get; set; } = default!;
    public bool AutoCreateSqlTable { get; set; }
}
