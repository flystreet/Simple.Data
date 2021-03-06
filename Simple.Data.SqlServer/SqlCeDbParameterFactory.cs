﻿namespace Simple.Data.SqlServer
{
    using System.ComponentModel.Composition;
    using System.Data;
    using System.Data.SqlClient;
    using Ado;
    using Ado.Schema;

    [Export(typeof(IDbParameterFactory))]
    public class SqlDbParameterFactory : IDbParameterFactory
    {
        public IDbDataParameter CreateParameter(string name, Column column)
        {
            var sqlColumn = (SqlColumn) column;
            return new SqlParameter(name, sqlColumn.SqlDbType, column.MaxLength, column.ActualName);
        }

        public IDbDataParameter CreateParameter(string name, DbType dbType, int maxLength)
        {
            IDbDataParameter parameter = new SqlParameter
                       {
                           ParameterName = name,
                           Size = maxLength
                       };
            parameter.DbType = dbType;
            return parameter;
        }
    }
}