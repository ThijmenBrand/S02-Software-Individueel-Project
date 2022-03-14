export interface IBaseTaskShape {
  taskTag: string;
  taskName: string;
}

interface ITaskShape extends IBaseTaskShape {
  taskId: number;
  taskDescription: string;
  taskStart: Date;
  taskEnd: Date;
}

export default class TaskModel implements ITaskShape {
  taskId;
  taskName;
  taskDescription;
  taskTag;
  taskStart;
  taskEnd;
  constructor(opts: ITaskShape) {
    this.taskId = opts.taskId;
    this.taskName = opts.taskName;
    this.taskDescription = opts.taskDescription;
    this.taskTag = opts.taskTag;
    this.taskStart = opts.taskStart;
    this.taskEnd = opts.taskEnd;
  }
}
