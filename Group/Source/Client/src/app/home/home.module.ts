import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IonicModule } from '@ionic/angular';
import { HomePageRoutingModule } from './home-routing.module';
import { HomePage } from './home-page/home.page';
import { LayoutModule } from '../layout/layout.module';
import { HomeComponent } from './home-component/home.component';
import { MatBadgeModule } from '@angular/material/badge';
import { ReactiveFormsModule} from '@angular/forms'
import {MatStepperModule} from '@angular/material/stepper'
import {MatNativeDateModule} from '@angular/material/core';
import {MatFormFieldModule,} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule,
    LayoutModule,
    MatBadgeModule,
    ReactiveFormsModule,
    MatStepperModule,
    MatNativeDateModule,
    MatFormFieldModule,
    MatInputModule,

  ],
  declarations: [HomePage, HomeComponent],
  exports: [HomeComponent]
})
export class HomePageModule {}
