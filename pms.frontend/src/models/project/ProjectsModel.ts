interface IProjectModelShape {
    projectId: number,
    projectName: string,
    projectDescription: string,
    projectOwnerId: number,
    projectDate: Date
}

export default class ProjectModel implements IProjectModelShape{
    projectId;
    projectName;
    projectDescription;
    projectOwnerId;
    projectDate;
    constructor(opts: IProjectModelShape) {
        this.projectId = opts.projectId;
        this.projectName = opts.projectName;
        this.projectDescription = opts.projectDescription;
        this.projectOwnerId = opts.projectOwnerId;
        this.projectDate = opts.projectDate;
    }
}