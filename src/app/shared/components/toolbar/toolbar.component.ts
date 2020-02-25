import { Component, OnInit } from '@angular/core';

//import { MaterialModule } from './../../../material.module';


@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})

export class ToolbarComponent implements OnInit {
public appName='mProyectProduct FS';
  constructor() { }

  ngOnInit(): void {
  }

}
