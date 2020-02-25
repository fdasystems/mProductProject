import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AboutComponent } from './about.component';
import { MaterialModule } from './../../../material.module';

const routes: Routes = [{ path: '', component: AboutComponent }];

@NgModule({
  imports: [MaterialModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AboutRoutingModule { }
