import { Component, OnInit } from '@angular/core';
import { TodoListService } from 'src/services/todo-list.service';
import { debug } from 'util';
import { TodoListItem } from './models/todo-list.model';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
})
export class ToDoListComponent implements OnInit {
  title = 'Todo List';

  items: Array<TodoListItem> = [];

  constructor(private todoService: TodoListService){
  }

  ngOnInit(){
    debugger;
    this.getAllTodo();
  }

  getAllTodo(){
    this.todoService.getAll().subscribe( 
      resp => {
        debugger;
        this.items = resp.data;
      }, err =>
      {
        debugger;
        this.items = [];
      }
    );
  }
}
