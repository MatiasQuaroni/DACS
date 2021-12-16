import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { LoginPageRoutingModule } from './login-routing.module';
import * as fromUsers from '../+state/reducer';

import { LoginPage } from './login-page/login.page';
import { LoginComponent } from './login-component/login.component';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { UsersEffects } from '../+state/effects';
import { LayoutModule } from 'src/app/layout/layout.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    LoginPageRoutingModule,
    LayoutModule,
  ],
  declarations: [LoginPage, LoginComponent],
})
export class LoginPageModule {}
