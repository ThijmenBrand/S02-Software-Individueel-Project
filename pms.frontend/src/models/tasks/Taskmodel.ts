export interface IBaseTaskShape {
  taskTag: string;
  taskName: string;
}

interface ITaskShape extends IBaseTaskShape {
  taskId: number;
  taskDescription: string;
  taskStartTime: Date | any;
  taskEndTime: Date | any;
}

export default class TaskModel implements ITaskShape {
  taskId;
  taskName;
  taskDescription;
  taskTag;
  taskStartTime;
  taskEndTime;
  constructor(opts: ITaskShape) {
    this.taskId = opts.taskId;
    this.taskName = opts.taskName;
    this.taskDescription = opts.taskDescription;
    this.taskTag = opts.taskTag;
    this.taskStartTime = opts.taskStartTime;
    this.taskEndTime = opts.taskEndTime;
  }
}
