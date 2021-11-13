import { Component, Input, OnInit } from '@angular/core';
import { TabDefinition } from '../models';

@Component({
  selector: 'tab-button',
  templateUrl: './tab-button.component.html',
  styleUrls: ['./tab-button.component.scss'],
})
export class TabButtonComponent implements OnInit {
  @Input()
  public tabDefinition: TabDefinition;

  constructor() {}

  ngOnInit() {}
}
