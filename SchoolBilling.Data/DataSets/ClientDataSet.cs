using System.Data;
using System.Globalization;

namespace SchoolBilling.Data.DataSets
{
    public class ClientDataSet: DataSet
    {
        #region Declaration

        public const string TableClient = "Client";

        public const string IdColumn = "Id";
        public const string NameColumn = "Name";
        public const string IsActiveColumn = "IsActive";
        public const string CreatedOnColumn = "CreatedOn";

        #endregion

        #region Constructor

        public ClientDataSet()
        {
            this.Locale = CultureInfo.CurrentCulture;
            this.BuildClientTable();
        }

        #endregion

        #region Methods

        private void BuildClientTable()
        {
            var table = new DataTable(TableClient);
            table.Locale = CultureInfo.CurrentCulture;

            table.Columns.Add(new DataColumn(IdColumn, typeof(int)));
            table.Columns.Add(new DataColumn(NameColumn, typeof(string)));
            table.Columns.Add(new DataColumn(IsActiveColumn, typeof(bool)));
            table.Columns.Add(new DataColumn(CreatedOnColumn, typeof(string)));

            this.Tables.Add(table);
        }

        #endregion
    }
}
