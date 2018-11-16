import { Component, OnInit } from '@angular/core';
import { TaskModel } from './taskmodel';
import { FormsModule } from '@angular/forms'

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

  newPanelVisible: boolean = false;
  showMainPanel: boolean = false;
  showSearchPanel:boolean = false;
  newTask: TaskModel;

  constructor() { }

  ngOnInit() {
    this.showMainPanel=true;
    this.newTask = new TaskModel();
    this.newTask.title = "New Task";
  }

  showNewTaskPanel(){
    this.newPanelVisible = true;
    this.showMainPanel = false;
  }

  hideNewTaskPanel(){
    this.newPanelVisible = false;
    this.showMainPanel = true;
  }

  saveNewTask(){
    alert(this.newTask.title);
  }

}
