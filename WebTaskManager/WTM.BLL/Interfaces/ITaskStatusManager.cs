using System.Collections.Generic;
using WTM.BLL.DTO;

namespace WTM.BLL.Interfaces
{
    public interface ITaskStatusManager
    {
        void CreateTaskStatus(TaskStatusDTO taskStatusDTO);
        TaskStatusDTO GetTaskStatus(int? id);
        void UpdateTaskStatus(TaskStatusDTO taskStatusDTO);
        void DeleteTaskStatus(TaskStatusDTO taskStatusDTO);
        IEnumerable<TaskStatusDTO> GetTaskStatuss();
        void Dispose();
    }
}
