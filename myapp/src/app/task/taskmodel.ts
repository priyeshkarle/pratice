import { Injectable } from "@angular/core";

@Injectable()
export class TaskModel
{
    public id: number;
    public title: string;
    public notes: string;
    public dueDate: Date;
    public priority: string;
    public status: string;
    public userid: number;

    constructor(){
        this.dueDate = new Date();
        this.title = "New Task";
        this.priority = "Medium";
    }
}