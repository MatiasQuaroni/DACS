import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotificationListComponent } from './notification-list/notification-list.component';
import { NotificationCardComponent } from './notification-card/notification-card.component';
import { IonicModule } from '@ionic/angular';



@NgModule({
  declarations: [ NotificationListComponent, NotificationCardComponent],
  imports: [ IonicModule,
    CommonModule
  ],
  exports: [NotificationListComponent, NotificationCardComponent]
})
export class NotificationsModule { }
