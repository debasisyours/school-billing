using System.Data;
using System.Globalization;

namespace SchoolBilling.Data.DataSets
{
    public class RouteDataSet: DataSet
    {
        #region Declaration

        public const string TableRoute = "Route";

        public const string IdColumn = "Id";
        public const string NameColumn = "Name";
        public const string RouteCostColumn = "RouteCost";
        public const string AidCostColumn = "AidCost";

        #endregion

        #region Constructor

        public RouteDataSet()
        {
            this.Locale = CultureInfo.CurrentCulture;
            this.BuildRouteTable();
        }

        #endregion

        #region Private methods

        private void BuildRouteTable()
        {
            var table = new DataTable(TableRoute);
            table.Locale = CultureInfo.CurrentCulture;

            table.Columns.Add(new DataColumn(IdColumn, typeof(int)));
            table.Columns.Add(new DataColumn(NameColumn, typeof(string)));
            table.Columns.Add(new DataColumn(RouteCostColumn, typeof(decimal)));
            table.Columns.Add(new DataColumn(AidCostColumn, typeof(decimal)));

            this.Tables.Add(table);
        }

        #endregion
    }
}
