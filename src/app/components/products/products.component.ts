import { Component, OnInit, ViewChild, EventEmitter, Output, Input } from '@angular/core';
import{ ProductsService} from './../../services/products.service';
import { Product } from 'src/app/models/products';
import {MatTableDataSource /*, MatTableModule*/} from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { PaginationService } from 'src/app/services/pagination.service';



@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  loadOK: boolean =false;
  products: Product[]=[];
  listData: MatTableDataSource<Product>;
  displayedColumns: string[] = ["Codigo", "Nombre", "Descripcion", "RutaImagen", "PrecioVenta", "urlEmail"]; //'Id', "Codigo", "Nombre", "Descripcion", "RutaImagen", "PrecioVenta"];"urlEmail"
  @ViewChild(MatPaginator) paginator1: MatPaginator;

  /*
  //test fix of mp
  @ViewChild(MatPaginator) set matPaginator(mp: MatPaginator) {
    this.paginator = mp;
    this.setDataSourceAttributes();
  }

  setDataSourceAttributes() {
    this.listData.paginator = this.paginator;
    //this.listData.sort = this.sort;

    //if (this.paginator && this.sort) {
    //  this.applyFilter('');
    //} 
  }   
*/
  
  @Input('listData')
  /*set allowDay(value: Product[]) {
      this.listData = new MatTableDataSource<Product>(value);
  }*/


  @Input() totalCount: number;
 // @Output() onDeleteCustomer = new EventEmitter();
  @Output() onPageSwitch = new EventEmitter();

  constructor(public productsService: ProductsService, public paginationService: PaginationService ) { }

  ngOnInit(): void { //this.totalCount=8;
    this.getAllProducts('init');
  }

  /*
  public ngAfterViewInit() {

    // If the user changes the sort order, reset back to the first page.
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    merge(this.sort.sortChange, this.paginator.page)
    .pipe(
        startWith({}),
        switchMap(() => {
        this.isLoadingResults = true;
        return this.entityService.fetchLatest(this.sort.active, this.sort.direction, 
              this.paginator.pageIndex + 1, this.paginator.pageSize, 
              (total) =>  this.resultsLength = total);
        }),
        map(data => {
        this.isLoadingResults = false;
        this.isRateLimitReached = false;
        //alternatively to response headers;
        //this.resultsLength = data.total;
        return data;
        }),
        catchError(() => {
        this.isLoadingResults = false;
        this.isRateLimitReached = true;
        return observableOf([]);
        })
    ).subscribe(data => this.entitiesDataSource.data = data);
} */


  /*
  getAllProductsOrig() {
    this.productsService.getData().subscribe(products => { 
      this.products = products;
      this.listData = new MatTableDataSource(this.products);
      this.listData.paginator = this.paginator;
    }, err => { console.log(err); });
  }
*/

  getAllProducts(origin) {
     console.log(origin); 
    this.productsService.getData()
        .subscribe((result: any) => {
           this.totalCount = JSON.parse(result.headers.get('X-Pagination')).totalCount;
           this.products = result.body;  //  .value        this.products = result;
           this.listData = new MatTableDataSource(this.products);
        });
  }

  /* ...sol. int. post llamado para no perder el enlace... pero lanza error de consola comment
  ngAfterViewInit() {
    this.listData.paginator = this.paginator1;
  }*/

  //normal direct call
  pageChanged(event: PageEvent) {
    console.log(event);
    this.paginationService.change(event);
    this.getAllProducts('pageChanged');
  } 

  /* Call with Event */
  switchPage(event: PageEvent) {
    this.paginationService.change(event);
    this.getAllProducts('switchPage');
  }
 

}
