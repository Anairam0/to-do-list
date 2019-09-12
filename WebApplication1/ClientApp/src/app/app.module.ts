import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ToDoListComponent } from './todo-list/todo-list.component';
import { TodoListService } from 'src/services/todo-list.service';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatButtonModule, MatSnackBarModule } from '@angular/material'
import { NotificacionService } from 'src/services/notificacion.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EditTaskComponent } from './todo-list/Components/edit-task.component';

@NgModule({
  declarations: [
    AppComponent,
    ToDoListComponent,
    EditTaskComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatSnackBarModule
  ],
  providers: [ TodoListService, NotificacionService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
