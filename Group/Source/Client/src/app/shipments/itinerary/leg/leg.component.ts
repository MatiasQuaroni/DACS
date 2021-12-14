import { Component, Input, OnInit } from '@angular/core';
import { Leg } from '../../+state/model';

@Component({
  selector: 'leg',
  templateUrl: './leg.component.html',
  styleUrls: ['./leg.component.scss'],
})
export class LegComponent implements OnInit {
  constructor() {}

  @Input()
  public leg: Leg;

  ngOnInit() {}
}
