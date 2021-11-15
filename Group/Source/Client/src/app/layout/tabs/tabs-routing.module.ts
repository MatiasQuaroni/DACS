import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePage } from 'src/app/home/home-page/home.page';
import { AuthenticatedGuard } from 'src/app/users/services/authenticated.guard';

import { TabsPage } from './tabs.page';

const routes: Routes = [
  {
    path: '',
    component: TabsPage,
    children: [
      {
        path: 'home',
        loadChildren: () =>
          import('../../home/home.module').then((m) => m.HomePageModule),
      },
      {
        path: 'shipments',
        loadChildren: () =>
          import('../../shipments/shipments.module').then(
            (m) => m.ShipmentsPageModule
          ),
      },
      {
        path: 'login',
        loadChildren: () =>
          import('../../users/login/login.module').then(
            (m) => m.LoginPageModule
          ),
      },
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TabsPageRoutingModule {}
