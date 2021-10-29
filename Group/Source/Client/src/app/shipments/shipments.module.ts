import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { ShipmentsPageRoutingModule } from './shipments-routing.module';
import { ShipmentsPage } from './shipments-page/shipments.page';
import { ShipmentsListComponent } from './shipments-list/shipments-list.component';
import { ShipmentListItemComponent } from './shipments-list/shipment-list-item/shipment-list-item.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ShipmentsPageRoutingModule,
  ],
  declarations: [ShipmentsPage, ShipmentsListComponent,ShipmentListItemComponent]
})
export class ShipmentsPageModule {}
