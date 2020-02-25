import { NgModule } from '@angular/core'; 
import {Routes, RouterModule} from '@angular/router';
import{ProductsComponent} from './components/products/products.component';
// import {} from './components/about';


const routes: Routes = [
{path: 'products', component: ProductsComponent },
{ path: 'about', loadChildren: () => import('./components/pages/about/about.module').then(m => m.AboutModule) }

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}