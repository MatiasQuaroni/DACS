import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { SignupPageRoutingModule } from './signup-routing.module';

import { SignupPage } from './signup-page/signup.page';
import { SignupComponent } from './signup/signup.component';
import { LayoutModule } from 'src/app/layout/layout.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    SignupPageRoutingModule,
    ReactiveFormsModule,
    LayoutModule,
  ],
  declarations: [SignupPage, SignupComponent],
})
export class SignupPageModule {}
