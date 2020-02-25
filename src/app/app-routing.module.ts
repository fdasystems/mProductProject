import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {Routes, RouterModule} from '@angular/router';
import{ProductsComponent} from './components/products/products.component';
 import { DashboardComponent } from './components/pages/dashboard/dashboard.component';


const routes: Routes = [
{path:'', pathMatch:'full', redirectTo:'dashboard'},
{path: 'products', component: ProductsComponent },
{ path: 'about', loadChildren: () => import('./components/pages/about/about.module').then(m => m.AboutModule) },
{ path: 'dashboard', component: DashboardComponent}
];

@NgModule({
    declarations: [],

    imports: [CommonModule, RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
