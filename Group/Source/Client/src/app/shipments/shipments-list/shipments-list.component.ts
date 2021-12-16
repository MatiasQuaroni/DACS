import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Shipment } from '../+state/model';
import { ItemState } from './shipment-list-item/shipment-list-item.component';

@Component({
  selector: 'shipments-list',
  templateUrl: './shipments-list.component.html',
  styleUrls: ['./shipments-list.component.scss'],
})
export class ShipmentsListComponent implements OnInit {
  constructor() {}

  @Input()
  public shipments: Shipment[];

  @Output()
  public itineraryButtonClicked = new EventEmitter<string[]>();

  @Output()
  public qrButtonClicked = new EventEmitter();

  public selectedItems: string[] = [];

  onItineraryButtonClicked() {
    this.itineraryButtonClicked.emit(this.selectedItems);
  }

  onShipmentSelected($event: ItemState) {
    if ($event.selected) {
      this.selectedItems = [...this.selectedItems, $event.id];
    } else {
      this.selectedItems.splice(this.selectedItems.indexOf($event.id, 1));
    }
  }

  onQrScannerClicked() {
    this.qrButtonClicked.emit();
  }

  ngOnInit() {}
}
