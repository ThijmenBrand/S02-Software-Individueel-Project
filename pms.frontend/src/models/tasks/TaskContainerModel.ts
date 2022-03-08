interface ITaskContainerShape {
    containerId: number,
    containerName: string,
}

export default class TaskContainerModel {
    containerId;
    containerName;
    constructor(opts: ITaskContainerShape) {
        this.containerId = opts.containerId;
        this.containerName = opts.containerName;
    }
}