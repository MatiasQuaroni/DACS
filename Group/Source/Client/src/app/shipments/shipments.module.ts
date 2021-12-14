import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { ShipmentsPageRoutingModule } from './shipments-routing.module';
import { ShipmentsPage } from './shipments-page/shipments.page';
import { ShipmentsListComponent } from './shipments-list/shipments-list.component';
import { ShipmentListItemComponent } from './shipments-list/shipment-list-item/shipment-list-item.component';
import { TrackingToolComponent } from './tracking-tool/tracking-tool.component';
import { MatStepperModule } from '@angular/material/stepper';
import { MatNativeDateModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { StoreModule } from '@ngrx/store';
import * as fromShipments from './+state/reducer';
import { ShipmentsEffects } from './+state/effects';
import { EffectsModule } from '@ngrx/effects';
import { HttpClientModule } from '@angular/common/http';
import { ItineraryComponent } from './itinerary/itinerary-component/itinerary.component';
import { LegComponent } from './itinerary/leg/leg.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ShipmentsPageRoutingModule,
    MatStepperModule,
    MatNativeDateModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule,
    StoreModule.forFeature(
      fromShipments.shipmentsFeatureKey,
      fromShipments.reducer
    ),
    EffectsModule.forFeature([ShipmentsEffects]),
    HttpClientModule,
  ],
  declarations: [
    ShipmentsPage,
    ShipmentsListComponent,
    ShipmentListItemComponent,
    TrackingToolComponent,
  ],
})
export class ShipmentsPageModule {}
