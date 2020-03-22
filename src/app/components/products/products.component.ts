import { Component, OnInit, ViewChild } from '@angular/core';
import{ ProductsService} from './../../services/products.service';
import { Product } from 'src/app/models/products';
import {MatTableDataSource /*, MatTableModule*/} from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';



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
  @ViewChild(MatPaginator) paginator: MatPaginator;


  constructor(public productsService: ProductsService ) { }

  ngOnInit(): void {
    
    this.productsService.getData().subscribe(
      products=>{ 
        this.products=products;
       // console.log(products)
       this.listData = new MatTableDataSource(this.products);
       this.listData.paginator = this.paginator;
      // this.loadOK=true;
      }
      ,
      err => {console.log(err); } //this.loadOK=false;}
    )

    
    //console.log(this.listData);
  }

  /* por las dudas si no funciona online...
  ngAfterViewInit() {
    this.listData.paginator = this.paginator
  }*/

}
