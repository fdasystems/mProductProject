import { Component, OnInit } from '@angular/core';
import{ ProductsService} from './../../services/products.service';
import { Product } from 'src/app/models/products';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  products: Product[]=[];

  constructor(public productsService: ProductsService ) { }

  ngOnInit(): void {
    
    this.productsService.getData().subscribe(
      products=>{ 
        this.products=products;
        console.log(products)
      }
      ,
      err => console.log(err)
    )

  }

}
