import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { MaterialModule } from './material.module';

import { HttpClientModule } from '@angular/common/http';
import { ProductsComponent } from './components/products/products.component';
import { ToolbarComponent } from './shared/components/toolbar/toolbar.component';
import { AppRoutingModule  } from './app-routing.module';
import { DashboardComponent } from './components/pages/dashboard/dashboard.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { CustomPaginator } from './CustomPaginatorConfiguration';
import { PaginationService } from './services/pagination.service';
//import { PaginationService } from './services/pagination.service';

@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent, 
    ToolbarComponent, DashboardComponent, FooterComponent  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule 
  ],
  providers: [PaginationService, {provide: MatPaginatorIntl, useValue: CustomPaginator()}],
  bootstrap: [AppComponent]
})
export class AppModule { }
