import { Component, Input, OnInit } from '@angular/core';
import { Itinerary, Leg, Location } from '../../+state/model';
import { LegComponent } from '../leg/leg.component';

@Component({
  selector: 'itinerary',
  templateUrl: './itinerary.component.html',
  styleUrls: ['./itinerary.component.scss'],
})
export class ItineraryComponent implements OnInit {
  constructor() {}

  @Input()
  public itinerary: Itinerary;

  @Input()
  public locations: Location[];

  ngOnInit() {}
}
