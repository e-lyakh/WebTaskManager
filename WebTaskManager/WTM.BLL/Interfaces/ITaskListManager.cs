using System.Collections.Generic;
using WTM.BLL.DTO;

namespace WTM.BLL.Interfaces
{
    public interface ITaskListManager
    {
        void CreateTaskList(TaskListDTO taskListDTO);
        TaskListDTO GetTaskList(int? id);
        void UpdateTaskList(TaskListDTO taskListDTO);
        void DeleteTaskList(TaskListDTO taskListDTO);
        IEnumerable<TaskListDTO> GetTaskLists();
        void Dispose();
    }
}