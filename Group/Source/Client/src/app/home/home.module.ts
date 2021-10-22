import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HomePageRoutingModule } from './home-routing.module';

import { HomePage } from './home.page';
import { LayoutModule } from '../layout/layout.module';
import { HomeComponent } from './home-component/home/home.component';
import { MatBadgeModule } from '@angular/material/badge';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule,
    LayoutModule,
    MatBadgeModule
  ],
  declarations: [HomePage, HomeComponent],
  exports: [HomeComponent]
})
export class HomePageModule {}
