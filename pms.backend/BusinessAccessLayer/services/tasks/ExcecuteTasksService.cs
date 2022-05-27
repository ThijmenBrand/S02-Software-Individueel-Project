using BusinessLayer.services.tasks.DataModels;
using DataAccessLayer.Models;
using DataLayer.repos.task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.services.tasks;

public class ExcecuteTasksService : IExcecuteTasksService
{
    private readonly ITasksRepo<Tasks> _repository;

    public ExcecuteTasksService(ITasksRepo<Tasks> _repository)
    {
        this._repository = _repository;
    }

    public async Task<bool> ExcecuteCreateTask(Tasks task) => await _repository.Create(task, null);

    public async Task<IEnumerable<Tasks>> ExcecuteGetTasksByProjectBySprint(int sprintId) => await _repository.GetTasksBySprint(sprintId);

    public async Task<IEnumerable<SprintView>> ExcecuteGetTasksByProjectModeledToSprintData(int sprintId)
    {
        var tasks = await _repository.GetTasksBySprint(sprintId);
        List<SprintView> sprintViewList = new List<SprintView>();

        foreach (var task in tasks)
        {
            Item item = new Item(id: task.TaskId, start: task.TaskStartTime, end: task.TaskEndTime);
            Group group = new Group(id: task.TaskId, content: task.TaskName);

            SprintView sprintListItem = new SprintView(group: group, item: item);


            sprintViewList.Add(sprintListItem);
        }

        return sprintViewList;
    }

    public async Task<bool> ExcecuteUpdateTaskTag(int taskId, string taskTag) => await _repository.UpdateTaskTag(taskId, taskTag);

    public async Task<bool> ExcecuteUpdateTask(Tasks task)
    {
        await _repository.Update(task);
        return true;
    }

    public void ExcecuteDeleteTask(int taskId) => _repository.Delete(taskId);

    public IEnumerable<Tasks> ExcecuteGetAllTasksByProject(int projectId)
    {
        var tasks = _repository.GetAllTasks(projectId).ToList();
        var plannedTasks = new List<Tasks>();

        foreach (var task in tasks)
        {
            if (task.TaskStartTime >= Convert.ToDateTime("2000-01-01 00:00:00.0000000"))
            {
                plannedTasks.Add(task);
            }
        }
        return plannedTasks;
    }

    public async Task<Tasks> ExcecuteGetTaskById(int taskId) => await _repository.GetById(taskId);
}
