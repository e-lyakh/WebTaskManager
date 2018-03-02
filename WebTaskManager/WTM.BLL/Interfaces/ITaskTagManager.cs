using System.Collections.Generic;
using WTM.BLL.DTO;

namespace WTM.BLL.Interfaces
{
    public interface ITaskTagManager
    {
        void CreateTaskTag(TaskTagDTO taskTagDTO);
        TaskTagDTO GetTaskTag(int? id);
        void UpdateTaskTag(TaskTagDTO taskTagDTO);
        void DeleteTaskTag(TaskTagDTO taskTagDTO);
        IEnumerable<TaskTagDTO> GetTaskTags();
        void Dispose();
    }
}
