using System;
using System.Data.Common;

namespace DbHelper
{
   public partial class CDbHelper
   {
      protected static void DoAdd<T>(T cmd, string strParam, Func<string, DbParameter> AddParam) where T : DbCommand
      {
         cmd.Parameters.Add(AddParam(strParam));
      }
   }
}