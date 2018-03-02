using System.Collections.Generic;
using WTM.BLL.DTO;

namespace WTM.BLL.Interfaces
{
    public interface ITaskFileManager
    {
        void CreateTaskFile(TaskFileDTO taskFileDTO);
        TaskFileDTO GetTaskFile(int? id);
        void UpdateTaskFile(TaskFileDTO taskFileDTO);
        void DeleteTaskFile(TaskFileDTO taskFileDTO);
        IEnumerable<TaskFileDTO> GetTaskFiles();
        void Dispose();
    }
}
