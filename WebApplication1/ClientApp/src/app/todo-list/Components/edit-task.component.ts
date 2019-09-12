import { Component, OnInit, Input } from '@angular/core';
import { TodoListService } from 'src/services/todo-list.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { NotificacionService } from 'src/services/notificacion.service';
import { TodoListItem } from '../models/todo-list.model';

@Component({
    selector: 'edit-task',
    templateUrl: './edit-task.component.html',
})
export class EditTaskComponent {
    isEditing: boolean = false;
    @Input() item: TodoListItem;
    public editTodoForm = new FormGroup({
        Description: new FormControl("", [Validators.required])
    });

    constructor(private todoService: TodoListService, private notificationService: NotificacionService) {
    }

    setEditMode() {
        this.editTodoForm.setValue({
            Description: this.item.description
        });
        this.isEditing = true;
    }

    editTodoTask() {
        let body = this.item;
        body.description = this.editTodoForm.get('Description').value;

        this.todoService.Edit(body).subscribe(
            resp => {
                this.onEditSuccess(resp.data);
            }, err => {
                this.notificationService.showNotification("Error", err.statusText);
            }
        );
    }

    onEditSuccess(body: TodoListItem){
        this.item = body;

        this.editTodoForm.setValue({
            Description: this.item.description
        });

        this.isEditing = false;
    }
}
