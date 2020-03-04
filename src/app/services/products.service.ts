import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Product } from '../models/products';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor( private http: HttpClient) { }

  getData(){
    var urlService='https://jsonplaceholder.typicode.com/photos?_limit=25';
    return this.http.get<Product[]>(urlService);    
  }

}