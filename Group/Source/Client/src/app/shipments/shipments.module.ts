import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { reducer, shipmentsFeatureKey } from './+state/reducer';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    StoreModule.forFeature(shipmentsFeatureKey, reducer)
  ]
})
export class ShipmentsModule { }
