import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GeolocationComponent } from './geolocation.component';



@NgModule({
  declarations: [GeolocationComponent],
  imports: [
    CommonModule,
    ],
  exports: [GeolocationComponent]
})
export class GeolocationModule { }
