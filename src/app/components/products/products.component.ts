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
  searchKey: string;
  eventLocal : PageEvent;

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

           if (origin=="refreshing")
           {
             this.listData.paginator=this.paginator1;
           }

        });
  }


  getFilteredData(origin) {
    console.log(origin); 
   this.productsService.getFilteredData(this.searchKey)
       .subscribe((result: any) => {
         var paginationData = JSON.parse(result.headers.get('X-Pagination'));
          this.totalCount = paginationData.totalCount;
          this.products = result.body;  //  .value        this.products = result;
          this.listData = new MatTableDataSource(this.products);
          //faltaria el this.pagination1 ???   
          if(origin=="searching-1st-time"){

            if (paginationData.totalPages==1)
            this.listData.paginator=this.paginator1;
            else
            this.paginator1.pageIndex=0;
          } 
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
    //ojo hay que ver si entrar por por getFilter o getAll 
    if (this.searchKey && this.searchKey.length>0)
    {
      this.getFilteredData('searching-2nd-time');
    }
    else
    {
      this.getAllProducts('pageChanged');
    }
    
  } 

  /* Call with Event */
  switchPage(event: PageEvent) {
    this.paginationService.change(event);
    //ojo hay que ver si entrar por por getAll o getFilter
    this.getAllProducts('switchPage');
  }

 // this.paginationModel.pageIndex = pageEvent.pageIndex + 1;
 // this.paginationModel.pageSize = pageEvent.pageSize;
 // this.paginationModel.allItemsLength = pageEvent.length;

  //search with searchKey
  searching(){
        // Clean pagination classic, change to normal pagination
        this.setNewPaginationForSearch(0, 0); //0 is the first page, other 0 is Not Required in first call = (overwrite in response)
        this.getFilteredData('searching-1st-time');
  }

  private setNewPaginationForSearch(pageIndex, pageSize) {
    //Primero Instancio la variable
    this.eventLocal =  new PageEvent(); //this.paginationService.paginationModel;

    this.eventLocal.pageIndex = pageIndex; //*Required
    this.eventLocal.pageSize = this.paginationService.pageSize; //*Required (Inherit from classic pagination)
    this.eventLocal.length = pageSize; //*Required in seconds calls

    //reset the paginationService for all calls
    this.paginationService.change(this.eventLocal);
  }

  //refreshing clear data searcher
  refreshing(){
    this.searchKey="";
      //clear el pagination (te va a servir despues para busquedas) se tiene que limpiar porque puede tener paginacion de busqueda
    this.setNewPaginationForSearch(0, 0); 
    this.getAllProducts('refreshing');
  }

  //enabled or disabled search
  // disableSearch(){
  //  return this.searchKey.length==0;
  //}


}
