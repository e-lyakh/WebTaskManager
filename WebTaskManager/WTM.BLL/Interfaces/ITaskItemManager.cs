using System.Collections.Generic;
using WTM.BLL.DTO;

namespace WTM.BLL.Interfaces
{
    public interface ITaskItemManager
    {
        void CreateTaskItem(TaskItemDTO taskItemDTO);
        TaskItemDTO GetTaskItem(int? id);
        void UpdateTaskItem(TaskItemDTO taskItemDTO);
        void DeleteTaskItem(TaskItemDTO taskItemDTO);
        IEnumerable<TaskItemDTO> GetTaskItems();
        void Dispose();
    }
}