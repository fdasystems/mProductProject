import { Component, OnInit } from '@angular/core';

import {ProductsService} from './services/products.service';

import { Event,
Router,
NavigationStart,
NavigationEnd, 
RouterEvent} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'mProductProject';
  showSpinner = true;


  constructor(public productService: ProductsService
    , private _router: Router
    ){

      this._router.events.subscribe(
          (routerEvent: Event) => {
            if (routerEvent instanceof NavigationStart)
            {
              this.showSpinner=true;
            }
            if (routerEvent instanceof NavigationEnd)
            {
              this.showSpinner=false;
            }
          }    
      )
    }

  ngOnInit(){
  }

}
