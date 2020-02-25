import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MaterialModule } from './material.module';

import { HttpClientModule } from '@angular/common/http';
import { ProductsComponent } from './components/products/products.component';
import { ToolbarComponent } from './shared/components/toolbar/toolbar.component';
import { AppRoutingModule } from './app-routing.module';
import { DashboardComponent } from './components/pages/dashboard/dashboard.component';


@NgModule({
  declarations: [
    AppComponent,
    ProductsComponent, 
    ToolbarComponent, DashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
