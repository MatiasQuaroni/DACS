import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ShipmentsPageRoutingModule } from './shipments-routing.module';
import {MatTableModule} from '@angular/material/table'

import { ShipmentsPage } from './shipments-page/shipments.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ShipmentsPageRoutingModule,
    MatTableModule
  ],
  declarations: [ShipmentsPage]
})
export class ShipmentsPageModule {}
