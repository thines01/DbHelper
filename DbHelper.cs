using System;
using System.Collections.Generic;
using System.Linq;

namespace DbHelper
{
   public partial class CDbHelper
   {
      private static string _strParamChar = "@";
      private static readonly Func<List<string>, string> colsWithoutParams = (lst) => string.Join(",", lst.Select(s => s.Replace(_strParamChar, "")).ToArray());
      private static readonly Func<List<string>, string> colsWithParams = (lst) => string.Join(",", lst.ToArray());

      public static Func<string, string> GetDeleteSql = (strTable) =>
         string.Format("DELETE FROM [{0}]", strTable);

      public static Func<string, List<string>, string> GetSelectSql = (strTable, lst_strCols) =>
         string.Format("SELECT {0} FROM [{1}]", colsWithoutParams(lst_strCols), strTable);

      public static Func<string, List<string>, string> GetInsertSql = (strTable, lst_strCols) =>
         string.Format("INSERT INTO [{0}] ({1}) VALUES({2})", strTable,
         colsWithoutParams(lst_strCols),
         colsWithParams(lst_strCols));

      protected string _strTableName { get; set; }
      protected string _strDeleteSQL { get; set; }
      protected string _strSelectSQL { get; set; }
      protected string _strInsertSQL { get; set; }

      public CDbHelper(string strPrefixChar, string strTableName, List<string> lst_strColumns)
      {
         _strParamChar = strPrefixChar;
         _strTableName = strTableName;
         _strDeleteSQL = GetDeleteSql(strTableName);
         _strSelectSQL = GetSelectSql(strTableName, lst_strColumns);
         _strInsertSQL = GetInsertSql(strTableName, lst_strColumns);
      }
   }
}