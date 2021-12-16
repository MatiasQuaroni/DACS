/* eslint-disable @typescript-eslint/member-ordering */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Shipment } from '../+state/model';
import { ShipmentsFacadeService } from '../services/shipments-facade.service';
import * as ShipmentsActions from '../+state/actions';

@Component({
  selector: 'app-shipments',
  templateUrl: './shipments.page.html',
  styleUrls: ['./shipments.page.scss'],
})
export class ShipmentsPage implements OnInit {
  constructor(private shipmentsFacade: ShipmentsFacadeService) {}

  public shipments$: Observable<Shipment[]> =
    this.shipmentsFacade.selectAllShipments$;

  onItinerarySelected($event) {
    this.shipmentsFacade.dispatch(
      ShipmentsActions.itineraryCreationRequested({ shipmentIds: $event })
    );
  }

  ngOnInit() {}
}
