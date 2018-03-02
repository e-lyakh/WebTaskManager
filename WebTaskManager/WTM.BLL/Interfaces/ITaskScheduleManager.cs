using System.Collections.Generic;
using WTM.BLL.DTO;

namespace WTM.BLL.Interfaces
{
    public interface ITaskScheduleManager
    {
        void CreateTaskSchedule(TaskScheduleDTO taskScheduleDTO);
        TaskScheduleDTO GetTaskSchedule(int? id);
        void UpdateTaskSchedule(TaskScheduleDTO taskScheduleDTO);
        void DeleteTaskSchedule(TaskScheduleDTO taskScheduleDTO);
        IEnumerable<TaskScheduleDTO> GetTaskSchedules();
        void Dispose();
    }
}
