import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login-component/login.component';
import { IonicModule } from '@ionic/angular';
import { StoreModule } from '@ngrx/store';
import * as fromUsers from './+state/reducer';
import { EffectsModule } from '@ngrx/effects';
import { UsersEffects } from './+state/effects';
import { LoginPageModule } from './login/login.module';
import { SignupPageModule } from './signup/signup.module';
import { UsersRoutingModule } from './users-routing.module';
import { AccountPageModule } from './account/account.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    IonicModule,
    LoginPageModule,
    SignupPageModule,
    UsersRoutingModule,
    AccountPageModule,
    StoreModule.forFeature(fromUsers.usersFeatureKey, fromUsers.reducer),
    EffectsModule.forFeature([UsersEffects]),
  ],
})
export class UsersPageModule {}
