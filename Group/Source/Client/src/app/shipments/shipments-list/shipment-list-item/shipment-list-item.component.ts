import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Shipment } from '../../+state/model';

export interface ItemState {
  id: string;
  selected: boolean;
}
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
  public selected: boolean = false;

  @Output()
  public itemSelected = new EventEmitter<ItemState>();

  onItemSelected() {
    this.selected = !this.selected;
    this.itemSelected.emit({ id: this.shipment.id, selected: this.selected });
  }

  ngOnInit() {}
}
