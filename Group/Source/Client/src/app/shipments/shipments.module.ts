import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { ShipmentsPageRoutingModule } from './shipments-routing.module';
import { ShipmentsPage } from './shipments-page/shipments.page';
import { ShipmentsListComponent } from './shipments-list/shipments-list.component';
import { ShipmentListItemComponent } from './shipments-list/shipment-list-item/shipment-list-item.component';
import { TrackingToolComponent } from './tracking-tool/tracking-tool.component';
import {MatStepperModule} from '@angular/material/stepper'
import {MatNativeDateModule} from '@angular/material/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule} from '@angular/forms'
import {MatInputModule} from '@angular/material/input';



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
  ],
  declarations: [ShipmentsPage, ShipmentsListComponent,ShipmentListItemComponent, TrackingToolComponent]
})
export class ShipmentsPageModule {}
