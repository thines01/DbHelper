using System;
using System.Collections.Generic;
using System.Data.Common;

namespace DbHelper
{
   public partial class CDbHelper
   {
      public static bool Store<T, U, V, W>(List<T> master, U cmdInsert, V cmdDelete, List<string> lst_strParams, W conn,
         Func<U, T, List<string>, DbCommand> fnParamFiller, ref string strError)
         where U : DbCommand
         where V : DbCommand
         where W : DbConnection
      {
         bool blnRetVal = true;

         try
         {
            using (conn)
            {
               conn.Open();

               using (DbTransaction trans = conn.BeginTransaction())
               {
                  cmdDelete.Transaction = trans;
                  cmdInsert.Transaction = trans;

                  try
                  {
                     cmdDelete.ExecuteNonQuery();
                  }
                  catch (Exception)
                  { }

                  master.ForEach(obj => fnParamFiller(cmdInsert, obj, lst_strParams).ExecuteNonQuery());
                  trans.Commit();
               }
               //
               conn.Close();
            }
         }
         catch (Exception exc)
         {
            blnRetVal = false;
            strError = exc.Message;
         }

         return blnRetVal;
      }
   }
}