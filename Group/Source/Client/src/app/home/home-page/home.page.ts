import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { TrackingToolComponent } from 'src/app/shipments/tracking-tool/tracking-tool.component';
import { Notification } from 'src/app/notifications/+state/model';

const notifications: Notification[] = [
  {
    id: '1',
    title: 'New shipment has arrived',
    date: new Date(),
    description: 'A new shipment from Gualeguaychu has arrived',
  },
  {
    id: '2',
    title: 'New shipment has arrived',
    date: new Date(),
    description: 'A new shipment from Concordia has arrived',
  },
  {
    id: '3',
    title: 'A shipment has departed',
    date: new Date(),
    description: 'A new shipment has departed from Gualeguay',
  },
  {
    id: '4',
    title: 'A shipment order is delayed',
    date: new Date(),
    description: 'A shipment order has been delayed for 2 days',
  }
]

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  constructor(private router: Router, private modalController: ModalController) { }

  async onTrackingToolClicked ()
  {
    const modal = await this.modalController.create({
      component: TrackingToolComponent
    });
    return await modal.present();
  }

  public notifications$ = notifications; // Note: this should be retrieved from the store and typed as Observable<Notification[]>, using dummy placeholder for the moment.


  ngOnInit() {
  }

}
