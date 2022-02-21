export interface tasksItem {
    id: number,
    group: number,
    start: Date,
    end: Date
}

export interface taskGroup {
    id: number,
    content: string
}

export default interface ITaskModel {
    item: tasksItem,
    group: taskGroup
}