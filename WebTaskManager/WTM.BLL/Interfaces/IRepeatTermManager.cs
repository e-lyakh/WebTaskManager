using System.Collections.Generic;
using WTM.BLL.DTO;

namespace WTM.BLL.Interfaces
{
    public interface IRepeatTermManager
    {
        void CreateRepeatTerm(RepeatTermDTO repeatTermDTO);
        RepeatTermDTO GetRepeatTerm(int? id);
        void UpdateRepeatTerm(RepeatTermDTO repeatTermDTO);
        void DeleteRepeatTerm(RepeatTermDTO repeatTermDTO);
        IEnumerable<RepeatTermDTO> GetRepeatTerms();
        void Dispose();
    }
}
