interface ITaskItemShape {
    id: number,
    group: number,
    start: Date,
    end: Date,
}

export default class TaskItemModel implements ITaskItemShape {
    id;
    group;
    start;
    end;
    constructor(opts: ITaskItemShape) {
        this.id = opts.id;
        this.group = opts.group;
        this.start = opts.start;
        this.end = opts.end;
    }
}