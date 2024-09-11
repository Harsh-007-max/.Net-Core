using System.Data;

namespace CRUD.Helpers;

public class FillDropdown
{
    public List<T> FIllDropDown<T>(DataTable dataTable) where T : new()
    {
        List<T> dropdownList = new List<T>();
        foreach (DataRow dataRow in dataTable.Rows)
        {
            T item = new T();
            foreach (var prop in typeof(T).GetProperties())
            {
                if (dataTable.Columns.Contains(prop.Name) && dataRow[prop.Name] != DBNull.Value)
                {
                    prop.SetValue(item,Convert.ChangeType(dataRow[prop.Name],prop.PropertyType));
                }
            }
            dropdownList.Add(item);
        }
        return dropdownList;
    }
}