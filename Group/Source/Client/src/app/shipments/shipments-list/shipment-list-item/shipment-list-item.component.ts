import { Component, Input, OnInit } from '@angular/core';
import { Shipment } from '../../+state/model';

@Component({
  selector: 'shipment-list-item',
  templateUrl: './shipment-list-item.component.html',
  styleUrls: ['./shipment-list-item.component.scss'],
})
export class ShipmentListItemComponent implements OnInit {
  constructor() {}

  @Input()
  public shipment: Shipment;

  @Input()
  public selected: boolean;

  ngOnInit() {}
}
