import { Component, OnInit } from '@angular/core';
import { TabDefinition } from '../models';

@Component({
  selector: 'tabs',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.scss'],
})
export class TabsComponent implements OnInit {
  public tabs: TabDefinition[];
  constructor() {}

  ngOnInit() {
    this.tabs = [
      // {
      //   icon: 'home-sharp',
      //   tabName: 'home',
      // },
      {
        icon: 'list-outline',
        tabName: 'shipments',
      },
      {
        icon: 'person-outline',
        tabName: 'account',
      },
    ];
  }
}
