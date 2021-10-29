import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ModalController } from '@ionic/angular';
import { TrackingToolComponent } from 'src/app/shipments/tracking-tool/tracking-tool.component';

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

  ngOnInit() {
  }

}
