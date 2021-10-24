import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { Geolocation, Geoposition, PositionError } from '@ionic-native/geolocation/ngx';

@Component({
  selector: 'app-geolocation',
  templateUrl: './geolocation.component.html',
  styleUrls: ['./geolocation.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class GeolocationComponent implements OnInit {

  constructor(private geolocationService: Geolocation) { }

  public watch$ = this.geolocationService.watchPosition();
  @Input()
  public longitude: number;
  @Input()
  public latitude: number;


  ngOnInit() {
    this.watch$.subscribe((position) => {
      if ("coords" in position)
      {
        this.longitude = position.coords.longitude;
        this.latitude = position.coords.latitude;
      }
    })

  }

}
