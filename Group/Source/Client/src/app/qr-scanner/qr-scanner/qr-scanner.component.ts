import { AfterViewInit, Component, OnDestroy } from '@angular/core';
import { BarcodeScanner } from '@capacitor-community/barcode-scanner';
import { AlertController } from '@ionic/angular';


@Component({
  selector: 'app-qr-scanner',
  templateUrl: './qr-scanner.component.html',
  styleUrls: ['./qr-scanner.component.scss'],
})
export class QrScannerComponent implements AfterViewInit, OnDestroy {
  scanActive = false;
  result = null;
  constructor(private alertController: AlertController) { }

  ngOnDestroy(): void {
    BarcodeScanner.stopScan();
  }
  ngAfterViewInit(): void {
    BarcodeScanner.prepare();
  }

  async startScan() {
    const allowed = await this.checkPermission();
    if (allowed) {
      this.scanActive = true;
      const result = await BarcodeScanner.startScan();
      if (result.hasContent) {
        this.result = result.content;
        this.scanActive = false;
      }
    }
  }

  async checkPermission() {
    return new Promise(async (resolve, reject) => {
      const status = await BarcodeScanner.checkPermission({ force: true });
      if (status.granted) {
        resolve(true);
      } else if (status.denied) {
        const alert = await this.alertController.create({
          header: 'No permission',
          message: 'Please allow camera permission in your settings',
          buttons: [
            {
              text: 'No',
              role: 'cancel',
            },
            {
              text: 'Open Settings',
              handler: () => {
                resolve(false);
                BarcodeScanner.openAppSettings();
              },
            },
          ],
        });
      } else {
        resolve(false);
      }
    });
  }

  stopScan() {
    BarcodeScanner.stopScan();
    this.scanActive = false;
  }
}
