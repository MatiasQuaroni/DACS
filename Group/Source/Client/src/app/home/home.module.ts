import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { HomePageRoutingModule } from './home-routing.module';
import { HomePage } from './home-page/home.page';
import { LayoutModule } from '../layout/layout.module';
import { HomeComponent } from './home-component/home.component';
import { MatBadgeModule } from '@angular/material/badge';
import { ShipmentsPageModule } from '../shipments/shipments.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule,
    LayoutModule,
    MatBadgeModule,
    ShipmentsPageModule,

  ],
  declarations: [HomePage, HomeComponent],
  exports: [HomeComponent]
})
export class HomePageModule {}
