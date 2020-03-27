import { NgModule } from '@angular/core';

import {     MatButtonModule} from '@angular/material/button';
import {     MatCardModule } from '@angular/material/card';
import {     MatToolbarModule} from '@angular/material/toolbar';
import {     MatTableModule } from '@angular/material/table';
import {     MatPaginatorModule} from '@angular/material/paginator';
import {     MatFormFieldModule} from '@angular/material/form-field';
import {     MatIconModule   } from '@angular/material/icon';
import {     MatInputModule} from '@angular/material/input';
import {     MatSelectModule  } from '@angular/material/select';
import {     MatDialogModule  } from '@angular/material/dialog'; 


const modules = [
                    MatButtonModule,        MatCardModule  ,        MatToolbarModule,
                    MatTableModule,         MatPaginatorModule,     MatFormFieldModule,
                    MatIconModule,          MatInputModule,         MatSelectModule,
                    MatDialogModule 
                ]


@NgModule({
    imports: [...modules],
    exports: [...modules],
    declarations: []
})

export class MaterialModule{}