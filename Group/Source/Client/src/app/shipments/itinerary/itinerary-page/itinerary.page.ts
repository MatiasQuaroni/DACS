import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Itinerary } from '../../+state/model';
import { ShipmentsFacadeService } from '../../services/shipments-facade.service';

@Component({
  selector: 'app-itinerary',
  templateUrl: './itinerary.page.html',
  styleUrls: ['./itinerary.page.scss'],
})
export class ItineraryPage implements OnInit {
  constructor(private shipmentsFacade: ShipmentsFacadeService) {}

  public itinerary$: Observable<Itinerary[]> =
    this.shipmentsFacade.selectItinerary$;

  public legs$ = this.shipmentsFacade.selectLegs$;

  ngOnInit() {}
}
