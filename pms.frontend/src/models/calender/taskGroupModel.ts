interface ITaskGroupShape {
    id: number,
    content: string,
}

export default class TaskGroupModel implements ITaskGroupShape {
    id;
    content;
    constructor(opts: ITaskGroupShape) {
        this.id = opts.id;
        this.content = opts.content;
    }
}