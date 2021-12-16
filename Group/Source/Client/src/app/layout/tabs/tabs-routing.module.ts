import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TabsPage } from './tabs.page';

const routes: Routes = [
  {
    path: '',
    component: TabsPage,
    children: [
      // {
      //   path: 'home',
      //   loadChildren: () =>
      //     import('../../home/home.module').then((m) => m.HomePageModule),
      // },
      {
        path: 'shipments',
        loadChildren: () =>
          import('../../shipments/shipments.module').then(
            (m) => m.ShipmentsPageModule
          ),
      },
      {
        path: 'account',
        loadChildren: () =>
          import('../../users/account/account.module').then(
            (m) => m.AccountPageModule
          ),
      },
      {
        path: '',
        redirectTo: 'shipments',
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
