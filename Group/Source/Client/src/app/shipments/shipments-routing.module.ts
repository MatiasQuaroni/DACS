import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

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
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ShipmentsPageRoutingModule {}
