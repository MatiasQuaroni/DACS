import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QrScannerComponent } from '../qr-scanner/qr-scanner/qr-scanner.component';

import { ShipmentsPage } from './shipments-page/shipments.page';
import { TrackingToolComponent } from './tracking-tool/tracking-tool.component';

const routes: Routes = [
  {
    path: '',
    component: ShipmentsPage,
  },
  {
    path: 'tracking-tool',
    component: TrackingToolComponent,
  },
  {
    path: 'itinerary',
    loadChildren: () =>
      import('./itinerary/itinerary.module').then((m) => m.ItineraryPageModule),
  },
  {
    path: 'qr-scanner',
    component: QrScannerComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ShipmentsPageRoutingModule {}
