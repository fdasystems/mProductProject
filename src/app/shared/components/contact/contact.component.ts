import { Component, OnInit, Input, Inject } from '@angular/core';
import {  MatDialogRef, MAT_DIALOG_DATA,  MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Product } from 'src/app/models/products';
import { ContactService } from './../../../services/contact.service';
import {  NgForm } from '@angular/forms';
import {  MatSnackBar} from '@angular/material/snack-bar'; //See snackbar   in const +++>private: snackbar:MAtSnackBar==> this.snackbar.open( res.toString(), '', {duration:5000, verticalPosition:'top'});
//import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {FormBuilder, Validators, FormGroup} from "@angular/forms";


@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {
  
itemToSend;
messageResult; 
subject: string;
body: string
form: FormGroup;

  constructor( private formBuilder: FormBuilder,
              public contactService : ContactService,
              public dialogRef: MatDialogRef<Product>,
              @Inject(MAT_DIALOG_DATA) public data: any
             )      
    {
      this.itemToSend=data;
    }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      bodyInForm: [null, Validators.required]
    });
  }
/*
  submit() {
    if (!this.form.valid) {
      return;
    }
    console.log(this.form.value);
  }*/


  SendMessage()
  {
    if (!this.form.valid) {
      return;
    }

    this.subject=this.itemToSend.Id+"-"+ this.itemToSend.Codigo;
    this.body=this.form.value.bodyInForm;
    this.SendSimpleMessage(this.subject, this.body);
   //direct 
   //this.dialogRef.close(this.form.value);
  }

  close() {
    this.dialogRef.close();
  }


  SendSimpleMessage(subjectToSend: string, bodyToSend: string) {
    this.contactService.SendSimpleMessage(subjectToSend, bodyToSend)
     //.AddEmployee(this.Dummyemployee)
     .subscribe(res => {
      //this.employeelist.push(res);
       // alert("Data added successfully !! ")
        //this.data;
        console.log("ok2 " + res);
        this.messageResult = res; 
        this.dialogRef.close(this.form.value);
    }), (err: string) => {
        console.log("Error Occured " + err);
        }
  }

}
