import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TodoListItem } from '../app/todo-list/models/todo-list.model';
import { environment } from './../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TodoListService {
  formData: TodoListItem;
  readonly rootURL = environment.baseUrl + 'api/TodoList/';
  list: TodoListItem[];

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get(this.rootURL);
  }

  getById(id: string) {
    return this.http.get(this.rootURL + id);
  }

  Create(item: TodoListItem) {
    return this.http.post(this.rootURL, item);
  }

  Edit(item: TodoListItem) {
    return this.http.put(this.rootURL + item.Id, item);
  }

  Delete(id: string) {
    return this.http.delete(this.rootURL + id);
  }

  Complete(id: string) {
    return this.http.put(this.rootURL + id + '/Complete', {});
  }

  /*refresh() {
    this.http.get(this.rootURL)
    .toPromise()
    .then(res => this.list = res as TodoListItem[]);
  }*/
}
