import SprintModel from "@/models/sprint/SprintModel";

export default function getCurrentSprint(sprints: SprintModel[]): number {
  const TodayDate = new Date().getDate();

  sprints.forEach((sprint) => {
    const sprintStartDate = new Date(sprint.sprintStart).getDate();
    let sprintEndDate: number | Date = new Date(sprint.sprintStart);
    sprintEndDate = sprintEndDate.setDate(
      sprintEndDate.getDate() + sprint.sprintDuration
    );
    if (TodayDate >= sprintStartDate && TodayDate <= sprintEndDate) {
      return sprint.sprintId;
    }
  });

  return 1;
}
