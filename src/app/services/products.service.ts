import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Product } from '../models/products';
import { PaginationService } from './pagination.service';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private urlService='http://localhost:61504/api/productos';
  
  constructor( private http: HttpClient, private paginationService: PaginationService) { }

  getData(){
    //var urlService='https://jsonplaceholder.typicode.com/photos?_limit=25';
    //var urlService='http://localhost:61504/api/productos';
    //var urlService='http://localhost:61504/api/productos?numberPage=1&takeCount=8';
   
    const mergedUrl = `${this.urlService}` +
            `?numberPage=${this.paginationService.page}&takeCount=${this.paginationService.pageSize}`;  // .pageCount

   // return this.http.get<Product[]>(mergedUrl);   //SOLO FALTA ACOMODAR EL RESULT AL OBJETO ESPERADO
    return this.http.get<any>(mergedUrl, {observe:'response'}); 
  }


  //Búsqueda por clave (en principio solo codigo)
  getFilteredData(searchKey){   
    const mergedUrl = `${this.urlService}` +
            `?numberPage=${this.paginationService.page}&takeCount=${this.paginationService.pageSize}&searchTerms=${searchKey}`;

    return this.http.get<any>(mergedUrl, {observe:'response'}); 
  }


}
