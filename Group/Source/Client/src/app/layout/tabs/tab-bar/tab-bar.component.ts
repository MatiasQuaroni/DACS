import { Component, Input, OnInit } from '@angular/core';
import { TabDefinition } from '../models';

@Component({
  selector: 'tab-bar',
  templateUrl: './tab-bar.component.html',
  styleUrls: ['./tab-bar.component.scss'],
})
export class TabBarComponent implements OnInit {

@Input()
public tabs: TabDefinition[];

  constructor() { }

  ngOnInit() {}

}
