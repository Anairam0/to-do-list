import { Component, OnInit } from '@angular/core';
import { TodoListService } from 'src/services/todo-list.service';
import { debug } from 'util';
import { TodoListItem } from './models/todo-list.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NotificacionService } from 'src/services/notificacion.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
})
export class ToDoListComponent implements OnInit {
  title = 'Todo List';
  items: Array<TodoListItem> = [];
  public newTodoForm = new FormGroup({
    Description: new FormControl("", [Validators.required])
  });

  constructor(private todoService: TodoListService, private notificationService: NotificacionService){
  }

  ngOnInit(){
    this.getAllTodo();
  }

  getAllTodo(){
    this.todoService.getAll().subscribe( 
      resp => {
        this.items = resp.data;
      }, err =>
      {
        this.notificationService.showNotification("Error", err.statusText);
      }
    );
  }

  addTodoTask() {
    this.todoService.Create(this.newTodoForm).subscribe(
      resp => {
        this.newTodoForm.setValue({
          Description: ""
        });
        this.getAllTodo();
      }, err => {
        this.notificationService.showNotification("Error", err.statusText);
      }
    );
  }

  CompleteTask(item: TodoListItem){
    this.todoService.Complete(item.id).subscribe(
      resp => {
        this.getAllTodo();
      },
      err => {
        this.notificationService.showNotification("Error", err.statusText);
      }
    )
  }

  DeleteTask(item: TodoListItem){
    this.todoService.Delete(item.id).subscribe(
      resp => {
        this.getAllTodo();
      },
      err => {
        this.notificationService.showNotification("Error", err.statusText);
      }
    )
  }

}
