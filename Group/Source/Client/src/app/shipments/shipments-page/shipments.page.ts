import { Component, OnInit } from '@angular/core';
import { Shipment } from '../+state/model';

const shipments: Shipment[] = [
  {
    id: '1',
    weight: 40,
    customerInfoId: '1',
    destinationAddressId: '1',
    trackingNumber: '1',
    estimatedArrivalDate: new Date(),
  },
  {
    id: '2',
    weight: 50,
    customerInfoId: '2',
    destinationAddressId: '2',
    trackingNumber: '2',
    estimatedArrivalDate: new Date(),
  },
  {
    id: '3',
    weight: 30,
    customerInfoId: '3',
    destinationAddressId: '3',
    trackingNumber: '3',
    estimatedArrivalDate: new Date(),
  },
  {
    id: '4',
    weight: 35,
    customerInfoId: '4',
    destinationAddressId: '4',
    trackingNumber: '4',
    estimatedArrivalDate: new Date(),
  }
]

@Component({
  selector: 'app-shipments',
  templateUrl: './shipments.page.html',
  styleUrls: ['./shipments.page.scss'],
})
export class ShipmentsPage implements OnInit {
  constructor() { }

  public shipments$ = shipments; // Note: this should be retrieved from the store and typed as Observable<Shipment[]>, using dummy placeholder for the moment.

  ngOnInit() {
  }

}
