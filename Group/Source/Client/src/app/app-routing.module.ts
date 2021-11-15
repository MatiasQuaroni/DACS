import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AuthenticatedGuard } from './users/services/authenticated.guard';

const routes: Routes = [
  {
    path: 'roads',
    canActivate: [AuthenticatedGuard],
    loadChildren: () =>
      import('./layout/tabs/tabs.module').then((m) => m.TabsPageModule),
  },
  {
    path: 'login',
    loadChildren: () =>
      import('./users/login/login.module').then((m) => m.LoginPageModule),
  },
  {
    path: 'signup',
    loadChildren: () =>
      import('./users/signup/signup.module').then((m) => m.SignupPageModule),
  },
  {
    path: '',
    redirectTo: 'roads',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
