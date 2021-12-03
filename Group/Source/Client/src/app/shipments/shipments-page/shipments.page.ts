import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Shipment } from '../+state/model';
import { ShipmentsFacadeService } from '../services/shipments-facade.service';

@Component({
  selector: 'app-shipments',
  templateUrl: './shipments.page.html',
  styleUrls: ['./shipments.page.scss'],
})
export class ShipmentsPage implements OnInit {
  constructor(private shipmentsFacade: ShipmentsFacadeService) {}

  public shipments$: Observable<Shipment[]> =
    this.shipmentsFacade.selectAllShipments$;

  ngOnInit() {}
}
