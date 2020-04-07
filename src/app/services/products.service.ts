import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Product } from '../models/products';
import { PaginationService } from './pagination.service';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
 //private baseUrl='https://webapimpp.azurewebsites.net/'; // 
 private baseUrl='http://localhost:61504/';
 private urlService=this.baseUrl+'api/products';
  
constructor(private http: HttpClient, private paginationService: PaginationService) { }

  getData(){
    //const mergedUrl='https://jsonplaceholder.typicode.com/photos?_limit=25';  
    const mergedUrl = `${this.urlService}` + `?numberPage=${this.paginationService.page}&takeCount=${this.paginationService.pageSize}`;  
        // const mergedUrl =this.urlService+'/10';
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