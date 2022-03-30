export interface IBaseSprintShape {
  sprintEnd: Date;
  sprintStart: Date;
  sprintName: String;
}

interface ISprintShape extends IBaseSprintShape {
  sprintId: number;
}

export default class SprintModel {
  sprintId;
  sprintName;
  sprintEnd;
  sprintStart;
  constructor(opts: ISprintShape) {
    this.sprintName = opts.sprintName;
    this.sprintId = opts.sprintId;
    this.sprintEnd = opts.sprintEnd;
    this.sprintStart = opts.sprintStart;
  }
}
