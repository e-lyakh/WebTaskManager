using System.Collections.Generic;
using WTM.BLL.DTO;

namespace WTM.BLL.Interfaces
{
    public interface ITaskPriorityManager
    {
        void CreateTaskPriority(TaskPriorityDTO taskPriorityDTO);
        TaskPriorityDTO GetTaskPriority(int? id);
        void UpdateTaskPriority(TaskPriorityDTO taskPriorityDTO);
        void DeleteTaskPriority(TaskPriorityDTO taskPriorityDTO);
        IEnumerable<TaskPriorityDTO> GetTaskPrioritys();
        void Dispose();
    }
}
