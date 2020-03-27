import { Component, OnInit, Input, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Product } from 'src/app/models/products';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  
itemToSend; 

  constructor(
    public dialogRef: MatDialogRef<Product>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.itemToSend=data;
    }


   
  /* public itemToSend: Product;
  private _itemToSend: Product;

  @Input()
  set itemToSend(value: Product){
    this._itemToSend = value;
  }
  get itemToSend() { return this._itemToSend; }
*/




  ngOnInit(): void {
  }

}
