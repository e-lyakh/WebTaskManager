using System.Collections.Generic;
using WTM.BLL.DTO;

namespace WTM.BLL.Interfaces
{
    public interface IListFilterManager
    {
        void CreateListFilter(ListFilterDTO listFilterDTO);
        ListFilterDTO GetListFilter(int? id);
        void UpdateListFilter(ListFilterDTO listFilterDTO);
        void DeleteListFilter(ListFilterDTO listFilterDTO);
        IEnumerable<ListFilterDTO> GetListFilters();
        void Dispose();
    }
}