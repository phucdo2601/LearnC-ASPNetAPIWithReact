using System.Collections.Generic;
using System.Linq;

namespace Tools
{
    public enum SortOrder { Ascending = 0, Descending = 1 }

    public class SortModel
    {
        private string UpIcon = "fa fa-arrow-up";
        private string DownIcon = "fa fa-arrow-down";

        public string SortedProperty { get; set; }

        public SortOrder SortedOrder { get; set; }

        private List<SortableColumn> sortableColumns = new List<SortableColumn>();

        public void AddColumn(string colName, bool isDefaultColumn = false)
        {
            SortableColumn tmp = sortableColumns.Where(c => c.ColumnName.ToLower().Equals(colName.ToLower())).SingleOrDefault();

            if (tmp == null)
            {
                sortableColumns.Add(new SortableColumn() { ColumnName = colName });
            }

            if (isDefaultColumn == true || sortableColumns.Count == 1)
            {
                SortedProperty = colName;
                SortedOrder = SortOrder.Ascending;
            }
        }

        public SortableColumn GetColumn(string colName)
        {
            SortableColumn tmp = sortableColumns.Where(c => c.ColumnName.ToLower().Equals(colName.ToLower())).SingleOrDefault();

            if (tmp == null)
            {
                sortableColumns.Add(new SortableColumn() { ColumnName = colName });
            }
            return tmp;
        }

        public void ApplySort(string sortExpression)
        {

            if (sortExpression == "")
            {
                sortExpression = SortedProperty;
            }

            sortExpression = sortExpression.ToLower();

            foreach (SortableColumn sortableColumn in sortableColumns)
            {
                sortableColumn.SortIcon = "";
                sortableColumn.SortExpression = sortableColumn.ColumnName;

                if (sortExpression == sortableColumn.ColumnName)
                {
                    SortedOrder = SortOrder.Ascending;
                    SortedProperty = sortableColumn.ColumnName;

                    sortableColumn.SortIcon = DownIcon;
                    sortableColumn.SortExpression = sortableColumn.ColumnName + "_desc";
                }

                if (sortExpression == sortableColumn.ColumnName.ToLower() + "_desc")
                {
                    SortedOrder = SortOrder.Descending;
                    SortedProperty = sortableColumn.ColumnName;

                    sortableColumn.SortIcon = UpIcon;
                    sortableColumn.SortExpression = sortableColumn.ColumnName;
                }

            }
        }
    }

    public class SortableColumn
    {
        public string ColumnName { get; set; }
        public string SortExpression { get; set; }
        public string SortIcon { get; set; }
    }
}
