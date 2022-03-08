interface IBaseSprintShape {
    sprintDuration: number,
    sprintStartTime: Date,
}

interface ISprintShape extends IBaseSprintShape {
    sprintId: number,
}

export default class SprintModel {
    sprintId;
    sprintDuration;
    sprintStartTime;
    constructor(opts: ISprintShape) {
        this.sprintId = opts.sprintId;
        this.sprintDuration = opts.sprintDuration;
        this.sprintStartTime = opts.sprintStartTime;
    }
}