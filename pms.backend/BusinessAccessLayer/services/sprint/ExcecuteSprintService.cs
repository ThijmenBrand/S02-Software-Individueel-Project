using DataAccessLayer.Models;
using DataLayer.repos.sprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.services.sprint;

    public class ExcecuteSprintService : IExcecuteSprintService
    {
        private readonly ISprintRepo<Sprint> _repository;

        public ExcecuteSprintService(ISprintRepo<Sprint> _repository)
        {
            this._repository = _repository;
        }

    public async Task<bool> ExcecuteAddSprint(Sprint sprint)
    {
        var res = await _repository.Create(sprint, null);

        if (!res)
            throw new KeyNotFoundException("Something went wrong while adding this sprint");

        return true;
    }

    public IEnumerable<Sprint> ExcecuteGetAllSprintsByProject(int projectId)
    {
        var sprints = _repository.GetAllByProject(projectId);

        if (sprints == null)
            return Enumerable.Empty<Sprint>();

        return sprints;
    }

    public Sprint ExcecuteGetCurrentSprint(int projectId)
    {
        var allSprints = _repository.GetAllByProject(projectId);
        DateTime today = DateTime.Today;

        foreach (Sprint sprint in allSprints)
        {
            DateTime sprintStart = sprint.SprintStart;
            DateTime sprintEnd = sprint.SprintEnd;

            if (today >= sprintStart && today <= sprintEnd)
            {
                return sprint;
            }
        }

        var closestSprint = allSprints.LastOrDefault();
        if(closestSprint is not null)
        {
            foreach (Sprint sprint in allSprints)
            {
                if (sprint.SprintStart > today && sprint.SprintStart < closestSprint.SprintStart)
                {
                    closestSprint = sprint;
                }
            }

            return closestSprint;
        }

        return new Sprint();
    }

    public async Task<Sprint> ExcecuteGetSprintDetails(int sprintId) => await _repository.GetById(sprintId);

    public async Task<bool> ExcecuteUpdateSprint(Sprint sprint)
    {
        await _repository.Update(sprint);
        return true;
    }
}
