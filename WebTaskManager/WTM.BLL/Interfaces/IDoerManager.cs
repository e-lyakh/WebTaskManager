using System.Collections.Generic;
using WTM.BLL.DTO;

namespace WTM.BLL.Interfaces
{
    public interface IDoerManager
    {
        void CreateDoer(DoerDTO doerDTO);
        DoerDTO GetDoer(int? id);
        void UpdateDoer(DoerDTO doerDTO);
        void DeleteDoer(DoerDTO doerDTO);
        IEnumerable<DoerDTO> GetDoers();
        void Dispose();
    }
}
