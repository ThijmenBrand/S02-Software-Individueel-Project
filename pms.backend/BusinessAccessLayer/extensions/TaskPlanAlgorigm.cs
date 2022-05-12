using DataAccessLayer.Models;

namespace BusinessLayer.extensions
{
    public class TaskPlanAlgorigm
    {
        Random rnd = new Random();
        public void planTasks(List<Tasks> tasks, Sprint sprint)
        {
            List<TaskPlanAlgorigmModel> RankedTasks = new List<TaskPlanAlgorigmModel>();
            tasks.ForEach(task => RankedTasks.Add(new TaskPlanAlgorigmModel(task)));
            RankedTasks.Sort();
            RankedTasks.ForEach(task =>
            {
                double estimatedTime = task.ranking * rnd.Next(0, 2);
            });
            
        }
    }

    internal class TaskPlanAlgorigmModel
    {
        public double ranking { get; set; }
        public Tasks task { get; set; }

        public TaskPlanAlgorigmModel(Tasks task)
        {
            this.task = task;
            this.ranking = computeRanking(task.TaskWorkLoad, task.TaskImportance);
        }

        private double computeRanking(int taskWorkload, int taskImportance)
        {
            return (taskWorkload + (taskImportance * 1.3)) / 2;
        }
    }
}
