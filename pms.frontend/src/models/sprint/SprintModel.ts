interface IBaseSprintShape {
  sprintDuration: number;
  sprintStart: Date;
}

interface ISprintShape extends IBaseSprintShape {
  sprintId: number;
}

export default class SprintModel {
  sprintId;
  sprintDuration;
  sprintStart;
  constructor(opts: ISprintShape) {
    this.sprintId = opts.sprintId;
    this.sprintDuration = opts.sprintDuration;
    this.sprintStart = opts.sprintStart;
  }
}
