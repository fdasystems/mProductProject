import {  Component, OnInit, ViewChild, EventEmitter, Output, Input } from '@angular/core';
import {   ProductsService} from './../../services/products.service';
import {  Product } from 'src/app/models/products';
import {  MatTableDataSource /*, MatTableModule*/} from '@angular/material/table';
import {  MatPaginator, PageEvent } from '@angular/material/paginator';
import {  PaginationService } from 'src/app/services/pagination.service';
import {  MatDialog, MatDialogConfig} from '@angular/material/dialog'; 
import {  ContactComponent } from 'src/app/shared/components/contact/contact.component';



@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  loadOK: boolean =false;
  products: Product[]=[];
  listData: MatTableDataSource<Product>;
  displayedColumns: string[] = ["RutaImagen", "Descripcion"]; //'Id',"urlEmail" "Codigo", "PrecioVenta",     "Nombre", "Descripcion", "RutaImagen", "PrecioVenta"];"urlEmail"
  @ViewChild(MatPaginator) paginator1: MatPaginator;
  searchKey: string;
  eventLocal : PageEvent;
  SentStatusOk:  boolean =false;
  SentStatusBad: boolean =false;
  enableRefresh: boolean =false;


  
  @Input('listData')


  @Input() totalCount: number;
 // @Output() onDeleteCustomer = new EventEmitter();
  @Output() onPageSwitch = new EventEmitter();

  constructor(public productsService: ProductsService,  public paginationService: PaginationService, 
              public dialog: MatDialog )
  { 
  }

  ngOnInit(): void { 
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

        },
            (error: any)=>
            { 
              console.log(error);  
              this.listData=new MatTableDataSource<Product>();
            }
        );
  }


  getFilteredData(origin) {
    console.log(origin); 
   this.productsService.getFilteredData(this.searchKey)
       .subscribe((result: any) => {
         var paginationData = JSON.parse(result.headers.get('X-Pagination'));
          this.totalCount = paginationData.totalCount;
          this.products = result.body;  
          this.listData = new MatTableDataSource(this.products);
            
          if(origin=="searching-1st-time"){
            if (paginationData.totalPages==1)
              this.listData.paginator=this.paginator1;
            else
              this.paginator1.pageIndex=0;
          } 
       },
       (error: any)=>
         { 
           console.log(error);  
           this.listData=new MatTableDataSource<Product>();
         });
 }

  //normal direct call
  pageChanged(event: PageEvent) {
    console.log(event);
    this.paginationService.change(event);
    this.listData=null;
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
    this.listData=null;//ojo hay que ver si entrar por por getAll o getFilter
    this.getAllProducts('switchPage');
  }

  //search with searchKey
  searching(){
        this.enableRefresh=true;// Clean pagination classic, change to normal pagination
        this.listData=null;
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
    this.enableRefresh=false;
    this.listData=null;  //clear el pagination (te va a servir despues para busquedas) se tiene que limpiar porque puede tener paginacion de busqueda
    this.setNewPaginationForSearch(0, 0); 
    this.getAllProducts('refreshing');
  }

    openDialog(element)
    {
      const mDialogConfig = new  MatDialogConfig();
      mDialogConfig.disableClose = true; //true;   para bloquear y cerrar solo con boton
      mDialogConfig.autoFocus = true;
      mDialogConfig.width = "60%";
      mDialogConfig.data = {Id: element.Id, Codigo: element.Codigo};

      const dialogRef = this.dialog.open(ContactComponent, mDialogConfig);
      
      dialogRef.afterClosed().subscribe(
        data => {
                  console.log("Dialog output:", data);

                  var delay = true;                   

                  switch(data)
                  {
                    case "error": { this.SentStatusBad=true;   this.SentStatusOk=false;}
                    break;
                    case "Succesfully": {this.SentStatusBad=false;  this.SentStatusOk=true; }
                    break;
                    default: {this.SentStatusBad=false; this.SentStatusOk=false; delay = false;}
                    break;
                    
                  }

                 if (delay)
                 {
                  //hide message result
                  this.delay(7000).then(any=>{
                    this.SentStatusBad=false;
                    this.SentStatusOk=false;
                  });    
                 }

                }
        );
    }
  
    async delay(ms: number) {
      await new Promise(resolve => setTimeout(()=>resolve(), ms)).then(()=>console.log("fired"));
    }

}
