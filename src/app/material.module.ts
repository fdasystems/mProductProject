import { NgModule } from '@angular/core';

import {     MatButtonModule} from '@angular/material/button';
import {     MatCardModule } from '@angular/material/card';
import {     MatToolbarModule} from '@angular/material/toolbar';
import {     MatTableModule } from '@angular/material/table';
import {     MatPaginatorModule} from '@angular/material/paginator';

@NgModule({
    imports:
    [
        MatButtonModule,        MatCardModule  ,        MatToolbarModule,
        MatTableModule,  MatPaginatorModule,     
    ],

    exports: [
        MatButtonModule,        MatCardModule ,                MatToolbarModule,
        MatTableModule,  MatPaginatorModule,
    ],

    declarations: []


})

export class MaterialModule{}