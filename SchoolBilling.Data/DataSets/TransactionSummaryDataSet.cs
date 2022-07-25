using System;
using System.Data;
using System.Globalization;

namespace SchoolBilling.Data.DataSets
{
    public class TransactionSummaryDataSet: DataSet
    {
        #region Declarations

        public const string TableSummaryReport = "SummaryReport";

        public const string ClientIdColumn = "ClientId";
        public const string ClientNameColumn = "SchoolName";
        public const string RouteIdColumn = "RouteId";
        public const string RouteNameColumn = "RouteName";
        public const string InvoiceDateColumn = "InvoiceDate";
        public const string RouteCostColumn = "RouteCost";
        public const string AideCostColumn = "AideCost";
        public const string PerDiemColumn = "Perdiem";
        public const string DayCountColumn = "DayCount";
        public const string TotalCostColumn = "TotalCost";

        #endregion

        #region Constructor

        public TransactionSummaryDataSet()
        {
            this.Locale = CultureInfo.CurrentCulture;
            this.BuildTables();
        }

        #endregion

        #region Private methods

        private void BuildTables()
        {
            var table = new DataTable(TableSummaryReport);
            table.Locale = this.Locale;

            table.Columns.Add(new DataColumn
            {
                ColumnName = ClientIdColumn,
                DataType = typeof(int),
                DefaultValue = 0
            });

            table.Columns.Add(new DataColumn
            {
                ColumnName = ClientNameColumn,
                DataType = typeof(string),
                DefaultValue = string.Empty
            });

            table.Columns.Add(new DataColumn
            {
                ColumnName = RouteIdColumn,
                DataType = typeof(int),
                DefaultValue = 0
            });

            table.Columns.Add(new DataColumn
            {
                ColumnName = RouteNameColumn,
                DataType = typeof(string),
                DefaultValue = string.Empty
            });

            table.Columns.Add(new DataColumn
            {
                ColumnName = InvoiceDateColumn,
                DataType = typeof(DateTime),
                DefaultValue = null
            });

            table.Columns.Add(new DataColumn
            {
                ColumnName = RouteCostColumn,
                DataType = typeof(decimal),
                DefaultValue = 0
            });

            table.Columns.Add(new DataColumn
            {
                ColumnName = AideCostColumn,
                DataType = typeof(decimal),
                DefaultValue = 0
            });

            table.Columns.Add(new DataColumn
            {
                ColumnName = PerDiemColumn,
                DataType = typeof(decimal),
                DefaultValue = 0
            });

            table.Columns.Add(new DataColumn
            {
                ColumnName = DayCountColumn,
                DataType = typeof(int),
                DefaultValue = 0
            });

            table.Columns.Add(new DataColumn
            {
                ColumnName = TotalCostColumn,
                DataType = typeof(decimal),
                DefaultValue = 0
            });

            this.Tables.Add(table);
        }

        #endregion
    }
}
