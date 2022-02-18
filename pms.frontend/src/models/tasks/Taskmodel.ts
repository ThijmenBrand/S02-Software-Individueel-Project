export default interface ITaskModel {
    taskId: number,
    taskName: string,
    taskDescription: string,
    taskTag: number,
    taskStartTime: Date,
    taskEndTime: Date,
    projectId: Number
}