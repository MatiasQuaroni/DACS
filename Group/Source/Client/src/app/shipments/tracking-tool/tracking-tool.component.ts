/* eslint-disable no-underscore-dangle */
/* eslint-disable @typescript-eslint/no-inferrable-types */
/* eslint-disable max-len */
/* eslint-disable @typescript-eslint/member-ordering */
/* eslint-disable @angular-eslint/component-selector */
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { modalController } from '@ionic/core';
import { ShipmentState } from '../+state/model';

const shipmentStates: ShipmentState[] = [
  {
    id: '1',
    currentState: 'In Preparation',
    fromDate: new Date(),
    toDate: new Date(Date.now() + 1 * 24 * 60 * 60 * 1000),
  },
  {
    id: '2',
    currentState: 'Ongoing',
    fromDate: new Date(Date.now() + 1 * 24 * 60 * 60 * 1000),
    toDate: new Date(Date.now() + 2 * 24 * 60 * 60 * 1000),
  },
  {
    id: '3',
    currentState: 'Ongoing',
    fromDate: new Date(Date.now() + 2 * 24 * 60 * 60 * 1000),
    toDate: new Date(Date.now() + 3 * 24 * 60 * 60 * 1000),
  },
  {
    id: '4',
    currentState: 'Delivered',
    fromDate: new Date(Date.now() + 3 * 24 * 60 * 60 * 1000),
    toDate: new Date(Date.now() + 3 * 24 * 60 * 60 * 1000),
  },
];

@Component({
  selector: 'tracking-tool',
  templateUrl: './tracking-tool.component.html',
  styleUrls: ['./tracking-tool.component.scss'],
})
export class TrackingToolComponent implements OnInit {
  isLinear = false;
  firstFormGroup: FormGroup;

  constructor(private _formBuilder: FormBuilder) { }

  @Input()
  public shipmentStates$ = shipmentStates; // Note: this should be retrieved from the store and typed as Observable<ShipmentState[]>, using dummy placeholder for the moment.

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      trackingID: ['', Validators.required],
    });
  }

  async closeTrackingTool() {
    const closeModal: string = 'Modal Closed';
    await modalController.dismiss(closeModal);
  }
}
