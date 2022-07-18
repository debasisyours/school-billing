using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBilling.Data.DataSets
{
    public class InvoiceDataSet: DataSet
    {
        #region Declaration

        public const string TableInvoice = "Invoice";

        public const string IdColumn = "Id";
        public const string ClientIdColumn = "ClientId";
        public const string ClientNameColumn = "ClientName";
        public const string RouteIdColumn = "RouteId";
        public const string RouteNameColumn = "RouteName";
        public const string InvoiceDateColumn = "InvoiceDate";
        public const string StartDateColumn = "StartDate";
        public const string EndDateColumn = "EndDate";
        public const string RouteCostColumn = "RouteCost";
        public const string AideCostColumn = "AideCost";
        public const string PerdiemColumn = "Perdiem";
        public const string DayCountColumn = "DayCount";
        public const string TotalCostColumn = "TotalCost";
        public const string CovidDayCountColumn = "CovidDayCount";
        public const string CovidNotesColumn = "CovidNotes";
        public const string InvoiceNumberColumn = "InvoiceNumber";

        public const string SelectedColumn = "Selected";

        #endregion

        #region Constructor

        public InvoiceDataSet()
        {
            this.Locale = CultureInfo.CurrentCulture;
            this.BuildInvoiceTable();
        }

        #endregion

        #region Private methods

        private void BuildInvoiceTable()
        {
            var table = new DataTable(TableInvoice);
            table.Locale = CultureInfo.CurrentCulture;

            table.Columns.Add(new DataColumn(SelectedColumn, typeof(bool)));
            table.Columns.Add(new DataColumn(IdColumn, typeof(int)));
            table.Columns.Add(new DataColumn(ClientIdColumn, typeof(int)));
            table.Columns.Add(new DataColumn(ClientNameColumn, typeof(string)));
            table.Columns.Add(new DataColumn(RouteIdColumn, typeof(int)));
            table.Columns.Add(new DataColumn(RouteNameColumn, typeof(string)));
            table.Columns.Add(new DataColumn(InvoiceDateColumn, typeof(string)));
            table.Columns.Add(new DataColumn(StartDateColumn, typeof(string)));
            table.Columns.Add(new DataColumn(EndDateColumn, typeof(string)));
            table.Columns.Add(new DataColumn(RouteCostColumn, typeof(decimal)));
            table.Columns.Add(new DataColumn(AideCostColumn, typeof(decimal)));
            table.Columns.Add(new DataColumn(PerdiemColumn, typeof(decimal)));
            table.Columns.Add(new DataColumn(DayCountColumn, typeof(int)));
            table.Columns.Add(new DataColumn(TotalCostColumn, typeof(decimal)));
            table.Columns.Add(new DataColumn(CovidDayCountColumn, typeof(int)));
            table.Columns.Add(new DataColumn(CovidNotesColumn, typeof(string)));
            table.Columns.Add(new DataColumn(InvoiceNumberColumn, typeof(int)));
            this.Tables.Add(table);
        }

        #endregion
    }
}
