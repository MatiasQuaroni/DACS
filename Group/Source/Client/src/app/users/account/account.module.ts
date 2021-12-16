import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { AccountPageRoutingModule } from './account-routing.module';

import { AccountComponent } from './account-component/account.component';
import { AccountPage } from './account-page/account.page';
import { LayoutModule } from 'src/app/layout/layout.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    AccountPageRoutingModule,
    LayoutModule,
  ],
  declarations: [AccountPage, AccountComponent],
})
export class AccountPageModule {}
