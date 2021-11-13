import { Component, OnInit, Input } from '@angular/core';
import { Notification } from '../+state/model';

@Component({
  selector: 'notification-list',
  templateUrl: './notification-list.component.html',
  styleUrls: ['./notification-list.component.scss'],
})
export class NotificationListComponent implements OnInit {
  constructor() {}

  @Input()
  public notifications: Notification[];

  public selectedNotifications: string[];

  ngOnInit() {}
}
