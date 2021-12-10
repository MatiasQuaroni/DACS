import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QrScannerComponent } from './qr-scanner.component';
import { IonicModule } from '@ionic/angular';
import { BrowserModule } from '@angular/platform-browser';



@NgModule({
  declarations: [QrScannerComponent],
  imports: [
    CommonModule,
    IonicModule,
    BrowserModule,
  ]
})
export class QrScannerModule { }
