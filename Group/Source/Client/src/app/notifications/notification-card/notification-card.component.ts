import { Component, Input, OnInit } from '@angular/core';
import { Notification } from '../+state/model';


@Component({
  selector: 'notification-card',
  templateUrl: './notification-card.component.html',
  styleUrls: ['./notification-card.component.scss'],
})
export class NotificationCardComponent implements OnInit {

  constructor() { }

  @Input()
  public notification: Notification;

  public selected: boolean;

  ngOnInit() {}

}
