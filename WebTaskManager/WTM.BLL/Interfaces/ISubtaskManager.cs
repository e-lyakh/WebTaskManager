using System.Collections.Generic;
using WTM.BLL.DTO;

namespace WTM.BLL.Interfaces
{
    public interface ISubtaskManager
    {
        void CreateSubtask(SubtaskDTO subtaskDTO);
        SubtaskDTO GetSubtask(int? id);
        void UpdateSubtask(SubtaskDTO subtaskDTO);
        void DeleteSubtask(SubtaskDTO subtaskDTO);
        IEnumerable<SubtaskDTO> GetSubtasks();
        void Dispose();
    }
}
