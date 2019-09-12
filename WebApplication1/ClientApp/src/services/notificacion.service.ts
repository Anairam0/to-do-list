import { Injectable } from '@angular/core';
import {MatSnackBar} from '@angular/material/snack-bar';

declare var $: any;

@Injectable()
export class NotificacionService {

    constructor(private _snackBar: MatSnackBar) { }

    showNotification(titulo: string, mensaje: string) {
        this._snackBar.open(titulo + ': ' + mensaje, "Close", {
            duration: 2000
        });
    }
}