import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Shipment } from '../+state/model';

@Injectable({
  providedIn: 'root',
})
export class ShipmentsService {
  getAllShipments(): Observable<Shipment[]> {
    return this.client.get('');
  }
  constructor(private client: HttpClient) {}
}
