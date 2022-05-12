export interface IBaseTaskShape {
  taskTag: string;
  taskName: string;
}

interface ITaskShape extends IBaseTaskShape {
  taskId: number;
  taskDescription: string;
  taskStartTime: Date | any;
  taskEndTime: Date | any;
  taskImportance: number;
  taskWorkLoad: number;
}

export default class TaskModel implements ITaskShape {
  taskId;
  taskName;
  taskDescription;
  taskTag;
  taskImportance;
  taskStartTime;
  taskEndTime;
  taskWorkLoad;
  constructor(opts: ITaskShape) {
    this.taskId = opts.taskId;
    this.taskName = opts.taskName;
    this.taskDescription = opts.taskDescription;
    this.taskTag = opts.taskTag;
    this.taskStartTime = opts.taskStartTime;
    this.taskEndTime = opts.taskEndTime;
    this.taskImportance = opts.taskImportance;
    this.taskWorkLoad = opts.taskWorkLoad;
  }
}
