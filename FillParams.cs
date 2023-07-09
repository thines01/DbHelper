using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace DbHelper
{
   public partial class CDbHelper
   {
      public static T FillParams<T>(T cmd, Dictionary<string, string> map) where T: DbCommand
      {
         map.ToList().ForEach(kvp => cmd.Parameters[kvp.Key].Value = DbEnsure(kvp.Value));
         return cmd;
      }
   }
}
