import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ItineraryPageRoutingModule } from './itinerary-routing.module';

import { ItineraryPage } from './itinerary-page/itinerary.page';
import { ItineraryComponent } from './itinerary-component/itinerary.component';
import { LegComponent } from './leg/leg.component';

@NgModule({
  imports: [CommonModule, FormsModule, IonicModule, ItineraryPageRoutingModule],
  declarations: [ItineraryPage, ItineraryComponent, LegComponent],
})
export class ItineraryPageModule {}
