/* eslint-disable @typescript-eslint/member-ordering */
/* eslint-disable @angular-eslint/component-selector */
import { Component, Input, OnInit } from '@angular/core';
import { Shipment } from '../+state/model';

@Component({
  selector: 'shipments-list',
  templateUrl: './shipments-list.component.html',
  styleUrls: ['./shipments-list.component.scss'],
})
export class ShipmentsListComponent implements OnInit {
  constructor() { }

  @Input()
  public shipments: Shipment[];

  public selectedItems: string[];

  ngOnInit() { }
}
