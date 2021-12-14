import { Component, Input, OnInit } from '@angular/core';
import { Itinerary, Leg } from '../../+state/model';

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
  public legs: Leg[];

  ngOnInit() {}
}
